using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoolWeatherAppUtility
{
    public class ForecastWeather
    {
        [JsonProperty("list")]
        public WeatherList[] WeatherListParams { get; set; }

        public class WeatherList
        {
            [JsonProperty("main")]
            public WeatherMain WeatherMainParams { get; set; }

            public class WeatherMain
            {
                [JsonProperty("temp")]
                public double Temperature;
            }

            [JsonProperty("weather")]
            public Weather[] WeatherParams { get; set; }

            public class Weather
            {
                [JsonProperty("description")]
                public string Description;
            }

            [JsonProperty("wind")]
            public Wind WindParams { get; set; }

            public class Wind
            {
                [JsonProperty("speed")]
                public double WindSpeed;
            }

            [JsonProperty("dt_txt")]
            public string WeatherDate;
        }
    }
}
