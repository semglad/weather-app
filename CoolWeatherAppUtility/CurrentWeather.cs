using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoolWeatherAppUtility
{
    public class CurrentWeather
    {
        [JsonProperty("weather")]
        public Weather[] WeatherParams { get; set; }

        public class Weather
        {
            [JsonProperty("id")]
            public int Id;

            [JsonProperty("main")]
            public string Main;

            [JsonProperty("description")]
            public string Description;

            //[JsonProperty("icon")]
            //public string Icon;
        }

        [JsonProperty("main")]
        public Main MainParams { get; set; }

        public class Main
        {
            [JsonProperty("temp")]
            public double Temperature;

            //[JsonProperty("pressure")]
            //public double Pressure;

            //[JsonProperty("humidity")]
            //public double Humidity;

            //[JsonProperty("temp_min")]
            //public double MinTemperature;

            //[JsonProperty("temp_max")]
            //public double MaxTemperature;

            //[JsonProperty("sea_level")]
            //public double PressureAtSeaLevel;

            //[JsonProperty("grnd_level")]
            //public double PressureAtGroundLevel;
        }

        [JsonProperty("wind")]
        public Wind WindParams { get; set; }

        public class Wind
        {
            [JsonProperty("speed")]
            public double WindSpeed;
        }
    }
}
