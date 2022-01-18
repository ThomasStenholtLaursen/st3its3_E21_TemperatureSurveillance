using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.Sensor
{
    public class ThermalCamera : ISensor
    {
        public string Placement { get; set; }
        public int ID { get; set; }
        public double AlarmTemperature { get; set; }

        private readonly Random _random = new Random();
        private readonly AmbientTemperature _ambient = new AmbientTemperature();

        public ThermalCamera(string placement, int id, double alarmTemp)
        {
            Placement = placement;
            ID = id;
            AlarmTemperature = alarmTemp;
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

