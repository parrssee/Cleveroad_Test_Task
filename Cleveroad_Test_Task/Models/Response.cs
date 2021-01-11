using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cleveroad_Test_Task.Models
{
    public class Response<T>
    {
        public bool Result { get; set; }

        public T Data { get; set; }

        public List<Error> Errors { get; set; }

        public Response()
        {
            Errors = new List<Error>();
        }

        public Response(T data)
        {
            Data = data;
            Result = true;
        }

        public Response(List<Error> errors)
        {
            Errors = errors;
        }

        public override string ToString() =>
            JsonConvert.SerializeObject(this);
    }
}

