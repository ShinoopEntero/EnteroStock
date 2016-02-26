using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entero_Stock.Forms;

namespace Entero_Stock
{
    public partial class frmSplash : Form
    {
        public frmSplash()
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
                    label3.Text = "Reading modules..";
                }
                else if (this.progressBar1.Value == 20)
                {
                    label3.Text = "Turning on modules.";
                }
                else if (this.progressBar1.Value == 40)
                {
                    label3.Text = "Starting modules..";
                }
                else if (this.progressBar1.Value == 60)
                {
                    label3.Text = "Loading modules..";
                }
                else if (this.progressBar1.Value == 80)
                {
                    label3.Text = "Done Loading modules..";
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
                //int errCode = GenericClass.assignErrCode(ex);
                //GenericClass.errorLogger(errCode, "Class : frmSplash.cs " + Environment.NewLine + "Function : timer1_Tick() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                //MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            progressBar1.Width = this.Width;
        }
    }
}
