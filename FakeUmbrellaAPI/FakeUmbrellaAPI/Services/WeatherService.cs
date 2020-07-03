using FakeUmbrellaAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        public static bool WillItRain(string latitude, string longitude)
        {
            var parameters = new List<string>();
            parameters.Add("appid=" + API_KEY);
            parameters.Add("lat=" + latitude);
            parameters.Add("lon=" + longitude);
            var response = client.GetAsync("/data/2.5/forecast?" + string.Join('&', parameters)).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new WeatherAPIUnavailableException();
            }

            var content = response.Content.ReadAsStringAsync().Result;
            // Very bad result parsing, to fix later
            return content.Contains("Rain");
           
        }
    }
}
    