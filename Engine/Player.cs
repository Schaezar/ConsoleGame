using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : Entity
    {

        public string Name { get; set; }
        public char Ascii { get; }

        //Hardcoded props, Just for testing
        public int CurrentHP { get; set; } = 100;
        public int MaxHP { get; } = 270;
        public int CurrentMP { get; set; } = 100;
        public int MaxMP { get; } = 270;
        public int CurrentXP { get; set; } = 60;
        public int XpToNextLevel { get; } = 100;
        public int Level { get; } = 12;
        public string CurrentJob { get; set; } = "Warrior";

        public Player(string name, Position pos)
        {
            Name = name;
            Position = pos;
            Ascii = '@';
        }

        public void MovePlayer(int xMod, int yMod)
        {
            Position destination = new Position(Position.X + xMod, Position.Y + yMod);
            // Get Tile at Destination

            if (DestinationValid(destination))
            {
                UI.EraseEntity(this);
                Position = destination;
            }
            UI.DrawEntity(this, Ascii, UI.FORE_WHITE);
        }

        public bool DestinationValid(Position dest)
        {
            if (dest.Y <= UI.MAP_TOP_BRDR-1 || dest.X >= UI.MAP_RIGHT_BRDR || dest.Y >= UI.MAP_BOTTOM_BRDR || dest.X <= UI.MAP_LEFT_BRDR)
            {
                UI.WriteToInfoArea("You cannot move there");
                return false;
            }
            return true;
        }
    }
}
