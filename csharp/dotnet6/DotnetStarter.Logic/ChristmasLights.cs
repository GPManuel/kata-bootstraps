using System.Linq;

namespace DotnetStarter.Logic
{
    public class ChristmasLights
    {
        private bool[,] _lights = new bool[1000,1000];

        public void TurnOn(int coordinateX1, int coordinateY1, int coordinateX2, int coordinateY2)
        {
            _lights[coordinateX1, coordinateY1] = true;
            _lights[coordinateX2, coordinateY2] = true;
        }

        public int CountLitLights()
        {
            return _lights.Cast<bool>().Count(light => light);
        }
    }
}