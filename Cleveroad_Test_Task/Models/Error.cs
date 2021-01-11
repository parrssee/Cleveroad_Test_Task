using Newtonsoft.Json;

namespace Cleveroad_Test_Task.Models
{
    public class Error
    {
        public string Message { get; set; }

        public string StatusCode { get; set; }

        public override string ToString() =>
            JsonConvert.SerializeObject(this);
    }
}
