using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class UI
    {
        public static void EraseEntity(Entity ent)
        {
            Console.SetCursorPosition(ent.Position.X, ent.Position.Y);
            Console.Write(' ');
        }

        public static void DrawEntity(Entity ent, char ascii)
        {
            Console.SetCursorPosition(ent.Position.X, ent.Position.Y);
            Console.Write(ascii);
        }
    }
}