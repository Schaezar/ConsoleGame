using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public struct Vector2
    {
        private int x, y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Vector2(int xAxis, int yAxis)
        {
            x = xAxis;
            y = yAxis;
        }

        public void Modify(int xMod, int yMod)
        {
            x += xMod;
            x += yMod;
        }
    }
}
