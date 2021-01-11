using System.Collections.Generic;

namespace Cleveroad_Test_Task.Models.WeatherInfo
{
    public class Forecast
    {
        public IEnumerable<Weather5> List { get; set; }

        public City City { get; set; }
    }
}
