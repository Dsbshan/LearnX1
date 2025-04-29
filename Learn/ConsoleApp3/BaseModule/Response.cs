using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BuisnessLogics.BaseModule
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
