using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Egipt___soft_educational
{
    public partial class Form3 : Form
    {
        int index;
        double puncte = 0;
        int[] intrebare = new int[6];
        int sec = 59, m = 30, nr=0;
        
        System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Application.StartupPath + @"\muzica\teste.wav");
        public Form3(int _index)
        {
            InitializeComponent();

            index = _index;
            sound.Play();

            #region Flickering off

            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, false);
            this.SetStyle(ControlStyles.Opaque, false);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            #endregion

            #region Pozitionare obiecte

            int width = Screen.PrimaryScreen.Bounds.Width / 17;
            int height = Screen.PrimaryScreen.Bounds.Height / 9;

            //Cerinte
            panel1.Left = (Screen.PrimaryScreen.Bounds.Width - panel1.Width) / 2;
            panel1.Top = (Screen.PrimaryScreen.Bounds.Height - panel1.Height) / 2;

            // Inchide
            pictureBox2.Location = new Point(Screen.PrimaryScreen.Bounds.Width - width, 0);
            pictureBox2.Width = width;
            pictureBox2.Height = height;

            //Timp ramas
            label7.Top = height;
            label7.Left = width;

            // Punctaj
            label9.Top = height;
            label9.Left = width;

            // Felicitari
            pictureBox1.Left = (Screen.PrimaryScreen.Bounds.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (Screen.PrimaryScreen.Bounds.Height - pictureBox1.Height) / 2;

            //Din pacate
            pictureBox3.Left = (Screen.PrimaryScreen.Bounds.Width - pictureBox3.Width) / 2;
            pictureBox3.Top = (Screen.PrimaryScreen.Bounds.Height - pictureBox3.Height) / 2;

            #endregion

            timer2.Start();

           // sound.Play();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'egiptDatabase.Utilizatori' table. You can move, or remove it, as needed.
            this.utilizatoriTableAdapter.Fill(this.egiptDatabase.Utilizatori);

            //Exceptie statut deja obtinut
            if (egiptDatabase.Utilizatori.Rows[index][3].ToString() != "TURIST")
            {
                Premii form = new Premii(index);
                Meniu form1 = new Meniu(index);
                form1.Show();
                form.Show();
                this.Hide();
            }
        }

        #region Salvare baze-de-date

        private void utilizatoriBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.utilizatoriBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.egiptDatabase);

        }

        #endregion

        #region Intrebari

        #region Intrebare 1

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked == true) 
            {
                intrebare[1] = 0;
                checkBox2.Checked = false; 
                checkBox3.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox2.Checked == true) 
            {
                intrebare[1] = 1;
                checkBox1.Checked = false; 
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox3.Checked == true)
            {
                intrebare[1] = 0;
                checkBox2.Checked = false;
                checkBox1.Checked = false;
            }
        }

        #endregion

        #region Intrebare 2

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox4.Checked == true)
            {
                intrebare[2] = 0;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox5.Checked == true)
            {
                intrebare[2] = 0;
                checkBox4.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox6.Checked == true)
            {
                intrebare[2] = 1;
                checkBox5.Checked = false;
                checkBox4.Checked = false;
            }
        }

        #endregion

        #region Intrebare 3

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox7.Checked == true)
            {
                intrebare[3] = 1;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox8.Checked == true)
            {
                intrebare[3] = 0;
                checkBox7.Checked = false;
                checkBox9.Checked = false;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox9.Checked == true)
            {
                intrebare[3] = 0;
                checkBox8.Checked = false;
                checkBox7.Checked = false;
            }
        }

        #endregion

        #region Intrebare 4

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox10.Checked == true)
            {
                intrebare[4] = 0;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox11.Checked == true)
            {
                intrebare[4] = 1;
                checkBox10.Checked = false;
                checkBox12.Checked = false;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox12.Checked == true)
            {
                intrebare[4] = 0;
                checkBox11.Checked = false;
                checkBox10.Checked = false;
            }
        }

        #endregion

        #region Intrebare 5

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox13.Checked == true)
            {
                intrebare[5] = 0;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox14.Checked == true)
            {
                intrebare[5] = 1;
                checkBox13.Checked = false;
                checkBox15.Checked = false;
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox15.Checked == true)
            {
                intrebare[5] = 0;
                checkBox14.Checked = false;
                checkBox13.Checked = false;
            }
        }

        #endregion

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Calculare timp ramas
            m--;
            if (m == 0) { m = 30; sec--; }
            label7.Text = "Timp ramas: " + sec.ToString() + ":" + m.ToString();
            
            
            //Calculare punctaj
            puncte = 0;
            for (int i = 1; i <= 5; i++) if (intrebare[i] == 1) puncte++;
            puncte = puncte * 1.5 + 2.5;


           //Daca timpul se scurge
            if (sec == 0) 
            {
                TestTerminat(sender,e);
                label9.Text = "Timpul s-a scurs!\nPunctajul tau: " + puncte.ToString()+" puncte";
                
            }

            //Daca testul este rezolvat corect mai repede
            if (puncte == 10)
            {
                TestTerminat(sender,e);
                label9.Text = "Ai obtinut punctajul maxim!";
            }
            

        }

        private void TestTerminat(object sender, EventArgs e)
        {
            timer1.Stop();
            label7.Hide();
            panel1.Hide();
            label9.Show();

            //Feedback
            if (puncte >= 8)
            {
                pictureBox1.Show();

                egiptDatabase.Utilizatori.Rows[index][3] = "EXPLORATOR";
                utilizatoriBindingNavigatorSaveItem_Click(sender, e);
                egiptDatabase.Utilizatori.AcceptChanges();
            }
            else pictureBox3.Show();
        }
       

        //Close
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sound.Stop();
            Meniu form = new Meniu(index);
            form.Show();
            this.Hide();
        }

        //Deschidere
        private void timer2_Tick(object sender, EventArgs e)
        {
            nr++;
            if (nr == 5)
            {
                timer2.Stop();
                pictureBox6.Visible = false;
                timer1.Start();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sound.Stop();
            Capitol2 form = new Capitol2(index);
            form.Show();
            this.Hide();
        }



       


    }
       
    }

