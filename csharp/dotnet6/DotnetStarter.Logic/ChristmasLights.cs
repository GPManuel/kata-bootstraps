using System.Linq;

namespace DotnetStarter.Logic
{
    public class ChristmasLights
    {
        private bool[,] _lights = new bool[1000, 1000];

        public int CountLitLights()
        {
            return _lights.Cast<bool>().Count(light => light);
        }

        public void TurnOn(Coordinates startCoordinates, Coordinates endCoordinates)
        {
            for (var initialPostionX = startCoordinates.X; initialPostionX <= endCoordinates.X; initialPostionX++)
            {
                for (var initialPositionY = startCoordinates.Y; initialPositionY <= endCoordinates.Y; initialPositionY++)
                {
                    _lights[initialPostionX, initialPositionY] = true;
                }
            }
        }

        public void TurnOff(Coordinates startCoordinates, Coordinates endCoordinates)
        {
            for (var initialPostionX = startCoordinates.X; initialPostionX <= endCoordinates.X; initialPostionX++)
            {
                for (var initialPositionY = startCoordinates.Y; initialPositionY <= endCoordinates.Y; initialPositionY++)
                {
                    _lights[initialPostionX, initialPositionY] = false;
                }
            }
        }

        public void Toggle(Coordinates startCoordinates, Coordinates endCoordinates)
        {
            for (var initialPostionX = startCoordinates.X; initialPostionX <= endCoordinates.X; initialPostionX++)
            {
                for (var initialPositionY = startCoordinates.Y; initialPositionY <= endCoordinates.Y; initialPositionY++)
                {
                    _lights[initialPostionX, initialPositionY] = !_lights[initialPostionX, initialPositionY];
                }
            }
        }
    }
}