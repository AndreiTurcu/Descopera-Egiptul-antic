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
    public partial class Final : Form
    {

        int index;

        public Final(int _index)
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


            axWindowsMediaPlayer1.URL = Application.StartupPath + @"\video\v15.mp4";
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.Ctlenabled = false;
            pictureBox5.Visible = true;
            timer1.Start();
        }

       
        private void Form13_Load(object sender, EventArgs e)
        {
           
        }

        #region Timers

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Visible = true;
                axWindowsMediaPlayer1.fullScreen = true;
                timer2.Start();
                timer1.Stop();
            }
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                Program.sound4.Stop();
                Meniu form = new Meniu(index);
                form.Show();
                this.Hide();

                timer2.Stop();
            }
        }

        #endregion


        

        
    }
}
