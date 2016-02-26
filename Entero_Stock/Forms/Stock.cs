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

    public partial class Stock : Form
    {
        GenericClass obj = new GenericClass();
        public Stock()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            bool isError1 = false;
            Exception sqlEx1 = new Exception();
            bool isError2 = false;
            Exception sqlEx2 = new Exception();
            try
            {
                string str = "select ProductId from tbl_Product";
                DataTable dt = obj.GetData(str, ref isError1, ref sqlEx1);
                if (isError1 == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataTable dtList = new DataTable();
                        DataColumn dc = new DataColumn("ProductId", typeof(int));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("ProductCode", typeof(string));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("PName", typeof(string));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("CName", typeof(string));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("Price", typeof(double));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("ProfitPercentage", typeof(double));
                        dtList.Columns.Add(dc);
                        dtList.AcceptChanges();

                        foreach (DataRow rw in dt.Rows)
                        {
                            str = "select top 1 p.ProductID,p.ProductCode,p.PName,c.CName,pd.Price,p.ProfitPercentage from tbl_Product p inner join tbl_Category c on c.Cid = p.Cid  inner join tbl_PurchaseDetails pd on pd.ProductId = p.ProductID  inner join tbl_PurchaseHeader ph on ph.ReferenceNumber = pd.ReferenceNumber where p.ProductId='" + rw["ProductId"].ToString() + "' order by ph.PDate desc";
                            DataTable dtt = obj.GetData(str, ref isError2, ref sqlEx2);
                            if (isError2 == false)
                            {
                                if (dtt.Rows.Count > 0)
                                {
                                    DataRow row = dtList.NewRow();
                                    row["ProductId"] = Convert.ToInt32(dtt.Rows[0]["ProductID"].ToString());
                                    row["ProductCode"] = dtt.Rows[0]["ProductCode"].ToString();
                                    row["PName"] = dtt.Rows[0]["PName"].ToString();
                                    row["CName"] = dtt.Rows[0]["CName"].ToString();
                                    row["Price"] = Convert.ToDouble(dtt.Rows[0]["Price"].ToString());
                                    row["ProfitPercentage"] = Convert.ToDouble(dtt.Rows[0]["ProfitPercentage"].ToString());
                                    dtList.Rows.Add(row);
                                }
                            }
                            else
                            {
                                GenericClass.errorLogger(2, "Class : Stock.cs " + Environment.NewLine + "Function : Stock_Load() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx2.Message, sqlEx2.StackTrace.ToString());
                            }
                        }
                        //if (isError1 == false && isError2 == false)
                        //{
                            FillProductList(dtList);
                       // }
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Stock.cs " + Environment.NewLine + "Function : Stock_Load() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx1.Message, sqlEx1.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Stock.cs " + Environment.NewLine + "Function : Stock_Load() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void FillProductList(DataTable dt)
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

                            rw["Price"] = (Convert.ToDouble(rw["Price"].ToString()) * (Convert.ToDouble(rw["ProfitPercentage"].ToString()) / 100)) + Convert.ToDouble(rw["Price"].ToString());
                        }
                        else
                        {
                            if(isError1 == true)
                                GenericClass.errorLogger(2, "Class : Stock.cs " + Environment.NewLine + "Function : FillProductList() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx1.Message, sqlEx1.StackTrace.ToString());
                            if(isError2 == true)
                                GenericClass.errorLogger(2, "Class : Stock.cs " + Environment.NewLine + "Function : FillProductList() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx2.Message, sqlEx2.StackTrace.ToString());
                        }
                    }
                    if (isError1 == false && isError2 == false)
                    {
                        grd_ProductList.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Stock.cs " + Environment.NewLine + "Function : FillProductList() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_ProductName_TextChanged(object sender, EventArgs e)
        {
            bool isError1 = false;
            Exception sqlEx1 = new Exception();
            bool isError2 = false;
            Exception sqlEx2 = new Exception();
            try
            {
                string str = "select ProductId from tbl_Product where PName like '" + txt_ProductName.Text + "%' ";
                DataTable dt = obj.GetData(str, ref isError1, ref sqlEx1);
                if (isError1 == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataTable dtList = new DataTable();
                        DataColumn dc = new DataColumn("ProductId", typeof(int));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("ProductCode", typeof(string));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("PName", typeof(string));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("CName", typeof(string));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("Price", typeof(double));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("ProfitPercentage", typeof(double));
                        dtList.Columns.Add(dc);
                        dtList.AcceptChanges();

                        foreach (DataRow rw in dt.Rows)
                        {
                            str = "select top 1 p.ProductID,p.ProductCode,p.PName,c.CName,pd.Price,p.ProfitPercentage from tbl_Product p inner join tbl_Category c on c.Cid = p.Cid  inner join tbl_PurchaseDetails pd on pd.ProductId = p.ProductID  inner join tbl_PurchaseHeader ph on ph.ReferenceNumber = pd.ReferenceNubmer where p.ProductId='" + rw["ProductId"].ToString() + "' order by ph.PDate desc";
                            DataTable dtt = obj.GetData(str, ref isError2, ref sqlEx2);
                            if (isError2 == false)
                            {
                                if (dtt.Rows.Count > 0)
                                {
                                    DataRow row = dtList.NewRow();
                                    row["ProductId"] = Convert.ToInt32(dtt.Rows[0]["ProductID"].ToString());
                                    row["ProductCode"] = dtt.Rows[0]["ProductCode"].ToString();
                                    row["PName"] = dtt.Rows[0]["PName"].ToString();
                                    row["CName"] = dtt.Rows[0]["CName"].ToString();
                                    row["Price"] = Convert.ToDouble(dtt.Rows[0]["Price"].ToString());
                                    row["ProfitPercentage"] = Convert.ToDouble(dtt.Rows[0]["ProfitPercentage"].ToString());
                                    dtList.Rows.Add(row);
                                }
                            }
                            else
                            {
                                GenericClass.errorLogger(2, "Class : Stock.cs " + Environment.NewLine + "Function : txt_ProductName_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx2.Message, sqlEx2.StackTrace.ToString());
                            }
                        }
                        if (isError2 == false)
                        {
                            FillProductList(dtList);
                        }
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Stock.cs " + Environment.NewLine + "Function : txt_ProductName_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx1.Message, sqlEx1.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Stock.cs " + Environment.NewLine + "Function : txt_ProductName_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txt_ProductCode_TextChanged(object sender, EventArgs e)
        {
            bool isError1 = false;
            Exception sqlEx1 = new Exception();
            bool isError2 = false;
            Exception sqlEx2 = new Exception();
            try
            {


                string str = "select ProductId from tbl_Product where ProductCode like'" + txt_ProductCode.Text + "%'";
                DataTable dt = obj.GetData(str, ref isError1, ref sqlEx1);
                if (isError1 == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataTable dtList = new DataTable();
                        DataColumn dc = new DataColumn("ProductId", typeof(int));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("ProductCode", typeof(string));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("PName", typeof(string));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("CName", typeof(string));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("Price", typeof(double));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("ProfitPercentage", typeof(double));
                        dtList.Columns.Add(dc);
                        dtList.AcceptChanges();

                        foreach (DataRow rw in dt.Rows)
                        {
                            str = "select top 1 p.ProductID,p.ProductCode,p.PName,c.CName,pd.Price,p.ProfitPercentage from tbl_Product p inner join tbl_Category c on c.Cid = p.Cid  inner join tbl_PurchaseDetails pd on pd.ProductId = p.ProductID  inner join tbl_PurchaseHeader ph on ph.ReferenceNumber = pd.ReferenceNubmer where p.ProductId='" + rw["ProductId"].ToString() + "' order by ph.PDate desc";
                            DataTable dtt = obj.GetData(str, ref isError2, ref sqlEx2);
                            if (isError2 == false)
                            {
                                if (dtt.Rows.Count > 0)
                                {
                                    DataRow row = dtList.NewRow();
                                    row["ProductId"] = Convert.ToInt32(dtt.Rows[0]["ProductID"].ToString());
                                    row["ProductCode"] = dtt.Rows[0]["ProductCode"].ToString();
                                    row["PName"] = dtt.Rows[0]["PName"].ToString();
                                    row["CName"] = dtt.Rows[0]["CName"].ToString();
                                    row["Price"] = Convert.ToDouble(dtt.Rows[0]["Price"].ToString());
                                    row["ProfitPercentage"] = Convert.ToDouble(dtt.Rows[0]["ProfitPercentage"].ToString());
                                    dtList.Rows.Add(row);
                                }
                            }
                            else
                            {
                                GenericClass.errorLogger(2, "Class : Stock.cs " + Environment.NewLine + "Function : txt_ProductCode_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx2.Message, sqlEx2.StackTrace.ToString());
                            }
                        }

                        if (isError2 == false)
                        {
                            FillProductList(dtList);
                        }
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Stock.cs " + Environment.NewLine + "Function : txt_ProductCode_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx1.Message, sqlEx1.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Stock.cs " + Environment.NewLine + "Function : txt_ProductCode_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool isError1 = false;
            Exception sqlEx1 = new Exception();
            bool isError2 = false;
            Exception sqlEx2 = new Exception();
            try
            {
                string str = "select p.ProductID from tbl_Product p inner join tbl_Category c on c.Cid = p.Cid where c.CName like '" + txt_Category.Text + "%'";

                DataTable dt = obj.GetData(str, ref isError1, ref sqlEx1);
                if (isError1 == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataTable dtList = new DataTable();
                        DataColumn dc = new DataColumn("ProductId", typeof(int));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("ProductCode", typeof(string));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("PName", typeof(string));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("CName", typeof(string));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("Price", typeof(double));
                        dtList.Columns.Add(dc);
                        dc = new DataColumn("ProfitPercentage", typeof(double));
                        dtList.Columns.Add(dc);
                        dtList.AcceptChanges();

                        foreach (DataRow rw in dt.Rows)
                        {
                            str = "select top 1 p.ProductID,p.ProductCode,p.PName,c.CName,pd.Price,p.ProfitPercentage from tbl_Product p inner join tbl_Category c on c.Cid = p.Cid  inner join tbl_PurchaseDetails pd on pd.ProductId = p.ProductID  inner join tbl_PurchaseHeader ph on ph.ReferenceNumber = pd.ReferenceNubmer where p.ProductId='" + rw["ProductId"].ToString() + "' order by ph.PDate desc";
                            DataTable dtt = obj.GetData(str, ref isError2, ref sqlEx2);
                            if (isError2 == false)
                            {
                                if (dtt.Rows.Count > 0)
                                {
                                    DataRow row = dtList.NewRow();
                                    row["ProductId"] = Convert.ToInt32(dtt.Rows[0]["ProductID"].ToString());
                                    row["ProductCode"] = dtt.Rows[0]["ProductCode"].ToString();
                                    row["PName"] = dtt.Rows[0]["PName"].ToString();
                                    row["CName"] = dtt.Rows[0]["CName"].ToString();
                                    row["Price"] = Convert.ToDouble(dtt.Rows[0]["Price"].ToString());
                                    row["ProfitPercentage"] = Convert.ToDouble(dtt.Rows[0]["ProfitPercentage"].ToString());
                                    dtList.Rows.Add(row);
                                }
                            }
                            else
                            {
                                GenericClass.errorLogger(2, "Class : Stock.cs " + Environment.NewLine + "Function : textBox1_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx2.Message, sqlEx2.StackTrace.ToString());
                            }
                        }

                        if (isError2 == false)
                        {
                            FillProductList(dtList);
                        }
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Stock.cs " + Environment.NewLine + "Function : textBox1_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx1.Message, sqlEx1.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Stock.cs " + Environment.NewLine + "Function : textBox1_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }

}
