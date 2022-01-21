using NUnit.Framework;
using TemperatureSurveillance.TempCorrection;

namespace UnitTest.Correction
{
    [TestFixture]
    class AmbientCorrectionTest
    {
        private AmbientCorrection _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new AmbientCorrection();
        }


        [TestCase(39.2, -5.1)]
        [TestCase(39.2, -10.0)]
        [TestCase(39.2, -7.8)]
        [TestCase(39.2, -9.4)]
        [TestCase(39.2, -6.7)]
        [TestCase(39.2, -8.3)]
        public void CorrectTemperature_NegativeAmbientTemperature_AddsThree(double c1, double c2)
        {
            var output = _uut.Correct(c1, c2);
            var correctedTemp = c1 + 3;
            Assert.That(output, Is.EqualTo(correctedTemp));
        }

        [TestCase(37.1, 31.2)]
        [TestCase(37.1, 32.5)]
        [TestCase(37.1, 33.3)]
        [TestCase(37.1, 34.6)]
        [TestCase(37.1, 35.0)]
        public void CorrectTemperature_PositiveAmbientTemperature_RemovesOne(double c1, double c2)
        {
            var output = _uut.Correct(c1, c2);
            var correctedTemp = c1 -1;
            Assert.That(output, Is.EqualTo(correctedTemp));
        }

        [TestCase(32.1, 11.2)]
        [TestCase(35.1, 11.2)]
        [TestCase(37.1, 11.2)]
        [TestCase(39.1, 11.2)]
        [TestCase(41.9, 11.2)]
        public void CorrectTemperature_PersonTempSequence_SameAmbient_AddsOne(double c1, double c2)
        {

            var output = _uut.Correct(c1, c2);
            var addedTemp = output - c1;


            Assert.That(addedTemp, Is.EqualTo(1));
        }


        [TestCase(31.5, 32.3)]
        [TestCase(35.9, 32.3)]
        [TestCase(37.7, 32.3)]
        [TestCase(39.8, 32.3)]
        [TestCase(41.9, 32.3)]
        public void CorrectTemperature_PersonTempSequence_SameAmbient_RemovesOne(double c1, double c2)
        {

            var output = _uut.Correct(c1, c2);
            var addedTemp = output - c1;


            Assert.That(addedTemp, Is.EqualTo(-1));
        }
    }
}