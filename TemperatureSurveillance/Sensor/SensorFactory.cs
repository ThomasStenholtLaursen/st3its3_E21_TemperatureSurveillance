using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.Sensor
{
    public class SensorFactory
    {
        public static ISensor CreateSensor(string sensor, string placement, int id, double alarmtemp)
        {
            if (sensor == "ThermalCamera")
            {
                return new ThermalCamera(placement, id, alarmtemp);
            }


            throw new ArgumentException("Unknown sensor: " + sensor);
        }
    }
}
