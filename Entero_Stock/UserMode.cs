using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Entero_Stock.Forms;
using System.Diagnostics;


namespace Entero_Stock
{
    public partial class UserMode : Form
    {
        public UserMode()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection();
        
        private void btn_SelectUser_Click(object sender, EventArgs e)
        {
            selectUserMode();
        }

        public void selectUserMode()
        {
            if (rdb_SingleUser.Checked == true)
            {
                changeMachineName();
            }
            else if (rdb_MultyUser.Checked == true)
            {
                //var obj_SetIP = new SetIP();
                //obj_SetIP.FormClosed += (s, args) => this.Close();
                //obj_SetIP.Show();
                if(rdb_Server.Checked == true)
                {
                    SetIP obj_SetIP = new SetIP();

                }
                if(rdb_Client.Checked == true)
                {
                    this.Hide();
                    SetIP obj_SetIP = new SetIP();

                    obj_SetIP.Show();

                }
            }
        }

        public void changeMachineName()
        {
            try
            {
                string conStr;
                string machineName = Environment.MachineName;
                conStr = "Data Source=";
                conStr = conStr + machineName;
                conStr = conStr + ";Initial Catalog=db_Entero_Stock;Integrated Security=False;User ID=sa;Password=qwerty;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings["myDB"].ConnectionString = conStr;
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("connectionStrings");

                if (checkConnection() == 1)
                {
                    MessageBox.Show("SQL Connection Established Successfully");
                    Splash_ obj_Splash = new Splash_();
                    this.Hide();
                    obj_Splash.Show();
                }
                else
                    MessageBox.Show("SQL Connection Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SetIP.cs " + Environment.NewLine + "Function : button1_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int checkConnection()
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["myDB"].ToString();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                con.Close();
            }
            catch (Exception)
            {
                return 0;
            }
            con.Close();
            return 1;
        }

        private void UserMode_Load(object sender, EventArgs e)
        {
            grp_Type.Visible = false;
        }

        private void rdb_MultyUser_CheckedChanged(object sender, EventArgs e)
        {
            if(rdb_MultyUser.Checked == true)
            {
                grp_Type.Visible = true;
            }
            else if(rdb_MultyUser.Checked == false)
            {
                grp_Type.Visible = false;
            }
        }

        //~UserMode()
        //{
        //    this.Dispose();
        //    MessageBox.Show("sdf");
        //}
    }
}
