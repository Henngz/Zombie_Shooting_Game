namespace zombieShooter
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.ammolbl = new System.Windows.Forms.Label();
            this.killslbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.playerhealthprg = new System.Windows.Forms.ProgressBar();
            this.playerpic = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.playerpic)).BeginInit();
            this.SuspendLayout();
            // 
            // ammolbl
            // 
            this.ammolbl.AutoSize = true;
            this.ammolbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ammolbl.ForeColor = System.Drawing.Color.White;
            this.ammolbl.Location = new System.Drawing.Point(41, 25);
            this.ammolbl.Name = "ammolbl";
            this.ammolbl.Size = new System.Drawing.Size(125, 32);
            this.ammolbl.TabIndex = 0;
            this.ammolbl.Text = "Ammo:0";
            this.ammolbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // killslbl
            // 
            this.killslbl.AutoSize = true;
            this.killslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.killslbl.ForeColor = System.Drawing.Color.White;
            this.killslbl.Location = new System.Drawing.Point(320, 25);
            this.killslbl.Name = "killslbl";
            this.killslbl.Size = new System.Drawing.Size(99, 32);
            this.killslbl.TabIndex = 1;
            this.killslbl.Text = "Kills:0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(597, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Health:";
            // 
            // playerhealthprg
            // 
            this.playerhealthprg.Location = new System.Drawing.Point(715, 30);
            this.playerhealthprg.Name = "playerhealthprg";
            this.playerhealthprg.Size = new System.Drawing.Size(179, 23);
            this.playerhealthprg.TabIndex = 3;
            this.playerhealthprg.Value = 100;
            // 
            // playerpic
            // 
            this.playerpic.ErrorImage = null;
            this.playerpic.Image = global::zombieShooter.Properties.Resources.up;
            this.playerpic.Location = new System.Drawing.Point(376, 289);
            this.playerpic.Name = "playerpic";
            this.playerpic.Size = new System.Drawing.Size(71, 100);
            this.playerpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.playerpic.TabIndex = 4;
            this.playerpic.TabStop = false;
            this.playerpic.Tag = "player";
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.MainTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(921, 658);
            this.Controls.Add(this.playerpic);
            this.Controls.Add(this.playerhealthprg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.killslbl);
            this.Controls.Add(this.ammolbl);
            this.Name = "Form1";
            this.Text = "Zombie Shooter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.playerpic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ammolbl;
        private System.Windows.Forms.Label killslbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar playerhealthprg;
        private System.Windows.Forms.PictureBox playerpic;
        private System.Windows.Forms.Timer GameTimer;
    }
}

