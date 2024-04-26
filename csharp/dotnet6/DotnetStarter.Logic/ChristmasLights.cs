using System.Linq;

namespace DotnetStarter.Logic
{
    public class ChristmasLights
    {
        private bool[,] _lights = new bool[1000, 1000];

        public void TurnOn(int coordinateX1, int coordinateY1, int coordinateX2, int coordinateY2)
        {
            //var initialPostionX = coordinateX1
            for (var initialPostionX = coordinateX1; initialPostionX <= coordinateX2; initialPostionX++)
            {
                for (var initialPositionY = coordinateY1; initialPositionY <= coordinateY2; initialPositionY++)
                {
                    _lights[initialPostionX, initialPositionY] = true;
                }
            }
        }

        public int CountLitLights()
        {
            return _lights.Cast<bool>().Count(light => light);
        }
    }
}