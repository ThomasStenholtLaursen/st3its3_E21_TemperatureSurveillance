using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.Alarm
{
    public class LightAlarm : IAlarm
    {
        public void On()
        {
            Console.Write(" - ALARM! RED LED ON!\n");
        }

        public void Off()
        {
            Console.Write(" - Clear!\n");
        }
    }
}
