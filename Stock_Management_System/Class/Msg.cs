using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Management_System.Class
{
    class Msg
    {
        public static string OPERATION_SUCCESS = "Operation Successful !!";
        public static string ASK_FOR_EXIT = "Do you want to exit?";

        public static bool Question(string messageText)
        {
            return (MessageBox.Show(messageText, "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) ? true : false;
        }
        public static void Error(string messageText)
        {
            MessageBox.Show(messageText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void Information(string messageText)
        {
            MessageBox.Show(messageText, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Warning(string messageText)
        {
            MessageBox.Show(messageText, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
