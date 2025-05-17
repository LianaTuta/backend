using System.Text.Json.Serialization;

namespace TicketService.Models.Exceptions
{
    public class ApiResult<T>
    {

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
        public T Data { get; set; }

        public ApiResult(T data = default)
        {
            Data = data;
        }

        public static ApiResult<T> Create(T data) =>
            new ApiResult<T>(data);
    }
}
