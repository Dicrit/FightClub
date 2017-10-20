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
    public partial class Form1 : Form
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
        public Form1()
        {
            InitializeComponent();
            player1 = new Player();
            player1.Block += block;
            player1.Wound += wound;
            player2 = new Player();
            player2.Block += block;
            player2.Wound += wound;
            player1.name = "player";
            player2.name = "computer";
            player1progress.Value = player1.Hp;
            player2progress.Value = player2.Hp;
            player1.Lose += () => { MessageBox.Show("You've lost"); };
            player2.Lose += () => { MessageBox.Show("You win!!!!!"); };
            //logger.ControlAdded += (o,e) => { logger.TopIndex = logger.Controls.Count - 1; };
        }

        void block(string name, int Hp)
        {
            if (player1turn)
                log(player2.name + " has blocked hit, remaining hp: " + Hp);
            else
                log(player1.name + " has blocked hit, remaining hp: " + Hp);
        }
        void log(string str)
        {
            logger.TopIndex =
            logger.Items.Add(str);

        }
        void wound(string name, int Hp)
        {
            if (player1turn)
            {
                player2name.Text = name + ":" + Hp;
                player2progress.Value = Hp;
                log(player2.name + " has been wounded, remaining hp: " + Hp);
            }
            else
            {
                player1name.Text = name + ":" + Hp;
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
            //MessageBox.Show();
        }
        void playerSetBlock(Player player, BodyPart b)
        {
            player1.Blocked = b;
            player1.getHit(getBotChoise());
        }

        void playerSetAttack(Player plyer, BodyPart b)
        {
            player2.Blocked = getBotChoise();
            player2.getHit(b);
        }
        private BodyPart getBotChoise()
        {
            Random r = new Random();
            int val = r.Next(3);
            return (BodyPart)val;
        }

    }
}
