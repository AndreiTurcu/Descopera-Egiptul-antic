using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Egipt___soft_educational
{
    public partial class Diploma : Form
    {
        int index;
        Image img;
        PrintDocument diploma = new PrintDocument();
        public Diploma(Image _img, int _index)
        {
            InitializeComponent();

            img = _img;
            index = _index;
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'egiptDatabase.Utilizatori' table. You can move, or remove it, as needed.
            this.utilizatoriTableAdapter.Fill(this.egiptDatabase.Utilizatori);

            #region Proprietati diploma

            diploma.DefaultPageSettings.PaperSize = diploma.PrinterSettings.PaperSizes[4];
            printPreviewControl1.Document = diploma;
            diploma.PrintPage += (sender1, args) =>
            {
                args.Graphics.DrawImage(img, new Rectangle(10, 10, 1170, 1620));

                string text = egiptDatabase.Utilizatori.Rows[index][1].ToString();
                Font font = new Font("Papyrus", 45, FontStyle.Bold);

                args.Graphics.DrawString(text, font, Brushes.Black, new Point(580, 800));
            };

            #endregion
        }

        private void utilizatoriBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.utilizatoriBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.egiptDatabase);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            diploma.Print();
        }
    }
}
