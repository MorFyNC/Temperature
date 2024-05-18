using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature.Data
{
    public static class DataContext
    {
        public static List<Sort> Sorts = 
        [
            new Sort("По дню", l => l.OrderBy(x => x.DateTime).ToList()),
            new Sort("По температуре", l => l.OrderBy(x => x.Temperature).ToList())
        ];

        public static List<WeatherStatus> weatherStatuses = new List<WeatherStatus>()
        {
            new WeatherStatus("Ясно"),
            new WeatherStatus("Облачно"),
            new WeatherStatus("Пасмурно"),
            new WeatherStatus("Туман"),
            new WeatherStatus("Дождь"),
            new WeatherStatus("Снег"),
            new WeatherStatus("Понятно"),
        };

        public static List<Weather> Weathers = new List<Weather>()
        {
            new Weather(DateTime.Now.AddDays(-20), 18, weatherStatuses[0]),
            new Weather(DateTime.Now.AddDays(-19), -5, weatherStatuses[0]),
            new Weather(DateTime.Now.AddDays(-18), 6, weatherStatuses[3]),
            new Weather(DateTime.Now.AddDays(-17), 10, weatherStatuses[2]),
            new Weather(DateTime.Now.AddDays(-16), 25, weatherStatuses[2]),
            new Weather(DateTime.Now.AddDays(-15), 30, weatherStatuses[5]),
            new Weather(DateTime.Now.AddDays(-14), 33, weatherStatuses[6]),
            new Weather(DateTime.Now.AddDays(-13), 10, weatherStatuses[3]),
            new Weather(DateTime.Now.AddDays(-12), 11, weatherStatuses[1]),
            new Weather(DateTime.Now.AddDays(-11), 0, weatherStatuses[2]),
            new Weather(DateTime.Now.AddDays(-10), -5, weatherStatuses[1]),
            new Weather(DateTime.Now.AddDays(-9), -10, weatherStatuses[1]),
            new Weather(DateTime.Now.AddDays(-8), 0, weatherStatuses[4]),
            new Weather(DateTime.Now.AddDays(-7), 0, weatherStatuses[5]),
            new Weather(DateTime.Now.AddDays(-6), 3, weatherStatuses[5]),
            new Weather(DateTime.Now.AddDays(-5), 12, weatherStatuses[5]),
            new Weather(DateTime.Now.AddDays(-4), 10, weatherStatuses[6]),
            new Weather(DateTime.Now.AddDays(-3), 8, weatherStatuses[4]),
            new Weather(DateTime.Now.AddDays(-2), 7, weatherStatuses[4]),
            new Weather(DateTime.Now.AddDays(-1), -3, weatherStatuses[2]),
            new Weather(DateTime.Now, 0, weatherStatuses[2]),
        };
    }
}
