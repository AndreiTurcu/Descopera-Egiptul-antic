using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Egipt___soft_educational
{
    public partial class Capitol1 : Form
    {
        int lectie = 1;
        int index;
        System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Application.StartupPath + @"\muzica\capitol 1.wav");

        public Capitol1(int _index)
        {
            InitializeComponent();

            index = _index;

            #region Flickering off

            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, false);
            this.SetStyle(ControlStyles.Opaque, false);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            #endregion

            #region Media
            sound.PlayLooping();
            axWindowsMediaPlayer1.URL = Application.StartupPath + @"\video\v" +lectie +".mp4";
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.Ctlenabled = false;
            pictureBox1.Visible = true;
            #endregion


            //Pozitionare obiecte
            #region Close-button

            int width = Screen.PrimaryScreen.Bounds.Width / 17;
            int height = Screen.PrimaryScreen.Bounds.Height / 9;

            pictureBox2.Location = new Point(Screen.PrimaryScreen.Bounds.Width - width,0);
            pictureBox2.Width = width;
            pictureBox2.Height = height;

            #endregion
            #region Next-button

            int width1 = Screen.PrimaryScreen.Bounds.Width / 6;
            int height1 = Screen.PrimaryScreen.Bounds.Height / 12;

            pictureBox3.Location = new Point(Screen.PrimaryScreen.Bounds.Width - width1 - 100, Screen.PrimaryScreen.Bounds.Height - height1 - 100);
            pictureBox3.Width = width1;
            pictureBox3.Height = height1;

            pictureBox4.Location = new Point(Screen.PrimaryScreen.Bounds.Width - width1 - 100, Screen.PrimaryScreen.Bounds.Height - height1 - 100);
            pictureBox4.Width = width1;
            pictureBox4.Height = height1;

            #endregion

            timer1.Start();
        }

        #region Timers

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Visible = true;
                axWindowsMediaPlayer1.fullScreen = true;
                pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\imagini\p" + lectie + ".jpg");
                timer2.Start();
                timer1.Stop();
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\imagini\p" + lectie + ".jpg");

                if (lectie == 3 ||
                    lectie == 4 ||
                    lectie == 5 ||
                    lectie == 6) pictureBox1.Enabled = true;
                else pictureBox1.Enabled = false;

                #region Switch

                axWindowsMediaPlayer1.Visible = false;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;

                #endregion

                //Exceptie test
                if (lectie == 6)
                {
                    toolTip1.SetToolTip(pictureBox1, "Incepe testul fulger!");
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                }
                else toolTip1.SetToolTip(pictureBox1, "Mareste");

                lectie++;
                timer2.Stop();
            }
        }

        #endregion


        #region Butoane

        //Inchide
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sound.Stop();
            Meniu form = new Meniu(index);
            form.Show();
            this.Hide();
        }


        //Mai departe
        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
        }
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Application.StartupPath + @"\video\v"+lectie+".mp4";
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.Ctlenabled = false;
            timer1.Start();
        }

        #region Mareste imagine

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            //Exceptie test
            if (lectie - 1 == 6)
            {
                sound.Stop();
                Form3 form = new Form3(index);
                form.Show();
                this.Hide();
            }
            else Mareste(lectie - 1);

        }

        private void Mareste (int lectie)
        {
            pictureBox5.Image = Image.FromFile(Application.StartupPath + @"\imagini\p" + lectie +".1.jpg");
            pictureBox5.Visible = true;

            if (lectie == 4) toolTip1.SetToolTip(pictureBox5, "Click dreapta pentru a vedea interiorul piramidei \nClick stanga pentru a inchide");
            else toolTip1.SetToolTip(pictureBox5, "Inchide");
        
        }

        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lectie-1 == 4)
                pictureBox5.Image = Image.FromFile(Application.StartupPath + @"\imagini\p" + (lectie-1) + ".2.jpg");
            

            if (e.Button == MouseButtons.Left) pictureBox5.Visible = false;
        }

        #endregion

        #endregion 
    }
}
