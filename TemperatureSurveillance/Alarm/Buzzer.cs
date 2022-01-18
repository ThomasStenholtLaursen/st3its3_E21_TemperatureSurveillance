using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.Alarm
{
    public class Buzzer : IAlarm
    {
        public void On()
        {
            Console.Write(" - BZZZ BZZZ\n");
        }

        public void Off()
        {
            Console.Write(" - *silence*\n");
        }
    }
}
