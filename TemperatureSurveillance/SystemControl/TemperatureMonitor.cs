using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureSurveillance.Sensor;
using TemperatureSurveillance.TempCorrection;

namespace TemperatureSurveillance.SystemControl
{
    public class TemperatureMonitor : TemperatureSubject
    {
        private bool _active = false;
        private readonly BlockingCollection<TemperatureDataContainer> _dataQueue;
        public double TemperatureSample { get; private set; } 
        public double AmbientTemperature { get; private set; }
        public double CorrectedTemperature { get; private set; }
        public string Placement { get; set; }
        public int ID { get; set; }

        private ICorrect _correction = new AmbientCorrection();

        public TemperatureMonitor(BlockingCollection<TemperatureDataContainer> dataQueue)
        {
            _dataQueue = dataQueue;
        }

        public void Run()
        {
            try
            {
                while (true)
                {
                    HandleOneTemperatureSample();
                }
            }
            catch (InvalidOperationException)
            {
                
            }
        }

        private void HandleOneTemperatureSample()
        {
            switch (_active)
            {
                case true:
                    Start();
                    break;
                case false:
                    Stop();
                    break;
            }
        }

        public void Stop()
        {
            _active = false;
            _dataQueue.Take();

            Console.WriteLine("Stopped!");
        }

        public void Start()
        {
            _active = true;

            var container = _dataQueue.Take();
            TemperatureSample = container.TemperatureSample;
            AmbientTemperature = container.AmbientTemperature;
            ID = container.ID;
            Placement = container.Placement;

            CorrectedTemperature = _correction.Correct(TemperatureSample, AmbientTemperature);

            Notify();
        }
    }
}
