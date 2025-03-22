using System.Net;
using System.Text.Json;
using TicketService.Models.Exceptions;

namespace TicketService.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)  
        {
            try
            {
                await _next(httpContext);
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
            var response = JsonSerializer.Serialize(new ApiResult<object>(new ErrorMesasge() { Message = message}));
            await httpContext.Response.WriteAsync(response);
        }
    }
}
