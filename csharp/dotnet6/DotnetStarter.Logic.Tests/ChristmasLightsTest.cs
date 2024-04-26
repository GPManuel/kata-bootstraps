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
            var coordinateX1 = 5;
            var coordinateY1 = 5;
            var coordinateX2 = 5;
            var coordinateY2 = 5;

            _christmasLights.TurnOn(coordinateX1, coordinateY1, coordinateX2, coordinateY2);

            Assert.That(_christmasLights.CountLitLights(), Is.EqualTo(1));
        }


        [Test]
        public void turn_on_a_range()
        {
            var coordinateX1 = 0;
            var coordinateY1 = 0;
            var coordinateX2 = 999;
            var coordinateY2 = 999;

            _christmasLights.TurnOn(coordinateX1, coordinateY1, coordinateX2, coordinateY2);

            Assert.That(_christmasLights.CountLitLights(), Is.EqualTo(1000000));
        }
    }
}