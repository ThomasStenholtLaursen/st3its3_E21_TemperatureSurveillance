using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSurveillance.Statistics
{
    public interface IStatistics
    {
        List<StatisticsDTO> CalculateStatisticsSeconds(int sec, List<StatisticsDTO> list);
        List<StatisticsDTO> CalculateStatisticsMinutes(int min, List<StatisticsDTO> list);
    }
}
