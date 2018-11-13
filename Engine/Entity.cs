using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public abstract class Entity
    {
        private Vector2 position;

        public Entity(Vector2 pos)
        {
            Position = pos;
        }

        public Vector2 Position { get => position; set => position = value; }
    }
}
