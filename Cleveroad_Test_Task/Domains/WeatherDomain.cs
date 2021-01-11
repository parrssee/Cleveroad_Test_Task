using Cleveroad_Test_Task.Models;
using Cleveroad_Test_Task.Models.WeatherInfo;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Cleveroad_Test_Task.Domains
{
    public class WeatherDomain
    {
        private ApiConfig Config;

        public WeatherDomain(ApiConfig config)
        {
            Config = config;
        }

        public Weather1 GetCurrent(string city)
        {
            var responseString = GetWeather("weather", city);
            var response = JsonConvert.DeserializeObject<Weather1>(responseString);
            response.Date = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt32(response.Date_ms)).UtcDateTime;
            return response;
        }

        public Forecast GetForecast(string city)
        {
            var responseString = GetWeather("forecast", city);
            var response = JsonConvert.DeserializeObject<Forecast>(responseString);
            return response;
        }

        private string GetWeather(string endpoint, string city)
        {
            var response = "";
            try
            {
                var request = WebRequest.Create($"{Config.BaseUrl}/{endpoint}?q={city}&units=metric&appid={Config.ApiKey}");
                var resp = request.GetResponse();

                using var streamReader = new StreamReader(resp.GetResponseStream());
                response = streamReader.ReadToEnd();
            }
            catch (System.Net.WebException ex)
            {
                var err = (HttpWebResponse)ex.Response;
                throw new Models.WebException(ex.Message, (int)err.StatusCode);
            }
            return response;
        }
    }
}
