using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Evora_Group
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();

        }
        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            UserLogin obj = new UserLogin();
            obj.Show();
            this.Hide();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string nameInput = usernameTextBox.Text;
            string passwordInput = passwordTextBox.Text;
            try
            {
                Database db = new Database();
                string sql = "SELECT * FROM dbinfo WHERE name = '" + nameInput + "' AND password = '" + passwordInput + "' AND usertype = 'Admin'";
                DataTable dt = db.selectCmd(sql);
                if (dt.Rows.Count > 0)
                {
                    Popup.Show("User login successful !", MessageBoxIcon.Information);
                    Main obj = new Main();
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

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2TileButton1_Click_1(object sender, EventArgs e)
        {
            UserLogin obj = new UserLogin();
            obj.Show();
            this.Hide();
        }
    }
}
