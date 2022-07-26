using Stock_Management_System.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Management_System.UIDesign
{
    public partial class frmBrowseDB : Form
    {
        public frmBrowseDB()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "ស្វែងរកទីតាំងប្រភពទិន្នន័យ!";
            //fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "Microsoft Access (*.accdb*)|*.accdb*";
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtDbPath.Text = fdlg.FileName;
                btnTestConnection.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.path = txtDbPath.Text.Trim();
            Properties.Settings.Default.Save();
            Msg.Information(Msg.OPERATION_SUCCESS);
            this.Hide();
            frmMain frm = new frmMain();
            frm.ShowDialog();
            this.Close();
        }
      

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (Setting.ConnectionSuccess(txtDbPath.Text.Trim())) 
            {
                Msg.Information(Setting.CONNECTION_TEXT);
                btnSave.Enabled = true;
            } 
            else 
            {
                Msg.Error(Setting.CONNECTION_TEXT);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Msg.Question(Msg.ASK_FOR_EXIT)) { Application.Exit(); }
        }
        
    }
}
