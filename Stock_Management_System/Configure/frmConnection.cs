using Stock_Management_System.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Management_System.Configure
{
    public partial class frmConnection : Form
    {
        private string connectionStr;
        private int statusCode; // 0 = Connection Fail / 1 = Connection Successful

        public string getConnection()
        {
            string constr = "";
            try
            {
                constr = "Server=" + txtServerName.Text.Trim() + ";Database=" + txtDatabase.Text.Trim() + ";User Id=" + txtUsername.Text.Trim() + ";Password=" + txtPassword.Text.Trim() + ";";
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "NSSF Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return constr;
        }

        public bool connectionSuccess()
        {
            bool databaseExist = true;
            SqlConnection sqlConnection = new SqlConnection(getConnection());
            try
            {
                var cmdText = "select count(*) from master.dbo.sysdatabases where name=@database";
                using (var sqlCmd = new SqlCommand(cmdText, sqlConnection))
                {
                    sqlCmd.Parameters.Add("@database", System.Data.SqlDbType.NVarChar).Value = txtDatabase.Text.Trim();
                    sqlConnection.Open();
                    databaseExist = Convert.ToInt32(sqlCmd.ExecuteScalar()) == 1;
                }

            }
            catch (Exception)
            {
                databaseExist = false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return databaseExist;

        }

        public frmConnection()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void frmConnection_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                progressBar1.Visible = true;
                container.Enabled = false;
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.statusCode = connectionSuccess() ? 1 : 0;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
            container.Enabled = true;
            if (this.statusCode == 0) { Msg.Error(Config.CONNECTION_FAIL_STR); } else { Msg.Information(Config.CONNECTION_SUCCESS_STR); }
        }
    }
}
