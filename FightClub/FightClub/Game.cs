using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub
{
    class Game
    {
        public readonly Player player1, player2;
        private bool playerAttacks = true;
        public string state
        {
            get
            {
                return playerAttacks ? "Attack" : "Block";
            }
        }

        public Game(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }


        public void Restart()
        {
            player1.Reincornate();
            player2.Reincornate();
            playerAttacks = true;
        }
        public void setPlayersAction(BodyPart part)
        {
            if (playerAttacks)
                playerSetAttack(part);
            else
                playerSetBlock(part);
            playerAttacks = !playerAttacks;
        }

        void playerSetBlock(BodyPart b) //Player blocks hit
        {
            player1.setBlock(b);
            player1.getHit(getBotChoise());
        }

        void playerSetAttack(BodyPart b)
        {
            player2.setBlock(getBotChoise());
            player2.getHit(b);
        }
        private BodyPart getBotChoise()   //Randomize bot's choise of which part to block/hit
        {
            Random r = new Random();
            int val = r.Next(3);
            return (BodyPart)val;
        }
    }
}
