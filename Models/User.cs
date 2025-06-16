using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStoreApiReqnrollTest.Models
{
    public class User
{
        [JsonPropertyName("userID")]
        public string UserID {  get; set; }

        [JsonPropertyName("userName")]
        public string Username {  get; set; }

        [JsonPropertyName("password")]
        public string Password {  get; set; }

        [JsonPropertyName("books")]
        public List<Object> Books {  get; set; }
}
}
