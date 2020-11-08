using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PringleAPI.Exceptions
{
    public class BadRequestException : HttpResponseException
    {
        /// <summary>
        /// Exception to throw when the user makes a bad request
        /// </summary>
        /// <param name="message">message to send back to the user</param>
        public BadRequestException(String message) : base(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.BadRequest,
            Content = new StringContent(message)
        })
        {
            Console.WriteLine($"Bad request recieved. Error Message: {message}");
        }
    }
}