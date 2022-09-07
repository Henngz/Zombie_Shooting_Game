using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zombieShooter
{
    public partial class Form1 : Form
    {
        //These boolean variables will be used for the player direction when he wants to go in the screen.
        bool goup;
        bool godown;
        bool goleft;
        bool goright;

        //The variables is used to guide the bullet.
        string facing = "up";

        double playerHealth = 100; 
        int speed = 10; 
        int ammo = 10;
        int zombieSpeed = 3;
        int score = 0;

        // this boolean is false in the beginning and it will be used when the game is finished
        bool gameOver = false;

        Random rnd = new Random();

        List<PictureBox> zombieList = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            //Identify if player health is greater than 1.
            if(playerHealth > 1)
            {
                playerhealthprg.Value = Convert.ToInt32(playerHealth);
            }
            else
            {
                //If health is less than 1, then game over.
                playerpic.Image = Properties.Resources.dead;
                GameTimer.Stop();
                gameOver = true;
            }

            ammolbl.Text = "Ammo:" + ammo;
            killslbl.Text = "Kills:" + score;

            //If health is less than 20, change the progress bar color to red.
            if(playerHealth < 20)
            {
                playerhealthprg.ForeColor = System.Drawing.Color.Red;
            }

            // If goleft is true(press the left key) and there is a gap between the left edge of player picturebox
            // to the left edge of form, then player go left.
            if(goleft && playerpic.Left > 0)
            {
                playerpic.Left -= speed;
            }

            // If goright is true(press the right key) and there is a gap between the right edge of player picturebox
            // to the right edge of form, then player go right(add the distance to the left edge of form).
            if (goright && playerpic.Left + playerpic.Width < this.ClientSize.Width)
            {
                playerpic.Left += speed;
            }

            // If goup is true(press the up key) and the gap between the up edge of player picturebox
            // to the up edge of form is greater than 60, then player go up.
            if (goup && playerpic.Top > 60)
            {
                playerpic.Top -= speed;
            }

            // If godown is true(press the down key) and the gap between the down edge of player picturebox
            // to the down edge of form is less than 700, then player go down.
            if (godown && playerpic.Top + playerpic.Height < this.ClientSize.Height)
            {
                playerpic.Top += speed;
            }

            // Using foreach loop to check all controls.
            foreach(Control x in this.Controls)
            {
                // Check if the control is a picturebox and it is ammo. 
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    // Check if player picturebox hit the ammo picturebox.
                    if (playerpic.Bounds.IntersectsWith(x.Bounds))
                    {
                        //Once player touches the ammo, remove the ammo pic.
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();

                        ammo += 5;
                    }

                    // Check if the control is bullet pic.             
                    if (x is PictureBox && (string)x.Tag == "bullet")
                    {
                        // Bullets hits four borders of the form will be removed.
                        if (((PictureBox)x).Left < 1 || ((PictureBox)x).Left > this.ClientSize.Width - 1
                            || ((PictureBox)x).Top < 10 || ((PictureBox)x).Top > this.ClientSize.Height - 1)
                        {
                            this.Controls.Remove((PictureBox)x);
                            ((PictureBox)x).Dispose();
                        }

                    }
                }
                    //Check if the control is bullet pic.
                    if (x is PictureBox && (string)x.Tag == "zombie")
                    {
                        //Check if the bounds of zombie hits the bounds of players.
                        if (playerpic.Bounds.IntersectsWith(x.Bounds))
                        {
                            playerHealth -= 1;
                        }

                        // Let zombies move towards to player.
                        if (x.Left > playerpic.Left)
                        {
                            x.Left -= zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zleft;
                        }

                        if (x.Top > playerpic.Top)
                        {
                            x.Top -= zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zup;
                        }

                        if (x.Left < playerpic.Left)
                        {
                            x.Left += zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zright;
                        }

                        if (x.Top < playerpic.Top)
                        {
                            x.Top += zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zdown;
                        }
                    }
                

                // This is the second foreach loop which is nested in the first one.
                foreach (Control j in this.Controls)
                {
                    // Check if pictureboxes are bullet and zombie.

                    if ((j is PictureBox && j.Tag == "bullet") && (x is PictureBox && x.Tag == "zombie"))
                    {
                        // below is the if statement thats checking if bullet hits the zombie
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++;  
                            this.Controls.Remove(j); 
                            j.Dispose(); 
                            this.Controls.Remove(x); 
                            x.Dispose();

                            // Invoking the make zombies method to add another zombie to the game.
                            makeZombies(); 
                        }
                    }
                }
            }
        }

        private void Keyisdown(object sender, KeyEventArgs e)
        {
            if (gameOver) return;

            // If the left key is pressed then do the following things.
            if(e.KeyCode == Keys.Left)
            {
                goleft = true;
                facing = "left";
                playerpic.Image = Properties.Resources.left;
            }

            // If the right key is pressed then do the following things.
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
                facing = "right";
                playerpic.Image = Properties.Resources.right;
            }

            // If the down key is pressed then do the following things.
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
                facing = "down";
                playerpic.Image = Properties.Resources.down;
            }

            // If the up key is pressed then do the following things.
            if (e.KeyCode == Keys.Up)
            {
                goup = true;
                facing = "up";
                playerpic.Image = Properties.Resources.up;
            }
        }

        private void Keyisup(object sender, KeyEventArgs e)
        {
            if (gameOver) return;

            if(e.KeyCode == Keys.Left)
            {
                goleft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }

            if(e.KeyCode == Keys.Space && ammo > 0)
            {
                ammo--;
                shoot(facing);

                if(ammo < 1)
                {
                    DropAmmo();
                }
            }
        }

        /// <summary>
        /// The method is to be used when the player needs more ammo in the game.
        /// </summary>
        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Tag = "ammo";
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;

            ammo.Left = rnd.Next(10, this.ClientSize.Width); 
            ammo.Top = rnd.Next(50, this.ClientSize.Height); 
            ammo.Tag = "ammo"; 
            this.Controls.Add(ammo);

            //Bring ammo to the front.
            ammo.BringToFront();

            //Bring player to the front.
            playerpic.BringToFront();
        }

        /// <summary>
        /// The method is to be used when the player is shooting in the game.
        /// </summary>
        /// <param name="direct"></param>
        private void shoot(string direction)
        {
            Bullet shootbullet = new Bullet();
            shootbullet.direction = direction;
            shootbullet.bulletLeft = playerpic.Left + (playerpic.Width / 2);
            shootbullet.bulletTop = playerpic.Top + (playerpic.Height/ 2);

            //Invoke makebullet method.
            shootbullet.MakeBullet(this);
        }

        /// <summary>
        /// The method is to be used when we need to make more zombies.
        /// </summary>
        private void makeZombies()
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown;

            // Generate a random number and assign the number to zombie's left and top.
            zombie.Left = rnd.Next(0, 900);
            zombie.Top = rnd.Next(0, 800);
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombieList.Add(zombie);
            this.Controls.Add(zombie);
            playerpic.BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {    
            
        }

        /// <summary>
        /// The method is to restart the game and reset the configuration.
        /// </summary>
        private void RestartGame()
        {
            playerpic.Image = Properties.Resources.up;

            foreach(PictureBox i in zombieList)
            {
                this.Controls.Remove(i);
            }

            zombieList.Clear();

            for(int i = 0; i <= 3; i++)
            {
                makeZombies();
            }

            goup = false;
            godown = false;
            goleft = false;
            goright = false;

            playerHealth = 100;
            score = 0;
            ammo = 10;

            GameTimer.Start();
        }
    }
}
