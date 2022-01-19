using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.Statistics
{
    public class AlarmStatistics : IStatistics
    {

        public List<StatisticsDTO> CalculateStatistics(int sec, int min, List<StatisticsDTO> DTOlist)
        {

            List<StatisticsDTO> locallist = new List<StatisticsDTO>();            
            List<int> SensorIDList = new List<int>();

            for (int i = 0; i < DTOlist.Count; i++)
            {
                if (!SensorIDList.Contains(DTOlist[i].ID))
                {
                    SensorIDList.Add(DTOlist[i].ID);
                }
            }

            foreach (var sensorID in SensorIDList)
            {
                StatisticsDTO dto = new StatisticsDTO();
                dto.ID = sensorID;
                locallist.Add(dto);
            }

            foreach (var dto in DTOlist)
            {
                TimeSpan ts = DateTime.Now.Subtract(dto.Time);
                if (ts <= new TimeSpan(00, min, sec))
                {
                    foreach (var localdto in locallist)
                    {
                        if (dto.ID == localdto.ID)
                        {
                            localdto.NumberOfAlarms++;
                        }
                    }
                }
                
            }

            return locallist;
        }        
    }
}
