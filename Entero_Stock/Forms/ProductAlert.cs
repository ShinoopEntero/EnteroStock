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
    public partial class ProductAlert : Form
    {
        GenericClass obj = new GenericClass();
        public ProductAlert()
        {
            InitializeComponent();
        }

        private void ProductAlert_Load(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                this.grd_ProductList.Columns["AlertQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                this.grd_ProductList.Columns["AvailableQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                string str = "select p.ProductID,p.ProductCode,p.PName,p.AlertQuantity,c.CName from tbl_Product p inner join tbl_Category c on c.Cid = p.Cid";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        FillGrid(dt);
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : ProductAlert.cs " + Environment.NewLine + "Function : ProductAlert_Load() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : ProductAlert.cs " + Environment.NewLine + "Function : ProductAlert_Load() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillGrid(DataTable dt)
        {
            bool isError1 = false;
            Exception sqlEx1 = new Exception();
            bool isError2 = false;
            Exception sqlEx2 = new Exception();
            try
            {
                if (dt.Rows.Count > 0)
                {
                    DataColumn dc = new DataColumn("Quantity", typeof(double));
                    dt.Columns.Add(dc);

                    foreach (DataRow rw in dt.Rows)
                    {
                        string strPQty = "select COALESCE(SUM(Quantity), 0) as Qty from tbl_PurchaseDetails where ProductId ='" + rw["ProductID"] + "'";
                        DataTable dtp = obj.GetData(strPQty, ref isError1, ref sqlEx1);

                        string strSQty = "select COALESCE(SUM(Quantity), 0) as Qty from tbl_SalesDetails where ProductId ='" + rw["ProductID"] + "'";
                        DataTable dts = obj.GetData(strSQty, ref isError2, ref sqlEx2);

                        if (isError1 == false && isError2 == false)
                        {
                            if (dtp.Rows.Count > 0 && dts.Rows.Count > 0)
                            {
                                rw["Quantity"] = Convert.ToInt32(dtp.Rows[0]["Qty"].ToString()) - Convert.ToInt32(dts.Rows[0]["Qty"].ToString());

                            }
                            if (Convert.ToInt32(rw["Quantity"].ToString()) > Convert.ToInt32(rw["AlertQuantity"].ToString()))
                            {
                                rw.Delete();
                            }
                        }
                        else
                        {
                            if(isError1 == true)
                                GenericClass.errorLogger(2, "Class : ProductAlert.cs " + Environment.NewLine + "Function : FillGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx1.Message, sqlEx1.StackTrace.ToString());
                            if(isError2 == true)
                                GenericClass.errorLogger(2, "Class : ProductAlert.cs " + Environment.NewLine + "Function : FillGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx2.Message, sqlEx2.StackTrace.ToString());
                        }
                    }
                    grd_ProductList.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : ProductAlert.cs " + Environment.NewLine + "Function : FillGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txt_ProductName_TextChanged(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select p.ProductID,p.ProductCode,p.PName,p.AlertQuantity,c.CName from tbl_Product p inner join tbl_Category c on c.Cid = p.Cid where PName like '" + txt_ProductName.Text + "%' order by PName";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        FillGrid(dt);
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : ProductAlert.cs " + Environment.NewLine + "Function : txt_ProductName_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : ProductAlert.cs " + Environment.NewLine + "Function : txt_ProductName_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_ProductCode_TextChanged(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select p.ProductID,p.ProductCode,p.PName,p.AlertQuantity,c.CName from tbl_Product p inner join tbl_Category c on c.Cid = p.Cid where ProductCode like'" + txt_ProductCode.Text + "%' order by PName";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        FillGrid(dt);
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : ProductAlert.cs " + Environment.NewLine + "Function : txt_ProductCode_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : ProductAlert.cs " + Environment.NewLine + "Function : txt_ProductCode_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
