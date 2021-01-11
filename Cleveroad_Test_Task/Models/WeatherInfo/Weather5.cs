using Newtonsoft.Json;
using System;

namespace Cleveroad_Test_Task.Models.WeatherInfo
{
    public class Weather5 : IWeather
    {
        public Main Main { get; set; }

        public Wind Wind { get; set; }

        public Cloudiness Clouds { get; set; }

        [JsonProperty("dt_txt")]
        public DateTime Date { get; set; }
    }
}
