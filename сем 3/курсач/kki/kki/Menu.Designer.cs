namespace kki
{
    partial class Menu
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
            this.Play = new System.Windows.Forms.Label();
            this.Settings = new System.Windows.Forms.Label();
            this.Collection = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Play
            // 
            this.Play.AutoSize = true;
            this.Play.BackColor = System.Drawing.Color.Transparent;
            this.Play.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Play.Font = new System.Drawing.Font("Segoe Print", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Play.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Play.Location = new System.Drawing.Point(744, 205);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(397, 140);
            this.Play.TabIndex = 0;
            this.Play.Text = "Играть";
            this.Play.Click += new System.EventHandler(this.Play_Click);
            this.Play.MouseEnter += new System.EventHandler(this.Play_MouseEnter);
            this.Play.MouseLeave += new System.EventHandler(this.Play_MouseLeave);
            // 
            // Settings
            // 
            this.Settings.AutoSize = true;
            this.Settings.BackColor = System.Drawing.Color.Transparent;
            this.Settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Settings.Font = new System.Drawing.Font("Segoe Print", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Settings.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Settings.Location = new System.Drawing.Point(691, 382);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(534, 140);
            this.Settings.TabIndex = 1;
            this.Settings.Text = "Настройки";
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            this.Settings.MouseEnter += new System.EventHandler(this.Settings_MouseEnter);
            this.Settings.MouseLeave += new System.EventHandler(this.Settings_MouseLeave);
            // 
            // Collection
            // 
            this.Collection.AutoSize = true;
            this.Collection.BackColor = System.Drawing.Color.Transparent;
            this.Collection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Collection.Font = new System.Drawing.Font("Segoe Print", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Collection.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Collection.Location = new System.Drawing.Point(691, 558);
            this.Collection.Name = "Collection";
            this.Collection.Size = new System.Drawing.Size(504, 140);
            this.Collection.TabIndex = 2;
            this.Collection.Text = "Коллекция";
            this.Collection.Click += new System.EventHandler(this.Collection_Click);
            this.Collection.MouseEnter += new System.EventHandler(this.Collection_MouseEnter);
            this.Collection.MouseLeave += new System.EventHandler(this.Collection_MouseLeave);
            // 
            // Exit
            // 
            this.Exit.AutoSize = true;
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit.Font = new System.Drawing.Font("Segoe Print", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Exit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Exit.Location = new System.Drawing.Point(787, 743);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(309, 140);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Выход";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            this.Exit.MouseEnter += new System.EventHandler(this.Exit_MouseEnter);
            this.Exit.MouseLeave += new System.EventHandler(this.Exit_MouseLeave);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::kki.Properties.Resources.MainMenu;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Collection);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.Play);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Play;
        private Label Settings;
        private Label Collection;
        private Label Exit;
    }
}