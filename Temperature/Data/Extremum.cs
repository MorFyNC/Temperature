﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature.Data
{
    public class Extremum(Weather prevDayWeather, Weather nextDayWeather)
    {
        public Weather PreviousDayWeather { get; set; } = prevDayWeather;
        public Weather NextDayWeather { get; set; } = nextDayWeather;
        public string MaxOrMin { get; set; } = prevDayWeather.Temperature > nextDayWeather.Temperature ? "Min" : "Max";
        public decimal Difference { get; set; } = Math.Abs(prevDayWeather.Temperature - nextDayWeather.Temperature);
    }
}
