using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Stock_Management_System.Entity;

namespace Stock_Management_System.Class
{
    class Config
    {
        public static DBStockEntities entities = new DBStockEntities(getConnection());
        public static string SERVERNAME = Properties.Settings.Default.SERVERNAME;
        public static string DATABASE = Properties.Settings.Default.DATABASE;
        public static string USERNAME = Properties.Settings.Default.USERNAME;
        public static string PASSWORD = Properties.Settings.Default.PASSWORD;

        public static string CONNECTION_FAIL_STR = "Connection Failed!!";
        public static string CONNECTION_SUCCESS_STR = "Connection Successful!!";

        public static string getConnection()
        {
            string constr = "";
            try
            {
                constr = @"metadata=res://*/NSSFModel.csdl|res://*/NSSFModel.ssdl|res://*/NSSFModel.msl;
                        provider=System.Data.SqlClient;
                        provider connection string=';
                        data source=" + SERVERNAME + ";" +
                        "initial catalog=" + DATABASE + ";" +
                        "persist security info=True;" +
                        "user id=" + USERNAME + ";" +
                        "password=" + PASSWORD + ";" +
                        "MultipleActiveResultSets=True;" +
                        "App=EntityFramework;" +
                        "Connection Timeout=500'";
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "NSSF Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return constr;
        }

        public static bool existDatabase()
        {
            bool databaseExist = true;
            SqlConnection sqlConnection = new SqlConnection(getConnection());
            try
            {
                var cmdText = "select count(*) from master.dbo.sysdatabases where name=@database";
                using (var sqlCmd = new SqlCommand(cmdText, sqlConnection))
                {
                    sqlCmd.Parameters.Add("@database", System.Data.SqlDbType.NVarChar).Value = DATABASE;
                    sqlConnection.Open();
                    databaseExist = Convert.ToInt32(sqlCmd.ExecuteScalar()) == 1;
                    if (!databaseExist) { Msg.Error(Config.CONNECTION_FAIL_STR); }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return databaseExist;

        }

        public static bool ConnectionSuccess()
        {
            bool connection = true;
            if (!serverConnected() || string.IsNullOrEmpty(Config.SERVERNAME) || string.IsNullOrEmpty(Config.DATABASE) || string.IsNullOrEmpty(Config.USERNAME) || string.IsNullOrEmpty(Config.PASSWORD))
            {
                connection = false;
                Msg.Error(Config.CONNECTION_FAIL_STR);
            }
            return connection;
        }

        public static bool serverConnected()
        {
            bool result = false;
            try
            {
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send(Config.SERVERNAME);
                result = reply.Status == IPStatus.Success ? true : false;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
