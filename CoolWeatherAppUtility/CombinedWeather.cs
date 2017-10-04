using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolWeatherAppUtility
{
    public class CombinedWeather
    {
        public string[] WeatherDate;
        public double[] Temperature;
        public string[] Description;
        public double[] WindSpeed;

        public CombinedWeather(string weatherDate, double temperature, string description, double windSpeed)
        {
            Array.Resize(ref WeatherDate, 1);
            Array.Resize(ref Temperature, 1);
            Array.Resize(ref Description, 1);
            Array.Resize(ref WindSpeed, 1);

            WeatherDate[0] = weatherDate;
            Temperature[0] = temperature;
            Description[0] = description;
            WindSpeed[0] = windSpeed;
        }

        public CombinedWeather(string[] weatherDate, double[] temperature, string[] description, double[] windSpeed)
        {
            WeatherDate = weatherDate;
            Temperature = temperature;
            Description = description;
            WindSpeed = windSpeed;
        }
    }
}
