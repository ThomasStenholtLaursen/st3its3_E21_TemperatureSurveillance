using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.SystemControl
{
    public interface ITemperatureObserver
    {
        void Update();
    }
}
