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
    public partial class Capitol3 : Form
    {
        int lectie = 10, pedeapsa=0, pag=1;
        int index;
        

        public Capitol3(int _index)
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
            Program.sound3.PlayLooping();
            axWindowsMediaPlayer1.URL = Application.StartupPath + @"\video\v10.mp4";
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

            pictureBox3.Location = new Point(Screen.PrimaryScreen.Bounds.Width - width1 - 100, Screen.PrimaryScreen.Bounds.Height - 2*height1 - 100);
            pictureBox3.Width = width1;
            pictureBox3.Height = height1;

            pictureBox4.Location = new Point(Screen.PrimaryScreen.Bounds.Width - width1 - 100, Screen.PrimaryScreen.Bounds.Height - 2*height1 - 100);
            pictureBox4.Width = width1;
            pictureBox4.Height = height1;

            #endregion
            #region Back-button

            pictureBox6.Location = new Point(width1, Screen.PrimaryScreen.Bounds.Height - height1 - 100);
            pictureBox6.Width = width1/2;
            pictureBox6.Height = height1;

            pictureBox7.Location = new Point(width1, Screen.PrimaryScreen.Bounds.Height - height1 - 100);
            pictureBox7.Width = width1/2;
            pictureBox7.Height = height1;

            #endregion
            #region Active-area

            pictureBox5.Location = new Point(Screen.PrimaryScreen.Bounds.Width/2 , 0);
            pictureBox5.Width = Screen.PrimaryScreen.Bounds.Width / 2;
            pictureBox5.Height = Screen.PrimaryScreen.Bounds.Height / 2;

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


                    #region Switch

                    axWindowsMediaPlayer1.Visible = false;
                    pictureBox2.Visible = true;
                   
                    if (pedeapsa == 0)
                    {
                        if (lectie == 13)
                        {
                            toolTip1.SetToolTip(pictureBox1, "Descifreaza blestemul mumiei!");
                            pictureBox1.Cursor = Cursors.Hand;
                        }
                        else
                        {
                            pictureBox3.Visible = true;
                            pictureBox4.Visible = true;
                            pictureBox6.Visible = false;
                            pictureBox7.Visible = false;
                            pictureBox1.Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        
                        pictureBox6.Visible = true;
                        pictureBox3.Visible = false;
                        pictureBox4.Visible = false;
                        pedeapsa = 0;
                        pictureBox1.Cursor = Cursors.Hand;
                    }

                //Exceptie mormant
                    if (lectie == 10)
                    {
                        pictureBox5.Visible = true;
                        pictureBox5.BringToFront();
                    }
                    else pictureBox5.Visible = false;

                    #endregion

                    lectie++;
                
                timer2.Stop();
            }
        }

        #endregion


        #region Butoane

        //Inchide
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Program.sound3.Stop();
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
            //Exceptie lectia "Jefuitorii"
            if (lectie - 1 == 12)
            {
                if (pag < 2)
                {
                    this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\imagini\p12.1.jpg");
                    pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\imagini\p12.1.jpg");
                    pag++;
                }
                else
                {
                    PornesteVideo(lectie);
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                }
            }
            else
            {
                //Exceptie fara jefuirea mormantului
                if (lectie == 11) lectie++;

                pictureBox5.Visible = false;
                PornesteVideo(lectie);
            }
        }

        private void PornesteVideo(int lectie)
        {
            axWindowsMediaPlayer1.URL = Application.StartupPath + @"\video\v" + lectie + ".mp4";

            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.Ctlenabled = false;
            timer1.Start();
        }

        //Inapoi
        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.Visible = true;
        }
        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Visible = false;
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Application.StartupPath + @"\video\v12.mp4";
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.Ctlenabled = false;
            timer1.Start();
            
        }

        #endregion 

        #region Detalii imagine

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            //Jefuire
            if (lectie - 1 == 11)
            {
                
                axWindowsMediaPlayer1.URL = Application.StartupPath + @"\video\v11-pedeapsa.mp4";
                axWindowsMediaPlayer1.Ctlcontrols.play();
                axWindowsMediaPlayer1.Ctlenabled = false;
                toolTip1.SetToolTip(pictureBox1, null);

                timer1.Start();
            }

            //Test-descifrare
            if (lectie - 1 == 13)
            {
                Form10 form = new Form10(index);
                form.Show();
                this.Hide();
            }

        }

        
        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {
            axWindowsMediaPlayer1.URL = Application.StartupPath + @"\video\v11.mp4";
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.Ctlenabled = false;
            timer1.Start();
            pictureBox5.Visible = false;
            #region Switch
            pedeapsa = 1;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            #endregion

            toolTip1.SetToolTip(pictureBox1, "Jefuieste mormantul!");
        }

        #endregion


        

        

    }
}
