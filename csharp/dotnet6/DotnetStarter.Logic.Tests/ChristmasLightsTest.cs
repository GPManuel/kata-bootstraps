using NUnit.Framework;
using NSubstitute;
using NUnit.Framework.Internal;

namespace DotnetStarter.Logic.Tests
{
    public class ChristmasLightsTest
    {
        private ChristmasLights _christmasLights;

        [SetUp]
        public void SetUp()
        {
            _christmasLights = new ChristmasLights();
        }

        [Test]
        public void turn_on_1_light()
        {
            var startCoordinate = new Coordinates(5, 5);
            var endCoordinate = new Coordinates(5, 5);

            _christmasLights.TurnOn(startCoordinate, endCoordinate);

            Assert.That(_christmasLights.MeasureTotalBrightness(), Is.EqualTo(1));
        }


        [Test]
        public void turn_on_a_range()
        {
            var startCoordinate = new Coordinates(0,0);
            var endCoordinate = new Coordinates(999,999);

            _christmasLights.TurnOn(startCoordinate, endCoordinate);

            Assert.That(_christmasLights.MeasureTotalBrightness(), Is.EqualTo(1000000));
        }

        [Test]
        public void turn_off_a_range()
        {
            var turnOnStartCoordinate = new Coordinates(0, 0);
            var turnOnEndCoordinate = new Coordinates(999, 999);
            var turnOffStartCoordinate = new Coordinates(499,499);
            var turnOffEndCoordinate = new Coordinates(500, 500);

            _christmasLights.TurnOn(turnOnStartCoordinate, turnOnEndCoordinate);
            _christmasLights.TurnOff(turnOffStartCoordinate, turnOffEndCoordinate);

            Assert.That(_christmasLights.MeasureTotalBrightness(), Is.EqualTo(999996));
        }

        [Test]
        public void toogle_a_range()
        {
            var turnOnStartCoordinate = new Coordinates(0, 0);
            var turnOnEndCoordinate = new Coordinates(50, 0);
            var toogleStartCoordinate = new Coordinates(0, 0);
            var toogleEndCoordinate = new Coordinates(51, 0);

            _christmasLights.TurnOn(turnOnStartCoordinate, turnOnEndCoordinate);
            _christmasLights.Toggle(toogleStartCoordinate, toogleEndCoordinate);

            Assert.That(_christmasLights.MeasureTotalBrightness(), Is.EqualTo(1));
        }

        [Test]
        public void increase_the_brightness_of_a_range()
        {
            var startCoordinate = new Coordinates(0, 0);
            var endCoordinate = new Coordinates(49, 0);
            var secondStartCoordinate = new Coordinates(24, 0);

            _christmasLights.TurnOn(startCoordinate, endCoordinate);
            _christmasLights.TurnOn(secondStartCoordinate, endCoordinate);

            Assert.That(_christmasLights.MeasureTotalBrightness(), Is.EqualTo(75));
        }
    }
}