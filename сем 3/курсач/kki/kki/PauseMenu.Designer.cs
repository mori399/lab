namespace kki
{
    partial class PauseMenu
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
            this.BackGame = new System.Windows.Forms.Label();
            this.MainMenu = new System.Windows.Forms.Label();
            this.Result = new System.Windows.Forms.Label();
            this.MenuSong = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BackGame
            // 
            this.BackGame.AutoSize = true;
            this.BackGame.BackColor = System.Drawing.Color.Transparent;
            this.BackGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackGame.Font = new System.Drawing.Font("Segoe Print", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BackGame.ForeColor = System.Drawing.Color.White;
            this.BackGame.Location = new System.Drawing.Point(284, 74);
            this.BackGame.Name = "BackGame";
            this.BackGame.Size = new System.Drawing.Size(304, 82);
            this.BackGame.TabIndex = 1;
            this.BackGame.Text = "Вернуться";
            this.BackGame.Click += new System.EventHandler(this.BackGame_Click);
            this.BackGame.MouseEnter += new System.EventHandler(this.BackGame_MouseEnter);
            this.BackGame.MouseLeave += new System.EventHandler(this.BackGame_MouseLeave);
            // 
            // MainMenu
            // 
            this.MainMenu.AutoSize = true;
            this.MainMenu.BackColor = System.Drawing.Color.Transparent;
            this.MainMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainMenu.Font = new System.Drawing.Font("Segoe Print", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenu.ForeColor = System.Drawing.Color.White;
            this.MainMenu.Location = new System.Drawing.Point(242, 346);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(382, 82);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "Главное меню";
            this.MainMenu.Click += new System.EventHandler(this.MainMenu_Click);
            this.MainMenu.MouseEnter += new System.EventHandler(this.MainMenu_MouseEnter);
            this.MainMenu.MouseLeave += new System.EventHandler(this.MainMenu_MouseLeave);
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.BackColor = System.Drawing.Color.Transparent;
            this.Result.Font = new System.Drawing.Font("Segoe Print", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Result.ForeColor = System.Drawing.Color.Red;
            this.Result.Location = new System.Drawing.Point(190, 53);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(513, 140);
            this.Result.TabIndex = 3;
            this.Result.Text = "Поражение";
            this.Result.Visible = false;
            // 
            // MenuSong
            // 
            this.MenuSong.AutoSize = true;
            this.MenuSong.BackColor = System.Drawing.Color.Transparent;
            this.MenuSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuSong.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MenuSong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MenuSong.Location = new System.Drawing.Point(330, 221);
            this.MenuSong.Name = "MenuSong";
            this.MenuSong.Size = new System.Drawing.Size(189, 70);
            this.MenuSong.TabIndex = 77;
            this.MenuSong.Text = "Музыка";
            this.MenuSong.Click += new System.EventHandler(this.MenuSong_Click);
            this.MenuSong.MouseEnter += new System.EventHandler(this.MenuSong_MouseEnter);
            this.MenuSong.MouseLeave += new System.EventHandler(this.MenuSong_MouseLeave);
            // 
            // PauseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::kki.Properties.Resources.PauseMenu;
            this.ClientSize = new System.Drawing.Size(874, 544);
            this.Controls.Add(this.MenuSong);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.BackGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PauseMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PauseMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label BackGame;
        private Label MainMenu;
        private Label Result;
        private Label MenuSong;
    }
}