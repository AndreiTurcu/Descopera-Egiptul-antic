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
    public partial class Capitol2 : Form
    {
        int lectie = 7, pag = 2;
        int index;
        System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Application.StartupPath + @"\muzica\capitol 2.wav");

        public Capitol2(int _index)
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
            axWindowsMediaPlayer1.URL = Application.StartupPath + @"\video\v7.mp4";
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.Ctlenabled = false;
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
        }

       
        private void Form4_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        #region Timers

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Visible = true;
                axWindowsMediaPlayer1.fullScreen = true;

                //Exceptie rebus
                if(lectie!=10) pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\imagini\p" + lectie + ".jpg");
                else pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\imagini\p9.2.jpg");

                
                timer2.Start();
                timer1.Stop();
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {

                #region Switch

                axWindowsMediaPlayer1.Visible = false;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;

                #endregion

                //Exceptie rebus
                if (lectie == 10) this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\imagini\p9.2.jpg");
                else this.BackgroundImage=Image.FromFile(Application.StartupPath + @"\imagini\p"+lectie+".jpg");
                
                //ToolTip pentru fiecare lectie
                if (lectie == 7) toolTip1.SetToolTip(pictureBox1, "Citeste papirusurile");
                else if (lectie == 8) toolTip1.SetToolTip(pictureBox1, "Vezi imagini cu mumiile animale");
                else if (lectie == 9) toolTip1.SetToolTip(pictureBox1, "Mareste");
                else if (lectie == 10)
                {
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    toolTip1.SetToolTip(pictureBox1, "Incepe testul!");
                    lectie--;
                }

                

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
            //Exceptie lectia "Mumificarea"
            if (lectie - 1 == 8 && pag<7)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\imagini\p8." + pag + ".jpg");
                pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\imagini\p8." + pag + ".jpg");
                pag++;
            }
            else
            {
                if (lectie == 10) axWindowsMediaPlayer1.URL = Application.StartupPath + @"\video\v9..mp4";
                else axWindowsMediaPlayer1.URL = Application.StartupPath + @"\video\v" + lectie + ".mp4";

                axWindowsMediaPlayer1.Ctlcontrols.play();
                axWindowsMediaPlayer1.Ctlenabled = false;
                timer1.Start();
            }
        }


        #endregion 

        #region Detalii imagine

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            //Citeste papirusuri
            if (lectie - 1 == 7)
            {
                Form7 form = new Form7();
                form.Show();
            }

            //Rebus
            else
            {
                if (lectie == 10 && toolTip1.GetToolTip(pictureBox1) == "Incepe testul!")
                {
                    sound.Stop();
                    Form8 form = new Form8(index);
                    form.Show();
                    this.Hide();
                }

                    //Mareste
                else Mareste(lectie - 1);
            }

        }

        private void Mareste (int lectie)
        {
            pictureBox5.Image = Image.FromFile(Application.StartupPath + @"\imagini\p" + lectie +".1.jpg");
            pictureBox5.Visible = true;
            toolTip1.SetToolTip(pictureBox5, "Inchide");
        
        }

        

        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lectie-1 == 4)
                pictureBox5.Image = Image.FromFile(Application.StartupPath + @"\imagini\p" + (lectie-1) + ".2.jpg");
            

            if (e.Button == MouseButtons.Left) pictureBox5.Visible = false;
        }

        #endregion

        

    }
}
