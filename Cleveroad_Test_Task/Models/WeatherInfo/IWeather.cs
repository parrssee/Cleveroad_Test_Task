using System;

namespace Cleveroad_Test_Task.Models.WeatherInfo
{
    public interface IWeather
    {
        Main Main { get; set; }

        Wind Wind { get; set; }

        Cloudiness Clouds { get; set; }

        DateTime Date { get; set; }
    }
}
