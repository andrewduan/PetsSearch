using System;
using System.Net;

namespace PetsSearchCommon
{
    public class InvalidUrlException : Exception
    {
        public string ErrorMessage { get; }
        public HttpStatusCode Code { get; }

        public InvalidUrlException(string errorMessage)
        {
            ErrorMessage = errorMessage;
            Code = HttpStatusCode.InternalServerError;
        }
    }
}
