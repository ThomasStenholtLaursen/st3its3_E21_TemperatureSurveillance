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
        public IStatistics _statisticsType { get; set; }

        public StatisticsControl(TemperatureMonitor tempSource, IStatistics statisticsType)
        {
            _tempSource = tempSource;
            _tempSource.Attach(this);
            _statisticsType = statisticsType;

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
            List<StatisticsDTO> secDTO = _statisticsType.CalculateStatisticsMinutes(2, _tempSource._statisticsDTO);
            List<StatisticsDTO> minDTO = _statisticsType.CalculateStatisticsSeconds(30, _tempSource._statisticsDTO);

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
            
            Console.WriteLine("---------------STATISTICS-----------------------");
            Console.WriteLine("Total number of alarms in the last 30 sek: " + totalalarm1);
            for (int i = 0; i < secDTO.Count; i++)
            {
                Console.WriteLine("Camera[" + secDTO[i].ID + "] triggered an alarm " + secDTO[i].NumberOfAlarms + " times");
            }
            
            Console.WriteLine("\nTotal number of alarms in the last 2 min: " + totalalarm2);
            for (int i = 0; i < minDTO.Count; i++)
            {
                Console.WriteLine("Camera[" + minDTO[i].ID + "] triggered an alarm " + minDTO[i].NumberOfAlarms + " times");
            }
            Console.WriteLine("------------------------------------------------\n");
        }
    }
}
