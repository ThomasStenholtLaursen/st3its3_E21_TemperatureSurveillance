using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureSurveillance.SystemControl;

namespace TemperatureSurveillance.Alarm
{
    public class AlarmControl : ITemperatureObserver
    {
        private readonly TemperatureMonitor _tempSource;
        
        public IAlarm AlarmType { get; set; }
        public AlarmControl(IAlarm alarmType, TemperatureMonitor tempSource)
        {
            AlarmType = alarmType;
            _tempSource = tempSource;
            _tempSource.Attach(this);
        }
        public void Update()
        {
            
            if (_tempSource.CorrectedTemperature > _tempSource.AlarmTemperature)
            {
                AlarmType.On();
            }
            else
            {
                AlarmType.Off();
            }
        }
    }
}
