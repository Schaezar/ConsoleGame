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
        public int CurrentXP { get; set; } = 60;
        public int XpToNextLevel { get; } = 100;
        public int Level { get; } = 12;
        public string CurrentJob { get; set; } = "Warrior";

        public Player(string name, Vector2 pos) : base (pos)
        {
            Name = name;
            Position = pos;
            Ascii = '@';
        }

        public void MovePlayer(int xMod, int yMod)
        {
            UI.EraseEntity(this);
            Position = new Vector2(Position.X + xMod, Position.Y + yMod);
            UI.DrawEntity(this, Ascii);
        }
    }
}
