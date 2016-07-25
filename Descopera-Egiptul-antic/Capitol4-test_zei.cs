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
    public partial class Form12 : Form
    {
        int index, index_zeu;
        int termeni = 0, ajutat=0;
            
        public Form12(int _index, int _index_zeu)
        {
            InitializeComponent();

            index = _index;
            index_zeu = _index_zeu;

            #region Pozitionare obiecte

            int width = Screen.PrimaryScreen.Bounds.Width / 17;
            int height = Screen.PrimaryScreen.Bounds.Height / 9;

            //Inchide;
            pictureBox1.Location = new Point(Screen.PrimaryScreen.Bounds.Width - width, 0);
            pictureBox1.Width = width;
            pictureBox1.Height = height;

            //Amon-Ra
            pictureBox2.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 4* width, height);
            pictureBox2.Width = 2* width;
            pictureBox2.Height = 2* height;

            //Nume zeu
            label1.Location = new Point(width, height);
            label1.Width = Screen.PrimaryScreen.Bounds.Width/2;

            //Informatie zeu
            label2.Location = new Point(width, 2*height);
            label2.MaximumSize = new Size(3 * Screen.PrimaryScreen.Bounds.Width / 4, 0);

            //Intrebare
            label3.Location = new Point(width, Screen.PrimaryScreen.Bounds.Height / 2);
            label3.Width = Screen.PrimaryScreen.Bounds.Width / 2;

            //Raspuns
            textBox1.Location = new Point(2*width, Screen.PrimaryScreen.Bounds.Height / 2 + label3.Height);
            textBox1.Width = Screen.PrimaryScreen.Bounds.Width / 2;
            textBox1.Height = Screen.PrimaryScreen.Bounds.Height / 5;

            //Verifica
            label4.Location = new Point(2 * width, Screen.PrimaryScreen.Bounds.Height / 2 + label3.Height + textBox1.Height);
            


            #endregion


        }

        private void Form12_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'egiptDatabase.Zei' table. You can move, or remove it, as needed.
            this.zeiTableAdapter.Fill(this.egiptDatabase.Zei);
            // TODO: This line of code loads data into the 'egiptDatabase.Utilizatori' table. You can move, or remove it, as needed.
            this.utilizatoriTableAdapter.Fill(this.egiptDatabase.Utilizatori);

            //Exceptie statut deja obtinut
            if (egiptDatabase.Utilizatori.Rows[index][3].ToString() != "SCRIB")
            {
                Premii form = new Premii(index);
                Meniu form1 = new Meniu(index);
                form1.Show();
                form.Show();
                this.Hide();
            }

            label1.Text = egiptDatabase.Zei.Rows[index_zeu][0].ToString();
            label2.Text = egiptDatabase.Zei.Rows[index_zeu][1].ToString();
           
        }

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            Capitol4 form = new Capitol4(index, 0);
            form.Show();
            this.Hide();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            label3.Text = egiptDatabase.Zei.Rows[index_zeu][7].ToString();
            label2.Hide();
            textBox1.Show();
            label4.Show();
            if(index_zeu!=0) pictureBox2.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            for(int i=2;i<7;i++)
                ContineTermen(i);

            //Daca s-a verificat raspunsul corect
            if (label4.Text == "Alege alt zeu")
            {
                Capitol4 form = new Capitol4(index, 0);
                form.Show();
                this.Hide();
            }

            //Daca s-a raspuns corect la toate cerintele zeilor
            if (label4.Text == "Felicitari! \n Ai raspuns corect la toate cerintele zeilor!")
            {
                Final form = new Final(index);
                form.Show();
                this.Hide();
            }

            //Cand se verifica raspunsul
            if (termeni ==5)
            {
                textBox1.Text = "Felicitari! \nAi raspuns corect la cerinta pentru " + egiptDatabase.Zei.Rows[index_zeu][0].ToString() + ".";
                textBox1.ForeColor = Color.ForestGreen;

                #region Salvare vector in coloana Zei a utilizatorului curent

                string[] zeu = egiptDatabase.Utilizatori.Rows[index][4].ToString().Split(' ');
                int terminat = 1;

                for (int i = 0; i < 10; i++)
                    if (i == index_zeu)
                        zeu[i] = "1";

                string zei = "";
                for (int i = 0; i < 10; i++)
                {
                    if (zeu[i] == "0") terminat = 0;
                    zei += zeu[i] + " ";
                }

                egiptDatabase.Utilizatori.Rows[index][4] = zei;
                utilizatoriBindingNavigatorSaveItem_Click(sender, e);
                egiptDatabase.Utilizatori.AcceptChanges();

                #endregion

                if (terminat == 0) label4.Text = "Alege alt zeu";
                else  //Daca s-a raspuns corect la toate cerintele zeilor
                {
                    label4.Text = "Felicitari! \n Ai raspuns corect la toate cerintele zeilor!";
                    egiptDatabase.Utilizatori.Rows[index][3] = "EGIPTOLOG";
                    utilizatoriBindingNavigatorSaveItem_Click(sender, e);
                    egiptDatabase.Utilizatori.AcceptChanges();
                }
            }
            else
            {
                textBox1.Text = "Din pacate nu ai raspuns corect la cerinta pentru " + egiptDatabase.Zei.Rows[index_zeu][0].ToString() + "!";
                textBox1.ForeColor = Color.DarkRed;
                
            }

            textBox1.ReadOnly = true;

        }

        private void ContineTermen(int index_termen)
        {
            if (textBox1.Text.Contains(egiptDatabase.Zei.Rows[index_zeu][index_termen].ToString())) termeni++;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ajutat = 1;
            textBox1.Text = egiptDatabase.Zei.Rows[index_zeu][8].ToString();
            pictureBox2.Enabled = false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                egiptDatabase.Utilizatori.Rows[index][4] = "1 1 1 1 1 1 1 1 1 1";
                egiptDatabase.Utilizatori.Rows[index][3] = "EGIPTOLOG";
                utilizatoriBindingNavigatorSaveItem_Click(sender, e);
                egiptDatabase.Utilizatori.AcceptChanges();
                label4.Text = "Felicitari! \n Ai raspuns corect la toate cerintele zeilor!";
            }
        }

        
    }
}
