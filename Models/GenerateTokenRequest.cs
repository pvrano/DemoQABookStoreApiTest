using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookStoreApiReqnrollTest.Models
{
    public class GenerateTokenRequest
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }

}