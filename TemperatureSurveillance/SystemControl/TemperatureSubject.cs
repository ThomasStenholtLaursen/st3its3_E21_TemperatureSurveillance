using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.SystemControl
{
    public class TemperatureSubject
    {
        private readonly List<ITemperatureObserver> _observers = new List<ITemperatureObserver>();

        public void Attach(ITemperatureObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(ITemperatureObserver observer)
        {
            _observers.Remove(observer);
        }

        protected void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}
