using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _04.Weather
{
    class WeatherInfo
    {
        public double Average { get; set; }
        public string Weather { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, WeatherInfo> registry = new Dictionary<string, WeatherInfo>();

            Regex regex = new Regex(@"(?<city>[A-Z]{2})(?<temp>\d+\.\d+)(?<weather>[a-zA-Z]+)\|");
            string line = Console.ReadLine();
            while (line != "end")
            {
                
                var weatherMatch = regex.Match(line);
                if(!weatherMatch.Success)
                {
                    line = Console.ReadLine();
                    continue;
                    
                }
                var currCity = weatherMatch.Groups["city"].Value;
                var currAvgTemp = double.Parse(weatherMatch.Groups["temp"].Value);
                var currWeatherType = weatherMatch.Groups["weather"].Value;
                var currWeatherInfo = new WeatherInfo
                {
                    Average = currAvgTemp,
                    Weather = currWeatherType
                };
                //currWeatherInfo.Average = currAvgTemp;
                currWeatherInfo.Weather = currWeatherType;

                registry[currCity] = currWeatherInfo;
                line = Console.ReadLine();
            }
            foreach (var item in registry.OrderBy(x => x.Value.Average))
            {
                Console.WriteLine($"{item.Key} => {item.Value.Average:F2} => {item.Value.Weather}");
            }
        }
    }
}
