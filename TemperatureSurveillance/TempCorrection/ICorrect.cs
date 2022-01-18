using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.TempCorrection
{
    public interface ICorrect
    {
        double Correct(double personTemp, double ambientTemp);
    }
}
