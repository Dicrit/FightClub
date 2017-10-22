using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub
{
    class Player
    {
        public readonly string name;
        public BodyPart Blocked;
        private int hp;
        public int Hp
        {
            get
            { return hp; }
        }

        public event EventHandler<PlayerActionsEventArgs> Block, Wound;
        public event Action Death;
        public Player(string name)
        {
            this.name = name;
            hp = 100;
        }
        private void getDamage(int amount)
        {
            hp -= amount;
        }

        public void getHit(BodyPart attack)
        {
            if (attack == Blocked)
            {
                if (Block != null)
                    Block(this, new PlayerActionsEventArgs(Hp, name));
                return;
            }
            if (attack == BodyPart.Head) getDamage(15);
            else if (attack == BodyPart.Torso) getDamage(12);
            else getDamage(10);
            if (Wound != null)
                Wound(this, new PlayerActionsEventArgs(Hp, name));
            if (Hp <= 0 && Death != null) Death();
        }

        public void Reincornate()
        {
            hp = 100;
        }
    }
    enum BodyPart
    {
        Head, Torso, Legs
    }
}
