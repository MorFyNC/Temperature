using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature.Data
{
    public class WeatherStatus
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public WeatherStatus(string title)
        {
            Title = title;
            Guid = Guid.NewGuid();
        }
    }
}
