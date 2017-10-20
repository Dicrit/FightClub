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
        private bool player1turn = true;
        public Form1()
        {
            InitializeComponent();
            player1 = new Player();
            player1.Block += block;
            player1.Wound += wound;
            player2 = new Player();
            player2.Block += block;
            player2.Wound += wound;
            player1progress.Value = player1.Hp;
        }

        void block(string name, int Hp)
        {
            
        }

        void wound(string name, int Hp)
        {
            if (player1turn)
            {
                player1name.Text = name + ":" + Hp;
                player1progress.Value = Hp;
            }
            else
            {
                player2name.Text = name + ":" + Hp;
                player2progress.Value = Hp;
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
        }
        void playerSetAttack(Player plyer, BodyPart b)
        {
            player2.getHit(b);
        }

    }
}
