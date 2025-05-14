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
    public partial class Loading : Form
    {
        private Timer progressTimer;
        private int progressValue = 0;
        public Loading()
        {
            InitializeComponent();

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {
           
        }
       
        private void Loading_Load(object sender, EventArgs e)
        {
            // this.BackColor = ColorTranslator.FromHtml("#FAFBFC");
            guna2HtmlLabel1.ForeColor = ColorTranslator.FromHtml("#828EF9");
            progressTimer = new Timer();
            progressTimer.Interval = 50; //timer ng circle na kwan
            progressTimer.Tick += ProgressTimer_Tick;
            progressTimer.Start();
            guna2HtmlLabel1.Text = $"{guna2CircleProgressBar1.Value}%";


            Timer animationTimer = new Timer();
            animationTimer.Interval = 400;
            string[] loadingTexts = { " Setting up your pet shop system and loading data", " Setting up your pet shop system and loading data.", "Setting up your pet shop system and loading data..", "Setting up your pet shop system and loading data..." };
            int currentIndex = 0;

            animationTimer.Tick += (s, args) =>
            {
                guna2HtmlLabel2.Text = loadingTexts[currentIndex];
                currentIndex = (currentIndex + 1) % loadingTexts.Length;
            };

            animationTimer.Start();

            this.FormClosing += (s, args) => animationTimer.Stop();


        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            progressValue += 1;
            guna2CircleProgressBar1.Value = progressValue;
            guna2HtmlLabel1.Text = $"{progressValue}%";

            if (progressValue >= 100)
            {
                progressTimer.Stop();
                progressTimer.Dispose();

                AdminLogin obj = new AdminLogin();
                obj.Show();
                this.Hide();


            }
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
        }
    }
}
