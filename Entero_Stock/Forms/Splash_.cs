using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entero_Stock.Forms
{
    public partial class Splash_ : Form
    {
        public Splash_()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Login frm = new Login();
                progressBar1.Visible = true;

                this.progressBar1.Value = this.progressBar1.Value + 2;
                if (this.progressBar1.Value == 10)
                {
                    label2.Text = "Reading modules..";
                }
                else if (this.progressBar1.Value == 20)
                {
                    label2.Text = "Turning on modules.";
                }
                else if (this.progressBar1.Value == 40)
                {
                    label2.Text = "Starting modules..";
                }
                else if (this.progressBar1.Value == 60)
                {
                    label2.Text = "Loading modules..";
                }
                else if (this.progressBar1.Value == 80)
                {
                    label2.Text = "Done Loading modules..";
                }
                else if (this.progressBar1.Value == 100)
                {
                    frm.Show();
                    timer1.Enabled = false;
                    this.Hide();
                }
            }
            catch (Exception)
            {
            }
        }

        private void Splash__Load(object sender, EventArgs e)
        {
            progressBar1.Width = this.Width;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
