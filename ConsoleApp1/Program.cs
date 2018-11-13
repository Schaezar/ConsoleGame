using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Engine;

namespace ConsoleGame
{
    public struct Position
    {

    }

    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;

            bool isValid = true;
            Player player = new Player(5, 5);

            do
            {
                isValid = true;
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.A:
                        {
                            player.MovePlayer(-1, 0);
                            break;
                        }

                    case ConsoleKey.W:
                        {
                            player.MovePlayer(0, -1);
                            break;
                        }

                    case ConsoleKey.D:
                        {
                            player.MovePlayer(1, 0);
                            break;
                        }

                    case ConsoleKey.S:
                        {
                            player.MovePlayer(0, 1);
                            break;
                        }
                }

            } while (isValid);

            Console.ReadKey(true);
        }
    }
}





   