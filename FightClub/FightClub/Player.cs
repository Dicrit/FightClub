using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub
{
    class Player
    {
        public string name;
        public BodyPart Blocked;
        public int Hp = 100;
        public event Action<string, int> Block, Wound;
        public event Action Lose;
        public Player()
        {
            name = "";
            Lose = () => { };
        }
        private void getDamage(int amount)
        {
            Hp -= amount;
            if (Hp <= 0) Lose();
        }
        
        public void getHit(BodyPart attack)
        {
            if (attack == Blocked)
            {
                Block(name, Hp);
                return;
            }
            if (attack == BodyPart.Head) getDamage(20);
            else getDamage(10);
            Wound(name, Hp);
        }


    }
    enum BodyPart
    {
        Head, Torso, Legs
    }
}
