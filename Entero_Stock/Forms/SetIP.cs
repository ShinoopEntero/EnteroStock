using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Entero_Stock.Forms
{
    public partial class SetIP : Form
    {
        SqlConnection con = new SqlConnection();
        public SetIP()
        {
            InitializeComponent();
        }
        //public int close = 0;
        
        private void button1_Click(object sender, EventArgs e)
        {
            int result = changeAppConfig();
            if(result == 1)
            {
                //close = 1;
                //this.Close();
                Splash_ obj_Splash = new Splash_();
                obj_Splash.Show();
            }
        }

        public int changeAppConfig()
        {
            try
            {
                string conStr;
                string ipAddress = txt_IP.Text;
                conStr = "Data Source=";
                conStr = conStr + ipAddress;
                conStr = conStr + ";Initial Catalog=db_Entero_Stock;Integrated Security=False;User ID=sa;Password=qwerty;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings["myDB"].ConnectionString = conStr;
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("connectionStrings");

                if (checkConnection() == 1)
                {
                    MessageBox.Show("IP Inserted Successfully");
                    //this.Close();
                    //this.Hide();
                    //this.ParentForm.Close();
                    //close = 1;
                    //Splash_ obj_Splash = new Splash_();
                    //obj_Splash.Show();

                    this.Hide();
                    
                    return 1;
                }
                else
                {
                    MessageBox.Show("Wrong IP. Try Different One !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SetIP.cs " + Environment.NewLine + "Function : changeAppConfig() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }
        public int checkConnection()
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["myDB"].ToString();
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception)
            {
                return 0;
            }
            con.Close();
            return 1;
        }

        private void SetIP_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (close == 1)
            //{
            //    Splash_ obj_Splash = new Splash_();
            //    obj_Splash.Show();
            //}
            //else
            //{
            //    MessageBox.Show("else working");
            //}
        }

        private void SetIP_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (close == 1)
            //{
            //    Splash_ obj_Splash = new Splash_();
            //    obj_Splash.Show();
            //}
            //else
            //{
            //    MessageBox.Show("else working");
            //}

        }
    }
}

