using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class UI
    {
        const int CONSOLE_WIDTH = 160;
        const int CONSOLE_HEIGHT = 57;

        const string TITLE = "Console RPG";
        const string HORIZ_DASH_LINE = " --------------------------------------------------------------------------------" +
                                               "------------------------------------------------------------------------------";
        const string HORIZ_SOLID_LINE = "____________________________________________________________" +
                                                "___________________________________________________________";

        const int BATTLE_TOP_BRDR = 3;
        const int BATTLE_LEFT_OUTER_BRDR = 0;
        const int BATTLE_LEFT_INNER_BRDR = 19;
        const int BATTLE_RIGHT_INNER_BRDR = 139;
        const int BATTLE_RIGHT_OUTER_BRDR = 159;
        const int BATTLE_BOTTOM_BRDR = 45;

        static Position player_ui_top_border = new Position(0, 0);
        static Position player_ui_name = new Position(10, 1);
        static Position player_ui_hp = new Position(47, 1);
        static Position player_ui_mp = new Position(77, 1);
        static Position player_ui_xp = new Position(107, 1);
        static Position player_ui_lvl = new Position(140, 1);

        static Position battle_ui_separator = new Position(20, 45);

        public const int MAP_TOP_BRDR = 3;
        public const int MAP_RIGHT_BRDR = 159;
        public const int MAP_BOTTOM_BRDR = 45;
        public const int MAP_LEFT_BRDR = 0;

        public const ConsoleColor FORE_DEFAULT = ConsoleColor.Gray;
        public const ConsoleColor FORE_WHITE = ConsoleColor.White;
        public const ConsoleColor FORE_DANGER = ConsoleColor.Red;
        public const ConsoleColor FORE_WARNING = ConsoleColor.Yellow;
        public const ConsoleColor FORE_INFO = ConsoleColor.Cyan;
        public const ConsoleColor FORE_SUCCESS = ConsoleColor.Green;
        public const ConsoleColor FORE_MAGIC = ConsoleColor.Magenta;

        public static InfoArea MapInfoArea = new InfoArea(46, 56, 0, 11, 56);
        public static InfoArea BattleInfoArea = new InfoArea(6, 34, 21, 28, 34);

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

            Console.SetCursorPosition(player_ui_top_border.X, player_ui_top_border.Y);
            Console.WriteLine(HORIZ_DASH_LINE);
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

            Console.Write(HORIZ_DASH_LINE);
        }

        public static void DrawBattleScreen()
        {
            for (int i = BATTLE_TOP_BRDR; i < BATTLE_BOTTOM_BRDR; i++)
            {
                Console.SetCursorPosition(BATTLE_LEFT_OUTER_BRDR, i);
                Console.WriteLine('|');
                Console.SetCursorPosition(BATTLE_LEFT_INNER_BRDR, i);
                Console.WriteLine('|');
                Console.SetCursorPosition(BATTLE_RIGHT_INNER_BRDR, i);
                Console.WriteLine('|');
                Console.SetCursorPosition(BATTLE_RIGHT_OUTER_BRDR, i);
                Console.WriteLine('|');
            }
            Console.SetCursorPosition(battle_ui_separator.X, battle_ui_separator.Y);
            Console.WriteLine(HORIZ_SOLID_LINE);
            Console.SetCursorPosition(BATTLE_BOTTOM_BRDR, BATTLE_BOTTOM_BRDR);
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

        public static void WriteToInfoArea(InfoArea infoArea, string message, ConsoleColor color)
        {
            Line line = new Line(message, color);

            if (infoArea.Buffer.Count >= infoArea.MaxBufferLength)
            {
                infoArea.Buffer.RemoveAt(infoArea.Buffer.Count - 1);
                infoArea.Buffer.Insert(0, line);
                infoArea.ClearBox();

                for (int i = 0; i < infoArea.Buffer.Count; i++)
                {
                    Console.SetCursorPosition(0, (infoArea.MaxLine - i));
                    Console.ForegroundColor = infoArea.Buffer[i].Color;
                    Console.WriteLine(infoArea.Buffer[i].Content);
                }
            }
            else
            {
                infoArea.ClearBox();
                Console.SetCursorPosition(infoArea.LeftMargin, infoArea.CurrConsoleLine);
                infoArea.Buffer.Add(line);
                for (int i = 0; i < infoArea.Buffer.Count; i++)
                {
                    Console.SetCursorPosition(0, (infoArea.MaxLine - i));
                    Console.ForegroundColor = infoArea.Buffer[i].Color;
                    Console.WriteLine(infoArea.Buffer[i].Content);
                }
                infoArea.CurrConsoleLine--;
            }
            Console.ResetColor();
        }

        public static void WriteBattleInstructions()
        {
            Console.SetCursorPosition(21, 3);
            Console.WriteLine("Choose a command to execute by typing the corresponding letter.");
            Console.SetCursorPosition(21, 4);
            Console.WriteLine("(a) to attack / (s) to cast a spell / (i) for items / (r) to run away");
            Console.SetCursorPosition(21, 5);
            Console.WriteLine("------------------------------------------------------------------------------------");
        }

        public static void FillLine(char character, int length = CONSOLE_WIDTH)
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