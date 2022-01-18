using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TemperatureSurveillance.Sensor
{
    public class SensorControl 
    {
        private const int _sampleTime = 1000;

        private readonly BlockingCollection<TemperatureDataContainer> _dataQueue;
        private readonly List<ISensor> _sensors;

        public SensorControl(BlockingCollection<TemperatureDataContainer> dataQueue, List<ISensor> sensors)
        {
            _dataQueue = dataQueue;
            _sensors = sensors;
        }

        public void Run()
        {
            while (true)
            {
                GetSamples(_sensors);
                Thread.Sleep(_sampleTime);
            }
        }

        public void GetSamples(List<ISensor> sensorList)
        {
            foreach (var sensor in sensorList)
            {
                TemperatureDataContainer container = new TemperatureDataContainer();
                container.TemperatureSample = sensor.Detect();
                container.ID = sensor.ID;
                container.Placement = sensor.Placement;
                _dataQueue.Add(container);
            }
        }
    }
}
