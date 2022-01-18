using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.Sensor
{
    public interface ISensor
    {
        double Detect();
        string Placement { get; set; }
        int ID { get; set; }
    }
}
