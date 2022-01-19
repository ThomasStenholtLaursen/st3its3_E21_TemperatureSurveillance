using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TemperatureSurveillance.SensorConfig
{
    public class ConfigurationControl
    {
        public ProgramConfiguration Load(ProgramConfiguration settings, string filename)
        {
            try
            {
                string text = File.ReadAllText(filename);
                ProgramConfiguration hospitalConfig = JsonSerializer.Deserialize<ProgramConfiguration>(text);
                return hospitalConfig;
            }
            catch (Exception)
            {
                string oldFilename = filename + ".custom";
                // Preserver customers file
                File.Move(filename, oldFilename);
                // Save new configuration
                string json = JsonSerializer.Serialize(settings);
                File.WriteAllText(filename, json);
                // Notify customer
                Console.WriteLine("Configuration file invalid, new file created. Old file can be found at: " + oldFilename);
                return settings;
            }
        }

        public void Save(ProgramConfiguration settings, string path)
        {
            string json = JsonSerializer.Serialize(settings);
            File.WriteAllText(path, json);
        }
    }

    public class ProgramConfiguration
    {
        public ProgramConfiguration()
        {
            TemperatureAlarm = new List<double>();
            SensorPlacement = new List<string>();
            SensorType = "ThermalCamera";
            TemperatureAlarm.Add(38.7);
            TemperatureAlarm.Add(20.5);
            TemperatureAlarm.Add(42.1);
            SensorPlacement.Add("Entrance");
            SensorPlacement.Add("Backdoor");
            SensorPlacement.Add("Canteen");
            
        }

        public List<double> TemperatureAlarm { get; set; }
        public List<string> SensorPlacement { get; set; }
        public string SensorType { get; set; }
        
    }
}
