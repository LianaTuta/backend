using TicketService.Models.DBModels.Events;
using TicketService.Models.RequestModels;
using TicketService.Models.RequestModels.Event;
using TicketService.Models.ResponseModels;

namespace TicketService.BL.Interface
{
    public interface ITicketService
    {
        Task AddTicketAsync(TicketRequestModel ticket);
        Task EditTicketAsync(int id, TicketRequestModel ticket);
        Task DeleteTicketAsync(int id);
        Task<List<TicketModel>> GetTicketsByEventScheduleIdAsync(int eventScheduleId);
        Task<ValidateTicketResponseModel> GetTicketDataAsync(string code);
        Task ValidateTicketAsync(ValidateTicketRequest validateTicketRequest);
        //Task<(MemoryStream Stream, string ContentType, string FileName)> DownloadTicketAsync(int orderId);
        Task<QrTIcketResponseMOdel> DownloadTicketAsync(int orderId);
    }
}
