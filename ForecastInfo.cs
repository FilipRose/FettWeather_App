using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FettWeather_App
{
    class ForecastInfo
    {
        public class temp
        {

            public double day { get; set; }
        }
        public class weather
        {
            public string main { get; set; }    
            public string description { get; set; }
            public string icon { get; set; }

        }
        public class daily
        {
            public long dt { get; set; }
            public temp temp { get; set; }

            public List<weather> weather { get; set; }
        }

        public class Forecast
        {
            public List<daily> daily { get; set; }

           
        }
    }
}
