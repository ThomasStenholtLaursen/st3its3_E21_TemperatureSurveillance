using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureSurveillance.SystemControl;

namespace TemperatureSurveillance.Statistics
{
    public class StatisticsControl : ITemperatureObserver
    {

        private readonly TemperatureMonitor _tempSource;
        public IStatistics StatisticsType { get; set; }

        public StatisticsControl(IStatistics statisticsType, TemperatureMonitor tempSource)
        {
            _tempSource = tempSource;
            _tempSource.Attach(this);
            StatisticsType = statisticsType;

        }
        public void Update()
        {
            if (_tempSource.CorrectedTemperature > _tempSource.AlarmTemperature)
            {
                StatisticsDTO dto = new StatisticsDTO();                
                dto.ID = _tempSource.ID;
                dto.Time = DateTime.Now;
                _tempSource._statisticsDTO.Add(dto);
            }
        }

        public void PrintStatistics(int lastSeconds, int lastMinutes)
        {
            List<StatisticsDTO> secDTO = StatisticsType.CalculateStatistics(lastSeconds, 0, _tempSource._statisticsDTO);
            List<StatisticsDTO> minDTO = StatisticsType.CalculateStatistics(0, lastMinutes, _tempSource._statisticsDTO);

            var totalalarm1 = 0;
            var totalalarm2 = 0;

            foreach (var item in secDTO)
            {
                totalalarm1 += item.NumberOfAlarms;
            }

            foreach (var item in minDTO)
            {
                totalalarm2 += item.NumberOfAlarms;
            }
            
            Console.WriteLine("------------------STATISTICS-----------------------");
            Console.WriteLine("Total triggered alarms in the last " + lastSeconds + " secounds: " + totalalarm1);
            for (int i = 0; i < secDTO.Count; i++)
            {
                var timestring = "";
                if (secDTO[i].NumberOfAlarms <= 1)
                {
                    timestring = "time";
                }
                else
                {
                    timestring = "times";
                }
                Console.WriteLine("Camera[" + secDTO[i].ID + "] triggered an alarm " + secDTO[i].NumberOfAlarms + " " + timestring);
            }
            
            Console.WriteLine("\nTotal triggered alarms in the last " + lastMinutes + " minutes: " + totalalarm2);
            for (int i = 0; i < minDTO.Count; i++)
            {
                var timestring = "";
                if (minDTO[i].NumberOfAlarms <= 1)
                {
                    timestring = "time";
                }
                else
                {
                    timestring = "times";
                }
                Console.WriteLine("Camera[" + minDTO[i].ID + "] triggered an alarm " + minDTO[i].NumberOfAlarms + " " + timestring);
            }
            Console.WriteLine("---------------------------------------------------\n");
        }
    }
}
