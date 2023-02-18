using System.Text.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WifiWeather.Models;
using WifiWeather.Secrets;

namespace WifiWeather.Services
{
    public static class WeatherService
    {
        static readonly string climateDataUri = "http://api.openweathermap.org/data/2.5/weather";
       
        static WeatherService() { }

        public static async Task<WeatherReading> GetWeatherForecast()
        {
            var secretAppsettingReader = new SecretAppsettingReader();
            var secretValues = secretAppsettingReader.ReadSection<WeatherAPISecretValues>("WeatherApiSecretValues");

            using HttpClient client = new HttpClient();
            try
            {
                client.Timeout = new TimeSpan(0, 5, 0);

                HttpResponseMessage response = await client.GetAsync($"{climateDataUri}?q={secretValues.City}&appid={secretValues.ApiKey}");

                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                var values = JsonSerializer.Deserialize<WeatherReading>(json);
                return values;
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Request timed out.");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Request went sideways: {e.Message}");
                return null;
            }
        }
    }
}