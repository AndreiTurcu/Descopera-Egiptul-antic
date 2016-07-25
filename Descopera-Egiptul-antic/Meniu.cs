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
    public partial class Meniu : Form
    {
        
        int nivel = 0;

        
        int index=-1;
        System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Application.StartupPath + @"\muzica\Intro.wav");
        
        public Meniu(int _index)
        {
            InitializeComponent();

            if (_index != -1) index = _index;

            #region Flickering off

            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, false);
            this.SetStyle(ControlStyles.Opaque, false);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            #endregion

            sound.PlayLooping();

            #region Pozitionare obiecte

            int width = Screen.PrimaryScreen.Bounds.Width / 32;
            int height = Screen.PrimaryScreen.Bounds.Height / 18;

           
            pictureBox2.Location = new Point(Screen.PrimaryScreen.Bounds.Width - width, 0);
            pictureBox2.Width = width;
            pictureBox2.Height = height;

            #endregion
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sound.Stop();
            this.Close();
        }

        #region Schimbare Mouse_Enter


        //Descopera Egiptul antic
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Goldenrod;
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Peru;
        }


        //Obiceiuri si traditii
        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Goldenrod;
        }
        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Peru;
        }


        //Blestemul mumiei
        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Goldenrod;
        }
        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Peru;
        }


        //Cultura egipteana
        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Goldenrod;
        }
        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Peru;
        }


        //Salveaza utilizator
        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Black;
        }
        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Peru;
        }

        
        //Creeaza utilizator
        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.ForeColor = Color.Peru;
        }
        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.ForeColor = Color.Goldenrod;
        }


        //Conecteaza-te
        private void label10_MouseEnter(object sender, EventArgs e)
        {
            label10.ForeColor = Color.Peru;
        }
        private void label10_MouseLeave(object sender, EventArgs e)
        {
            label10.ForeColor = Color.Goldenrod;
        }

        
        //Acces utilizator
        private void label13_MouseEnter(object sender, EventArgs e)
        {
            label13.ForeColor = Color.Black;
        }
        private void label13_MouseLeave(object sender, EventArgs e)
        {
            label13.ForeColor = Color.Peru;
        }


        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'egiptDatabase.Utilizatori' table. You can move, or remove it, as needed.
            this.utilizatoriTableAdapter.Fill(this.egiptDatabase.Utilizatori);

            if (index != -1) Conectare(index);

        }

        #region Butoane

        //Descopera Egiptul antic
        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                sound.Stop();
                Capitol1 form = new Capitol1(index);
                form.Show();
                this.Hide();
            }

            //Shortcut Test-fulger
            if (e.Button == MouseButtons.Right)
            {
                sound.Stop();
                Form3 form = new Form3(index);
                form.Show();
                this.Hide();
            }

        }

        //Obiceiuri si traditii
        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (nivel >= 1)
                {
                    label17.Hide();
                    sound.Stop();
                    Capitol2 form = new Capitol2(index);
                    form.Show();
                    this.Hide();
                }
                else label17.Show();

            //Shortcut Test-rebus
            if (e.Button == MouseButtons.Right)
            {
                sound.Stop();
                Form8 form = new Form8(index);
                form.Show();
                this.Hide();
            }
        }
        

        //Blestemul mumiei
        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (nivel >= 2)
                {
                    label18.Hide();
                    sound.Stop();
                    Capitol3 form = new Capitol3(index);
                    form.Show();
                    this.Hide();
                }
                else label18.Show();

            //Shortcut Test-descifrare
            if (e.Button == MouseButtons.Right)
            {
                sound.Stop();
                Form10 form = new Form10(index);
                form.Show();
                this.Hide();
            }
        }
        
        //Cultura egipteana 
        
        private void label3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (nivel >= 3)
                {
                    label19.Hide();
                    sound.Stop();
                    Capitol4 form = new Capitol4(index, 1);
                    form.Show();
                    this.Hide();

                }
                else label19.Show();

            //Shortcut Test-zei
            if (e.Button == MouseButtons.Right)
            {

                sound.Stop();
                Capitol4 form = new Capitol4(index, 0);
                form.Show();
                this.Hide();
            }

        }
        


        #endregion

        
        private void utilizatoriBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.utilizatoriBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.egiptDatabase);

        }

       

        #region Creeaza utilizator
        
        private void label9_Click(object sender, EventArgs e)
        {
            label6.Show();
            label7.Show();
            label8.Show();
            textBox1.Show();
            textBox2.Show();
            label15.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SalveazaEnabled();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SalveazaEnabled();
        }
        
        private void SalveazaEnabled()
        { 
            if (textBox1.Text != "" && textBox2.Text != "") label8.Enabled = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            int ok = 0;
            for (int i = 0; i < egiptDatabase.Utilizatori.Rows.Count; i++)
                if (egiptDatabase.Utilizatori.Rows[i][1].ToString() == textBox1.Text) ok = 1;

            if (ok == 0)
            {
                egiptDatabase.Utilizatori.Rows.Add(null, textBox1.Text, textBox2.Text, "TURIST", "0 0 0 0 0 0 0 0 0 0");
                utilizatoriBindingNavigatorSaveItem_Click(sender, e);
                egiptDatabase.Utilizatori.AcceptChanges();
                tableAdapterManager.UtilizatoriTableAdapter.Update(egiptDatabase.Utilizatori);
                label16.Hide();
                label20.Show();
            }
            else
            {
                label16.Show();
                textBox1.Text = "";
                textBox2.Text = "";
            }

        }

        #endregion

        #region Conecteaza-te

        private void label10_Click(object sender, EventArgs e)
        {
            label11.Show();
            label12.Show();
            label13.Show();
            textBox3.Show();
            textBox4.Show();

            label6.Hide();
            label7.Hide();
            label8.Hide();
            label16.Hide();
            label20.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void label13_Click(object sender, EventArgs e)
        {
            int ok = 0;

            for (int i = 0; i < egiptDatabase.Utilizatori.Rows.Count; i++)
                if (egiptDatabase.Utilizatori.Rows[i][1].ToString() == textBox3.Text && 
                    egiptDatabase.Utilizatori.Rows[i][2].ToString() == textBox4.Text)
                {
                    ok = 1;
                    index = i;

                    Conectare(index);
                }

            if (ok == 0)
            {
                label15.Show();
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }

        private void Conectare(int index)
        {

            label14.Text = "Utilizator: " + egiptDatabase.Utilizatori.Rows[index][1].ToString() +
                                      "-" + egiptDatabase.Utilizatori.Rows[index][3].ToString();

            if (egiptDatabase.Utilizatori.Rows[index][3].ToString() == "EXPLORATOR") nivel = 1;
            else if (egiptDatabase.Utilizatori.Rows[index][3].ToString() == "ARHEOLOG") nivel = 2;
            else if (egiptDatabase.Utilizatori.Rows[index][3].ToString() == "SCRIB") nivel = 3;
            else if (egiptDatabase.Utilizatori.Rows[index][3].ToString() == "EGIPTOLOG")
            {
                nivel = 3;
                label5.Show();
            }


            label14.Show();
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            label21.Show();

            label11.Hide();
            label12.Hide();
            label13.Hide();
            label15.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox3.Text = "";
            textBox4.Text = "";
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if(egiptDatabase.Utilizatori.Rows[id-1][3].ToString()=="EXPLORATOR")
        }

        private void label21_Click(object sender, EventArgs e)
        {
            Premii form = new Premii(index);
            form.Show();
        }

       

        

        

        
    }
}
