using Newtonsoft.Json;
using System.Net;
using System.Text.Json;
using TicketService.Models.Exceptions;

namespace TicketService.Middleware
{
    public class ResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ResponseMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                Stream currentBody = httpContext.Response.Body;
                using MemoryStream memoryStream = new();
                httpContext.Response.Body = memoryStream;
                await _next(httpContext);
                httpContext.Response.Body = currentBody;
                _ = memoryStream.Seek(0, SeekOrigin.Begin);
                string readToEnd = new StreamReader(memoryStream).ReadToEnd();

                object? result = JsonConvert.DeserializeObject(readToEnd);
                object? response = result;
                if (httpContext.Response.StatusCode is not ((int)HttpStatusCode.Created) and not ((int)HttpStatusCode.OK) and not ((int)HttpStatusCode.NoContent))
                {
                    JsonDocument jsonDocument = JsonDocument.Parse(readToEnd);
                    if (jsonDocument.RootElement.TryGetProperty("errors", out _))
                    {
                        result = JsonConvert.DeserializeObject<ErrorResponse>(readToEnd);
                        await HandleExceptionAsync(httpContext, (HttpStatusCode)httpContext.Response.StatusCode, System.Text.Json.JsonSerializer.Serialize(result).ToString());
                    }
                    else
                    {
                        await httpContext.Response.WriteAsync(response.ToString());
                    }
                }
                else
                {
                    var apiResult = new ApiResult<dynamic>(result);
                    var json = JsonConvert.SerializeObject(apiResult, Formatting.Indented);
                    await httpContext.Response.WriteAsync(json); 
                }
            }
            catch (CustomException ex)
            {
                _logger.LogError(ex, "A custom error occurred");
                await HandleExceptionAsync(httpContext, ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred");
                await HandleExceptionAsync(httpContext, HttpStatusCode.InternalServerError, "An unexpected error occurred.");
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, HttpStatusCode statusCode, string message)
        {
            httpContext.Response.StatusCode = (int)statusCode;
            httpContext.Response.ContentType = "application/json";
            string response = System.Text.Json.JsonSerializer.Serialize(new ApiResult<object>(new ErrorMesasge() { Message = message }));
            await httpContext.Response.WriteAsync(response);
        }
    }
}
