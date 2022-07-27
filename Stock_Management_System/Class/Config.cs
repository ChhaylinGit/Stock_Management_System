using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_Management_System.Entity;

namespace Stock_Management_System.Class
{
    class Config
    {
        public static string SERVER = "aglbenefit.nssf.gov.kh";
        public static string DATABASE = "nssf_benefit";
        public static string USERNAME = "benefit";
        public static string PASSWORD = "P@$$w0rdBen9";

        public static string f_Connection()
        {
            string constr = "";
            try
            {
                constr = @"metadata=res://*/NSSFModel.csdl|res://*/NSSFModel.ssdl|res://*/NSSFModel.msl;provider=System.Data.SqlClient;provider connection string=';data source=" + server + ";initial catalog=" + database + ";persist security info=True;user id=" + username + ";password=" + password + ";MultipleActiveResultSets=True;App=EntityFramework;Connection Timeout=500'";
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "NSSF Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return constr;
        }
    }
}
