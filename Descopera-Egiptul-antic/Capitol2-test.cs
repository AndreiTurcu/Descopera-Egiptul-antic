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
    public partial class Form8 : Form
    {
        int index;
        int puncte;
        int sec = 59, m = 30, min=2, nr=0;

        int width = Screen.PrimaryScreen.Bounds.Width / 17;
        int height = Screen.PrimaryScreen.Bounds.Height / 9;

        TextBox[][] careu = new TextBox[10][];
        Label cerinta = new Label();
        Label[] intrebare = new Label[10];
        System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Application.StartupPath + @"\muzica\teste.wav");

        public Form8(int _index)
        {
            InitializeComponent();

            index = _index;
            sound.PlayLooping();

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
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'egiptDatabase.Rebus' table. You can move, or remove it, as needed.
            this.rebusTableAdapter.Fill(this.egiptDatabase.Rebus);
            // TODO: This line of code loads data into the 'egiptDatabase.Utilizatori' table. You can move, or remove it, as needed.
            this.utilizatoriTableAdapter.Fill(this.egiptDatabase.Utilizatori);

            //Exceptie statut deja obtinut
            if (egiptDatabase.Utilizatori.Rows[index][3].ToString() != "EXPLORATOR")
            {
                Premii form = new Premii(index);
                Meniu form1 = new Meniu(index);
                form1.Show();
                form.Show();
                this.Hide();
            }

            #region Genearare rebus


            //Cerinta
            cerinta.Text = "Rezolva careul alaturat in timpul acordat si vei\ndescoperi pe verticala urmatorul tau statut:";
            cerinta.Font = new Font("Papyrus", 20 ,FontStyle.Bold);
            cerinta.ForeColor = Color.DarkSeaGreen;
            cerinta.Location = new Point(width, Screen.PrimaryScreen.Bounds.Height / 5);
            cerinta.BackColor = Color.Transparent;
            cerinta.Width = Screen.PrimaryScreen.Bounds.Width / 2;
            cerinta.Height = 100;

            Controls.Add(cerinta);


            //Intrebari
            for (int i = 0; i < egiptDatabase.Rebus.Rows.Count; i++)
            {
                intrebare[i] = new Label();

                intrebare[i].Text = egiptDatabase.Rebus.Rows[i][0].ToString();
                intrebare[i].Font = new Font("Papyrus", 15, FontStyle.Bold);
                intrebare[i].ForeColor = Color.OldLace;
                intrebare[i].Location = new Point(width, Screen.PrimaryScreen.Bounds.Height / 3 + i * 40);
                intrebare[i].BackColor = Color.Transparent;
                intrebare[i].Width = Screen.PrimaryScreen.Bounds.Width / 3;

                Controls.Add(intrebare[i]);
            }


            //Careu
            for (int i = 0; i < egiptDatabase.Rebus.Rows.Count; i++)
            { 
                careu[i] = new TextBox[10];
                string[] cod = egiptDatabase.Rebus.Rows[i][2].ToString().Split(' ');

                for (int j = 0; j < 10; j++)
                {
                    if (cod[j] == "1")
                    {
                        careu[i][j] = new TextBox();

                        careu[i][j].Font = new Font("Papyrus", 20, FontStyle.Bold);
                        careu[i][j].ForeColor = Color.Black;
                        careu[i][j].Location = new Point( Screen.PrimaryScreen.Bounds.Width / 2 + j * 50, Screen.PrimaryScreen.Bounds.Height / 3 + i * 50);
                        careu[i][j].MaxLength = 1;
                        careu[i][j].Width = 50;
                        careu[i][j].KeyDown += new KeyEventHandler(Shortcut);
                        careu[i][j].Text = "";
                        Controls.Add(careu[i][j]);
                    }
                }


            }
            #endregion
        }


        private void Shortcut(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                for (int i = 0; i < egiptDatabase.Rebus.Rows.Count; i++)
                {
                    
                    string[] cod = egiptDatabase.Rebus.Rows[i][2].ToString().Split(' ');
                    string[] litera = egiptDatabase.Rebus.Rows[i][1].ToString().Split(' ');
                    int index_litera = 0;

                    for (int j = 0; j < 10; j++)
                        if (cod[j] == "1")
                        {
                            careu[i][j].Text = litera[index_litera];
                            index_litera++;
                        }
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

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Calculare timp ramas
            m--;
            if (m == 0) { m = 30; sec--; }
            if (sec == 0)
            {
                sec = 59; min--;
            }
            label7.Text = "Timp ramas: " + min.ToString() + ":" + sec.ToString() + ":" + m.ToString();
            
            
            //Calculare punctaj
            puncte = 2;
            for (int i = 0; i < egiptDatabase.Rebus.Rows.Count; i++)
            {
                string[] cod = egiptDatabase.Rebus.Rows[i][2].ToString().Split(' ');
                string[] litera = egiptDatabase.Rebus.Rows[i][1].ToString().Split(' ');
                int index_litera = 0, ok = 1;

                for (int j = 0; j < 10; j++)
                    if (cod[j] == "1")
                    {
                        if (litera[index_litera] != careu[i][j].Text) ok = 0;
                        index_litera++;
                    }
                if (ok == 1) puncte++;
            }
                    

           //Daca timpul se scurge
            if (sec == 0 && min==0) 
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
            #region Switch

            timer1.Stop();
            label7.Hide();
            label9.Show();
            cerinta.Hide();

            for (int i = 0; i < egiptDatabase.Rebus.Rows.Count; i++)
            {
                intrebare[i].Hide();
                for (int j = 0; j < 10; j++)
                    try { careu[i][j].Hide(); }
                    catch { }
            }
            #endregion

            //Feedback
            if (puncte >= 8)
            {
                pictureBox1.Show();

                egiptDatabase.Utilizatori.Rows[index][3] = "ARHEOLOG";
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

        //Delay deschidere
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
            Capitol3 form = new Capitol3(index);
            form.Show();
            this.Hide();
        }



       

    }
       
    }

