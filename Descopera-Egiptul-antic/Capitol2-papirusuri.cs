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
    public partial class Form7 : Form
    {
        int width = Screen.PrimaryScreen.Bounds.Width / 17;
        int height = Screen.PrimaryScreen.Bounds.Height / 9;
        public Form7()
        {
            InitializeComponent();

            #region Pozitionare obiecte

            //Inchide
            pictureBox3.Location = new Point(Screen.PrimaryScreen.Bounds.Width - width, 0);
            pictureBox3.Width = width;
            pictureBox3.Height = height;


            //Papirus 1
            ProprietatiPapirus(pictureBox1, 0, 0);

            //Papirus 2
            ProprietatiPapirus(pictureBox7, 0, 1);

            //Papirus 3
            ProprietatiPapirus(pictureBox6, 1, 0);

            //Papirus 4
            ProprietatiPapirus(pictureBox8, 1, 1);

            //Papirus 5
            ProprietatiPapirus(pictureBox2, 2, 0);

            //Papirus 6
            ProprietatiPapirus(pictureBox12, 2, 1);

            //Papirus 7
            ProprietatiPapirus(pictureBox9, 3, 0);

            //Papirus 8
            ProprietatiPapirus(pictureBox10, 3, 1);

            #endregion

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            
        }

        #region Papirusuri

        private void ProprietatiPapirus(PictureBox papirus, int coloana, int rand)
        {
            //Marime
            papirus.Width = width;
            papirus.Height = 3*height;

            //Locatie
            papirus.Location = new Point((2 + coloana*3) * width, (1 + 4*rand) * height);
        }

        private void DeschiderePapirus(PictureBox papirus, int lungime)
        {
            papirus.Width = papirus.Width + lungime;
        }

        private void InchiderePapirus(PictureBox papirus, int lungime)
        {
            papirus.Width = papirus.Width - lungime;
        }

        //Papirus 1
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            DeschiderePapirus(pictureBox1, 5 * width);
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            InchiderePapirus(pictureBox1, 5 * width);
        }

        //Papirus 2
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            DeschiderePapirus(pictureBox2, 5 * width);
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            InchiderePapirus(pictureBox2, 5 * width);
        }

        //Papirus 3
        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            DeschiderePapirus(pictureBox6, 5 * width);
            
        }
        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            InchiderePapirus(pictureBox6, 5 * width);
        }

        //Papirus 4
        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            DeschiderePapirus(pictureBox7, 5 * width);
        }
        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            InchiderePapirus(pictureBox7, 5 * width);
        }

        //Papirus 5
        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            DeschiderePapirus(pictureBox8, 5 * width);
        }
        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            InchiderePapirus(pictureBox8, 5 * width);
        }

        //Papirus 6
        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            DeschiderePapirus(pictureBox9, 3 * width);
        }
        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            InchiderePapirus(pictureBox9, 3 * width);
        }

        //Papirus 7
        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            DeschiderePapirus(pictureBox10, 3 * width);
        }
        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            InchiderePapirus(pictureBox10, 3 * width);
        }

        //Papirus 8
        private void pictureBox12_MouseEnter(object sender, EventArgs e)
        {
            DeschiderePapirus(pictureBox12, 4 * width);
        }
        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            InchiderePapirus(pictureBox12, 4 * width);
        }

        #endregion

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

       
    }
}

