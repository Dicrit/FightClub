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
        }
        
        public void getHit(BodyPart attack)
        {
            if (attack == Blocked)
            {
                Block(name, Hp);
                return;
            }
            if (attack == BodyPart.Head) getDamage(15); //You get more damage to head
            else if (attack == BodyPart.Torso) getDamage(12);
            else getDamage(10);
            Wound(name, Hp);
            if (Hp <= 0) Lose();
        }


    }
    enum BodyPart
    {
        Head, Torso, Legs
    }
}
