using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AuthIservices.Entities
{
    public class Response
    {
        public object Result { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public HttpStatusCode httpStatusCode { get; set; }
        public bool MessageShow { get; set; }
    }
}
