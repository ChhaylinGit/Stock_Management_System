using Stock_Management_System.UIDesign;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Management_System.Class
{
    class Setting
    {
        public static string CONNECTION_TEXT;

        public static bool ConnectionSuccess(string path)
        {
            bool result = false;
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Persist Security Info=False;");
            try
            {
                con.Open();
                result = true;
                CONNECTION_TEXT = "Connection Successful !!";
            }
            catch (Exception ex)
            {
                CONNECTION_TEXT ="ការភ្ជាប់ទៅកាន់ម៉ាស៊ីនមេបរាជ័យ!\n"+ ex.Message;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        
    }
}
