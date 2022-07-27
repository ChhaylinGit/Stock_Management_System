using Stock_Management_System.Class;
using Stock_Management_System.Configure;
using Stock_Management_System.UIDesign;
using System;
using System.Windows.Forms;

namespace Stock_Management_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string DB_PATH = Properties.Settings.Default.path.Trim();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Setting.ConnectionSuccess(DB_PATH))
            {
                Application.Run(new frmMain());
            }
            else 
            {
                Msg.Error(Setting.CONNECTION_TEXT);
                new frmConnection().ShowDialog(); 
            }
        }
    }
}
