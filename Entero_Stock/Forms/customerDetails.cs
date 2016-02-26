using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entero_Stock;
using Entero_Stock.Forms;
//using Entero_Stock.Report;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using CrystalDecisions.CrystalReports.Engine;
namespace Entero_Stock
{
    public partial class customerDetails : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_Entero_Stock;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //DataSet ds = new DataSet();
        //SqlCommand cmd = null;
        //DataTable dt = new DataTable();
        public int CId;
        GenericClass obj = new GenericClass();

        public customerDetails()
        {
            InitializeComponent();
        }

        private void grd_CustomerDetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //    int rowIndex = e.RowIndex;
            //    DataGridViewRow row = grd_CustomerDetails.Rows[rowIndex];
            //    CId = Convert.ToInt16(row.Cells[0].Value);
            //    // FillTextField();
            try
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow row = grd_suppliDetails.Rows[rowIndex];
                CId = Convert.ToInt16(row.Cells[0].Value);
                FillTextField();
                //CId = Convert.ToInt16(row.Cells[0].Value);
                //FillTextField();
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : customerDetails.cs " + Environment.NewLine + "Function : grd_CustomerDetails_RowHeaderMouseClick() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void FillTextField()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                CustomerRegistration frm = new CustomerRegistration();
                frm.Show();
                frm.btnup.Enabled = true;
                frm.btndel.Enabled = true;
                frm.btnreg.Enabled = false;
                string str = "select * from tbl_Customer where CustomerId='" + CId + "'";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        frm.txt_FName.Text = dt.Rows[0]["FirstName"].ToString();
                        frm.txt_LName.Text = dt.Rows[0]["LastName"].ToString();
                        frm.txt_Address.Text = dt.Rows[0]["Address"].ToString();
                        frm.txt_City.Text = dt.Rows[0]["City"].ToString();
                        frm.cmbstate.Text = dt.Rows[0]["State"].ToString();
                        frm.txt_Pin.Text = dt.Rows[0]["PostalCode"].ToString();
                        frm.txt_Email.Text = dt.Rows[0]["Email"].ToString();
                        frm.txt_Phone.Text = dt.Rows[0]["Phone"].ToString();
                        frm.CId = CId;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : customerDetails.cs " + Environment.NewLine + "Function : FillTextField() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }

            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : customerDetails.cs " + Environment.NewLine + "Function : FillTextField() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //try
            //{
            //    DataGridViewRow dr = grd_CustomerDetails.SelectedRows[0];
            //    this.Hide();

            //    CustomerRegistration frm = new CustomerRegistration();
            //    frm.Show();
            //    frm.txt_FName.Text = dr.Cells[0].Value.ToString();
            //    frm.txt_LName.Text = dr.Cells[1].Value.ToString();
            //    frm.txt_Address.Text = dr.Cells[2].Value.ToString();
            //    frm.txt_City.Text = dr.Cells[3].Value.ToString();
            //    frm.cmbstate.Text = dr.Cells[4].Value.ToString();
            //    frm.txt_Pin.Text = dr.Cells[5].Value.ToString();
            //    frm.txt_Email.Text = dr.Cells[6].Value.ToString();
            //    frm.txt_Phone.Text = dr.Cells[7].Value.ToString();
            //    frm.label2.Text = label1.Text;



            //} 

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void txtCustomers_TextChanged(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {

                string str = "SELECT (FirstName) as [First Name],(LastName) as [Last Name],(Address) as [Address],(City) as [City],(State) as [State],(PostalCode) as [Postal Code],(Email) as [Email],(Phone) as [Mobile No]  from tbl_Customer where FirstName like '" + txtCustomers.Text + "%' order by FirstName";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        grd_suppliDetails.DataSource = dt;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : customerDetails.cs " + Environment.NewLine + "Function : txtCustomers_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : customerDetails.cs " + Environment.NewLine + "Function : txtCustomers_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customerDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
             
            //this.Hide();
            //CustomerRegistration frm = new CustomerRegistration();

            //frm.label2.Text = label1.Text;
            //frm.Show();
        }

        private void customerDetails_Load(object sender, EventArgs e)
        { 
            LoadGrid();
           
        }

        private void LoadGrid()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string strSel = "select CustomerId,FirstName,LastName,Address,City,Email,Phone from tbl_Customer";
                DataTable dt = obj.GetData(strSel, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        grd_suppliDetails.DataSource = dt;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : customerDetails.cs " + Environment.NewLine + "Function : LoadGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : customerDetails.cs " + Environment.NewLine + "Function : LoadGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (grd_suppliDetails.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = grd_suppliDetails.RowCount - 1;
                colsTotal =grd_suppliDetails.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = grd_suppliDetails.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = grd_suppliDetails.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "regular";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : customerDetails.cs " + Environment.NewLine + "Function : Button3_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
              //  CrystalReport1 rpt = new CrystalReport1();
                //The report you created.
                //cmd = new SqlCommand();
                // SqlDataAdapter myDA = new SqlDataAdapter();

                DataTable dt = obj.GetData("SELECT * from tbl_Customer order by FirstName", ref isError, ref sqlEx);

                if(isError == false)
                {

                }
                else
                {
                    GenericClass.errorLogger(2, "Class : customerDetails.cs " + Environment.NewLine + "Function : button1_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }

                //db_Entero_StockDataSet myDS = new db_Entero_StockDataSet();
                //The DataSet you created.
                //con = new SqlConnection();
                //cmd.Connection = con;
                //cmd.CommandText = "SELECT * from tbl_Customer order by FirstName";
                //cmd.CommandType = CommandType.Text;
                //myDA.SelectCommand = cmd;
                //myDA.Fill(myDS," tbl_Customer");
                // rpt.SetDataSource(dt);
                //Form1 frm = new Form1();
                //frm.crystalReportViewer1.ReportSource = rpt;

                // frm.Visible = true;
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : customerDetails.cs " + Environment.NewLine + "Function : button1_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void grd_suppliDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }

    
        
    

       
   
    

