using BookStoreApiReqnrollTest.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace BookStoreApiReqnrollTest.Helpers
{
    public class CustomException
    {
    }

    public class NotAcceptableException : Exception
    {
        public NotAcceptableException(string message) : base(message) { }
    }

    public class NotAuthorisedException : Exception
    {
        private RestResponse _response;
        private NotAuthorisedExceptionResponse _notAuthorisedExceptionResponse;

        public NotAuthorisedExceptionResponse NotAuthorisedExceptionResponse
        {
            get { return _notAuthorisedExceptionResponse; }
            set { _notAuthorisedExceptionResponse = value; }
        }

        public RestResponse Response
        {
            get { return _response; }
            set { _response = value; }
        }
        public NotAuthorisedException(string message, RestResponse response) : base(message)
        {
            this._response = response;
            this._notAuthorisedExceptionResponse = JsonSerializer.Deserialize<NotAuthorisedExceptionResponse>(response.Content!)!;
            
            
        }
    }

}
