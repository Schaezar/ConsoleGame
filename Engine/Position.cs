using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int xCoord, int yCoord)
        {
            X = xCoord;
            Y = yCoord;
        }
    }
}
