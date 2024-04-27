using System.Linq;

namespace DotnetStarter.Logic
{
    public class ChristmasLights
    {
        private const int CoordinateXMaxValue = 1000;
        private const int CoordinateYMaxValue = 1000;
        private readonly Light[,] _lightsWithBrightness = new Light[CoordinateXMaxValue, CoordinateYMaxValue];

        public ChristmasLights()
        {
            InitializeChristmasLights();
        }

        public int MeasureTotalBrightness()
        {
            return _lightsWithBrightness.Cast<Light>().Sum(light => light.Brightness);
        }

        public void TurnOn(Coordinates startCoordinates, Coordinates endCoordinates)
        {
            for (var initialPostionX = startCoordinates.X; initialPostionX <= endCoordinates.X; initialPostionX++)
            {
                for (var initialPositionY = startCoordinates.Y; initialPositionY <= endCoordinates.Y; initialPositionY++)
                {
                    ChangeLightBrightness(initialPostionX, initialPositionY, 1);
                }
            }
        }

        public void TurnOff(Coordinates startCoordinates, Coordinates endCoordinates)
        {
            for (var initialPostionX = startCoordinates.X; initialPostionX <= endCoordinates.X; initialPostionX++)
            {
                for (var initialPositionY = startCoordinates.Y; initialPositionY <= endCoordinates.Y; initialPositionY++)
                {
                    ChangeLightBrightness(initialPostionX, initialPositionY, -1);
                }
            }
        }

        public void Toggle(Coordinates startCoordinates, Coordinates endCoordinates)
        {
            for (var initialPostionX = startCoordinates.X; initialPostionX <= endCoordinates.X; initialPostionX++)
            {
                for (var initialPositionY = startCoordinates.Y; initialPositionY <= endCoordinates.Y; initialPositionY++)
                {
                    ChangeLightBrightness(initialPostionX, initialPositionY, 2);
                }
            }
        }

        private void ChangeLightBrightness(int initialPostionX, int initialPositionY, int increasedBrightness)
        {
            _lightsWithBrightness[initialPostionX, initialPositionY].ChangeBrightness(increasedBrightness);
        }

        private void InitializeChristmasLights()
        {
            for (var initialPostionX = 0; initialPostionX < CoordinateXMaxValue; initialPostionX++)
            {
                for (var initialPositionY = 0; initialPositionY < CoordinateYMaxValue; initialPositionY++)
                {
                    _lightsWithBrightness[initialPostionX, initialPositionY] = new Light();
                }
            }
        }
    }
}