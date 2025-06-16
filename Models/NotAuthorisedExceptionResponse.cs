using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookStoreApiReqnrollTest.Models
{
    public class NotAuthorisedExceptionResponse
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }


    }
}   