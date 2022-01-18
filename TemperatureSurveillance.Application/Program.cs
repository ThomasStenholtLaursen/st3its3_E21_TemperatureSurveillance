using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using TemperatureSurveillance.Alarm;
using TemperatureSurveillance.Log;
using TemperatureSurveillance.Sensor;
using TemperatureSurveillance.SystemControl;

namespace TemperatureSurveillance.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<TemperatureDataContainer> dataQueue =
                new BlockingCollection<TemperatureDataContainer>();

            

            var sensor1 = new ThermalCamera("Entrance", 10);
            List<ISensor> sensorList = new List<ISensor>();
            sensorList.Add(sensor1);
            


            var sensorControl = new SensorControl(dataQueue, sensorList);
            var temperatureMonitor = new TemperatureMonitor(dataQueue);

            var logType = new DisplayLog();
            var logControl = new LogControl(logType, temperatureMonitor);

            var alarmType = new LightAlarm();
            var alarmControl = new AlarmControl(alarmType, temperatureMonitor);

            var producerThread = new Thread(sensorControl.Run);
            producerThread.IsBackground = true;
            var consumerThread = new Thread(temperatureMonitor.Run);
            consumerThread.IsBackground = true;

            producerThread.Start();
            consumerThread.Start();

            
            Console.WriteLine("Control menu:");
            Console.WriteLine("-------------------");
            Console.WriteLine("[X]    Quit");
            Console.WriteLine("[G]    Start");
            Console.WriteLine("[H]    Stop");
            Console.WriteLine("[B]    Buzzer Alarm");
            Console.WriteLine("[L]    Light Alarm");
            Console.WriteLine("-------------------\n");

            var cont = true;
            while (cont)
            {
                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'x':
                    case 'X':
                        cont = false;
                        break;
                    case 'g':
                    case 'G':
                        temperatureMonitor.Start();
                        break;
                    case 'h':
                    case 'H':
                        temperatureMonitor.Stop();
                        break;
                    case 'b':
                    case 'B':
                        alarmControl.AlarmType = new Buzzer();
                        break;
                    case 'l':
                    case 'L':
                        alarmControl.AlarmType = new LightAlarm();
                        break;
                }
            }
        }
    }
}
