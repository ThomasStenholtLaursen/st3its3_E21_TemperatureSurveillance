using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.Sensor
{
    public class AmbientTemperature
    {
        private readonly Random _random = new Random();
        private const double min_val = -10;
        private const double max_val = 35;
        public double GetAmbientTemp()
        {
            var next = _random.NextDouble();
            return Math.Round((_random.NextDouble() * (max_val - min_val) + min_val),1);
        }

    }
}
