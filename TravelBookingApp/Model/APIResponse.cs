﻿using System.Net;

namespace TravelBookingApp.Model
{
    public class APIResponse
    {
        public APIResponse()
        {
            ErrorMessage = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }


        // Bydefault the IsSuccess is set to true but if any error comes in future we need to change it to false.
        public bool IsSuccess { get; set; } = true;

        public List<string> ErrorMessage { get; set; }

        public object Result { get; set; }
    }
}
