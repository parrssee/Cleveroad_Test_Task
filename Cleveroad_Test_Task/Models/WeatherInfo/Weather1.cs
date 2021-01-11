using Newtonsoft.Json;
using System;

namespace Cleveroad_Test_Task.Models.WeatherInfo
{
    public class Weather1 : IWeather
    {
        public Main Main { get; set; }

        public Wind Wind { get; set; }

        public Cloudiness Clouds { get; set; }

        public string Name { get; set; }

        [JsonProperty("dt")]
        public string Date_ms { get; set; }

        public DateTime Date { get; set; }
    }
}
