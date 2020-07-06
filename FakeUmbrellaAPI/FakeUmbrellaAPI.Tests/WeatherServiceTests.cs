using FakeUmbrellaAPI.Services;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Text.Json;

namespace FakeUmbrellaAPI.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConnectToAPI()
        {
            //Make sure you can get API data without an exception
            WeatherService.WillItRain("37.7510", "-97.8220");
            Assert.Pass();
        }

        [Test]
        public void TestParsePayload()
        {
            string response = "{\"cod\":\"200\",\"message\":0,\"cnt\":40,\"list\":[{\"dt\":1594058400,\"main\":{\"temp\":301.91,\"feels_like\":304.78,\"temp_min\":301.77,\"temp_max\":301.91,\"pressure\":1011,\"sea_level\":1014,\"grnd_level\":966,\"humidity\":65,\"temp_kf\":0.14},\"weather\":[{\"id\":501,\"main\":\"Rain\",\"description\":\"moderate rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":45},\"wind\":{\"speed\":2.25,\"deg\":158},\"rain\":{\"3h\":9.43},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-06 18:00:00\"},{\"dt\":1594069200,\"main\":{\"temp\":303.7,\"feels_like\":305.5,\"temp_min\":303.7,\"temp_max\":304.16,\"pressure\":1012,\"sea_level\":1013,\"grnd_level\":965,\"humidity\":54,\"temp_kf\":-0.46},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04d\"}],\"clouds\":{\"all\":74},\"wind\":{\"speed\":2.82,\"deg\":98},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-06 21:00:00\"},{\"dt\":1594080000,\"main\":{\"temp\":303.47,\"feels_like\":304.97,\"temp_min\":303.47,\"temp_max\":303.57,\"pressure\":1012,\"sea_level\":1012,\"grnd_level\":964,\"humidity\":53,\"temp_kf\":-0.1},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04d\"}],\"clouds\":{\"all\":53},\"wind\":{\"speed\":2.91,\"deg\":125},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-07 00:00:00\"},{\"dt\":1594090800,\"main\":{\"temp\":299.4,\"feels_like\":300.29,\"temp_min\":299.38,\"temp_max\":299.4,\"pressure\":1013,\"sea_level\":1013,\"grnd_level\":965,\"humidity\":65,\"temp_kf\":0.02},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":2},\"wind\":{\"speed\":3.44,\"deg\":142},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2020-07-07 03:00:00\"},{\"dt\":1594101600,\"main\":{\"temp\":297.26,\"feels_like\":298.76,\"temp_min\":297.26,\"temp_max\":297.26,\"pressure\":1014,\"sea_level\":1014,\"grnd_level\":965,\"humidity\":79,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":1},\"wind\":{\"speed\":3.29,\"deg\":158},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2020-07-07 06:00:00\"},{\"dt\":1594112400,\"main\":{\"temp\":296.16,\"feels_like\":297.77,\"temp_min\":296.16,\"temp_max\":296.16,\"pressure\":1013,\"sea_level\":1013,\"grnd_level\":964,\"humidity\":84,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":3.08,\"deg\":172},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2020-07-07 09:00:00\"},{\"dt\":1594123200,\"main\":{\"temp\":295.92,\"feels_like\":298.33,\"temp_min\":295.92,\"temp_max\":295.92,\"pressure\":1014,\"sea_level\":1014,\"grnd_level\":965,\"humidity\":85,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":1.91,\"deg\":180},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-07 12:00:00\"},{\"dt\":1594134000,\"main\":{\"temp\":301.07,\"feels_like\":302.92,\"temp_min\":301.07,\"temp_max\":301.07,\"pressure\":1014,\"sea_level\":1014,\"grnd_level\":966,\"humidity\":62,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":2.6,\"deg\":180},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-07 15:00:00\"},{\"dt\":1594144800,\"main\":{\"temp\":304.94,\"feels_like\":305.69,\"temp_min\":304.94,\"temp_max\":304.94,\"pressure\":1013,\"sea_level\":1013,\"grnd_level\":965,\"humidity\":45,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":3.15,\"deg\":155},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-07 18:00:00\"},{\"dt\":1594155600,\"main\":{\"temp\":306.96,\"feels_like\":306.94,\"temp_min\":306.96,\"temp_max\":306.96,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":963,\"humidity\":37,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":3.46,\"deg\":158},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-07 21:00:00\"},{\"dt\":1594166400,\"main\":{\"temp\":305.24,\"feels_like\":304.5,\"temp_min\":305.24,\"temp_max\":305.24,\"pressure\":1009,\"sea_level\":1009,\"grnd_level\":961,\"humidity\":45,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":5.44,\"deg\":145},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-08 00:00:00\"},{\"dt\":1594177200,\"main\":{\"temp\":300.65,\"feels_like\":299.8,\"temp_min\":300.65,\"temp_max\":300.65,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":963,\"humidity\":59,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":5.68,\"deg\":149},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2020-07-08 03:00:00\"},{\"dt\":1594188000,\"main\":{\"temp\":298.57,\"feels_like\":298.44,\"temp_min\":298.57,\"temp_max\":298.57,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":962,\"humidity\":69,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":5.01,\"deg\":155},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2020-07-08 06:00:00\"},{\"dt\":1594198800,\"main\":{\"temp\":297.08,\"feels_like\":296.91,\"temp_min\":297.08,\"temp_max\":297.08,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":962,\"humidity\":71,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":3},\"wind\":{\"speed\":4.44,\"deg\":165},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2020-07-08 09:00:00\"},{\"dt\":1594209600,\"main\":{\"temp\":296.25,\"feels_like\":297.25,\"temp_min\":296.25,\"temp_max\":296.25,\"pressure\":1010,\"sea_level\":1010,\"grnd_level\":961,\"humidity\":80,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":2},\"wind\":{\"speed\":3.49,\"deg\":178},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-08 12:00:00\"},{\"dt\":1594220400,\"main\":{\"temp\":302.05,\"feels_like\":301.44,\"temp_min\":302.05,\"temp_max\":302.05,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":963,\"humidity\":59,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":6.2,\"deg\":176},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-08 15:00:00\"},{\"dt\":1594231200,\"main\":{\"temp\":306.11,\"feels_like\":305.2,\"temp_min\":306.11,\"temp_max\":306.11,\"pressure\":1008,\"sea_level\":1008,\"grnd_level\":961,\"humidity\":45,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":6.19,\"deg\":169},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-08 18:00:00\"},{\"dt\":1594242000,\"main\":{\"temp\":308.73,\"feels_like\":307.85,\"temp_min\":308.73,\"temp_max\":308.73,\"pressure\":1006,\"sea_level\":1006,\"grnd_level\":960,\"humidity\":36,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":5.36,\"deg\":169},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-08 21:00:00\"},{\"dt\":1594252800,\"main\":{\"temp\":307.71,\"feels_like\":306.53,\"temp_min\":307.71,\"temp_max\":307.71,\"pressure\":1005,\"sea_level\":1005,\"grnd_level\":958,\"humidity\":38,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":5.76,\"deg\":152},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-09 00:00:00\"},{\"dt\":1594263600,\"main\":{\"temp\":302.11,\"feels_like\":299.72,\"temp_min\":302.11,\"temp_max\":302.11,\"pressure\":1005,\"sea_level\":1005,\"grnd_level\":958,\"humidity\":53,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10n\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":7.65,\"deg\":146},\"rain\":{\"3h\":0.28},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2020-07-09 03:00:00\"},{\"dt\":1594274400,\"main\":{\"temp\":300.6,\"feels_like\":299.11,\"temp_min\":300.6,\"temp_max\":300.6,\"pressure\":1005,\"sea_level\":1005,\"grnd_level\":957,\"humidity\":63,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":7.25,\"deg\":162},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2020-07-09 06:00:00\"},{\"dt\":1594285200,\"main\":{\"temp\":300.07,\"feels_like\":298.94,\"temp_min\":300.07,\"temp_max\":300.07,\"pressure\":1005,\"sea_level\":1005,\"grnd_level\":957,\"humidity\":67,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":7.08,\"deg\":177},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2020-07-09 09:00:00\"},{\"dt\":1594296000,\"main\":{\"temp\":299.61,\"feels_like\":298.94,\"temp_min\":299.61,\"temp_max\":299.61,\"pressure\":1005,\"sea_level\":1005,\"grnd_level\":957,\"humidity\":67,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":6.12,\"deg\":172},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-09 12:00:00\"},{\"dt\":1594306800,\"main\":{\"temp\":305.24,\"feels_like\":304.87,\"temp_min\":305.24,\"temp_max\":305.24,\"pressure\":1006,\"sea_level\":1006,\"grnd_level\":958,\"humidity\":48,\"temp_kf\":0},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"clouds\":{\"all\":11},\"wind\":{\"speed\":5.59,\"deg\":150},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-09 15:00:00\"},{\"dt\":1594317600,\"main\":{\"temp\":309.84,\"feels_like\":307.75,\"temp_min\":309.84,\"temp_max\":309.84,\"pressure\":1004,\"sea_level\":1004,\"grnd_level\":958,\"humidity\":36,\"temp_kf\":0},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"clouds\":{\"all\":16},\"wind\":{\"speed\":7.7,\"deg\":174},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-09 18:00:00\"},{\"dt\":1594328400,\"main\":{\"temp\":313.07,\"feels_like\":310.92,\"temp_min\":313.07,\"temp_max\":313.07,\"pressure\":1003,\"sea_level\":1003,\"grnd_level\":957,\"humidity\":28,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03d\"}],\"clouds\":{\"all\":41},\"wind\":{\"speed\":7.01,\"deg\":189},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-09 21:00:00\"},{\"dt\":1594339200,\"main\":{\"temp\":309.22,\"feels_like\":309.39,\"temp_min\":309.22,\"temp_max\":309.22,\"pressure\":1001,\"sea_level\":1001,\"grnd_level\":954,\"humidity\":37,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":24},\"wind\":{\"speed\":4.4,\"deg\":18},\"rain\":{\"3h\":0.9},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-10 00:00:00\"},{\"dt\":1594350000,\"main\":{\"temp\":301.51,\"feels_like\":300.8,\"temp_min\":301.51,\"temp_max\":301.51,\"pressure\":1006,\"sea_level\":1006,\"grnd_level\":958,\"humidity\":60,\"temp_kf\":0},\"weather\":[{\"id\":501,\"main\":\"Rain\",\"description\":\"moderate rain\",\"icon\":\"10n\"}],\"clouds\":{\"all\":57},\"wind\":{\"speed\":6.18,\"deg\":112},\"rain\":{\"3h\":5.22},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2020-07-10 03:00:00\"},{\"dt\":1594360800,\"main\":{\"temp\":296.04,\"feels_like\":294.65,\"temp_min\":296.04,\"temp_max\":296.04,\"pressure\":1009,\"sea_level\":1009,\"grnd_level\":960,\"humidity\":77,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10n\"}],\"clouds\":{\"all\":77},\"wind\":{\"speed\":6.38,\"deg\":63},\"rain\":{\"3h\":1.66},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2020-07-10 06:00:00\"},{\"dt\":1594371600,\"main\":{\"temp\":296.18,\"feels_like\":296.53,\"temp_min\":296.18,\"temp_max\":296.18,\"pressure\":1009,\"sea_level\":1009,\"grnd_level\":961,\"humidity\":72,\"temp_kf\":0},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02n\"}],\"clouds\":{\"all\":21},\"wind\":{\"speed\":3.31,\"deg\":39},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2020-07-10 09:00:00\"},{\"dt\":1594382400,\"main\":{\"temp\":295.13,\"feels_like\":296.48,\"temp_min\":295.13,\"temp_max\":295.13,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":962,\"humidity\":84,\"temp_kf\":0},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"clouds\":{\"all\":11},\"wind\":{\"speed\":2.78,\"deg\":65},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-10 12:00:00\"},{\"dt\":1594393200,\"main\":{\"temp\":300.46,\"feels_like\":302.47,\"temp_min\":300.46,\"temp_max\":300.46,\"pressure\":1012,\"sea_level\":1012,\"grnd_level\":964,\"humidity\":70,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":3.36,\"deg\":43},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-10 15:00:00\"},{\"dt\":1594404000,\"main\":{\"temp\":306.55,\"feels_like\":305.8,\"temp_min\":306.55,\"temp_max\":306.55,\"pressure\":1012,\"sea_level\":1012,\"grnd_level\":965,\"humidity\":42,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":5.5,\"deg\":57},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-10 18:00:00\"},{\"dt\":1594414800,\"main\":{\"temp\":308.71,\"feels_like\":308.22,\"temp_min\":308.71,\"temp_max\":308.71,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":964,\"humidity\":37,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":5.06,\"deg\":82},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-10 21:00:00\"},{\"dt\":1594425600,\"main\":{\"temp\":306.95,\"feels_like\":306.99,\"temp_min\":306.95,\"temp_max\":306.95,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":964,\"humidity\":44,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":5.1,\"deg\":97},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-11 00:00:00\"},{\"dt\":1594436400,\"main\":{\"temp\":300.74,\"feels_like\":302.2,\"temp_min\":300.74,\"temp_max\":300.74,\"pressure\":1013,\"sea_level\":1013,\"grnd_level\":965,\"humidity\":68,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":3.99,\"deg\":97},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2020-07-11 03:00:00\"},{\"dt\":1594447200,\"main\":{\"temp\":298.47,\"feels_like\":299.63,\"temp_min\":298.47,\"temp_max\":298.47,\"pressure\":1013,\"sea_level\":1013,\"grnd_level\":964,\"humidity\":79,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":4.61,\"deg\":145},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2020-07-11 06:00:00\"},{\"dt\":1594458000,\"main\":{\"temp\":297.48,\"feels_like\":298.89,\"temp_min\":297.48,\"temp_max\":297.48,\"pressure\":1012,\"sea_level\":1012,\"grnd_level\":963,\"humidity\":82,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":4,\"deg\":133},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2020-07-11 09:00:00\"},{\"dt\":1594468800,\"main\":{\"temp\":296.81,\"feels_like\":298.55,\"temp_min\":296.81,\"temp_max\":296.81,\"pressure\":1012,\"sea_level\":1012,\"grnd_level\":963,\"humidity\":87,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":3.76,\"deg\":145},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-11 12:00:00\"},{\"dt\":1594479600,\"main\":{\"temp\":303.77,\"feels_like\":305.63,\"temp_min\":303.77,\"temp_max\":303.77,\"pressure\":1012,\"sea_level\":1012,\"grnd_level\":964,\"humidity\":55,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":6},\"wind\":{\"speed\":2.99,\"deg\":193},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020-07-11 15:00:00\"}],\"city\":{\"id\":4269447,\"name\":\"Cheney\",\"coord\":{\"lat\":37.63,\"lon\":-97.7825},\"country\":\"US\",\"population\":2094,\"timezone\":-18000,\"sunrise\":1594034163,\"sunset\":1594086932}}";
            var forecast = JsonSerializer.Deserialize<OWMForecastObject>(response);
            var whenRain = WeatherService.ExtractAPIResponse(forecast);
            Assert.AreEqual("2020-07-06 18:00:00", whenRain);
        }
    }
}