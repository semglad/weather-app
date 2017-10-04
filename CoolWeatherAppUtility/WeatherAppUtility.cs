using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace CoolWeatherAppUtility
{
    public static class WeatherAppUtility
    {
        public static async Task<CombinedWeather> RunAsync(string city, string countryCode, bool isForecast)
        {
            if (!isForecast)
            {
                var url = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "," + countryCode + "&APPID=52087b841a0e19eae02720bc08ef0b5b";

                string json = await GetWeatherAsync(url);
                CurrentWeather cw = JsonConvert.DeserializeObject<CurrentWeather>(json);

                CombinedWeather comWeather = new CombinedWeather("Today", cw.MainParams.Temperature, cw.WeatherParams[0].Description, cw.WindParams.WindSpeed);

                return comWeather;
            }
            else
            {
                var url = "http://api.openweathermap.org/data/2.5/forecast?q=" + city + "," + countryCode + "&APPID=52087b841a0e19eae02720bc08ef0b5b";

                string json = await GetWeatherAsync(url);
                ForecastWeather fw = JsonConvert.DeserializeObject<ForecastWeather>(json);

                int arraySize = fw.WeatherListParams.Length;

                string[] weatherDate = new string[arraySize];
                double[] temperature = new double[arraySize];
                string[] description = new string[arraySize];
                double[] windSpeed = new double[arraySize];

                for (int i = 0; i < fw.WeatherListParams.Length; i++)
                {
                    weatherDate[i] = fw.WeatherListParams[i].WeatherDate;
                    temperature[i] = fw.WeatherListParams[i].WeatherMainParams.Temperature;
                    description[i] = fw.WeatherListParams[i].WeatherParams[0].Description;
                    windSpeed[i] = fw.WeatherListParams[i].WindParams.WindSpeed;
                }

                CombinedWeather comWeather = new CombinedWeather(weatherDate, temperature, description, windSpeed);
                return comWeather;
            }
        }

        public static async Task<string> GetWeatherAsync(string path)
        {
            string dw = null;
            GetWeatherData gwd = new GetWeatherData();
            HttpResponseMessage response = await gwd.Client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                dw = await response.Content.ReadAsStringAsync();
            }
            return dw;
        }
    }
}
