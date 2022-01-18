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
            Console.WriteLine("(ALARM! RED LED ON!)\n");
        }

        public void Off()
        {
            Console.WriteLine("(Clear!)\n");
        }
    }
}
