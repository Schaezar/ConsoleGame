using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public struct Position
    {
        int X;
        int Y;

        public int x { get => X; set => X = value; }
        public int y { get => Y; set => Y = value; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void ChangePosition(int x, int y)
        {
            X += x;
            Y += y;
        }
    }

    static class Player
    {
        public static Position position = new Position(9, 9);
    }

    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;

            bool isValid = true;

            do
            {
                isValid = true;
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.A:
                        {
                            MovePlayer(-1, 0);
                            break;
                        }

                    case ConsoleKey.W:
                        {
                            MovePlayer(0, -1);
                            break;
                        }

                    case ConsoleKey.D:
                        {
                            MovePlayer(1, 0);
                            break;
                        }

                    case ConsoleKey.S:
                        {
                            MovePlayer(0, 1);
                            break;
                        }
                }

            } while (isValid);

            Console.ReadKey(true);
        }

        static void MovePlayer(int x, int y)
        {
            Console.SetCursorPosition(Player.position.x, Player.position.y);
            Console.Write(" ");
            Player.position.ChangePosition(x, y);
            Console.SetCursorPosition(Player.position.x, Player.position.y);
            Console.Write("X");
        }
    }
}





   