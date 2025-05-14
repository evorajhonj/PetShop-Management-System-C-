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

namespace System_Evora_Group
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }
        public void DisplayData()
        {
            try
            {
                Database db = new Database();
                EmployeesDGV.DataSource = db.selectCmd("Select * from EmployeeTbl");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void guna2Shapes1_Click(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmpNameTbl.Text) || string.IsNullOrWhiteSpace(EmpAddTbl.Text) || string.IsNullOrWhiteSpace(EmpPhoneTbl.Text) || string.IsNullOrWhiteSpace(EmpPassTbl.Text))
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {
                try
                {
                    Database db = new Database();
                    string sql = "INSERT INTO EmployeeTbl (EmpName, EmpAdd, DOB, EmpPhone, EmpPas, EmpMail) " +
                                 "VALUES ('" + EmpNameTbl.Text + "', '" + EmpAddTbl.Text + "', '" +
                                 DOBTbl.Value.Date.ToString("yyyy-MM-dd") + "', '" + EmpPhoneTbl.Text + "', '" + EmpPassTbl.Text + "','" + EmpMailTbl.Text + "')";
                    if (db.cudCMD(sql) > 0)
                    {
                        DisplayData();
                        MessageBox.Show("Data Inserted");
                    }
                    else
                    {
                        MessageBox.Show("Data Not Inserted");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            DisplayData();

        }

        private void EmployeesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void EditBtn_Click(object sender, EventArgs e)
        {

        }

        private void Employees_Load(object sender, EventArgs e)
        {
            try
            {
                Database db = new Database();
                DisplayData();
            }
            catch
            {
                con.ForeColor = Color.Red;
            }
           
        }

        private void EmpAddTbl_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
