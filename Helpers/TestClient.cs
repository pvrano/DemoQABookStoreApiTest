using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BookStoreApiReqnrollTest.Models;


namespace BookStoreApiReqnrollTest.Helpers
{
    public class TestClient
    {
        private readonly RestClient _client;
        private User _user;

        public TestClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
            _user = new User();


        }

        public RestResponse<UserResponse> createNewUser(string username, string password)
        {
            _user.Username = username;
            _user.Password = password;
            var request = new RestRequest("/Account/v1/User", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(_user);
            var response = _client.Execute<UserResponse>(request);
            if (!response.IsSuccessful)
            {
                raiseException(response);
            }

            return response;

        }

        public RestResponse getUserById(string userID)
        {
            var request = new RestRequest($"/Account/v1/User/{userID}",Method.Get);
            var response = _client.Execute(request);
            if (!response.IsSuccessful)
            {
                raiseException(response);
            }

            return response;
        }

        public RestResponse generateToken(string username, string password)
        {
            var request = new RestRequest("/Account/v1/GenerateToken", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new GenerateTokenRequest
            {
                UserName = username,
                Password = password
            });
            var response = _client.Execute<GenerateTokenResponse>(request);
            if (!response.IsSuccessful)
            {
                raiseException(response);
            }

            return response;
        }
        
        public void raiseException(RestResponse response)
        {
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.NotAcceptable:
                    throw new NotAcceptableException("User exists!");
                case System.Net.HttpStatusCode.Unauthorized:
                    throw new NotAuthorisedException("User not authorised", response);
            }


        }
    }
}
