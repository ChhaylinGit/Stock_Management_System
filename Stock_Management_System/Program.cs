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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Config.ConnectionSuccess())
            {
                if (Config.existDatabase())
                {
                    Application.Run(new frmMain());
                }
                else { new frmConnection().ShowDialog(); }
            }
            else 
            {
                new frmConnection().ShowDialog(); 
            }
        }
    }
}
