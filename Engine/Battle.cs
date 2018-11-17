using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Battle
    {
        enum BattleState
        {
            INIT,
            CHOOSE_PLAYER_ACTION,
            PROCESS_PLAYER_ACTION,
            CHOOSE_MONSTER_ACTION,
            PROCESS_MONSTER_ACTION,
            CHECK_FOR_DEATH
        };

        static bool battleActive = false;
        static bool isValid = true;

        static BattleState currState = BattleState.INIT;

        public Entity StartBattle(Monster monster, Player player)
        {
            Entity victim = null;
            battleActive = true;
            ConsoleKeyInfo battleCommand;

            do
            {
                switch (currState)
                {
                    case BattleState.INIT:
                        {
                            UI.BattleInfoArea.ClearBox();
                            UI.MapInfoArea.Buffer.Clear();
                            UI.MapInfoArea.CurrConsoleLine = 34;
                            Console.SetCursorPosition(21, 0);

                            UI.WriteBattleInstructions();
                            UI.WriteToInfoArea(UI.BattleInfoArea, "A battle with " + monster.Name + " begins!", UI.FORE_DEFAULT);
                            currState = BattleState.CHOOSE_PLAYER_ACTION;
                            break;
                        }
                }
            } while (victim == null);

            return victim;
        }
    }
}
