using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weather.Models;

namespace Weather.Services
{
    public class OpenWeatherApiService
    {
        private const string ApiKey = "2f63b951fbd17efb48af5e2283f48f70";
        private const string ApiUri = "https://api.openweathermap.org/data/2.5/";
        private static readonly string CurrentWeatherRequestUri = $"{ApiUri}weather";
        private static readonly string ThreeHourForecastRequestUri = $"{ApiUri}forecast";
        private static readonly string DailyForecastRequestUri = $"{ApiUri}forecast/daily";

        private static string GetRequiredParameters() => $"&units={GetUnits()}&appid={ApiKey}";
        private static string GetUnits() => _userSettings.IsMetric ? "metric" : "imperial";

        private static IUserSettings _userSettings;

        public OpenWeatherApiService(IUserSettings userSettings)
        {
            _userSettings = userSettings;
        }

        public async Task<CurrentWeatherData> GetCurrentWeather(string city) => await GetRequest<CurrentWeatherData>($"{CurrentWeatherRequestUri}?q={city}{GetRequiredParameters()}");

        public async Task<ThreeHourForecast> GetThreeHourForecast(string city) => await GetRequest<ThreeHourForecast>($"{ThreeHourForecastRequestUri}?q={city}{GetRequiredParameters()}");

        public async Task<DailyForecast> GetDailyForecast(string city)
        {
            var result = await GetRequest<DailyForecast>($"{DailyForecastRequestUri}?q={city}&cnt=6{GetRequiredParameters()}");

            //Sometimes includes yesterday
            result.Items?.RemoveAll(item => item.CalculationTime.Date < DateTime.Today);
            if (result.Items?.Count > 5)
            {
                result.Items = result.Items.Take(5).ToList();
            }

            return result;
        }

        private static async Task<T> GetRequest<T>(string request) where T : class
        {
            var client = new HttpClient();
            var response = await client.GetAsync(request);

            if (response != null)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(json);
            }

            return null;
        }
    }
}
