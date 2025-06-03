using Microsoft.AspNetCore.Http;
using QRCoder;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using TicketService.ApiClient.Interface;
using TicketService.BL.Helpers;
using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.DBModels.Orders;
using TicketService.Models.DBModels.User;
using TicketService.Models.Enum;
using TicketService.Models.QR;


namespace TicketService.BL.Implementation
{
    public class QrTicketService : IQRTicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IGoogleClient _googleClient;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserAcccountRepository _userAcccountRepository;
        public QrTicketService(ITicketRepository ticketRepository,
            IGoogleClient googleClient,
            IOrderRepository orderRepository,
            IUserAcccountRepository userAcccountRepository)

        {
            _ticketRepository = ticketRepository;
            _googleClient = googleClient;
            _orderRepository = orderRepository;
            _userAcccountRepository = userAcccountRepository;
        }

        public async Task GenerateTicketAsync(int userId, int checkoutOrderId)
        {
            List<TicketOrderModel> userTicketOrders = await _orderRepository.GetTicketOrderByCheckoutOrderIdAsync(checkoutOrderId);
            await _orderRepository.UpdateCheckoutOrderAsync(checkoutOrderId, (int)OrderStep.QrCode);


            foreach (TicketOrderModel ticketOrderModel in userTicketOrders)
            {
                UserModel? user = await _userAcccountRepository.GetUserByIdAsync(userId);
                TicketModel? ticketDetails = await _ticketRepository.GetTicketDetailsByIdAsync(ticketOrderModel.TicketId);
                TicketQRModel ticketQRModel = new()
                {
                    Email = user.Email,
                    EventScheduleEndDate = ticketDetails.EventSchedule.StartDate,
                    EventScheduleStartDate = ticketDetails.EventSchedule.EndDate,
                    EventName = ticketDetails.EventSchedule.EventModel.Name,
                    Price = ticketOrderModel.Ticket.Price.Value,
                    TicketCategory = ticketDetails.TicketCategory.Name,
                };
                string code = await InsertQrCodeAsync(ticketOrderModel.Id);
                string frontendBaseUrl = "https://frontend-767515572560.europe-north2.run.app/validate-ticket";
                string url = $"{frontendBaseUrl}/{code}";
                byte[] qrPng = GenerateQrCodePng(url);
                List<string> path = await _googleClient.GetFilesAsync($"event/{ticketDetails.EventSchedule.EventModel.Id}/");
                string? imageUrl = path.Any() ? _googleClient.GenerateSignedUrl(path.FirstOrDefault()) : null;

                using HttpClient httpClient = new();
                byte[] imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

                byte[] pdfBytes = GeneratePdf(ticketQRModel, qrPng, imageBytes);
                IFormFile formFile = CreateFormFile(pdfBytes, $"ticket.pdf", "application/pdf");
                await _googleClient.UploadFileAsync(formFile, $"order/{ticketOrderModel.Id}");
            }
            await _orderRepository.UpdateCheckoutOrderAsync(checkoutOrderId, (int)OrderStep.Completed);
        }

        public async Task UpdateTicketAsync(int userId, int checkoutOrderId)
        {
            List<TicketOrderModel> userTicketOrders = await _orderRepository.GetTicketOrderByCheckoutOrderIdAsync(checkoutOrderId);
            foreach (TicketOrderModel ticketOrderModel in userTicketOrders)
            {
                _ = await _userAcccountRepository.GetUserByIdAsync(userId);
                _ = await _ticketRepository.GetTicketDetailsByIdAsync(ticketOrderModel.TicketId);
                QrTicketModel qrCode = await _ticketRepository.GetQrCodeByTicketOrderId(ticketOrderModel.Id);
                if (qrCode != null)
                {
                    qrCode.Status = (int)QrCodeEnum.Cancelled;
                    await _ticketRepository.UpdateQrCodeTicketAsync(qrCode);
                    await _orderRepository.UpdateCheckoutOrderAsync(checkoutOrderId, (int)OrderStep.Cancelled);
                }
            }
        }

        #region

        private static IFormFile CreateFormFile(byte[] bytes, string fileName, string contentType)
        {
            MemoryStream stream = new(bytes);
            return new FormFile(stream, 0, bytes.Length, "file", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = contentType
            };
        }

        private static byte[] GenerateQrCodePng(string payload)
        {
            using QRCodeGenerator qrGen = new();
            using QRCodeData qrData = qrGen.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            return new PngByteQRCode(qrData).GetGraphic(20);
        }

        private byte[] GeneratePdf(TicketQRModel ticket, byte[] qrPng, byte[] imageBytes)
        {

            byte[] pdfBytes = Document.Create(container =>
                {

                    _ = container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(20);
                        page.DefaultTextStyle(x => x.FontSize(12));

                        _ = page.Header().AlignCenter().Text("Ticket").SemiBold().FontSize(20);

                        page.Content().PaddingTop(10).Column(column =>
                        {
                            column.Spacing(10);
                            _ = column.Item().AlignCenter().Text("Thank you for your purchase! Below you’ll find your event ticket details. Please present this ticket (either printed or on your mobile device) at the entrance.")
                                .FontSize(12)
                                .AlignLeft();

                            column.Spacing(20);
                            column.Item().Row(row =>
                            {
                                _ = row.RelativeItem(1).Image(imageBytes).FitWidth();

                                row.RelativeItem(1).AlignMiddle().Column(col =>
                                {
                                    _ = col.Item().PaddingLeft(30).PaddingBottom(10).Text(
                                        $"You’ve successfully purchased a ticket for “{ticket.EventName}”, " +
                                        $"scheduled to begin on {ticket.EventScheduleStartDate:MMMM dd, yyyy 'at' HH:mm} " +
                                        $"and conclude on {ticket.EventScheduleEndDate:MMMM dd, yyyy 'at' HH:mm}. " +
                                        $"We look forward to welcoming you!"
                                    ).FontSize(12).Italic();

                                    _ = col.Item().PaddingLeft(30).Text($"Ticket Price: {ticket.Price:C}").FontSize(12).Italic();
                                    _ = col.Item().PaddingLeft(30).Text($"Ticket Category: {ticket.TicketCategory}").FontSize(12).Italic();
                                });
                            });

                            column.Spacing(20);
                            column.Item().Row(row =>
                            {

                                _ = row.RelativeItem(1).AlignMiddle().Text("This QR code is your official ticket. Please ensure it's clearly visible when scanned at the venue entrance. We look forward to seeing you!")
                                    .FontSize(12)
                                    .LineHeight(1.5f);

                                _ = row.RelativeItem(1).AlignCenter().Image(qrPng).FitWidth();

                            });
                        });

                        _ = page.Footer().AlignCenter().Text($"Generated on {DateTime.UtcNow:yyyy-MM-dd HH:mm}").FontSize(8);
                    });
                })
             .GeneratePdf();
            return pdfBytes;
        }

        private async Task<string> InsertQrCodeAsync(int tickerOrderId)

        {
            QrTicketModel ticketQr = new()
            {
                Code = RandomStringHelper.Generate(16),
                DateCreated = DateTime.UtcNow,
                Status = (int)QrCodeEnum.Active,
                TicketOrderId = tickerOrderId,
            };
            await _ticketRepository.InsertQrCodeTicketAsync(ticketQr);

            return ticketQr.Code;
        }
        #endregion

    }
}
