using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Egipt___soft_educational
{
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static System.Media.SoundPlayer sound3 = new System.Media.SoundPlayer(Application.StartupPath + @"\muzica\capitol 3.wav");
        public static System.Media.SoundPlayer sound4 = new System.Media.SoundPlayer(Application.StartupPath + @"\muzica\capitol 4.wav");

        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Meniu form1 = new Meniu(-1);
            Blank form6 = new Blank();
            form6.Show();
            form1.Show();
            Application.Run();
        }
    }
}
