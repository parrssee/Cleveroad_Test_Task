using System;
using System.Runtime.Serialization;

namespace Cleveroad_Test_Task.Models
{
    [Serializable()]
    public class WebException : Exception
    {
        public WebException() : base() { }

        public WebException(string message) : base(message) { }

        public WebException(string message, Exception inner) : base(message, inner) { }

        public WebException(string message, int statusCode) : base(message) 
        {
            StatusCode = statusCode;
        }

        protected WebException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Context = context;
        }

        public StreamingContext Context { get; }

        public int StatusCode { get; }
    }
}
