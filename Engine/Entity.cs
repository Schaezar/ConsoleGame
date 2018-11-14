using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public abstract class Entity
    {
        public Vector2 Position { get; set; }

        public Entity(Vector2 pos)
        {
            Position = pos;
        }
    }
}
