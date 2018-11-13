using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : Entity
    {
        private string name;

        public string Name { get => name; set => name = value; }

        public Player(string name, Vector2 pos) : base (pos)
        {
            Name = name;
            Position = pos;
        }

        public void MovePlayer(int moveX, int moveY)
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(" ");
            Position.Modify(moveX, moveY);
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write("@");
        }
    }
}
