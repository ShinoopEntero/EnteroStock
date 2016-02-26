using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Entero_Stock.Forms
{
    public partial class SalesAdmin : Form
    {
        GenericClass obj = new GenericClass();
        public int CId;
        public SalesAdmin()
        {
            InitializeComponent();
        }

        private void SalesAdmin_Load(object sender, EventArgs e)
        {
            bool isError1 = false;
            Exception sqlEx1 = new Exception();
            bool isError2 = false;
            Exception sqlEx2 = new Exception();
            try
            {
                auto();

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
                                GenericClass.errorLogger(2, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : SalesAdmin_Load() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx2.Message, sqlEx2.StackTrace.ToString());
                            }
                        }

                        if (isError1 == false && isError2 == false)
                        {
                            FillProductList(dtList);
                            fillTax();
                            FillBiller();
                            //string str = "select top 1 p.ProductID,p.ProductCode,p.PName,c.CName,pd.Price,p.ProfitPercentage from tbl_Product p inner join tbl_Category c on c.Cid = p.Cid  inner join tbl_PurchaseDetails pd on pd.ProductId = p.ProductID  inner join tbl_PurchaseHeader ph on ph.ReferenceNumber = pd.ReferenceNubmer  order by ph.PDate desc";
                            //FillProductList(str);

                        }
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : SalesAdmin_Load() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx1.Message, sqlEx1.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : SalesAdmin_Load() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void auto()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select max(SalesId) as SalesId from tbl_SalesHeader";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        txt_ReferenceNo.Text = "SA-" + GetUniqueKey(4) + dt.Rows[0]["SalesId"].ToString();
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : auto() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : auto() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public static string GetUniqueKey(int maxSize)
        {
            try
            {
                char[] chars = new char[62];
                chars = "123456789".ToCharArray();
                byte[] data = new byte[1];
                RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
                StringBuilder result = new StringBuilder(maxSize);

                foreach (byte b in data)
                {
                    result.Append(chars[b % (chars.Length)]);
                }
                return result.ToString();
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : GetUniqueKey() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }





        private void fillTax()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string strSel = "select TaxId,TaxType from tbl_Tax";
                DataTable dt = new DataTable();

                dt = obj.GetData(strSel, ref isError, ref sqlEx);
                cmb_Tax.DisplayMember = "TaxType";
                cmb_Tax.ValueMember = "TaxId";
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        cmb_Tax.DataSource = dt;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : fillTax() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : fillTax() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
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
                    //DataTable dt = obj.GetData(str);
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
                            if (isError1 == true)
                                GenericClass.errorLogger(2, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : FillProductList() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx1.Message, sqlEx1.StackTrace.ToString());
                            if (isError2 == true)
                                GenericClass.errorLogger(2, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : FillProductList() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx2.Message, sqlEx2.StackTrace.ToString());
                        }
                    }
                }
                if (isError1 == false && isError2 == false)
                {
                    grd_ProductList.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : FillProductList() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillBiller()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select u.UserId,u.FirstName,u.LastName from tbl_User u  inner join tbl_Login l on l.UserId = u.UserId inner join tbl_UserRole ur on ur.RoleId = l.RoleId where ur.Role = 'Biller'";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dt.Rows)
                        {
                            rw["FirstName"] = rw["FirstName"].ToString() + " ( " + rw["LastName"].ToString() + " )";
                        }


                        cmb_BillerName.DisplayMember = "FirstName";
                        cmb_BillerName.ValueMember = "UserId";
                        cmb_BillerName.DataSource = dt;

                        DataRow dr = dt.NewRow();
                        dr["FirstName"] = "--Select--";
                        dr["UserId"] = 0;
                        dt.Rows.InsertAt(dr, 0);
                        cmb_BillerName.SelectedIndex = 0;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : FillBiller() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : FillBiller() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
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
                                GenericClass.errorLogger(2, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : txt_ProductName_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx2.Message, sqlEx2.StackTrace.ToString());
                            }
                        }

                        FillProductList(dtList);

                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : txt_ProductName_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx1.Message, sqlEx1.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : txt_ProductName_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
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
                                GenericClass.errorLogger(2, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : txt_ProductCode_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx2.Message, sqlEx2.StackTrace.ToString());
                            }
                        }


                        FillProductList(dtList);

                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : txt_ProductCode_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx1.Message, sqlEx1.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : txt_ProductCode_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_AddToCart_Click(object sender, EventArgs e)
        {

            int row = 0;
            grd_PurchaseList.Rows.Add();
            row = grd_PurchaseList.Rows.Count - 1;
            grd_PurchaseList["PurchaseProductID", row].Value = txt_HidenProductId.Text;
            grd_PurchaseList["PurchseProductCode", row].Value = txt_HidenProdcutCode.Text;
            grd_PurchaseList["PurchasePName", row].Value = txtproductname.Text;
            grd_PurchaseList["PurchaseQuantity", row].Value = txt_PurchaseQty.Text;
            grd_PurchaseList["PurchaseUnitPrice", row].Value = txt_UnitPrice.Text;
            grd_PurchaseList["PurchaseTotalPrice", row].Value = txt_TotalAmount.Text;
            txt_ProductName.Focus();
            txt_HidenProductId.Text = "";
            txt_HidenProdcutCode.Text = "";
            txtproductname.Text = "";
            txt_PurchaseQty.Text = "";
            txt_UnitPrice.Text = "";
            txt_TotalAmount.Text = "";
            txt_Aval_Qty.Text = "";
            calcSubSum();
        }

        private void calcSubSum()
        {
            try
            {
                double sum = 0;
                for (int x = 0; x < grd_PurchaseList.Rows.Count; x++)
                {
                    sum += Convert.ToDouble(grd_PurchaseList.Rows[x].Cells["PurchaseTotalPrice"].Value);
                }
                txt_SubTotal.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : calcSubSum() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            bool isError1 = false;
            Exception sqlEx1 = new Exception();
            bool isError2 = false;
            Exception sqlEx2 = new Exception();
            bool isError3 = false;
            Exception sqlEx3 = new Exception();
            bool isError4 = false;
            Exception sqlEx4 = new Exception();
            try
            {
                string strIns = "insert into tbl_SalesHeader(ReferenceNumber,SDate,CustomerId,TotalAmount,Uid) values('" + txt_ReferenceNo.Text + "','" + dtpPurchaseDate.Value.Date + "','" + CId + "','" + txt_GrandTotal.Text + "','" + cmb_BillerName.SelectedValue + "')";
                obj.InsertData(strIns, ref isError1, ref sqlEx1);
                if (isError1 == false)
                {
                    for (int i = 0; i < grd_PurchaseList.Rows.Count; i++)
                    {
                        string strInsDetails = "INSERT INTO tbl_SalesDetails VALUES('" + txt_ReferenceNo.Text + "','" + grd_PurchaseList.Rows[i].Cells["PurchaseProductID"].Value + "','" + grd_PurchaseList.Rows[i].Cells["PurchaseQuantity"].Value + "','" + grd_PurchaseList.Rows[i].Cells["PurchaseUnitPrice"].Value + "')";
                        obj.InsertData(strInsDetails, ref isError2, ref sqlEx2);
                    }

                    if (isError2 == false)
                    {
                        MessageBox.Show("Successfully Inserted");

                        string str = "select ProductId from tbl_Product";
                        DataTable dt = obj.GetData(str, ref isError3, ref sqlEx3);
                        if (isError3 == false)
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
                                    DataTable dtt = obj.GetData(str, ref isError4, ref sqlEx4);
                                    if (isError4 == false)
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
                                        GenericClass.errorLogger(2, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : btn_Save_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx4.Message, sqlEx4.StackTrace.ToString());
                                    }
                                }

                                if (isError4 == false)
                                {
                                    FillProductList(dtList);

                                    PrintReceipt();

                                    ExportToPdfDemo();
                                    //  PrintReceipt();
                                    ClearFields();
                                }
                            }
                        }
                        else
                        {
                            GenericClass.errorLogger(2, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : btn_Save_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx3.Message, sqlEx3.StackTrace.ToString());
                        }
                    }
                    else
                    {
                        GenericClass.errorLogger(2, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : btn_Save_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx2.Message, sqlEx2.StackTrace.ToString());
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : btn_Save_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx1.Message, sqlEx1.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : btn_Save_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintReceipt()
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();

                PrintDocument printDocument = new PrintDocument();

                printDialog.Document = printDocument; //add the document to the dialog box...        

                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing

                //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

                DialogResult result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    printDocument.Print();

                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : PrintReceipt() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                // int total = 0;
                float cash = float.Parse(txt_GrandTotal.Text.Substring(1, 5));
                //float change = 0.00f;

                //this prints the reciept

                Graphics graphic = e.Graphics;

                System.Drawing.Font font = new System.Drawing.Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

                float fontHeight = font.GetHeight();

                int startX = 10;
                int startY = 10;
                int offset = 50;

                graphic.DrawString("  Entero SuperMarket ", new System.Drawing.Font("Courier New", 18), new SolidBrush(System.Drawing.Color.Black), startX, startY);
                string top = "Item Name".PadRight(15) + "Qty".PadRight(5) + "Price".PadRight(10) + "Total Price";
                graphic.DrawString(top, font, new SolidBrush(System.Drawing.Color.Black), startX, startY + offset);
                offset = offset + (int)fontHeight; //make the spacing consistent
                graphic.DrawString("----------------------------------", font, new SolidBrush(System.Drawing.Color.Black), startX, startY + offset);
                offset = offset + (int)fontHeight + 5; //make the spacing consistent

                //float totalprice = 0.00f;
                if (grd_PurchaseList.Rows.Count > 0)
                {
                    foreach (DataGridViewRow rw in grd_PurchaseList.Rows)
                    {
                        //create the string to print on the reciept
                        string productName = rw.Cells["PurchasePName"].Value.ToString().PadRight(15) + rw.Cells["PurchaseQuantity"].Value.ToString().PadRight(5) + rw.Cells["PurchaseUnitPrice"].Value.ToString().PadRight(10) + rw.Cells["PurchaseTotalPrice"].Value.ToString();
                        graphic.DrawString(productName, font, new SolidBrush(System.Drawing.Color.Black), startX, startY + offset);
                        offset = offset + (int)fontHeight + 5; //make the spacing consistent

                    }

                }

                offset = offset + 20; //make some room so that the total stands out.

                graphic.DrawString("Total to pay ".PadRight(30) + String.Format("{0:c}", txt_GrandTotal.Text), new System.Drawing.Font("Courier New", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + offset);

                offset = offset + 30; //make some room so that the total stands out.
                graphic.DrawString("  -----Thank you-----  ,", font, new SolidBrush(System.Drawing.Color.Black), startX, startY + offset);
                offset = offset + 15;
                graphic.DrawString("       Visit Again...!", font, new SolidBrush(System.Drawing.Color.Black), startX, startY + offset);
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : CreateReceipt() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void ExportToPdfDemo()
        {

            try
            {

                Document document = new Document(PageSize.A4);
                // string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\PURCHASE REPORTS\";
                string appPath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Sales Report\";
                if (Directory.Exists(appPath) == false)
                {
                    Directory.CreateDirectory(appPath);
                }
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(appPath + "/" + txt_ReferenceNo.Text + ".pdf", FileMode.Create));
                document.Open();
                PdfContentByte cb = writer.DirectContent;
                cb.SetLineWidth(2.0f);   // Make a bit thicker than 1.0 default
                cb.SetGrayStroke(0.95f); // 1 = black, 0 = white
                cb.MoveTo(20, document.Top - 30f);
                cb.LineTo(400, document.Top - 30f);
                cb.Stroke();

                PdfPTable Ttable = new PdfPTable(1);
                float[] widths = new float[] { 1f };
                Ttable.SetWidths(widths);


                PdfPCell numeroCell = new PdfPCell(new Phrase("Reference No: " + txt_ReferenceNo.Text));
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                Ttable.AddCell(numeroCell);


                numeroCell = new PdfPCell(new Phrase("Date: " + dtpPurchaseDate.Text));
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                Ttable.AddCell(numeroCell);

                numeroCell = new PdfPCell(new Phrase("Customer Code: " + txt_CustomerCode.Text));
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                Ttable.AddCell(numeroCell);



                numeroCell = new PdfPCell(new Phrase("Customer Name: " + txt_CustomerName.Text));
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                Ttable.AddCell(numeroCell);




                numeroCell = new PdfPCell(new Phrase(""));
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                Ttable.AddCell(numeroCell);


                numeroCell = new PdfPCell(new Phrase(""));
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                Ttable.AddCell(numeroCell);




                PdfPTable table = new PdfPTable(5);
                widths = new float[] { 1f, 1f, 1f, 1f, 1f };
                table.SetWidths(widths);
                numeroCell = new PdfPCell(new Phrase("Product Code"));
                numeroCell.BackgroundColor = new iTextSharp.text.Color(1, 159, 222);
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                table.AddCell(numeroCell);

                numeroCell = new PdfPCell(new Phrase("Product Name"));
                numeroCell.BackgroundColor = new iTextSharp.text.Color(1, 159, 222);
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                table.AddCell(numeroCell);


                numeroCell = new PdfPCell(new Phrase("Unit Price"));
                numeroCell.BackgroundColor = new iTextSharp.text.Color(1, 159, 222);
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                table.AddCell(numeroCell);


                numeroCell = new PdfPCell(new Phrase("Quantity"));
                numeroCell.BackgroundColor = new iTextSharp.text.Color(1, 159, 222);
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                table.AddCell(numeroCell);



                numeroCell = new PdfPCell(new Phrase("Total Price"));
                numeroCell.BackgroundColor = new iTextSharp.text.Color(1, 159, 222);
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                table.AddCell(numeroCell);

                PdfPCell cell;
                foreach (DataGridViewRow row in grd_PurchaseList.Rows)
                {

                    cell = new PdfPCell(new Phrase(row.Cells["PurchseProductCode"].Value.ToString()));
                    cell.Border = 0;
                    cell.HorizontalAlignment = 0;
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase(row.Cells["PurchasePName"].Value.ToString()));
                    cell.Border = 0;
                    cell.HorizontalAlignment = 0;
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase(row.Cells["PurchaseQuantity"].Value.ToString()));
                    cell.Border = 0;
                    cell.HorizontalAlignment = 0;
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase(row.Cells["PurchaseUnitPrice"].Value.ToString()));
                    cell.Border = 0;
                    cell.HorizontalAlignment = 0;
                    table.AddCell(cell);


                    cell = new PdfPCell(new Phrase(row.Cells["PurchaseTotalPrice"].Value.ToString()));
                    cell.Border = 0;
                    cell.HorizontalAlignment = 0;
                    table.AddCell(cell);

                }


                for (int i = 0; i < 23; i++)
                {
                    cell = new PdfPCell(new Phrase(""));
                    cell.Border = 0;
                    cell.HorizontalAlignment = 0;
                    table.AddCell(cell);
                }

                cell = new PdfPCell(new Phrase("Tax Amount :"));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                table.AddCell(cell);

                double taxAmount = Convert.ToDouble(txt_GrandTotal.Text) - Convert.ToDouble(txt_SubTotal.Text);


                cell = new PdfPCell(new Phrase("" + taxAmount));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                table.AddCell(cell);



                for (int i = 0; i < 3; i++)
                {
                    cell = new PdfPCell(new Phrase(""));
                    cell.Border = 0;
                    cell.HorizontalAlignment = 0;
                    table.AddCell(cell);
                }


                cell = new PdfPCell(new Phrase("Total Amount :"));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                table.AddCell(cell);


                cell = new PdfPCell(new Phrase(txt_GrandTotal.Text));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                table.AddCell(cell);


                //table.SpacingBefore = 20f;
                //table.SpacingAfter = 30f;

                document.Add(Ttable);
                Ttable.SpacingAfter = 40f;
                document.Add(table);
                document.Close();

            }
            catch (DocumentException de)
            {
                int errCode = GenericClass.assignErrCode(de);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : ExportToPdfDemo() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + de.Message, de.StackTrace.ToString());
                MessageBox.Show(de.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ioe)
            {
                int errCode = GenericClass.assignErrCode(ioe);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : ExportToPdfDemo() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ioe.Message, ioe.StackTrace.ToString());
                MessageBox.Show(ioe.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : ExportToPdfDemo() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txt_GrandTotal.Text = "";
            txt_SubTotal.Text = "";
            txt_CustomerCode.Text = "C-";
            txt_CustomerName.Text = "";
            txt_ReferenceNo.Text = "";
            auto();
            grd_PurchaseList.Rows.Clear();
        }

        private void btn_CustomerSearch_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string strSel = "select CustomerId,FirstName,LastName from tbl_Customer where CustomerCode like '" + txt_CustomerCode.Text + "%'";
                DataTable dt = obj.GetData(strSel, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        dt.Rows[0]["FirstName"] = dt.Rows[0]["FirstName"] + " " + dt.Rows[0]["LastName"];
                        txt_CustomerName.Text = dt.Rows[0]["FirstName"].ToString();
                        CId = Convert.ToInt32(dt.Rows[0]["CustomerId"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Please enter correct customer code", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : btn_CustomerSearch_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : btn_CustomerSearch_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grd_ProductList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int i = e.RowIndex;//get the Row Index      
                DataGridViewRow row = grd_ProductList.Rows[i];

                txtproductname.Text = row.Cells[2].Value.ToString();
                txt_HidenProductId.Text = row.Cells[0].Value.ToString();
                txt_HidenProdcutCode.Text = row.Cells[1].Value.ToString();
                txt_Aval_Qty.Text = row.Cells[6].Value.ToString();
                txt_UnitPrice.Text = row.Cells[4].Value.ToString();
                txt_PurchaseQty.Focus();
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : grd_ProductList_RowHeaderMouseClick() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grd_PurchaseList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == grd_PurchaseList.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    grd_PurchaseList.Rows.Remove(grd_PurchaseList.Rows[e.RowIndex]);
                    calcSubSum();
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : grd_PurchaseList_CellContentClick() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_PurchaseQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_PurchaseQty.Text != "" && Convert.ToInt32(txt_Aval_Qty.Text) < Convert.ToInt32(txt_PurchaseQty.Text))
                {
                    MessageBox.Show("Sale Quantity should be less than available quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_PurchaseQty.Text = "";
                    txt_PurchaseQty.Focus();
                }
                if (txt_UnitPrice.Text != "" && txt_PurchaseQty.Text != "")
                {
                    txt_TotalAmount.Text = (Convert.ToDouble(txt_UnitPrice.Text) * Convert.ToDouble(txt_PurchaseQty.Text)).ToString();
                }
                else
                {
                    txt_TotalAmount.Text = "";

                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : txt_PurchaseQty_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_GrandTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_SubTotal_TextChanged(object sender, EventArgs e)
        {
            GrandTotal();
        }
        private void GrandTotal()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select Percentage from tbl_Tax where TaxId= '" + cmb_Tax.SelectedValue + "'";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var taxRate = dt.Rows[0]["Percentage"].ToString();
                        if (txt_SubTotal.Text != "")
                        {
                            txt_GrandTotal.Text = (((Convert.ToDouble(taxRate) / 100) * Convert.ToDouble(txt_SubTotal.Text)) + Convert.ToDouble(txt_SubTotal.Text)).ToString();
                        }
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : GrandTotal() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SalesAdmin.cs " + Environment.NewLine + "Function : GrandTotal() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmb_Tax_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrandTotal();
        }
    }
}
