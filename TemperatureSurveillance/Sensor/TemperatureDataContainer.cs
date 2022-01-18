using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.Sensor
{
    public class TemperatureDataContainer
    {
        public string Placement { get; set; }
        public int ID { get; set; }
        public double TemperatureSample { get; set; }
        public double AmbientTemperature { get; set; }
        public double AlarmTemperature { get; set; }
    }
}
