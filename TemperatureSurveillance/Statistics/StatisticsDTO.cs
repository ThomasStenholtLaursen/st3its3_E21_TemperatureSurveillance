using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.Statistics
{
    public class StatisticsDTO
    {        
        public DateTime Time { get; set; }
        public int ID { get; set; }
        public int NumberOfAlarms { get; set; }
    }
}
