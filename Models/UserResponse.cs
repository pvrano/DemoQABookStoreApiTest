using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStoreApiReqnrollTest.Models
{
    public class UserResponse
    {
        [JsonPropertyName("userID")]
        public string UserID { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }


        [JsonPropertyName("books")]
        public List<Object> Books { get; set; }
    }
}
