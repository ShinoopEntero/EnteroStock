using Entero_stock;
using Entero_Stock.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Entero_Stock
{
    static class Program
    {
        /// <summary> new changes
        /// The main entry point for the application.
        /// </summary>sdfsdfd newly updated....
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login obj_Login = new Login();
            string className = obj_Login.checkConnection();

            if(className == "UserMode")
            {
                Application.Run(new UserMode());
            }
            else if(className == "SetIP")
            {
                Application.Run(new SetIP());
            }
            else if (className == "Login")
            {
                Application.Run(new Splash_());
            }
            else if (className == "Error")
            {
                MessageBox.Show("Connection Lost!");
            }
            else
            {
                MessageBox.Show("Error!");
            }
          //  Application.Run(new Splash_());
  // Application.Run(new UserRegister());
        }


        //public void checkConnection()
        //{
        //    SqlConnection con = new SqlConnection();
        //    try
        //    {
        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["myDB"].ToString();
        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();
        //        }
        //        con.Open();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        string errType = ex.GetType().ToString();
        //        if (errType == "System.NullReferenceException" || errType == "System.Data.SqlClient.SqlException")
        //        {
        //            string conStr = ConfigurationManager.ConnectionStrings["myDB"].ToString();
        //            string[] conStrs = conStr.Split('=');
        //            conStrs = conStrs[1].Split(';');
        //            string mName = conStrs[0];

        //            if (mName == "")
        //            {
        //                // this.Close();
        //                UserMode obj_UserMode = new UserMode();
        //                obj_UserMode.Show();
        //            }
        //            else if (mName.Contains("192") == false && mName.Contains("168") == false && mName.Contains("169") == false && mName.Contains("127") == false)
        //            {
        //                if (changeMachineName() == 1)
        //                {
        //                    MessageBox.Show("Connection Successful");
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Connection Error!");
        //                    this.Close();
        //                    UserMode obj_UserMode = new UserMode();
        //                    obj_UserMode.Show();
        //                }

        //            }
        //            else if (mName.Contains("192") == true || mName.Contains("168") == true || mName.Contains("169") == true || mName.Contains("127") == true)
        //            {
        //                MessageBox.Show("Connection Error!");
        //                this.Close();
        //                SetIP obj_SetIP = new SetIP();
        //                obj_SetIP.Show();
        //            }

        //        }
        //        else
        //        {
        //            MessageBox.Show("Undefined Error! Check SQL Connection");
        //        }

        //        //int errCode = GenericClass.assignErrCode(ex);
        //        //GenericClass.errorLogger(errCode, "Class : GenericClass.cs " + Environment.NewLine + "Function : GenericClass() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
        //    }
        //}


        //public int changeMachineName()
        //{
        //    try
        //    {
        //        string conStr;
        //        string machineName = Environment.MachineName;
        //        conStr = "Data Source=";
        //        conStr = conStr + machineName;
        //        conStr = conStr + ";Initial Catalog=db_Entero_Stock;Integrated Security=False;User ID=sa;Password=qwerty;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        //        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //        config.ConnectionStrings.ConnectionStrings["myDB"].ConnectionString = conStr;
        //        config.Save(ConfigurationSaveMode.Modified, true);
        //        ConfigurationManager.RefreshSection("connectionStrings");

        //        if (checkSQLConnection() == 1)
        //            return 1;
        //        else
        //            return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //}

        //public int checkSQLConnection()
        //{
        //    SqlConnection con = new SqlConnection();
        //    try
        //    {
        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["myDB"].ToString();
        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();
        //        }
        //        con.Open();
        //        con.Close();
        //    }
        //    catch (Exception)
        //    {
        //        return 0;
        //    }
        //    con.Close();
        //    return 1;
        //}

    }
} 
