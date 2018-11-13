using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player
    {
        private static CoOrds position;

        internal static CoOrds Position { get => position; set => position = value; }

        public Player(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

        public void MovePlayer(int moveX, int moveY)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(" ");
            position.ChangeCoOrds(moveX, moveY);
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write("X");
        }
    }
}
