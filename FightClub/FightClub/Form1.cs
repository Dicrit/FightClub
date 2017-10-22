using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightClub
{
    public partial class FightClub : Form
    {
        private Player player1, player2;
        private bool _turn = true;
        private bool player1turn
        {
            get
            {
                return _turn;
            }
            set
            {
                state.Text = value ? "Attack" : "Block";
                _turn = value;
            }
        }
        Player InitializePlayer(string name)
        {
            Player player = new Player(name);
            player.Block += block;
            player.Wound += wound;
            player.Death += restart;
            return player;
        }
        public FightClub()
        {
            InitializeComponent();
            string name = Prompt.ShowDialog("Please, enter your name", "Hello!");
            player1 = InitializePlayer(name);
            player2 = InitializePlayer("computer");
            player1progress.Value = player1.Hp;
            player2progress.Value = player2.Hp;
            player1name.Text = player1.name;
            player2name.Text = player2.name;
        }
        private void restart()
        {
            if (MessageBox.Show("You " + (player1turn ? "Win!" : "Lost :(") + " Do you want to restart?", "Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                player1.Reincornate();
                player2.Reincornate();
                player1progress.Value = player1.Hp;
                player2progress.Value = player2.Hp;
                player1name.Text = player1.name;
                player2name.Text = player2.name;
                logger.Items.Clear();
            }
            else
            {
                Application.Exit();
            }
        }


        void block(object sender, PlayerActionsEventArgs args)
        {
            int Hp = args.hp;
            if (player1turn)
                log(player2.name + " has blocked hit, remaining hp: " + Hp);
            else
                log(player1.name + " has blocked hit, remaining hp: " + Hp);
        }
        void log(string str)
        {
            logger.TopIndex = logger.Items.Add(str); //Add element and scroll to it
        }
        void wound(object sender, PlayerActionsEventArgs args)
        {
            int Hp = args.hp;
            if (Hp < 0) Hp = 0; //Prevent Progress bar error when value < 0.
            if (player1turn)
            {
                player2name.Text = args.name + ":" + Hp;
                player2progress.Value = Hp;
                log(player2.name + " has been wounded, remaining hp: " + Hp);
            }
            else
            {
                player1name.Text = args.name + ":" + Hp;
                player1progress.Value = Hp;
                log(player1.name + " has been wounded, remaining hp: " + Hp);
            }

        }


        private void Player1setPart(object sender, EventArgs e)
        {
            BodyPart part = BodyPart.Head;
            switch (((Button)sender).Tag.ToString())
            {
                case "Torso":
                    part = BodyPart.Torso;
                    break;
                case "Legs":
                    part = BodyPart.Legs;
                    break;
            }
            if (player1turn)
            {
                playerSetAttack(player1, part);
            }
            else playerSetBlock(player1, part);
            player1turn = !player1turn;
        }
        void playerSetBlock(Player player, BodyPart b) //Player blocks hit
        {
            player1.Blocked = b;
            player1.getHit(getBotChoise());
        }

        void playerSetAttack(Player plyer, BodyPart b)
        {
            player2.Blocked = getBotChoise();
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
