using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public struct Vector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2(int xAxis, int yAxis)
        {
            X = xAxis;
            Y = yAxis;
        }
    }
}
