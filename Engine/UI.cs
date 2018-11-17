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

        public const int MAP_TOP_BRDR = 3;
        public const int MAP_RIGHT_BRDR = 159;
        public const int MAP_BOTTOM_BRDR = 45;
        public const int MAP_LEFT_BRDR = 0;

        static Position top_player_ui_border = new Position(0, 0);
        static Position player_ui_info_line = new Position(0, 1);
        static Position bottom_player_ui_border = new Position(0, 2);

        static Position player_ui_name = new Position(10, 1);
        static Position player_ui_hp = new Position(47, 1);
        static Position player_ui_mp = new Position(77, 1);
        static Position player_ui_xp = new Position(107, 1);
        static Position player_ui_lvl = new Position(140, 1);

        public const ConsoleColor FORE_DEFAULT = ConsoleColor.Gray;
        public const ConsoleColor FORE_WHITE = ConsoleColor.White;
        public const ConsoleColor FORE_DANGER = ConsoleColor.Red;
        public const ConsoleColor FORE_WARNING = ConsoleColor.Yellow;
        public const ConsoleColor FORE_INFO = ConsoleColor.Cyan;
        public const ConsoleColor FORE_SUCCESS = ConsoleColor.Green;
        public const ConsoleColor FORE_MAGIC = ConsoleColor.Magenta;

        public static int CurrentConsoleLine = 46;

        public static List<string> UIBuffer = new List<string>();

        public static void Initialize()
        {
            Console.SetWindowSize(CONSOLE_WIDTH, CONSOLE_HEIGHT);
            Console.Title = TITLE;
            Console.CursorVisible = false;
        }

        public static void DrawGameBorders()
        {
            for (int i = MAP_TOP_BRDR; i < MAP_BOTTOM_BRDR; i++)
            {
                Console.SetCursorPosition(MAP_LEFT_BRDR, i);
                Console.WriteLine('|');
                Console.SetCursorPosition(MAP_RIGHT_BRDR, i);
                Console.WriteLine('|');
            }
            Console.SetCursorPosition(MAP_LEFT_BRDR, MAP_BOTTOM_BRDR);
            Console.WriteLine(HORIZ_DASH_LINE);
        }

        public static void DrawPlayerUI(Player player)
        {

            Console.SetCursorPosition(top_player_ui_border.X, top_player_ui_border.Y);
            Console.WriteLine(HORIZ_DASH_LINE);
            Console.SetCursorPosition(player_ui_info_line.X, player_ui_info_line.Y);
            UI.FillLine(' ');

            Console.SetCursorPosition(player_ui_name.X, player_ui_name.Y);
            Console.WriteLine($"Name : {player.Name}");

            Console.SetCursorPosition(player_ui_hp.X, player_ui_hp.Y);
            Console.WriteLine($"HP : {player.CurrentHP}/{player.MaxHP}");

            Console.SetCursorPosition(player_ui_mp.X, player_ui_mp.Y);
            Console.WriteLine($"MP : {player.CurrentMP}/{player.MaxMP}");

            Console.SetCursorPosition(player_ui_xp.X, player_ui_xp.Y);
            Console.WriteLine($"EXP : {player.CurrentXP}/{player.XpToNextLevel}");

            Console.SetCursorPosition(player_ui_lvl.X, player_ui_lvl.Y);
            Console.WriteLine($"LVL : {player.Level}");
            Console.WriteLine(HORIZ_DASH_LINE);
        }

        public static void DrawEntity(Entity ent, char ascii, ConsoleColor color = UI.FORE_DEFAULT)
        {
            Console.SetCursorPosition(ent.Position.X, ent.Position.Y);
            Console.ForegroundColor = color;
            Console.Write(ascii);
            Console.ForegroundColor = UI.FORE_DEFAULT;
        }

        public static void EraseEntity(Entity ent)
        {
            Console.SetCursorPosition(ent.Position.X, ent.Position.Y);
            Console.Write(' ');
        }

        public static void ClearMessageBox()
        {
            for (int iy = 46; iy < 57; iy++)
            {
                Console.SetCursorPosition(0, iy);
                UI.FillLine(' ');
            }
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

        public static void WriteToInfoArea(string mess)
        {
            if (CurrentConsoleLine >= 57)
            {
                UIBuffer.RemoveAt(10);
                UIBuffer.Insert(0, mess);
                ClearMessageBox();

                for (int i = 0; i < UIBuffer.Count; i++)
                {
                    Console.SetCursorPosition(0, (46 + i));
                    Console.WriteLine(UIBuffer[i]);
                }
            }
            else
            {
                ClearMessageBox();
                Console.SetCursorPosition(0, CurrentConsoleLine);
                UIBuffer.Add(mess);
                for (int i = 0; i < UIBuffer.Count; i++)
                {
                    Console.SetCursorPosition(0, (46 + i));
                    Console.WriteLine(UIBuffer[i]);
                }
                CurrentConsoleLine++;
            }
        }
    }
}