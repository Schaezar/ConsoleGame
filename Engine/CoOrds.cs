using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    struct CoOrds
    {
        private int x, y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public CoOrds(int xAxis, int yAxis)
        {
            x = xAxis;
            y = yAxis;
        }

        public void ChangeCoOrds(int x, int y)
        {
            X += x;
            Y += y;
        }
    }
}
