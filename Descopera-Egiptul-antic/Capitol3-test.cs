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
    public partial class Form10 : Form
    {
        int index;
        int nr=0;

        int width = Screen.PrimaryScreen.Bounds.Width / 17;
        int height = Screen.PrimaryScreen.Bounds.Height / 9;


        //System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Application.StartupPath + @"\muzica\teste.mp3");
        public Form10(int _index)
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

            #region Pozitionare obiecte

            
            // Inchide
            pictureBox2.Location = new Point(Screen.PrimaryScreen.Bounds.Width - width, 0);
            pictureBox2.Width = width;
            pictureBox2.Height = height;

            //Suprafata scris
            textBox1.Location = new Point(Screen.PrimaryScreen.Bounds.Width/4, 2*(Screen.PrimaryScreen.Bounds.Height/3));
            textBox1.Width = Screen.PrimaryScreen.Bounds.Width/2;
            textBox1.Height = height;

            // Felicitari
            pictureBox1.Width = Screen.PrimaryScreen.Bounds.Width / 2;
            pictureBox1.Height = 2 * height;
            pictureBox1.Left = Screen.PrimaryScreen.Bounds.Width/4;
            pictureBox1.Top = 2*(Screen.PrimaryScreen.Bounds.Height/3);

            
            #endregion


           // sound.Play();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'egiptDatabase.Utilizatori' table. You can move, or remove it, as needed.
            this.utilizatoriTableAdapter.Fill(this.egiptDatabase.Utilizatori);

            //Exceptie statut deja obtinut
            if (egiptDatabase.Utilizatori.Rows[index][3].ToString() != "ARHEOLOG")
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


        //Close
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Program.sound3.Stop();
            Meniu form = new Meniu(index);
            form.Show();
            this.Hide();
        }

        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Program.sound3.Stop();
            Capitol4 form = new Capitol4(index ,1);
            form.Show();
            this.Hide();
        }

        //Shortcut
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                textBox1.Text = "Moartea vine pe aripi repezi celui care tulbura mormantul faraonului";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == "Moartea vine pe aripi repezi celui care tulbura mormantul faraonului")
            {
            //Feedback
            pictureBox1.Show();
            pictureBox1.BringToFront();

                egiptDatabase.Utilizatori.Rows[index][3] = "SCRIB";
                utilizatoriBindingNavigatorSaveItem_Click(sender, e);
                egiptDatabase.Utilizatori.AcceptChanges();
            }
            
        }


        }

    }
       
    

