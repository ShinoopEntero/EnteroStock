using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Entero_Stock
{
    class GenericClass
    {
        SqlConnection con = new SqlConnection();

        // SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_Entero_Stock;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //SqlConnection con = new SqlConnection(@"Data Source=(192.168.1.101)\SQLEXPRESS,1433;Network Library=DBMSSOCN;Initial Catalog=db_Entero_Stock;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public GenericClass()
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["myDB"].ToString();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : GenericClass.cs " + Environment.NewLine + "Function : GenericClass() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
            }


        }
        internal static class iniVar
        {
            public static string URole;
            public static string LoginName;
            public static string LoggedUserId;
        }

        //public void InsertData(string str)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(str, con);
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        int errCode = GenericClass.assignErrCode(ex);
        //        GenericClass.errorLogger(errCode, "Class : GenericClass.cs " + Environment.NewLine + "Function : InsertData() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
        //    }
        //}

        //public void InsertData(string str, ref bool isError, ref string errMessage)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(str, con);
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception exc)
        //    {
        //        isError = true;
        //        errMessage = exc.Message;
        //    }
        //}

        public void InsertData(string str, ref bool isError, ref Exception ex)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                isError = true;
                ex = exc;
            }
        }
        public DataTable GetData(string str)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : GenericClass.cs " + Environment.NewLine + "Function : InsertData() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                return dt;
            }
        }


        public DataTable GetData(string str, ref bool isError, ref Exception ex)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
            catch (Exception exc)
            {
                isError = true;
                ex = exc;
                return dt;
            }
        }

        public static int assignErrCode(Exception ex)
        {
            try
            {
                if (ex.GetType().ToString() == "System.Data.SqlClient.SqlException")
                    return 2;
                else
                    return 1;
            }
            catch (Exception exc)
            {
                errorWriterDesc(ex, exc);
                return -1;
            }
        }

        public static void errorLogger(int errType, string errLog, string stackTrace)
        {
            int userId = 0;
            string ipAddress = getIPAddress();


            string machineName = Environment.MachineName;
            try
            {
                userId = Convert.ToInt32(GenericClass.iniVar.LoggedUserId);
                errLog = errLog.Replace("'", "\"");

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["MyDB"].ToString();
                con.Open();

                string str = "INSERT INTO tbl_ErrorLogger (UserId ,ErrorType ,ErrorLog ,StackTrace ,MachineName ,IPAddress ,CreatedDate) VALUES (" + userId + "," + errType + ",'" + errLog + "','" + stackTrace + "','" + machineName + "','" + ipAddress + "',GETDATE())";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                errorWriter(userId, errType, errLog, stackTrace, machineName, ipAddress, ex);
            }
        }

        public static string getIPAddress()
        {
            string ipAddress = "";
            try
            {
                int ipLength = Dns.GetHostEntry(Environment.MachineName).AddressList.Length;
                for (int i = 0; i < ipLength; i++)
                {
                    string addressList = Dns.GetHostEntry(Environment.MachineName).AddressList[i].ToString();
                    if (addressList.Contains("192") || addressList.Contains("169") || addressList.Contains("168") || addressList.Contains("127"))
                    {
                        ipAddress = addressList;
                        return ipAddress;
                    }
                }
                return "-1";
            }
            catch (Exception)
            {
                return "-1";
            }
        }

        public static void errorWriterDesc(Exception ex, Exception exc)
        {
            int userId = 0;
            string errLog = string.Empty;
            string ipAddress = getIPAddress();
            string machineName = Environment.MachineName;

            userId = Convert.ToInt32(GenericClass.iniVar.LoggedUserId);
            errLog = "Class : GenericClass.cs , Function : assignErrCode() Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message;
            errLog = errLog.Replace("'", "\"");

            errorWriter(userId, 1, errLog, ex.StackTrace, machineName, ipAddress, exc);
        }
        public static void errorWriterDesc2(Exception ex, Exception exc)
        {
            int userId = 0;
            string errLog = string.Empty;
            string ipAddress = getIPAddress();
            string machineName = Environment.MachineName;

            userId = Convert.ToInt32(GenericClass.iniVar.LoggedUserId);
            errLog = "Class : GenericClass.cs , Function : assignErrCode() Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message;
            //errLog = errLog.Replace("'", "\"");

            errorWriter(userId, 1, errLog, ex.StackTrace, machineName, ipAddress, exc);
        }

        public static void errorWriter(int userId, int errType, string errLog, string stackTrace, string machineName, string ipAddress, Exception ex)
        {
            string filePath = createDirectory();
            StreamWriter file = new StreamWriter(filePath, true);
            file.WriteLine("");
            file.WriteLine("");
            file.WriteLine("");
            file.WriteLine("*****************************************************************************");
            file.WriteLine("*****************************************************************************");
            file.WriteLine("*****************************************************************************");
            file.WriteLine("");
            file.WriteLine("============================" + DateTime.Now.ToString() + "============================");
            file.WriteLine("-----------------------------Affected Page Error-----------------------------");
            file.WriteLine("");
            file.WriteLine("User Id      : " + userId);
            file.WriteLine("Machine Name : " + machineName);
            file.WriteLine("IP Address   : " + ipAddress);
            file.WriteLine("");
            file.WriteLine("Namespace    : Entero_Stock");
            file.WriteLine(errLog);
            file.WriteLine("");
            file.WriteLine("Stack Trace  : " + stackTrace);
            file.WriteLine("");
            file.WriteLine("-----------------------------ErrorLogger Page Error-----------------------------");
            file.WriteLine("");
            file.WriteLine("Namespace    : Entero_Stock");
            file.WriteLine("Class        : GenericClass.cs ");
            file.WriteLine("Date         : " + DateTime.Now);
            file.WriteLine("Error Message: " + ex.Message);
            file.WriteLine("");
            file.WriteLine("Stack Trace  : " + ex.StackTrace);
            file.WriteLine("");
            file.WriteLine("*****************************************************************************");
            file.WriteLine("*****************************************************************************");
            file.WriteLine("*****************************************************************************");

            file.Close();
        }
        //public static void errorWriter()
        //{
        //    string filePath = createDirectory();
        //    StreamWriter file = new StreamWriter(filePath, true);

        //    file.Close();
        //}

        public static string createDirectory()
        {
            string filePath = Path.GetDirectoryName(Application.ExecutablePath);
            //char[] removeChar = { 'b', 'i', 'n', '\\', 'D', 'e', 'b', 'u', 'g' };
            //filePath = filePath.TrimEnd(removeChar);
            filePath = filePath + "\\Reports\\ErrorReports\\";
            if (Directory.Exists(filePath) == false)
            {
                Directory.CreateDirectory(filePath);
            }

            DateTime dt;
            dt = DateTime.Now;
            string timeName = String.Format("{0:dd-MM-yyyy}", dt);
            filePath = filePath + "ErrorLog_" + timeName + ".txt";

            return filePath;
        }
        public DataSet GetDataChartPurchase(string str)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt, "Purchase");
                return dt;

            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : GenericClass.cs " + Environment.NewLine + "Function : InsertData() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                return dt;
            }
        }
        public DataSet GetDataChartPurchase(string str, ref bool isError, ref Exception sqlEx)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt, "Purchase");
                return dt;

            }
            catch (Exception ex)
            {
                isError = true;
                sqlEx = ex;
                return dt;
            }
        }
        public DataSet GetDataChartSales(string str)
        {
            DataSet dt = new DataSet();
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt, "Sales");
            return dt;
        }



    }
}


//// string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\PURCHASE REPORTS\";
//string appPath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Sales Report\";

//            if (Directory.Exists(appPath) == false)
//            {
//                Directory.CreateDirectory(appPath);
//            }
//            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(appPath + "/" + txt_ReferenceNo.Text + ".pdf", FileMode.Create));

//string appPath2 = Path.GetDirectoryName(Application.ExecutablePath) + @"\ProductImages\";
//            //string appPath = "~\\Entero_Stock\\Entero_Stock\\ProductImages\\
//            if (Directory.Exists(appPath) == false)
//            {
//                Directory.CreateDirectory(appPath);
//            }
//            if (opFile.ShowDialog() == DialogResult.OK)
//            {
//                try
//                {
//                    string iName = txtproductid.Text + ".jpg";
//string filepath = opFile.FileName;

//File.Copy(filepath, appPath + iName);
//                    pictureBox1.Image = new Bitmap(opFile.OpenFile());
//                    FilePath = appPath + iName;

//                }
//                catch (Exception exp)
//                {
//                    MessageBox.Show("Unable to open file " + exp.Message);
//                }
//            }

