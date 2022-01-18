using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.Sensor
{
    public class ThermalCamera : ISensor
    {
        private readonly Random _random = new Random();
        public string Placement { get; set; }
        public int ID { get; set; }

        public ThermalCamera(string placement, int id)
        {
            Placement = placement;
            ID = id;
        }
        public double Detect()
        {
            var next = _random.NextDouble();
            //return Math.Round((34.0 + (next * (42.5 - 34.0))),1);
            return (34.0 + (next * (42.5 - 34.0)));
        }

        
    }
}

