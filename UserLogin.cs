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
using System_Evora_Group;

namespace System_Evora_Group
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string nameInput = usernameTextBox.Text;
            string passwordInput = passwordTextBox.Text;
            try
            {
                Database db = new Database();
                string sql = "SELECT * FROM dbinfo WHERE name = '" + nameInput + "' AND password = '" + passwordInput + "'";
                DataTable dt = db.selectCmd(sql);
                if (dt.Rows.Count > 0)
                {
                    Popup.Show("User login successful !", MessageBoxIcon.Information);
                    UserMain obj = new UserMain();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    Popup.Show("Something went wrong", "Oops!", MessageBoxIcon.Error);
                    nameInput = "";
                    passwordInput = "";
                }
            }
            catch (Exception ex)
            {
                Popup.Show("Error: " + ex.Message);
            }

        }


        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            AdminLogin obj = new AdminLogin();
            obj.Show();
            this.Hide();
        }
    }
}


