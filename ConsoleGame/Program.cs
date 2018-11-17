using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Engine;

namespace ConsoleGame
{
    class Program
    {
        enum States { Init, Exploration, Menu, Battle, Idle };

        static Player player;

        static States currState;

        static void Main()
        {
            Position startPos = new Position(50, 10);
            player = new Player("Ragnar", startPos);

            bool isValid;
            bool gameOver = false;

            do
            {
                switch (currState)
                {
                    case States.Init:
                        {
                            UI.Initialize();
                            UI.DrawEntity(player, player.Ascii, UI.FORE_WHITE);
                            UI.DrawGameBorders();
                            UI.DrawPlayerUI(player);
                            currState = States.Exploration;
                            break;
                        }
                    case States.Exploration:
                        {
                            UI.DrawPlayerUI(player);
                            isValid = ParseCommand();
                            break;
                        }
                    case States.Menu:
                        {                          
                            currState = States.Battle;
                            break;
                        }
                    case States.Battle:
                        {
                            currState = States.Idle;
                            break;
                        }
                    case States.Idle:
                        {
                            currState = States.Exploration;
                            break;
                        }
                }
            } while (!gameOver);
        }

        static bool ParseCommand()
        {
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.A:
                    {
                        player.MovePlayer(-1, 0);
                        return true;
                    }

                case ConsoleKey.W:
                    {
                        player.MovePlayer(0, -1);
                        return true;
                    }

                case ConsoleKey.D:
                    {
                        player.MovePlayer(1, 0);
                        return true;
                    }

                case ConsoleKey.S:
                    {
                        player.MovePlayer(0, 1);
                        return true;
                    }
                default:
                    {
                        UI.WriteToInfoArea("This is not a valid command");
                        return false;
                    }
            }
        }
    }
}





   