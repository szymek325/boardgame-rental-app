using System;
using Newtonsoft.Json;

namespace Rental.WebApi.Middleware
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public Guid Guid { get; set; }
        public string ExceptionType { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}