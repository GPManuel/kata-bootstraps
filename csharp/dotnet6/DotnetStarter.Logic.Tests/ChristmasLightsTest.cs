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

            Assert.That(_christmasLights.CountLitLights(), Is.EqualTo(1));
        }


        [Test]
        public void turn_on_a_range()
        {
            var startCoordinate = new Coordinates(0,0);
            var endCoordinate = new Coordinates(999,999);

            _christmasLights.TurnOn(startCoordinate, endCoordinate);

            Assert.That(_christmasLights.CountLitLights(), Is.EqualTo(1000000));
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

            Assert.That(_christmasLights.CountLitLights(), Is.EqualTo(999996));
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

            Assert.That(_christmasLights.CountLitLights(), Is.EqualTo(1));
        }

        [Test]
        public void final_test()
        {
            _christmasLights.TurnOn(new Coordinates(887, 9), new Coordinates(959, 629));
            _christmasLights.TurnOn(new Coordinates(454, 398), new Coordinates(844, 448));
            _christmasLights.TurnOff(new Coordinates(539, 243), new Coordinates(559, 965));
            _christmasLights.TurnOff(new Coordinates(370, 819), new Coordinates(676, 868));
            _christmasLights.TurnOff(new Coordinates(145, 40), new Coordinates(370, 997));
            _christmasLights.TurnOff(new Coordinates(301, 3), new Coordinates(808, 453));
            _christmasLights.TurnOn(new Coordinates(351, 678), new Coordinates(951, 908));
            _christmasLights.Toggle(new Coordinates(720, 196), new Coordinates(897, 994));
            _christmasLights.Toggle(new Coordinates(831, 394), new Coordinates(904, 860));
            
            Assert.That(_christmasLights.CountLitLights(), Is.EqualTo(230022));
        }

        [Test]
        public void medium_test()
        {
            _christmasLights.TurnOn(new Coordinates(0,0), new Coordinates(999,999));
            _christmasLights.Toggle(new Coordinates(0,0), new Coordinates(999,0));
            _christmasLights.TurnOff(new Coordinates(499,499), new Coordinates(500,500));

            Assert.That(_christmasLights.CountLitLights(), Is.EqualTo(998996));
        }
    }
}