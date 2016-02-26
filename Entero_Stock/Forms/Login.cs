using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Entero_Stock.Forms
{
    public partial class Login : Form
    {
        GenericClass obj = new GenericClass();

        public Login()
        {
            try
            {
                InitializeComponent();
                txt_UserName.KeyDown += new KeyEventHandler(tb_KeyEnter_LeaveFocus);
                txt_Password.KeyDown += new KeyEventHandler(tb_KeyEnter_LoginClick);

                //checkConnection();
                txt_UserName.Text = "sibynedu";
                txt_Password.Text = "qwerty";

                btn_SetIP.Enabled = false;
                button1.Enabled = false;
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Login.cs " + Environment.NewLine + "Function : Login() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public string checkConnection()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["myDB"].ToString();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                con.Close();
                return "Login";
            }
            catch (Exception ex)
            {
                string errType = ex.GetType().ToString();
                if(errType == "System.NullReferenceException" || errType == "System.Data.SqlClient.SqlException")
                {
                    string conStr = ConfigurationManager.ConnectionStrings["myDB"].ToString();
                    string[] conStrs = conStr.Split('=');
                    conStrs = conStrs[1].Split(';');
                    string mName = conStrs[0];

                    if(mName == "AppFirstUse")
                    {
                        // this.Close();
                        return "UserMode";
                        //UserMode obj_UserMode = new UserMode();
                        //obj_UserMode.Show();
                    }
                    else if(mName.Contains("192") == false && mName.Contains("168") == false && mName.Contains("169") == false && mName.Contains("127") == false)
                    {
                        if (changeMachineName() == 1)
                        {
                            return "Login";
                            //MessageBox.Show("Connection Successful");
                        }
                        else
                        {
                            return "UserMode";
                            //MessageBox.Show("Connection Error!");
                            ////this.Close();
                            //UserMode obj_UserMode = new UserMode();
                            //obj_UserMode.Show();
                        }

                    }
                    else if (mName.Contains("192") == true || mName.Contains("168") == true || mName.Contains("169") == true || mName.Contains("127") == true)
                    {
                        return "SetIP";
                        //MessageBox.Show("Connection Error!");
                        ////this.Close();
                        //SetIP obj_SetIP = new SetIP();
                        //obj_SetIP.Show();
                    }
                    return "Error";

                }
                else
                {
                    return "Error";
                    //MessageBox.Show("Undefined Error! Check SQL Connection");
                }

                //int errCode = GenericClass.assignErrCode(ex);
                //GenericClass.errorLogger(errCode, "Class : GenericClass.cs " + Environment.NewLine + "Function : GenericClass() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
            }
        }


        public int changeMachineName()
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

                if (checkSQLConnection() == 1)
                    return 1;
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int checkSQLConnection()
        {
            SqlConnection con = new SqlConnection();
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
        private void btn_Login_Click(object sender, EventArgs e)
        {
            login();
        }
        public void login()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                DataTable dtt = new DataTable();
                string str = "select * from tbl_Login where LoginName='" + txt_UserName.Text + "' and password='" + txt_Password.Text + "'";
                dtt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dtt.Rows.Count > 0)
                    {
                        string strRole = "select Role from tbl_UserRole ur where RoleId ='" + dtt.Rows[0][3] + "'";
                        DataTable dt = obj.GetData(strRole, ref isError, ref sqlEx);
                        if (isError == false)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                GenericClass.iniVar.URole = dt.Rows[0][0].ToString();
                                GenericClass.iniVar.LoginName = txt_UserName.Text;
                                GenericClass.iniVar.LoggedUserId = dtt.Rows[0]["UserId"].ToString();
                                Home frm = new Home();
                                frm.Show();
                                frm.lblUser.Text = GenericClass.iniVar.URole;
                                this.Hide();
                            }
                        }
                        else
                        {
                            GenericClass.errorLogger(2, "Class : Login.cs " + Environment.NewLine + "Function : login() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                            MessageBox.Show("Login Failed!");
                        }
                    }

                    else
                    {
                        MessageBox.Show("Login is Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        txt_UserName.Clear();
                        txt_Password.Clear();
                        txt_UserName.Focus();
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Login.cs " + Environment.NewLine + "Function : login() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                    MessageBox.Show("Login Failed!");
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Login.cs " + Environment.NewLine + "Function : login() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Return)
                return true;
            return base.IsInputKey(keyData);
        }

        private void tb_KeyEnter_LeaveFocus(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Enter key is down

                //Capture the text
                if (sender is TextBox)
                {
                    TextBox txb = (TextBox)sender;
                    txt_Password.Focus();
                }
            }
        }
        private void tb_KeyEnter_LoginClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Enter key is down

                //Capture the text
                if (sender is TextBox)
                {
                    TextBox txb = (TextBox)sender;
                    login();
                }
            }
        }

        private void btn_SetIP_Click(object sender, EventArgs e)
        {
            SetIP frm = new SetIP();
            frm.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

