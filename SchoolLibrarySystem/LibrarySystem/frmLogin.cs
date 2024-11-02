using LibrarySystem.Includes;
using System;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class frmLogin : Form
    {
        private Form1 frm;

        public frmLogin(Form1 frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private SQLConfig config = new SQLConfig();
        private string sql;

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }

        private void OK_Click(object sender, EventArgs e)
        {
            sql = "SELECT * FROM `tbluser` WHERE User_name= '" + UsernameTextBox.Text + "' and Pass = '" + PasswordTextBox.Text + "'";
            config.singleResult(sql);

            if (config.dt.Rows.Count > 0)
            {
                MessageBox.Show("Welcome to Library System");
                frm.enabled_menu();
                this.Close();
            }
            else
            {
                MessageBox.Show("Account does not exist. Please contact administrator.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}