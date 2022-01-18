using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.Statistics
{
    public class Counter : IStatistics
    {

        public List<StatisticsDTO> CalculateStatisticsMinutes(int min, List<StatisticsDTO> list)
        {

            List<StatisticsDTO> locallist = new List<StatisticsDTO>();

            var dto1 = new StatisticsDTO();
            dto1.ID = 10;
            var dto2 = new StatisticsDTO();
            dto2.ID = 11;
            var dto3 = new StatisticsDTO();
            dto3.ID = 12;


            foreach (var dto in list)
            {

                TimeSpan ts = DateTime.Now.Subtract(dto.Time);

                if (ts <= new TimeSpan(00, min, 00))
                {
                    if (dto.ID == 10)
                    {

                        dto1.NumberOfAlarms++;

                    }
                    if (dto.ID == 11)
                    {

                        dto2.NumberOfAlarms++;

                    }
                    if (dto.ID == 12)
                    {

                        dto3.NumberOfAlarms++;

                    }
                }
            }

            locallist.Add(dto1);
            locallist.Add(dto2);
            locallist.Add(dto3);



            return locallist;
        }

        public List<StatisticsDTO> CalculateStatisticsSeconds(int sec, List<StatisticsDTO> list)
        {
            List<StatisticsDTO> locallist = new List<StatisticsDTO>();

            var dto1 = new StatisticsDTO();
            dto1.ID = 10;
            var dto2 = new StatisticsDTO();
            dto2.ID = 11;
            var dto3 = new StatisticsDTO();
            dto3.ID = 12;


            foreach (var dto in list)
            {

                TimeSpan ts = DateTime.Now.Subtract(dto.Time);

                if (ts <= new TimeSpan(00, 00, sec))
                {
                    if (dto.ID == 10)
                    {

                        dto1.NumberOfAlarms++;

                    }
                    if (dto.ID == 11)
                    {

                        dto2.NumberOfAlarms++;

                    }
                    if (dto.ID == 12)
                    {

                        dto3.NumberOfAlarms++;

                    }
                }
            }

            locallist.Add(dto1);
            locallist.Add(dto2);
            locallist.Add(dto3);


            return locallist;
        }
    }
}
