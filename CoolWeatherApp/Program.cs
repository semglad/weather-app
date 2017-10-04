using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolWeatherAppUtility;

namespace CoolWeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tervetuloa saatietopalveluun! Voit poistua ohjelmasta milloin tahansa kirjoittamalla \"exit\"\n");
            Console.Write("Kirjoita kaupunki, josta haluat saatiedot: ");
            string city = Console.ReadLine();

            string countryCode = "";

            while (city != "exit")
            {
                Console.Write("Kirjoita sen maan maakoodi, jossa ko. kaupunki sijaitsee (tai jata tyhjaksi jos FI): ");
                countryCode = Console.ReadLine();

                if (countryCode != "exit")
                {
                    if (countryCode == "")
                        countryCode = "FI";

                    Console.Write("Haluatko taman hetkisen tilanteen (T) vai viiden paivan ennusteen (E): ");
                    var forecast = Console.ReadKey();
                    Console.WriteLine("");

                    bool isForecast = false;

                    if (forecast.Key == ConsoleKey.E)
                        isForecast = true;

                    var data = WeatherAppUtility.RunAsync(city, countryCode, isForecast).Result;

                    for (int i = 0; i < data.WeatherDate.Length; i++)
                    {
                        Console.WriteLine("Date: {0}", data.WeatherDate[i]);
                        Console.WriteLine("Temperature: {0} C", ConversionUtility.ConvertFahrenheitToCelsius(data.Temperature[i]));
                        Console.WriteLine("Description: {0}", data.Description[i]);
                        Console.WriteLine("Wind speed: {0} m/s\n", data.WindSpeed[i]);
                    }

                    Console.Write("Kirjoita kaupunki, josta haluat saatiedot: ");
                    city = Console.ReadLine();
                } else
                {
                    city = "exit";
                }
            }

        }
    }
}
