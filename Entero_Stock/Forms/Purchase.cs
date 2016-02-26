using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Entero_Stock.Forms
{
    public partial class Purchase : Form
    {
        GenericClass obj = new GenericClass();
        DataTable dtCart = new DataTable();
        public Purchase()
        {
            InitializeComponent();
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                auto();
                FillSupplier();
                string str = "select ProductId from tbl_Product";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
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
                        dc = new DataColumn("AlertQuantity", typeof(double));
                        dtList.Columns.Add(dc);
                        dtList.AcceptChanges();

                        foreach (DataRow rw in dt.Rows)
                        {
                            str = "select top 1 ProductID,ProductCode,PName,CName,AlertQuantity from tbl_Product p inner join tbl_Category c on c.Cid=p.Cid  where p.ProductId='" + rw["ProductId"].ToString() + "' order by PName";
                            DataTable dtt = obj.GetData(str, ref isError, ref sqlEx);
                            if (isError == false)
                            {
                                if (dtt.Rows.Count > 0)
                                {
                                    DataRow row = dtList.NewRow();
                                    row["ProductId"] = Convert.ToInt32(dtt.Rows[0]["ProductID"].ToString());
                                    row["ProductCode"] = dtt.Rows[0]["ProductCode"].ToString();
                                    row["PName"] = dtt.Rows[0]["PName"].ToString();
                                    row["CName"] = dtt.Rows[0]["CName"].ToString();
                                    row["AlertQuantity"] = Convert.ToDouble(dtt.Rows[0]["AlertQuantity"].ToString());
                                    dtList.Rows.Add(row);
                                }
                            }
                            else
                            {
                                GenericClass.errorLogger(2, "Class : Purchase.cs " + Environment.NewLine + "Function : Purchase_Load() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                            }
                        }

                        FillProductList(dtList);



                        fillTax();
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Purchase.cs " + Environment.NewLine + "Function : Purchase_Load() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : Purchase_Load() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        cmb_Tax.DisplayMember = "TaxType";
                        cmb_Tax.ValueMember = "TaxId";
                        cmb_Tax.DataSource = dt;


                        DataRow dr = dt.NewRow();
                        dr["TaxType"] = "--Select--";
                        dr["TaxId"] = 0;
                        dt.Rows.InsertAt(dr, 0);
                        cmb_Tax.SelectedIndex = 0;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Purchase.cs " + Environment.NewLine + "Function : fillTax() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : fillTax() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FillSupplier()
        {

            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select SupplierId,SName,SCompany from tbl_Supplier";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dt.Rows)
                        {
                            rw["SName"] = rw["SName"].ToString() + " ( " + rw["SCompany"].ToString() + " )";
                        }


                        cmb_SupplierName.DisplayMember = "SName";
                        cmb_SupplierName.ValueMember = "SupplierId";
                        cmb_SupplierName.DataSource = dt;

                        DataRow dr = dt.NewRow();
                        dr["SName"] = "--Select--";
                        dr["SupplierId"] = 0;
                        dt.Rows.InsertAt(dr, 0);
                        cmb_SupplierName.SelectedIndex = 0;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Purchase.cs " + Environment.NewLine + "Function : FillSupplier() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : FillSupplier() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void auto()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select max(PurchaseId) as PurchaseId from tbl_PurchaseHeader";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        txt_ReferenceNo.Text = "PR-" + GetUniqueKey(4) + dt.Rows[0]["PurchaseId"].ToString();
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Purchase.cs " + Environment.NewLine + "Function : auto() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : auto() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
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
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : GetUniqueKey() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
        private void FillProductList(DataTable dt)
        {
            bool isError1 = false, isError2 = false;
            Exception sqlEx1 = new Exception();
            Exception sqlEx2 = new Exception();
            try
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
                    }
                    else
                    {
                        if (isError1 == true)
                            GenericClass.errorLogger(2, "Class : Purchase.cs " + Environment.NewLine + "Function : FillProductList() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx1.Message, sqlEx1.StackTrace.ToString());
                        if (isError2 == true)
                            GenericClass.errorLogger(2, "Class : Purchase.cs " + Environment.NewLine + "Function : FillProductList() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx2.Message, sqlEx2.StackTrace.ToString());

                    }
                }
                grd_ProductList.DataSource = dt;
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : FillProductList() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txt_ProductName_TextChanged(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {


                string str = "select ProductId from tbl_Product where PName like '" + txt_ProductName.Text + "%' order by PName";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
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
                        dc = new DataColumn("AlertQuantity", typeof(double));
                        dtList.Columns.Add(dc);
                        dtList.AcceptChanges();

                        foreach (DataRow rw in dt.Rows)
                        {
                            str = "select top 1 ProductID,ProductCode,PName,CName,AlertQuantity from tbl_Product p inner join tbl_Category c on c.Cid=p.Cid  where p.ProductId='" + rw["ProductId"].ToString() + "' order by PName";
                            DataTable dtt = obj.GetData(str, ref isError, ref sqlEx);
                            if (isError == false)
                            {
                                if (dtt.Rows.Count > 0)
                                {
                                    DataRow row = dtList.NewRow();
                                    row["ProductId"] = Convert.ToInt32(dtt.Rows[0]["ProductID"].ToString());
                                    row["ProductCode"] = dtt.Rows[0]["ProductCode"].ToString();
                                    row["PName"] = dtt.Rows[0]["PName"].ToString();
                                    row["CName"] = dtt.Rows[0]["CName"].ToString();
                                    row["AlertQuantity"] = Convert.ToDouble(dtt.Rows[0]["AlertQuantity"].ToString());
                                    dtList.Rows.Add(row);
                                }
                            }
                            else
                            {
                                GenericClass.errorLogger(2, "Class : Purchase.cs " + Environment.NewLine + "Function : Purchase_Load() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                            }
                        }

                        FillProductList(dtList);

                    }
                }
            }





            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : txt_ProductName_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_ProductCode_TextChanged(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select ProductId from tbl_Product where ProductCode like'" + txt_ProductCode.Text + "%' order by PName";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
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
                        dc = new DataColumn("AlertQuantity", typeof(double));
                        dtList.Columns.Add(dc);
                        dtList.AcceptChanges();

                        foreach (DataRow rw in dt.Rows)
                        {
                            str = "select top 1 ProductID,ProductCode,PName,CName,AlertQuantity from tbl_Product p inner join tbl_Category c on c.Cid=p.Cid  where p.ProductId='" + rw["ProductId"].ToString() + "' order by PName";
                            DataTable dtt = obj.GetData(str, ref isError, ref sqlEx);
                            if (isError == false)
                            {
                                if (dtt.Rows.Count > 0)
                                {
                                    DataRow row = dtList.NewRow();
                                    row["ProductId"] = Convert.ToInt32(dtt.Rows[0]["ProductID"].ToString());
                                    row["ProductCode"] = dtt.Rows[0]["ProductCode"].ToString();
                                    row["PName"] = dtt.Rows[0]["PName"].ToString();
                                    row["CName"] = dtt.Rows[0]["CName"].ToString();
                                    row["AlertQuantity"] = Convert.ToDouble(dtt.Rows[0]["AlertQuantity"].ToString());
                                    dtList.Rows.Add(row);
                                }
                            }
                            else
                            {
                                GenericClass.errorLogger(2, "Class : Purchase.cs " + Environment.NewLine + "Function : Purchase_Load() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                            }
                        }

                        FillProductList(dtList);

                    }
                }
            }

            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : txt_ProductCode_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
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
                txt_Aval_Qty.Text = row.Cells["AvailableQuantity"].Value.ToString();
                txt_UnitPrice.Focus();
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : grd_ProductList_RowHeaderMouseClick() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txt_PurchaseQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_UnitPrice.Text != "" && txt_PurchaseQty.Text != "")
                {
                    txt_TotalAmount.Text = (Convert.ToInt32(txt_UnitPrice.Text) * Convert.ToInt32(txt_PurchaseQty.Text)).ToString();
                }
                else
                {
                    txt_TotalAmount.Text = "";

                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : txt_PurchaseQty_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreateDatatable()
        {


        }
        private void Button3_Click(object sender, EventArgs e)
        {
            try
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

                calcSubSum();
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : Button3_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void calcSubSum()
        {
            try
            {
                int sum = 0;
                for (int x = 0; x < grd_PurchaseList.Rows.Count; x++)
                {
                    sum += Convert.ToInt32(grd_PurchaseList.Rows[x].Cells["PurchaseTotalPrice"].Value);
                }
                txt_SubTotal.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : calcSubSum() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





        }
        private void grd_PurchaseList_CellClick(object sender, DataGridViewCellEventArgs e)
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
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : grd_PurchaseList_CellClick() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void cmb_Tax_SelectedIndexChanged(object sender, EventArgs e)
        {


            GrandTotal();

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
                    GenericClass.errorLogger(2, "Class : Purchase.cs " + Environment.NewLine + "Function : GrandTotal() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : GrandTotal() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            bool isError1 = false;
            Exception sqlEx1 = new Exception();
            bool isError2 = false;
            Exception sqlEx2 = new Exception();
            try
            {
                if (cmb_SupplierName.Text == "--Select--")
                {
                    MessageBox.Show("Please select supplier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    string strIns = "insert into tbl_PurchaseHeader(ReferenceNumber,PDate,SupplierId,TotalAmount) values('" + txt_ReferenceNo.Text + "','" + dtpPurchaseDate.Value.Date + "','" + cmb_SupplierName.SelectedValue + "','" + txt_GrandTotal.Text + "')";
                    obj.InsertData(strIns, ref isError1, ref sqlEx1);
                    for (int i = 0; i < grd_PurchaseList.Rows.Count; i++)
                    {
                        string strInsDetails = "INSERT INTO tbl_PurchaseDetails VALUES('" + txt_ReferenceNo.Text + "','" + grd_PurchaseList.Rows[i].Cells["PurchaseProductID"].Value + "','" + grd_PurchaseList.Rows[i].Cells["PurchaseQuantity"].Value + "','" + grd_PurchaseList.Rows[i].Cells["PurchaseUnitPrice"].Value + "')";
                        obj.InsertData(strInsDetails, ref isError2, ref sqlEx2);
                    }
                    if (isError1 == false && isError2 == false)
                    {
                        MessageBox.Show("Successfully Inserted");
                    }
                    else
                    {
                        if (isError1 == true)
                            GenericClass.errorLogger(2, "Class : Purchase.cs " + Environment.NewLine + "Function : btn_Save_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx1.Message, sqlEx1.StackTrace.ToString());
                        if (isError2 == true)
                            GenericClass.errorLogger(2, "Class : Purchase.cs " + Environment.NewLine + "Function : btn_Save_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx2.Message, sqlEx2.StackTrace.ToString());
                        MessageBox.Show("Insertion Failed");
                    }

                    RefreshGrid();




                    ExportToPdfDemo();
                    ClearFields();


                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : btn_Save_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGrid()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select ProductId from tbl_Product";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
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
                        dc = new DataColumn("AlertQuantity", typeof(double));
                        dtList.Columns.Add(dc);
                        dtList.AcceptChanges();

                        foreach (DataRow rw in dt.Rows)
                        {
                            str = "select top 1 ProductID,ProductCode,PName,CName,AlertQuantity from tbl_Product p inner join tbl_Category c on c.Cid=p.Cid  where p.ProductId='" + rw["ProductId"].ToString() + "' order by PName";
                            DataTable dtt = obj.GetData(str, ref isError, ref sqlEx);
                            if (isError == false)
                            {
                                if (dtt.Rows.Count > 0)
                                {
                                    DataRow row = dtList.NewRow();
                                    row["ProductId"] = Convert.ToInt32(dtt.Rows[0]["ProductID"].ToString());
                                    row["ProductCode"] = dtt.Rows[0]["ProductCode"].ToString();
                                    row["PName"] = dtt.Rows[0]["PName"].ToString();
                                    row["CName"] = dtt.Rows[0]["CName"].ToString();
                                    row["AlertQuantity"] = Convert.ToDouble(dtt.Rows[0]["AlertQuantity"].ToString());
                                    dtList.Rows.Add(row);
                                }
                            }
                            else
                            {
                                GenericClass.errorLogger(2, "Class : Purchase.cs " + Environment.NewLine + "Function : RefreshGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                            }
                        }

                        FillProductList(dtList);
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Purchase.cs " + Environment.NewLine + "Function : RefreshGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : RefreshGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txt_GrandTotal.Text = "";
            txt_SubTotal.Text = "";
            cmb_SupplierName.ResetText();
            txt_ReferenceNo.Text = "";
            auto();
            grd_PurchaseList.Rows.Clear();
        }



        private void ExportToPdfDemo()
        {

            try
            {

                Document document = new Document(PageSize.A4);
                // string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\PURCHASE REPORTS\";
                string appPath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Purchase Report\";
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


                numeroCell = new PdfPCell(new Phrase("Supplier Name: " + cmb_SupplierName.Text));
                numeroCell.Border = 0;
                numeroCell.HorizontalAlignment = 0;
                Ttable.AddCell(numeroCell);


                numeroCell = new PdfPCell(new Phrase("Date: " + dtpPurchaseDate.Text));
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
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : ExportToPdfDemo() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + de.Message, de.StackTrace.ToString());
                MessageBox.Show(de.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ioe)
            {
                int errCode = GenericClass.assignErrCode(ioe);
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : ExportToPdfDemo() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ioe.Message, ioe.StackTrace.ToString());
                MessageBox.Show(ioe.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Purchase.cs " + Environment.NewLine + "Function : ExportToPdfDemo() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmb_SupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Supplier.Text = cmb_SupplierName.Text;
        }

        private void grd_ProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Purchase_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}

