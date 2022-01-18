using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.Sensor
{
    public interface ISensor
    {
        TemperatureDTO Detect();
        string Placement { get; set; }
        double AlarmTemperature { get; set; }
        int ID { get; set; }

    }
}
