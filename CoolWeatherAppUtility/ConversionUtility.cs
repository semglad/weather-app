using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolWeatherAppUtility
{
    public static class ConversionUtility
    {
        public static double ConvertFahrenheitToCelsius (double kelvin)
        {
            return kelvin - 273.15;
        }
    }
}
