using System;
using System.Data;
using System.Windows.Forms;
//using Entero_Stock.Report;
using Excel = Microsoft.Office.Interop.Excel;

namespace Entero_Stock.Forms
{
    public partial class ProductDetails : Form
    {
        GenericClass obj = new GenericClass();
        public int PId;
        public int DId;
        public string identifier;
        public ProductDetails()
        {
            InitializeComponent();
            //DataGridViewColumn column = grd_ProductList.Columns[1];
            //column.Width = 60;
            //grd_ProductList.Columns[1].Width = 100;
            //fixColumnWidth();
        }


        public ProductDetails(string formClassName)
        {
            identifier = formClassName;
            //grd_ProductList.Columns[1].Width = 50;
            InitializeComponent();
            //grd_ProductList.Columns[1].Width = 50;
            //fixColumnWidth();
        }

        public void fixColumnWidth()
        {
            grd_ProductList.Columns[1].Width = 50;

            //foreach (DataControlField column in grd_ProductList.Columns)
            //{
            //    column.ItemStyle.Width = Unit.Pixel(500);
            //}
        }
        private void btn_Export_Click(object sender, EventArgs e)
        {
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

                //  rowsTotal = grd_ProductList.RowCount - 1;
                rowsTotal = grd_ProductList.RowCount;
                colsTotal = grd_ProductList.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = grd_ProductList.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = grd_ProductList.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : ProductDetails.cs " + Environment.NewLine + "Function : btn_Export_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void txt_ProductId_TextChanged(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select ProductID, ProductCode, PName, CName, Features, ProductUnit, AlertQuantity, ProductImage,ProfitPercentage from tbl_Product p inner join tbl_Category c on c.Cid = p.Cid  where ProductCode like '" + txt_ProductId.Text + "%' order by ProductID";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        grd_ProductList.DataSource = dt;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : ProductDetails.cs " + Environment.NewLine + "Function : txt_ProductId_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : ProductDetails.cs " + Environment.NewLine + "Function : txt_ProductId_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select ProductID, ProductCode, PName, CName, Features, ProductUnit, AlertQuantity ,ProductImage,ProfitPercentage from tbl_Product p inner join tbl_Category c on c.Cid = p.Cid where CName like '" + txtCategory.Text + "%' order by PName";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        grd_ProductList.DataSource = dt;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : ProductDetails.cs " + Environment.NewLine + "Function : txtCategory_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : ProductDetails.cs " + Environment.NewLine + "Function : txtCategory_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProductname_TextChanged(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select ProductID,ProductCode,PName,CName,Features,ProductUnit,AlertQuantity ,ProductImage,ProfitPercentage from tbl_Product p inner join tbl_Category c on c.Cid=p.Cid where PName like '" + txtProductname.Text + "%' order by PName";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        grd_ProductList.DataSource = dt;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : ProductDetails.cs " + Environment.NewLine + "Function : txtProductname_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }

            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : ProductDetails.cs " + Environment.NewLine + "Function : txtProductname_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProductDetails_Load(object sender, EventArgs e)
        {
            //this.grd_ProductList.Columns["ProductID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            //this.grd_ProductList.Columns["ProductUnit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.grd_ProductList.Columns["AlertQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            //this.grd_ProductList.Columns["ProfitPercentage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            fillGrid();
        }

        private void fillGrid()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select ProductID,ProductCode,PName,CName,Features,ProductUnit,AlertQuantity,ProductImage,ProfitPercentage from tbl_Product p inner join tbl_Category c on c.Cid=p.Cid";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        grd_ProductList.DataSource = dt;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : ProductDetails.cs " + Environment.NewLine + "Function : fillGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : ProductDetails.cs " + Environment.NewLine + "Function : fillGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grd_ProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void grd_ProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        //t.Enabled = true;
        //        ProductCrystalReport rpt = new ProductCrystalReport();
        //        //The report you created.
        //        //cmd = new SqlCommand();
        //        // SqlDataAdapter myDA = new SqlDataAdapter();

        //        DataTable dt = obj.GetData("SELECT * from tbl_Product order by PName");

        //        db_Entero_StockDataSet myDS = new db_Entero_StockDataSet();
        //        //The DataSet you created.
        //        //con = new SqlConnection();
        //        //cmd.Connection = con;
        //        //cmd.CommandText = "SELECT * from tbl_Customer order by FirstName";
        //        //cmd.CommandType = CommandType.Text;
        //        //myDA.SelectCommand = cmd;
        //        //myDA.Fill(myDS," tbl_Customer");
        //        rpt.SetDataSource(dt);
        //        ProductReport frm = new ProductReport();
        //        frm.crystalReportViewer1.ReportSource = rpt;
        //        frm.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void grd_ProductList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Hide();
            bool isError = false;
            Exception sqlEx = new Exception();
            
            try
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow row = grd_ProductList.Rows[rowIndex];
                PId = Convert.ToInt16(row.Cells[0].Value);

                if (identifier == "DamageProductDetails")
                {
                    DamageProductDetails obj_DamageProductDetails = new DamageProductDetails();
                    obj_DamageProductDetails.Show();

                    //int rowIndex = e.RowIndex;


                    //DataGridViewRow row = grd_ProductList.Rows[rowIndex];
                    DId = Convert.ToInt16(row.Cells[0].Value);
                    obj_DamageProductDetails.txtproductid.Text = row.Cells[1].Value.ToString();
                    obj_DamageProductDetails.txtProductName.Text = row.Cells[2].Value.ToString();
                    // obj_DamageProductDetails.txtProductName.Text = row.Cells[4].Value.ToString();
                    //obj_DamageProductDetails.txtdamagequantity.Text = row.Cells[5].Value.ToString();
                    //obj_DamageProductDetails.btnUpdate.Enabled = true;
                    //obj_DamageProductDetails.btnDelete.Enabled = true;



                }
                else
                // if (identifier == "ProductDetails" || identifier == "Product")
                {
                    Product frm = new Product();
                    frm.Show();
                    frm.btnUpdate.Enabled = true;
                    frm.btnDelete.Enabled = true;
                    frm.btnNew.Enabled = false;
                    frm.btnSave.Enabled = false;
                    string str = "select * from tbl_Product where ProductID='" + PId + "'";
                    DataTable dt = obj.GetData(str, ref isError, ref sqlEx);

                    frm.txtProductName.Text = row.Cells[2].Value.ToString();
                    frm.txtproductid.Text = row.Cells[1].Value.ToString();
                    frm.cmbCategory.Text = row.Cells[3].Value.ToString();
                    frm.txtfeatures.Text = row.Cells[4].Value.ToString();
                    frm.cmbpdtunit.Text = row.Cells[5].Value.ToString();
                    frm.txt_Quantity.Text = row.Cells[6].Value.ToString();
                    frm.txt_Profit.Text = row.Cells[8].Value.ToString();
                    if (isError == false)
                    {

                    }
                    else
                    {
                        GenericClass.errorLogger(2, "Class : ProductDetails.cs " + Environment.NewLine + "Function : grd_ProductList_RowHeaderMouseClick() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : ProductDetails.cs " + Environment.NewLine + "Function : grd_ProductList_RowHeaderMouseClick() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ProductDetails_Activated(object sender, EventArgs e)
        {
            {
                this.Refresh();

                fillGrid();

            }
        }
    }
}


