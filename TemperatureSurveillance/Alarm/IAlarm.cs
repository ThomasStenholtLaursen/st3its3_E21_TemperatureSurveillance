using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.Alarm
{
    public interface IAlarm
    {
        void On();
        void Off();
    }
}
