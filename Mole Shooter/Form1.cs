
using Mole_Shooter.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace Mole_Shooter
{
    public partial class MoleShooter : Form
    {


        bool bloodSplat = false;
        private int bloodTime;
        const int frameNum = 10;
        const int splatNum = 3;

        int gameFrame = 0;

        //koordinates
        int cursX = 0;
        int cursY = 0;


        //lentele
        int misses = 0;
        int hits = 0;
        int totalShots = 0;

        //laikas
        int timeleft = 10;


        Cmole mole;
        Splat splat;
        Sign sign;
        ScoreBoard scoreBoard;

        //random generatorius
        Random rand = new Random();


        public MoleShooter()
        {
            InitializeComponent();


            Bitmap b = new Bitmap(Resources.crosshair);
            this.Cursor = CustomCursor.CreateCursor(b, b.Height / 2, b.Width / 2);


            scoreBoard = new ScoreBoard() { left = 400, top = 150 };
            sign = new Sign() { left = 420, top = 60 };
            splat = new Splat();
            mole = new Cmole() { left = 10, top = 200 };
        }


        //Nustatome viskas kas juda. Tai yra kas kiek laiko kas keiciasi (komponentai)
        private void timerGameLoop_Tick(object sender, EventArgs e)
        {
            if (gameFrame >= frameNum)
            {
                updateMole();
                gameFrame = 0;
            }
            gameFrame++;

            if (bloodSplat)
            {
                if (bloodTime >= splatNum)
                {
                    bloodSplat = false;
                    bloodTime = 0;
                    updateMole();
                }
                bloodTime++;
            }


            this.Refresh();
        }


        //Atsitikine MOLE pozicija
        private void updateMole()
        {
            mole.Update(
                rand.Next(Resources.Mole.Width, this.Width - Resources.Mole.Width),   //kad neiseitu is ribu (kaires ir desines)
                rand.Next(this.Height / 2, this.Height - Resources.Mole.Height * 2));   //kad neiseitu is ribu (apacios ir auksciau  ]pacio lauko)
        }


        //Piesimo events
        protected override void OnPaint(PaintEventArgs e)
        {

            //dc = device contact
            Graphics dc = e.Graphics;

            if (bloodSplat == true)
            {
                splat.DrawImage(dc);
            }
            else
            {
                mole.DrawImage(dc);

            }

            sign.DrawImage(dc);
            scoreBoard.DrawImage(dc);


            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font font = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            //TextRenderer.DrawText(dc, "X=" + cursX.ToString() + ":" + "Y=" + cursY.ToString(), font,
            //    new Rectangle(0, 0, 120, 20), SystemColors.ControlText, flags);


            TextFormatFlags flag = TextFormatFlags.Left;
            Font fonts = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextRenderer.DrawText(e.Graphics, "Shots: " + totalShots.ToString(), font, new Rectangle(410, 160, 120, 20), SystemColors.ControlText, flags);
            TextRenderer.DrawText(e.Graphics, "Hits: " + hits.ToString(), font, new Rectangle(410, 180, 120, 20), SystemColors.ControlText, flags);
            TextRenderer.DrawText(e.Graphics, "Misses: " + misses.ToString(), font, new Rectangle(410, 200, 120, 20), SystemColors.ControlText, flags);

            base.OnPaint(e);
        }

        //kada judinama pele, tada nuolat atnaujinamos x ir y koordinates
        private void MoleShooter_MouseMove(object sender, MouseEventArgs e)
        {

            cursX = e.X;
            cursY = e.Y;
            this.Refresh();
        }



        Thread t;

        //game menu
        private void MoleShooter_MouseClick(object sender, MouseEventArgs e)
        {


            if (e.X > 450 && e.X < 550 && e.Y > 70 && e.Y < 85) //START MYGTUKAS
            {
                timerGameLoop.Start();
                //timer1.Start();

                t = new Thread(new ThreadStart(test));
                t.Start();
                // timerCD();
                //Console.WriteLine("wefewefwe");
            }


            else if (e.X > 450 && e.X < 550 && e.Y > 100 && e.Y < 115) //RESET MYGTUKAS
            {
                timerGameLoop.Stop();

                misses = 0;
                hits = 0;
                totalShots = 0;
            }


            else if (e.X > 450 && e.X < 550 && e.Y > 125 && e.Y < 140) //EXIT MYGTUKAS
            {
                Application.Exit();
            }

            else
            {
                if (mole.Hit(e.X, e.Y))
                {
                    bloodSplat = true;
                    splat.left = mole.left - Resources.blood.Width / 40;
                    splat.top = mole.top - Resources.blood.Height / 40;

                    hits++;
                }

                else
                {
                    misses++;
                }

                totalShots = hits + misses;
            }
            fireGun();
        }


        //Suvio garsas
        private void fireGun()
        {
            SoundPlayer sound = new SoundPlayer(Resources.shotSound1);
            sound.Play();
        }



        //laikmatis


        private void timer1_Tick(object sender, EventArgs e)
        {
         

        }


        public void test()
        {
            for (;;)
            {
                if (timeleft > 0)
                {
                    timeleft = timeleft - 1;
                    //timerBox.Text = timeleft + " seconds";
                    timerBox.Invoke((MethodInvoker)(() => timerBox.Text = timeleft + " seconds"));
                    Thread.Sleep(1000);
                    Console.WriteLine("timeleft"); //reikalingas siap, kad patikrinti kaip veikia thread

                }


                else
                {
                  
                    //timer1.Stop();
                    timerGameLoop.Stop();
                    this.timeleft = 10;

                    MessageBox.Show("TIMEOUT" + "\r\n" + "TotalShots: " + totalShots +
                            "\r\n" + "Hits: " + hits + "\r\n" + "Misses: " + misses);

                    t.Abort();
                    break;
                }
            }
            
            }
        }
    }
