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


        Game game;
        Player InitializePlayer(string name)
        {
            Player player = new Player(name);
            player.Block += block;
            player.Wound += wound;
            player.Death += restart;
            return player;
        }

        private void setUpControls()
        {
            player1progress.Value = 100;
            player2progress.Value = 100;
            player1name.Text = game.player1.name;
            player2name.Text = game.player2.name;
            logger.Items.Clear();
        }

        public FightClub()
        {
            InitializeComponent();
            string name = Prompt.ShowDialog("Please, enter your name", "Hello!");
            game = new Game(InitializePlayer(name), InitializePlayer("computer"));
            setUpControls();
        }


        private void restart()
        {
            bool win = game.state == "Attack";
            if (MessageBox.Show("You " + (win ? "Win!" : "Lost :(") + " Do you want to restart?", "Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                game.Restart();
                setUpControls();
            }
            else
            {
                EndGame();
            }
        }
        void EndGame()
        {
            unsubscribe(game.player1);
            unsubscribe(game.player2);

            Application.Exit();
        }
        void unsubscribe(Player player)
        {
            player.Block -= block;
            player.Wound -= wound;
            player.Death -= restart;
        }

        void log(string str)
        {
            logger.TopIndex = logger.Items.Add(str); //Add element and scroll to it
        }



        void block(object sender, PlayerActionsEventArgs args)
        {
            Player player = sender as Player;
            int Hp = args.hp;
            log(player.name + " has blocked hit, remaining hp: " + Hp);
        }

        void wound(object sender, PlayerActionsEventArgs args)
        {
            Player player = sender as Player;
            int Hp = args.hp;
            if (Hp < 0) Hp = 0; //Prevent Progress bar error when value < 0.
            if (sender == game.player1)
            {
                player1name.Text = args.name + ":" + Hp;
                player1progress.Value = Hp;
            }
            else
            {
                player2name.Text = args.name + ":" + Hp;
                player2progress.Value = Hp;
            }
            log(player.name + " has been wounded, remaining hp: " + Hp);
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
            game.setPlayersAction(part);
            state.Text = game.state;
        }
    }
}
