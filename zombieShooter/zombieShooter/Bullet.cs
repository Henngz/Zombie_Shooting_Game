using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace zombieShooter
{
    class Bullet
    {
        public string direction;
        public int bulletLeft;
        public int bulletTop;

        private int speed = 50;
        private PictureBox bullet = new PictureBox();
        private Timer bulletTimer = new Timer();

        public void MakeBullet(Form form)
        {
            bullet.BackColor = Color.White;
            bullet.Size = new Size(5, 5);
            bullet.Tag = "bullet";
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.BringToFront();

            form.Controls.Add(bullet);
            bulletTimer.Tick += BulletTimer_Tick;
            bulletTimer.Start();
        }

        private void BulletTimer_Tick(object sender, EventArgs e)
        {
            // Check the direction of player facing.   
            if (direction == "left")
            {
                bullet.Left -= speed; 
            }

            if (direction == "right")
            {
                bullet.Left += speed;
            }
            
            if (direction == "up")
            {
                bullet.Top -= speed;
            }
            
            if (direction == "down")
            {
                bullet.Top += speed; 
            }

            // If bullets don't hit any zombies, then bullet will disappear.
            if (bullet.Left < 16 || bullet.Left > 860 || bullet.Top < 10 || bullet.Top > 616)
            {
                bulletTimer.Stop(); // stop the timer
                bulletTimer.Dispose(); // dispose the timer event and component from the program
                bullet.Dispose(); // dispose the bullet
                bulletTimer = null; // nullify the timer object
                bullet = null; // nullify the bullet object
            }
        }
    }
}
