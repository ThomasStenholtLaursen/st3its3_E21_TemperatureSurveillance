using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.TempCorrection
{
    public class AmbientCorrection : ICorrect
    {
        public double Correct(double personTemp, double ambientTemp)
        {
            var _personTemp = personTemp;
            var _ambientTemp = ambientTemp;

            try
            {
                if (ambientTemp >= -10.0 && ambientTemp <= -5.1) return (_personTemp += 3);
                if (ambientTemp >= -5.0 && ambientTemp <= -0.1) return (_personTemp += 2.5);
                if (ambientTemp >= 0.0 && ambientTemp <= 4.9) return(_personTemp += 2.0);
                if (ambientTemp >= 5.0 && ambientTemp <= 9.9) return(_personTemp += 1.5);
                if (ambientTemp >= 10.0 && ambientTemp <= 14.9) return(_personTemp += 1.0);
                if (ambientTemp >= 15.0 && ambientTemp <= 19.9) return(_personTemp += 0.5);
                if (ambientTemp >= 20.0 && ambientTemp <= 24.9) return(_personTemp += 0);
                if (ambientTemp >= 25.0 && ambientTemp <= 29.9) return(_personTemp -= 0.5);
                if (ambientTemp >= 30.0 && ambientTemp <= 35) return(_personTemp -= 1.0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not correct!");
                
            }

            return 10000;
        }
    }
}
