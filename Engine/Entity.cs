using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public abstract class Entity
    {
        protected Position _position;

        public Position Position
        {
            get { return _position; }
        }

        public void SetPosition(int x, int y)
        {
            _position.X = x;
            _position.Y = y;
        }
    }
}
