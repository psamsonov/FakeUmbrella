using FakeUmbrellaAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FakeUmbrellaAPI.Services
{
    public class WeatherService
    {
        public const string API_KEY = "5cedf59df0570506c20bcbd1d51107f8";
        public static HttpClient client;

        static WeatherService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org");
        }

        public static string WillItRain(string latitude, string longitude)
        {
            OWMForecastObject forecast = GetAPIResponse(latitude, longitude);

            return ExtractAPIResponse(forecast);

        }

        public static string ExtractAPIResponse(OWMForecastObject forecast)
        {
            foreach (var list in forecast.list)
            {
                foreach (var weather in list.weather)
                {
                    if (weather.main.Contains("Rain"))
                    {
                        return list.dt_txt;
                    }
                }
            }

            return String.Empty;
        }

        public static OWMForecastObject GetAPIResponse(string latitude, string longitude)
        {
            var parameters = new List<string>();
            parameters.Add("appid=" + API_KEY);
            parameters.Add("lat=" + latitude);
            parameters.Add("lon=" + longitude);
            var response = client.GetAsync("/data/2.5/forecast?" + string.Join('&', parameters)).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new WeatherAPIUnavailableException("Weather API unavailable: " + response.StatusCode);
            }

            var content = response.Content.ReadAsStringAsync().Result;
            var forecast = JsonSerializer.Deserialize<OWMForecastObject>(content);
            return forecast;
        }
    }
}
    