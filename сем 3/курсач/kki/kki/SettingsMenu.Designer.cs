namespace kki
{
    partial class SettingsMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsMenu));
            this.Settings = new System.Windows.Forms.Label();
            this.Enemycard1 = new System.Windows.Forms.PictureBox();
            this.Enemycard2 = new System.Windows.Forms.PictureBox();
            this.Enemycard3 = new System.Windows.Forms.PictureBox();
            this.MenuSong = new System.Windows.Forms.Label();
            this.Reset = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Enemycard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemycard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemycard3)).BeginInit();
            this.SuspendLayout();
            // 
            // Settings
            // 
            this.Settings.AutoSize = true;
            this.Settings.BackColor = System.Drawing.Color.Transparent;
            this.Settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Settings.Font = new System.Drawing.Font("Segoe Print", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Settings.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Settings.Location = new System.Drawing.Point(787, 725);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(297, 140);
            this.Settings.TabIndex = 2;
            this.Settings.Text = "Назад";
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            this.Settings.MouseEnter += new System.EventHandler(this.Settings_MouseEnter);
            this.Settings.MouseLeave += new System.EventHandler(this.Settings_MouseLeave);
            // 
            // Enemycard1
            // 
            this.Enemycard1.BackColor = System.Drawing.Color.Transparent;
            this.Enemycard1.BackgroundImage = global::kki.Properties.Resources.shirt;
            this.Enemycard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Enemycard1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Enemycard1.Location = new System.Drawing.Point(634, 284);
            this.Enemycard1.Name = "Enemycard1";
            this.Enemycard1.Size = new System.Drawing.Size(103, 178);
            this.Enemycard1.TabIndex = 73;
            this.Enemycard1.TabStop = false;
            this.Enemycard1.Click += new System.EventHandler(this.Enemycard1_Click);
            // 
            // Enemycard2
            // 
            this.Enemycard2.BackColor = System.Drawing.Color.Transparent;
            this.Enemycard2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Enemycard2.BackgroundImage")));
            this.Enemycard2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Enemycard2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Enemycard2.Location = new System.Drawing.Point(890, 284);
            this.Enemycard2.Name = "Enemycard2";
            this.Enemycard2.Size = new System.Drawing.Size(103, 178);
            this.Enemycard2.TabIndex = 74;
            this.Enemycard2.TabStop = false;
            this.Enemycard2.Click += new System.EventHandler(this.Enemycard2_Click);
            // 
            // Enemycard3
            // 
            this.Enemycard3.BackColor = System.Drawing.Color.Transparent;
            this.Enemycard3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Enemycard3.BackgroundImage")));
            this.Enemycard3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Enemycard3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Enemycard3.Location = new System.Drawing.Point(1140, 284);
            this.Enemycard3.Name = "Enemycard3";
            this.Enemycard3.Size = new System.Drawing.Size(103, 178);
            this.Enemycard3.TabIndex = 75;
            this.Enemycard3.TabStop = false;
            this.Enemycard3.Click += new System.EventHandler(this.Enemycard3_Click);
            // 
            // MenuSong
            // 
            this.MenuSong.AutoSize = true;
            this.MenuSong.BackColor = System.Drawing.Color.Transparent;
            this.MenuSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuSong.Font = new System.Drawing.Font("Segoe Print", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MenuSong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MenuSong.Location = new System.Drawing.Point(992, 552);
            this.MenuSong.Name = "MenuSong";
            this.MenuSong.Size = new System.Drawing.Size(283, 105);
            this.MenuSong.TabIndex = 76;
            this.MenuSong.Text = "Музыка";
            this.MenuSong.Click += new System.EventHandler(this.Song_Click);
            this.MenuSong.MouseEnter += new System.EventHandler(this.MenuSong_MouseEnter);
            this.MenuSong.MouseLeave += new System.EventHandler(this.MenuSong_MouseLeave);
            // 
            // Reset
            // 
            this.Reset.AutoSize = true;
            this.Reset.BackColor = System.Drawing.Color.Transparent;
            this.Reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Reset.Font = new System.Drawing.Font("Segoe Print", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Reset.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Reset.Location = new System.Drawing.Point(634, 561);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(221, 105);
            this.Reset.TabIndex = 77;
            this.Reset.Text = "Сброс";
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            this.Reset.MouseEnter += new System.EventHandler(this.Reset_MouseEnter);
            this.Reset.MouseLeave += new System.EventHandler(this.Reset_MouseLeave);
            // 
            // SettingsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::kki.Properties.Resources.menu;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.MenuSong);
            this.Controls.Add(this.Enemycard3);
            this.Controls.Add(this.Enemycard2);
            this.Controls.Add(this.Enemycard1);
            this.Controls.Add(this.Settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.Enemycard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemycard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemycard3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Settings;
        private PictureBox Enemycard1;
        private PictureBox Enemycard2;
        private PictureBox Enemycard3;
        private Label MenuSong;
        private Label Reset;
    }
}