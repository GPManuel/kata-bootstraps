using System.Linq;

namespace DotnetStarter.Logic
{
    public class ChristmasLights
    {
        private const int CoordinateXMaxValue = 1000;
        private const int CoordinateYMaxValue = 1000;
        private const int TurnOnValue = 1;
        private const int TurnOffValue = -1;
        private const int ToggleBrightnessValue = 2;
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
                    ChangeLightBrightness(new Coordinates(initialPostionX, initialPositionY), TurnOnValue);
                }
            }
        }

        public void TurnOff(Coordinates startCoordinates, Coordinates endCoordinates)
        {
            for (var initialPositionX = startCoordinates.X; initialPositionX <= endCoordinates.X; initialPositionX++)
            {
                for (var initialPositionY = startCoordinates.Y; initialPositionY <= endCoordinates.Y; initialPositionY++)
                {
                    ChangeLightBrightness(new Coordinates(initialPositionX, initialPositionY), TurnOffValue);
                }
            }
        }

        public void Toggle(Coordinates startCoordinates, Coordinates endCoordinates)
        {
            for (var initialPositionX = startCoordinates.X; initialPositionX <= endCoordinates.X; initialPositionX++)
            {
                for (var initialPositionY = startCoordinates.Y; initialPositionY <= endCoordinates.Y; initialPositionY++)
                {
                    ChangeLightBrightness(new Coordinates(initialPositionX, initialPositionY), ToggleBrightnessValue);
                }
            }
        }

        private void ChangeLightBrightness(Coordinates coordinates, int increasedBrightness)
        {
            _lightsWithBrightness[coordinates.X, coordinates.Y].ChangeBrightness(increasedBrightness);
        }

        private void InitializeChristmasLights()
        {
            for (var initialPositionX = 0; initialPositionX < CoordinateXMaxValue; initialPositionX++)
            {
                for (var initialPositionY = 0; initialPositionY < CoordinateYMaxValue; initialPositionY++)
                {
                    _lightsWithBrightness[initialPositionX, initialPositionY] = new Light();
                }
            }
        }
    }
}