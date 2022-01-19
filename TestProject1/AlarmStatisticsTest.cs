using NUnit.Framework;
using System;
using System.Collections.Generic;
using TemperatureSurveillance.Statistics;
using TemperatureSurveillance.TempCorrection;

namespace UnitTest.Statistics
{
    [TestFixture]
    class AlarmStatisticsTest
    {
        private AlarmStatistics _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new AlarmStatistics();
        }

        private List<StatisticsDTO> CreateDTOList1()
        {
            List<StatisticsDTO> list = new List<StatisticsDTO>();

            for (int i = 0; i < 20; i++)
            {

                StatisticsDTO dto = new StatisticsDTO();

                dto.ID = 10;
                dto.Time = DateTime.Now;
                list.Add(dto);
            }


            return list;
        }

        private List<StatisticsDTO> CreateDTOList2()
        {
            List<StatisticsDTO> list = new List<StatisticsDTO>();


            StatisticsDTO dto1 = new StatisticsDTO();
            StatisticsDTO dto2 = new StatisticsDTO();
            StatisticsDTO dto3 = new StatisticsDTO();
            StatisticsDTO dto4 = new StatisticsDTO();
            StatisticsDTO dto5 = new StatisticsDTO();
            StatisticsDTO dto6 = new StatisticsDTO();

            dto1.ID = 10;
            dto2.ID = 11;
            dto3.ID = 10;
            dto4.ID = 12;
            dto5.ID = 11;
            dto6.ID = 11;

            dto1.Time = DateTime.Now;
            dto2.Time = DateTime.Now;
            dto3.Time = DateTime.Now;
            dto4.Time = DateTime.Now;
            dto5.Time = DateTime.Now;
            dto6.Time = DateTime.Now;

            list.Add(dto1);
            list.Add(dto2);
            list.Add(dto3);
            list.Add(dto4);
            list.Add(dto5);
            list.Add(dto6);


            return list;
        }       

        private List<StatisticsDTO> CreateDTOList3()
        {
            List<StatisticsDTO> list = new List<StatisticsDTO>();


            StatisticsDTO dto1 = new StatisticsDTO();
            StatisticsDTO dto2 = new StatisticsDTO();
            StatisticsDTO dto3 = new StatisticsDTO();
            StatisticsDTO dto4 = new StatisticsDTO();
            StatisticsDTO dto5 = new StatisticsDTO();
            StatisticsDTO dto6 = new StatisticsDTO();

            dto1.ID = 12;
            dto2.ID = 11;
            dto3.ID = 10;
            dto4.ID = 12;
            dto5.ID = 11;
            dto6.ID = 11;

            dto1.Time = new DateTime();
            dto2.Time = new DateTime();
            dto3.Time = new DateTime();
            dto4.Time = new DateTime();
            dto5.Time = new DateTime();
            dto6.Time = new DateTime();

            list.Add(dto1);
            list.Add(dto2);
            list.Add(dto3);
            list.Add(dto4);
            list.Add(dto5);
            list.Add(dto6);


            return list;
        }

        private List<StatisticsDTO> CreateDTOList4()
        {
            List<StatisticsDTO> list = new List<StatisticsDTO>();


            StatisticsDTO dto1 = new StatisticsDTO();
            StatisticsDTO dto2 = new StatisticsDTO();
            StatisticsDTO dto3 = new StatisticsDTO();
            StatisticsDTO dto4 = new StatisticsDTO();
            StatisticsDTO dto5 = new StatisticsDTO();
            StatisticsDTO dto6 = new StatisticsDTO();

            dto1.ID = 12;
            dto2.ID = 11;
            dto3.ID = 10;
            dto4.ID = 12;
            dto5.ID = 11;
            dto6.ID = 11;

            dto1.Time = new DateTime();
            dto2.Time = new DateTime();
            dto3.Time = new DateTime();
            dto4.Time = DateTime.Now;
            dto5.Time = DateTime.Now;
            dto6.Time = DateTime.Now;

            list.Add(dto1);
            list.Add(dto2);
            list.Add(dto3);
            list.Add(dto4);
            list.Add(dto5);
            list.Add(dto6);


            return list;
        }

        private List<StatisticsDTO> CreateDTOList5()
        {
            List<StatisticsDTO> list = new List<StatisticsDTO>();

            for (int i = 0; i < 20; i++)
            {

                StatisticsDTO dto = new StatisticsDTO();

                dto.ID = 10+i;
                dto.Time = DateTime.Now;
                list.Add(dto);
            }


            return list;
        }

        [Test]
        public void AlarmStatisticsTest_ListContainsTwentyDTO_onlyOneReturnedDueToIdenticalID()
        {
            var list = CreateDTOList1();
            var output = _uut.CalculateStatistics(30, 0, list);

            Assert.That(output.Count, Is.EqualTo(1));

        }

        [Test]
        public void AlarmStatisticsTest_TotalAlarmsTwenty_OnlyOneDTOReturned_IDisTen()
        {
            var list = CreateDTOList1();
            var output = _uut.CalculateStatistics(30, 0, list);
            var totalAlarms = 0;

            foreach (var item in output)
            {
                totalAlarms += item.NumberOfAlarms;
            }

            Assert.That(totalAlarms, Is.EqualTo(20));
            Assert.That(output[0].NumberOfAlarms, Is.EqualTo(20));
            Assert.That(output.Count, Is.EqualTo(1));
            Assert.That(output[0].ID, Is.EqualTo(10));

        }

        [Test]
        public void AlarmStatisticsTest_DifferentSensorsTriggersAlarm_TotalAlarmsIsSix()
        {
            var list = CreateDTOList2();
            var output = _uut.CalculateStatistics(30, 0, list);
            var totalAlarms = 0;

            foreach (var item in output)
            {
                totalAlarms += item.NumberOfAlarms;
            }

            Assert.That(totalAlarms, Is.EqualTo(6));
        }

        [Test]
        public void AlarmStatisticsTestSeconds_TimespanIsGreaterThan30Seconds_NoAlarmTriggers()
        {
            var list = CreateDTOList3();
            var output = _uut.CalculateStatistics(30, 0, list);
            var totalAlarms = 0;

            foreach (var item in output)
            {
                totalAlarms += item.NumberOfAlarms;
            }

            Assert.That(totalAlarms, Is.EqualTo(0));
        }

        [Test]
        public void AlarmStatisticsTestMinutes_TimespanIsGreaterThan30Seconds_NoAlarmTriggers()
        {
            var list = CreateDTOList3();
            var output = _uut.CalculateStatistics(0, 2, list);
            var totalAlarms = 0;

            foreach (var item in output)
            {
                totalAlarms += item.NumberOfAlarms;
            }

            Assert.That(totalAlarms, Is.EqualTo(0));
        }


        [Test]
        public void AlarmStatisticsTest_HalfOFTimespanIsGreaterThan2Minutes_3AlarmTriggers()
        {
            var list = CreateDTOList4();
            var output = _uut.CalculateStatistics(0, 2, list);
            var totalAlarms = 0;

            foreach (var item in output)
            {
                totalAlarms += item.NumberOfAlarms;
            }

            Assert.That(totalAlarms, Is.EqualTo(3));
        }

        [Test]
        public void AlarmStatisticsTest_SensorWithDifferentID_LengthOfReturnedDTOListIsTwenty()
        {
            var list = CreateDTOList5();
            var output = _uut.CalculateStatistics(30, 0, list);

            Assert.That(output.Count, Is.EqualTo(20));
        }        

    }
}