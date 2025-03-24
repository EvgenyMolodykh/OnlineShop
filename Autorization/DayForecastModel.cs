using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorization
{
    public class DayForecastModel
    {
        public DateTime DataTime { get; set; }
        public float MaxTemperature { get; set; }
        public float MinTemperature { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
