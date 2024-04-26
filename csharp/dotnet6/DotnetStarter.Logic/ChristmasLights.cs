using System.Linq;

namespace DotnetStarter.Logic
{
    public class ChristmasLights
    {
        private const int COORDINATEX_MAX_VALUE = 1000;
        private const int COORFINATEY_MAX_VALUE = 1000;
        private Light[,] _lightsWithBrightness = new Light[COORDINATEX_MAX_VALUE, COORFINATEY_MAX_VALUE];

        public ChristmasLights()
        {
            InitializeChristmasLights();
        }

        public int MeasureTotalBrightness()
        {
            return _lightsWithBrightness.Cast<Light>().Count(light => light.State);
        }

        public void TurnOn(Coordinates startCoordinates, Coordinates endCoordinates)
        {
            for (var initialPostionX = startCoordinates.X; initialPostionX <= endCoordinates.X; initialPostionX++)
            {
                for (var initialPositionY = startCoordinates.Y; initialPositionY <= endCoordinates.Y; initialPositionY++)
                {
                    ChangeLightBrightness(initialPostionX, initialPositionY, true);
                }
            }
        }

        public void TurnOff(Coordinates startCoordinates, Coordinates endCoordinates)
        {
            for (var initialPostionX = startCoordinates.X; initialPostionX <= endCoordinates.X; initialPostionX++)
            {
                for (var initialPositionY = startCoordinates.Y; initialPositionY <= endCoordinates.Y; initialPositionY++)
                {
                    ChangeLightBrightness(initialPostionX, initialPositionY, false);
                }
            }
        }

        public void Toggle(Coordinates startCoordinates, Coordinates endCoordinates)
        {
            for (var initialPostionX = startCoordinates.X; initialPostionX <= endCoordinates.X; initialPostionX++)
            {
                for (var initialPositionY = startCoordinates.Y; initialPositionY <= endCoordinates.Y; initialPositionY++)
                {
                    ChangeLightBrightness(initialPostionX, initialPositionY, !_lightsWithBrightness[initialPostionX, initialPositionY].State);
                }
            }
        }

        private void ChangeLightBrightness(int initialPostionX, int initialPositionY, bool state)
        {
            _lightsWithBrightness[initialPostionX, initialPositionY].ChangeBrightness(state);
        }

        private void InitializeChristmasLights()
        {
            for (var initialPostionX = 0; initialPostionX < COORDINATEX_MAX_VALUE; initialPostionX++)
            {
                for (var initialPositionY = 0; initialPositionY < COORFINATEY_MAX_VALUE; initialPositionY++)
                {
                    _lightsWithBrightness[initialPostionX, initialPositionY] = new Light();
                }
            }
        }
    }
}