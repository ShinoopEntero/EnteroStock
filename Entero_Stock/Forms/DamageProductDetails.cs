using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace Entero_Stock.Forms
{
    public partial class DamageProductDetails : Form
    {
        public int DId;
        GenericClass obj = new GenericClass();
        public string Dpcode;
        public DamageProductDetails()
        {
            InitializeComponent();
        }

        private void DamageProductDetails_Load(object sender, EventArgs e)
        {
            //LoadGrid();//auto();
        }
        //private void auto()
        //{
        //    txtproductid.Text = "P-" + GetUniqueKey(4);

        //}
        //public static string GetUniqueKey(int maxSize)
        //{
        //    char[] chars = new char[62];
        //    chars = "123456789".ToCharArray();
        //    byte[] data = new byte[1];
        //    RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
        //    crypto.GetNonZeroBytes(data);
        //    data = new byte[maxSize];
        //    crypto.GetNonZeroBytes(data);
        //    StringBuilder result = new StringBuilder(maxSize);

        //    foreach (byte b in data)
        //    {
        //        result.Append(chars[b % (chars.Length)]);
        //    }
        //    return result.ToString();
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            if (txtProductName.Text == "")
            {
                MessageBox.Show("Please enter product name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductName.Focus();
                return;

            }
            if (dtpdamgepdtDate.Text.Trim() == "" || txtproductid.Text.Trim() == "" || txtProductName.Text.Trim() == "" || txtdamagequantity.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter all the fields");
            }
            else
            {
                try
                {
                    string strIns = "insert into tbl_DamageProductDetails (Date,ProductCode,PName,DamageQuantity) values('" + DateTime.Now + "','" + txtproductid.Text + "','" + txtProductName.Text + "','" + txtdamagequantity.Text + "')";


                    obj.InsertData(strIns, ref isError, ref sqlEx);
                    if (isError == false)
                    {
                        MessageBox.Show("Successfully Inserted");
                        //LoadGrid();
                    }
                    else
                    {
                        GenericClass.errorLogger(2, "Class : DamageProductDetails.cs " + Environment.NewLine + "Function : btnSave_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + " Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                        MessageBox.Show("Insertion Failed");
                    }

                }
              
                catch (Exception ex)
                {
                    int errCode = GenericClass.assignErrCode(ex);
                    GenericClass.errorLogger(errCode, "Class : DamageProductDetails.cs " + Environment.NewLine + "Function : btnSave_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + " Error Message : " + ex.Message, ex.StackTrace.ToString());
                    MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
                
        private void btnGetData_Click(object sender, EventArgs e)
        {

            this.Hide();


            DamageProduct frm = new DamageProduct();
            frm.label1.Text = label6.Text;
            frm.Show();
        }
        //private void LoadGrid()
        //{
        //    string strSel = "select Date,ReferenceNumber,PName,DamageQuantity from tbl_DamageProductDetails";
        //    DataTable dt = obj.GetData(strSel);

        //    if (dt.Rows.Count > 0)
        //    {
        //        grd.DataSource = dt;
        //    }

        //}


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string strUpdate = "update tbl_DamageProductDetails set Date='" + dtpdamgepdtDate.Text + "',ProductCode='" + txtproductid.Text + "', PName='" + txtProductName.Text + "',DamageQuantity='" + txtdamagequantity.Text + "' where ProductID='" + Convert.ToInt32(txt_DP_PrimaryKey.Text) + "'";
                obj.InsertData(strUpdate, ref isError, ref sqlEx);
                if (isError == false)
                {
                    MessageBox.Show("Updated Successfully.");
                    btnUpdate.Enabled = false;
                    //LoadGrid();
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : DamageProductDetails.cs " + Environment.NewLine + "Function : btnUpdate_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + " Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                    MessageBox.Show("Updation Failed");
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : DamageProductDetails.cs " + Environment.NewLine + "Function : btnUpdate_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + " Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clear();
           btnSave.Enabled = true;
           btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        public void clear()
        {
            dtpdamgepdtDate.Text = "";
            txtproductid.Text = "";
            txtProductName.Text = "";
            txtdamagequantity.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string strDel = "delete from tbl_DamageProductDetails where ProductID='" + Convert.ToInt32(txt_DP_PrimaryKey.Text)+ "'";
                obj.InsertData(strDel, ref isError, ref sqlEx);
                if (isError == false)
                {
                    MessageBox.Show("Deleted Successfully.");
                    this.clear();
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : DamageProductDetails.cs " + Environment.NewLine + "Function : btnDelete_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + " Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                    MessageBox.Show("Failed to Deleted");
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : DamageProductDetails.cs " + Environment.NewLine + "Function : btnDelete_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + " Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            ProductDetails frm = new ProductDetails("DamageProductDetails");
            frm.Show();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            // frm.GetData();
        }
    }
}
