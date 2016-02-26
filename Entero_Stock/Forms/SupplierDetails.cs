using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Entero_Stock.Report;
using Entero_Stock;
using Entero_Stock.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
namespace Entero_Stock.Forms
{
    public partial class SupplierDetails : Form
    {
        public int SId;
        GenericClass obj = new GenericClass();

        public SupplierDetails()
        {
            InitializeComponent();
        }

        private void grd_SupplierDetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {this.Hide();
            try
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow row = grd_SupplierDetails.Rows[rowIndex];
                SId = Convert.ToInt16(row.Cells[0].Value);
                FillTextField();
                
                
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SupplierDetails.cs " + Environment.NewLine + "Function : grd_SupplierDetails_RowHeaderMouseClick() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void FillTextField()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {

                SupplierRegistration frm = new SupplierRegistration();
                frm.Show();
                frm.btnup.Enabled = true;
                frm.btndel.Enabled = true; 
                frm.btnreg.Enabled = false;
                frm.btnnew.Enabled = false;
                string str = "select * from tbl_Supplier where SupplierId='" + SId + "'";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                frm.SId = SId;
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        frm.txt_FName.Text = dt.Rows[0]["SName"].ToString();
                        frm.txt_company.Text = dt.Rows[0]["SCompany"].ToString();
                        frm.txt_Address.Text = dt.Rows[0]["SAddress"].ToString();
                        frm.txt_City.Text = dt.Rows[0]["City"].ToString();
                        frm.cmbstate.Text = dt.Rows[0]["State"].ToString();
                        frm.txt_Pin.Text = dt.Rows[0]["PostalCode"].ToString();
                        frm.txt_Email.Text = dt.Rows[0]["Email"].ToString();
                        frm.txt_Phone.Text = dt.Rows[0]["Phone"].ToString();
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : SupplierDetails.cs " + Environment.NewLine + "Function : FillTextField() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }

            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SupplierDetails.cs " + Environment.NewLine + "Function : FillTextField() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCustomers_TextChanged(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {

                string str = "SELECT (SName) as [Name],(SCompany) as [Company],(SAddress) as [Address],(City) as [City],(State) as [State],(PostalCode) as [Pin],(Email) as [Email],(Phone) as [Phone]  from tbl_Supplier where SName like '" + txtSuppliers.Text + "%' order by Name";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        grd_SupplierDetails.DataSource = dt;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : SupplierDetails.cs " + Environment.NewLine + "Function : txtCustomers_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SupplierDetails.cs " + Environment.NewLine + "Function : txtCustomers_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void SupplierDetails_Load(object sender, EventArgs e)
        {
            LoadGrid();

        }

        private void LoadGrid()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string strSel = "select SupplierId,SName,SCompany,SAddress,City,State,Email,Phone,PostalCode from tbl_Supplier";
                DataTable dt = obj.GetData(strSel, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        grd_SupplierDetails.DataSource = dt;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : SupplierDetails.cs " + Environment.NewLine + "Function : LoadGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SupplierDetails.cs " + Environment.NewLine + "Function : LoadGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {

            if (grd_SupplierDetails.DataSource == null)
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

                rowsTotal = grd_SupplierDetails.RowCount - 1;
                colsTotal = grd_SupplierDetails.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = grd_SupplierDetails.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = grd_SupplierDetails.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "bold";
                _with1.Rows["1:1"].Font.Size = 10;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SupplierDetails.cs " + Environment.NewLine + "Function : Button3_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
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
            //try
            //{
            //    Cursor = Cursors.WaitCursor;
            //    //timer1.Enabled = true;
            //    supplierCrystalReport rpt = new supplierCrystalReport();
            //    //The report you created.
            //    //cmd = new SqlCommand();
            //    // SqlDataAdapter myDA = new SqlDataAdapter();

            //    DataTable dt = obj.GetData("SELECT * from tbl_Supplier order by SName");

            //    db_Entero_StockDataSet myDS = new db_Entero_StockDataSet();
            //    //The DataSet you created.
            //    //con = new SqlConnection();
            //    //cmd.Connection = con;
            //    //cmd.CommandText = "SELECT * from tbl_Customer order by FirstName";
            //    //cmd.CommandType = CommandType.Text;
            //    //myDA.SelectCommand = cmd;
            //    //myDA.Fill(myDS," tbl_Customer");
            //    rpt.SetDataSource(dt);
            //    customerReport frm = new customerReport();
            //    frm.crystalReportViewer1.ReportSource = rpt;
            //    frm.Visible = true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}




