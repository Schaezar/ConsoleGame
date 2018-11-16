using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class UI
    {
        private const int CONSOLE_WIDTH = 160;
        private const int CONSOLE_HEIGHT = 57;
        private const string TITLE = "Console RPG";
        private const string HORIZ_DASH_LINE = " --------------------------------------------------------------------------------" +
                                               "------------------------------------------------------------------------------";
        private const string HORIZ_SOLID_LINE = "____________________________________________________________" +
                                                "___________________________________________________________";

        public const ConsoleColor RED = ConsoleColor.Red;
        public const ConsoleColor MAGENTA = ConsoleColor.DarkMagenta;
        public const ConsoleColor CYAN = ConsoleColor.Cyan;
        public const ConsoleColor GREEN = ConsoleColor.Green;
        public const ConsoleColor DEFAULT = ConsoleColor.White;

        public static void Initialize()
        {
            Console.SetWindowSize(CONSOLE_WIDTH, CONSOLE_HEIGHT);
            Console.Title = TITLE;
        }

        public static void DrawGameBorders()
        {
            for (int i = 3; i < 45; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine('|');
                Console.SetCursorPosition(159, i);
                Console.WriteLine('|');
            }
            Console.SetCursorPosition(0, 45);
            Console.WriteLine(HORIZ_DASH_LINE);
        }

        public static void DrawPlayerUI(Player player)
        {

            Console.SetCursorPosition(0, 0);
            Console.WriteLine(HORIZ_DASH_LINE);
            Console.SetCursorPosition(0, 1);
            UI.FillLine(' ');
            Console.SetCursorPosition(17, 1);
            Console.WriteLine($"Name : {player.Name}");
            Console.SetCursorPosition(47, 1);
            Console.WriteLine($"HP : {player.CurrentHP}/{player.MaxHP}");
            Console.SetCursorPosition(77, 1);
            Console.WriteLine($"EXP : {player.CurrentXP}/{player.XpToNextLevel}");
            Console.SetCursorPosition(107, 1);
            Console.WriteLine($"LVL : {player.Level}");
            Console.SetCursorPosition(127, 1);
            Console.WriteLine("Class : {0}", player.CurrentJob);
            Console.WriteLine(HORIZ_DASH_LINE);
        }

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

        public static void FillLine(char character, int length = 160)
        {
            string completeText = string.Empty;

            while (completeText.Length < length)
            {
                completeText += character;
            }

            Console.Write(completeText);
        }
    }
}