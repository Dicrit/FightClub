namespace FightClub
{
    partial class FightClub
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.player1name = new System.Windows.Forms.Label();
            this.HeadButton = new System.Windows.Forms.Button();
            this.TorsoButton = new System.Windows.Forms.Button();
            this.LegsButton = new System.Windows.Forms.Button();
            this.player1progress = new System.Windows.Forms.ProgressBar();
            this.player2progress = new System.Windows.Forms.ProgressBar();
            this.player2name = new System.Windows.Forms.Label();
            this.state = new System.Windows.Forms.Label();
            this.logger = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // player1name
            // 
            this.player1name.AutoSize = true;
            this.player1name.Location = new System.Drawing.Point(68, 73);
            this.player1name.Name = "player1name";
            this.player1name.Size = new System.Drawing.Size(41, 13);
            this.player1name.TabIndex = 0;
            this.player1name.Text = "player1";
            // 
            // HeadButton
            // 
            this.HeadButton.Location = new System.Drawing.Point(195, 150);
            this.HeadButton.Name = "HeadButton";
            this.HeadButton.Size = new System.Drawing.Size(75, 23);
            this.HeadButton.TabIndex = 1;
            this.HeadButton.Tag = "Head";
            this.HeadButton.Text = "head";
            this.HeadButton.UseVisualStyleBackColor = true;
            this.HeadButton.Click += new System.EventHandler(this.Player1setPart);
            // 
            // TorsoButton
            // 
            this.TorsoButton.Location = new System.Drawing.Point(195, 200);
            this.TorsoButton.Name = "TorsoButton";
            this.TorsoButton.Size = new System.Drawing.Size(75, 23);
            this.TorsoButton.TabIndex = 2;
            this.TorsoButton.Tag = "Torso";
            this.TorsoButton.Text = "torso";
            this.TorsoButton.UseVisualStyleBackColor = true;
            this.TorsoButton.Click += new System.EventHandler(this.Player1setPart);
            // 
            // LegsButton
            // 
            this.LegsButton.Location = new System.Drawing.Point(195, 253);
            this.LegsButton.Name = "LegsButton";
            this.LegsButton.Size = new System.Drawing.Size(75, 23);
            this.LegsButton.TabIndex = 3;
            this.LegsButton.Tag = "Legs";
            this.LegsButton.Text = "legs";
            this.LegsButton.UseVisualStyleBackColor = true;
            this.LegsButton.Click += new System.EventHandler(this.Player1setPart);
            // 
            // player1progress
            // 
            this.player1progress.Location = new System.Drawing.Point(71, 102);
            this.player1progress.Name = "player1progress";
            this.player1progress.Size = new System.Drawing.Size(100, 23);
            this.player1progress.TabIndex = 4;
            // 
            // player2progress
            // 
            this.player2progress.Location = new System.Drawing.Point(290, 101);
            this.player2progress.Name = "player2progress";
            this.player2progress.Size = new System.Drawing.Size(100, 23);
            this.player2progress.TabIndex = 5;
            // 
            // player2name
            // 
            this.player2name.AutoSize = true;
            this.player2name.Location = new System.Drawing.Point(349, 73);
            this.player2name.Name = "player2name";
            this.player2name.Size = new System.Drawing.Size(41, 13);
            this.player2name.TabIndex = 0;
            this.player2name.Text = "player2";
            // 
            // state
            // 
            this.state.AutoSize = true;
            this.state.Location = new System.Drawing.Point(212, 111);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(41, 13);
            this.state.TabIndex = 6;
            this.state.Text = "Atttack";
            // 
            // logger
            // 
            this.logger.FormattingEnabled = true;
            this.logger.Location = new System.Drawing.Point(71, 304);
            this.logger.Name = "logger";
            this.logger.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.logger.Size = new System.Drawing.Size(391, 95);
            this.logger.TabIndex = 7;
            // 
            // FightClub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(502, 420);
            this.Controls.Add(this.logger);
            this.Controls.Add(this.state);
            this.Controls.Add(this.player2progress);
            this.Controls.Add(this.player1progress);
            this.Controls.Add(this.LegsButton);
            this.Controls.Add(this.TorsoButton);
            this.Controls.Add(this.HeadButton);
            this.Controls.Add(this.player2name);
            this.Controls.Add(this.player1name);
            this.Name = "FightClub";
            this.Text = "FightClub";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label player1name;
        private System.Windows.Forms.Button HeadButton;
        private System.Windows.Forms.Button TorsoButton;
        private System.Windows.Forms.Button LegsButton;
        private System.Windows.Forms.ProgressBar player1progress;
        private System.Windows.Forms.ProgressBar player2progress;
        private System.Windows.Forms.Label player2name;
        private System.Windows.Forms.Label state;
        private System.Windows.Forms.ListBox logger;
    }
}

