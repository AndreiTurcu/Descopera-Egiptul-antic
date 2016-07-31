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
    public partial class Capitol4 : Form
    {
      
        int index, video;
        int width = Screen.PrimaryScreen.Bounds.Width / 13;
        int height = Screen.PrimaryScreen.Bounds.Height / 10;

        public Capitol4(int _index, int _video)
        {
            InitializeComponent();

            index = _index;
            video=_video;


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
            if (video == 1)
            {
                Program.sound4.PlayLooping();
                axWindowsMediaPlayer1.URL = Application.StartupPath + @"\video\v14.mp4";
                axWindowsMediaPlayer1.Ctlcontrols.play();
                axWindowsMediaPlayer1.Ctlenabled = false;
                pictureBox1.Visible = true;
            }
            #endregion

            //Pozitionare obiecte
            #region Close-button
            int width1 = Screen.PrimaryScreen.Bounds.Width / 17;
            int height1 = Screen.PrimaryScreen.Bounds.Height / 9;
            pictureBox2.Location = new Point(Screen.PrimaryScreen.Bounds.Width - width1 ,0);
            pictureBox2.Width = width1;
            pictureBox2.Height = height1;

            #endregion

            #region Zei

            //Amon-Ra
            Amon_Ra(pictureBox6);
            Amon_Ra(pictureBox7);

            //Ra
            Ra(pictureBox8);
            Ra(pictureBox9);

            //Isis
            Isis(pictureBox10);
            Isis(pictureBox11);

            //Nut
            Nut(pictureBox12);
            Nut(pictureBox13);

            //Nun
            Nun(pictureBox14);
            Nun(pictureBox15);

            //Thot
            Thot(pictureBox16);
            Thot(pictureBox17);

            //Anubis
            Anubis(pictureBox18);
            Anubis(pictureBox19);

            //Horus
            Horus(pictureBox20);
            Horus(pictureBox21);

            //Sobek
            Sobek(pictureBox22);
            Sobek(pictureBox23);

            //Osiris
            Osiris(pictureBox24);
            Osiris(pictureBox25);

            #endregion

        }

        #region Functii proprietati zei

        private void Amon_Ra (PictureBox picture)
        {
            picture.Location = new Point(width, 2*height);
            picture.Width = 2*width;
            picture.Height = Screen.PrimaryScreen.Bounds.Height / 2 + height;
        }

        private void Ra(PictureBox picture)
        {
            picture.Location = new Point(3 * width, (7 * height)/2 );
            picture.Width = width;
            picture.Height = Screen.PrimaryScreen.Bounds.Height / 2 - height/2;
        }

        private void Isis(PictureBox picture)
        {
            picture.Location = new Point(4 * width, (11 * height)/2);
            picture.Width = 2 *width;
            picture.Height = Screen.PrimaryScreen.Bounds.Height / 4;
        }

        private void Nut(PictureBox picture)
        {
            picture.Location = new Point(4 * width, 3 * height);
            picture.Width = 3 * width;
            picture.Height = Screen.PrimaryScreen.Bounds.Height / 4;
        }

        private void Nun(PictureBox picture)
        {
            picture.Location = new Point(6 * width, (11 * height) / 2);
            picture.Width = width;
            picture.Height = Screen.PrimaryScreen.Bounds.Height / 4;
        }

        private void Thot(PictureBox picture)
        {
            picture.Location = new Point(7 * width, 4 * height );
            picture.Width = width;
            picture.Height = Screen.PrimaryScreen.Bounds.Height / 2 - height;
        }

        private void Anubis(PictureBox picture)
        {
            picture.Location = new Point(8 * width, 4 * height);
            picture.Width = width;
            picture.Height = Screen.PrimaryScreen.Bounds.Height / 2 - height;
        }

        private void Horus(PictureBox picture)
        {
            picture.Location = new Point(9 * width, (7 * height) / 2);
            picture.Width = width;
            picture.Height = Screen.PrimaryScreen.Bounds.Height / 2 - height / 2;
        }

        private void Sobek(PictureBox picture)
        {
            picture.Location = new Point(10 * width, 3 * height);
            picture.Width = width;
            picture.Height = Screen.PrimaryScreen.Bounds.Height / 2;
        }

        private void Osiris(PictureBox picture)
        {
            picture.Location = new Point(11 * width, 3 * height);
            picture.Width = width;
            picture.Height = Screen.PrimaryScreen.Bounds.Height / 2;
        }
        #endregion


        private void Form11_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'egiptDatabase.Zei' table. You can move, or remove it, as needed.
            this.zeiTableAdapter.Fill(this.egiptDatabase.Zei);
            // TODO: This line of code loads data into the 'egiptDatabase.Utilizatori' table. You can move, or remove it, as needed.
            this.utilizatoriTableAdapter.Fill(this.egiptDatabase.Utilizatori);

            if(video==1) timer1.Start();
            else Switch();

            #region Verificare imagini zei

            string[] zeu = egiptDatabase.Utilizatori.Rows[index][4].ToString().Split(' ');
            if (Int32.Parse(zeu[0].ToString()) >0) pictureBox7.Visible=false;
            if (Int32.Parse(zeu[1].ToString()) >0) pictureBox9.Visible=false;
            if (Int32.Parse(zeu[2].ToString()) >0) pictureBox11.Visible=false;
            if (Int32.Parse(zeu[3].ToString()) >0) pictureBox13.Visible=false;
            if (Int32.Parse(zeu[4].ToString()) >0) pictureBox15.Visible=false;
            if (Int32.Parse(zeu[5].ToString()) >0) pictureBox21.Visible=false;
            if (Int32.Parse(zeu[6].ToString()) >0) pictureBox17.Visible=false;
            if (Int32.Parse(zeu[7].ToString()) >0) pictureBox19.Visible=false;
            if (Int32.Parse(zeu[8].ToString()) >0) pictureBox23.Visible=false;
            if (Int32.Parse(zeu[9].ToString()) >0) pictureBox25.Visible=false;

            #endregion
            
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
                this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\imagini\p14.jpg");
                pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + @"\imagini\p14.jpg");
                axWindowsMediaPlayer1.Visible = false;
                pictureBox2.Visible = true;
               

                timer2.Stop();
            }
        }

        #endregion

        //Inchide
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Program.sound4.Stop();
            Meniu form = new Meniu(index);
            form.Show();
            this.Hide(); 
        }


        #region Detalii imagine

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Switch();
        }

        private void Switch () 
        {
            pictureBox2.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            pictureBox10.Visible = true;
            pictureBox11.Visible = true;
            pictureBox12.Visible = true;
            pictureBox13.Visible = true;
            pictureBox14.Visible = true;
            pictureBox15.Visible = true;
            pictureBox16.Visible = true;
            pictureBox17.Visible = true;
            pictureBox18.Visible = true;
            pictureBox19.Visible = true;
            pictureBox20.Visible = true;
            pictureBox21.Visible = true;
            pictureBox22.Visible = true;
            pictureBox23.Visible = true;
            pictureBox24.Visible = true;
            pictureBox25.Visible = true;
            this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\imagini\p14.1.jpg");
            }

        #endregion


        #region Selectare zei

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form12 form = new Form12(index, 0);
            form.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form12 form = new Form12(index, 1);
            form.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Form12 form = new Form12(index, 2);
            form.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Form12 form = new Form12(index, 3);
            form.Show();
            this.Hide();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Form12 form = new Form12(index, 4);
            form.Show();
            this.Hide();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            Form12 form = new Form12(index, 5);
            form.Show();
            this.Hide();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Form12 form = new Form12(index, 6);
            form.Show();
            this.Hide();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Form12 form = new Form12(index, 7);
            form.Show();
            this.Hide();
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            Form12 form = new Form12(index, 8);
            form.Show();
            this.Hide();
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            Form12 form = new Form12(index, 9);
            form.Show();
            this.Hide();
        }

        #endregion

        #region Salvare baza-de-date

        private void utilizatoriBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.utilizatoriBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.egiptDatabase);

        }

        private void zeiBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.zeiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.egiptDatabase);

        }

        #endregion


    }
}
