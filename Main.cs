using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace System_Evora_Group
{
    public partial class Main : Form
    {
        bool sideBar_Expand;
        public Main()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
           Controls.Add(ContainerV);
           LoadInContainer(new Dashboard());

        }
        private void LoadInContainer(object _form)
        {
            try
            {
                if (ContainerV.Controls.Count > 0)
                {
                    foreach (Control ctrl in ContainerV.Controls)
                    {
                        ctrl.Dispose();
                    }
                    ContainerV.Controls.Clear();
                }
                if (!(_form is Form fm))
                    throw new ArgumentException("Parameter must be a Form.", nameof(_form));

                fm.TopLevel = false;
                fm.FormBorderStyle = FormBorderStyle.None;
                fm.Dock = DockStyle.Fill;
                ContainerV.Controls.Add(fm);
                ContainerV.Tag = fm;
                fm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sideBar_Expand)
            {
                SideBar.Width -= 10;
                if (SideBar.Width == SideBar.MinimumSize.Width)
                {
                    sideBar_Expand = false;
                    timer1.Stop();
                }
            }
            else
            {
                SideBar.Width += 10;
                if (SideBar.Width == SideBar.MaximumSize.Width)
                {
                    sideBar_Expand = true;
                    timer1.Stop();
                }
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            LoadInContainer(new Dashboard());
        }
        private void guna2TileButton4_Click(object sender, EventArgs e)
        {

        }

        private void guna2TileButton6_Click(object sender, EventArgs e)
        {
            if (Popup.ShowConfirm("Are you sure you want to logout?", "Confirm", MessageBoxIcon.Question, this) == DialogResult.Yes)
            {
                UserLogin obj = new UserLogin();
                obj.Show();
                this.Hide();
            }
        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            LoadInContainer(new Employees());
        }

        private void guna2TileButton1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
