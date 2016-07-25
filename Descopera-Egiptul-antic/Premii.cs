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
    public partial class Premii : Form
    {

        int index;
        public Premii(int _index)
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

            

            //Inchide
            int width = Screen.PrimaryScreen.Bounds.Width / 32;
            int height = Screen.PrimaryScreen.Bounds.Height / 18;
            pictureBox5.Location = new Point(Screen.PrimaryScreen.Bounds.Width - width, 0);
            pictureBox5.Width = width;
            pictureBox5.Height = height;


            #endregion


        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {

            //egiptDatabase.Premii.Rows.Add(File.ReadAllBytes(Application.StartupPath + @"\imagini\1.png"));
            //egiptDatabase.Premii.Rows.Add(File.ReadAllBytes(Application.StartupPath + @"\imagini\2.png"));
            //egiptDatabase.Premii.Rows.Add(File.ReadAllBytes(Application.StartupPath + @"\imagini\3.png"));
            //egiptDatabase.Premii.Rows.Add(File.ReadAllBytes(Application.StartupPath + @"\imagini\4.png"));
            //egiptDatabase.Premii.Rows.Add(File.ReadAllBytes(Application.StartupPath + @"\imagini\diploma.png"));

            //premiiBindingNavigatorSaveItem_Click(sender, e);
            //egiptDatabase.Premii.AcceptChanges();

            this.Hide();
        }

        #region Salvare baze-de-date

        private void premiiBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.premiiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.egiptDatabase);

        }
        private void utilizatoriBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.utilizatoriBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.egiptDatabase);

        }

        #endregion

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'egiptDatabase.Utilizatori' table. You can move, or remove it, as needed.
            this.utilizatoriTableAdapter.Fill(this.egiptDatabase.Utilizatori);
            // TODO: This line of code loads data into the 'egiptDatabase.Premii' table. You can move, or remove it, as needed.
            this.premiiTableAdapter.Fill(this.egiptDatabase.Premii);

            if (egiptDatabase.Utilizatori.Rows[index][3].ToString() == "EXPLORATOR")
                PremiuExplorator();
            else if (egiptDatabase.Utilizatori.Rows[index][3].ToString() == "ARHEOLOG")
                PremiuArheolog();
            else if (egiptDatabase.Utilizatori.Rows[index][3].ToString() == "SCRIB")
                PremiuScrib();
            else if (egiptDatabase.Utilizatori.Rows[index][3].ToString() == "EGIPTOLOG")
                PremiuEgiptolog();
        }

        #region Generare premii

        private void PremiuExplorator()
        {
            byte[] img = (byte[])egiptDatabase.Premii.Rows[0][0];
            MemoryStream ms = new MemoryStream(img);
            pictureBox2.Image = Image.FromStream(ms);

        }

        private void PremiuArheolog()
        {
            byte[] img = (byte[])egiptDatabase.Premii.Rows[1][0];
            MemoryStream ms = new MemoryStream(img);
            pictureBox3.Image = Image.FromStream(ms);
            PremiuExplorator();
        }

        private void PremiuScrib()
        {
            byte[] img = (byte[])egiptDatabase.Premii.Rows[2][0];
            MemoryStream ms = new MemoryStream(img);
            pictureBox4.Image = Image.FromStream(ms);
            PremiuExplorator();
            PremiuArheolog();
        }

        private void PremiuEgiptolog()
        {
            byte[] img = (byte[])egiptDatabase.Premii.Rows[3][0];
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.Cursor = Cursors.Hand;
            toolTip1.SetToolTip(pictureBox1, "Descarca-ti diploma!");

            PremiuExplorator();
            PremiuArheolog();
            PremiuScrib();
        }

        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Cursor == Cursors.Hand)
            {
                byte[] img = (byte[])egiptDatabase.Premii.Rows[4][0];
                MemoryStream ms = new MemoryStream(img);
                Image.FromStream(ms);
                Diploma form = new Diploma(Image.FromStream(ms), index);
                form.Show();
                form.BringToFront();
                this.Hide();
            }
        }

    }
}
