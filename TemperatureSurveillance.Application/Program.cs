using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using TemperatureSurveillance.Alarm;
using TemperatureSurveillance.Log;
using TemperatureSurveillance.Sensor;
using TemperatureSurveillance.SensorConfig;
using TemperatureSurveillance.Statistics;
using TemperatureSurveillance.SystemControl;
using TemperatureSurveillance.TempCorrection; 

namespace TemperatureSurveillance.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Creation of JSON file for configuration
            //ProgramConfiguration configDefault = new ProgramConfiguration();
            //string configFilename = "SensorConfig.json";
            //string json = JsonSerializer.Serialize(configDefault);
            //File.WriteAllText(configFilename, json);
            #endregion


            BlockingCollection<TemperatureDataContainer> dataQueue =
                new BlockingCollection<TemperatureDataContainer>();

            List<ISensor> sensorList = new List<ISensor>();

            var SensorConfig = new ProgramConfiguration();
            var ConfigControl = new ConfigurationControl();
            string filename = "SensorConfig.json";
            SensorConfig = ConfigControl.Load(SensorConfig, filename);

            for (int i = 0; i < SensorConfig.TemperatureAlarm.Count; i++)
            {
                double Alarmtemp = SensorConfig.TemperatureAlarm[i];
                string placement = SensorConfig.SensorPlacement[i];
                string sensortype = SensorConfig.SensorType;
                sensorList.Add(SensorFactory.CreateSensor(sensortype, placement, 10+i , Alarmtemp));
            }                      
            

            var correctionType = new AmbientCorrection(); //default
            var logType = new DisplayLog(); //default
            var alarmType = new LightAlarm(); //default
            var statisticsType = new Counter(); //default


            var temperatureMonitor = new TemperatureMonitor(dataQueue, correctionType);
            var sensorControl = new SensorControl(dataQueue, sensorList);
            var logControl = new LogControl(logType, temperatureMonitor);            
            var alarmControl = new AlarmControl(alarmType, temperatureMonitor);
            var statisticsControl = new StatisticsControl(temperatureMonitor, statisticsType);

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
            Console.WriteLine("[S]    Statistics Report");
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
                    case 's':
                    case 'S':
                        statisticsControl.PrintStatistics(30, 2);                        
                        break;
                }
            }
        }
    }
}
