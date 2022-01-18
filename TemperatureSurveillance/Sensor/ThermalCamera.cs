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

        private readonly AmbientTemperature _ambient = new AmbientTemperature();

        public ThermalCamera(string placement, int id)
        {
            Placement = placement;
            ID = id;
        }
        public TemperatureDTO Detect()
        {
            TemperatureDTO dto = new TemperatureDTO();
            double persontemp = (34.0 + (_random.NextDouble() * (42.5 - 34.0)));
            double ambienttemp = _ambient.GetAmbientTemp();

            dto.PersonTemperature = persontemp; 
            dto.AmbientTemperature = ambienttemp;

            return dto;
        }

        
    }
}

