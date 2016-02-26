using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Entero_Stock.Forms
{
    public partial class Product : Form
    {
        GenericClass obj = new GenericClass();
        public int CatId;
        public string FilePath;
        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            auto();
            fillCombo();
        }

        private void fillCombo()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select * from tbl_Category";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        cmbCategory.DisplayMember = "CName";
                        cmbCategory.ValueMember = "Cid";
                        cmbCategory.DataSource = dt;

                    }


                    DataRow dr = dt.NewRow();
                    dr["CName"] = "--Select--";
                    dr["Cid"] = 0;
                    dt.Rows.InsertAt(dr, 0);
                    cmbCategory.SelectedIndex = 0;
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Product.cs " + Environment.NewLine + "Function : fillCombo() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Product.cs " + Environment.NewLine + "Function : fillCombo() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void auto()
        {
            txtproductid.Text = "P-" + GetUniqueKey(4);

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
                GenericClass.errorLogger(errCode, "Class : Product.cs " + Environment.NewLine + "Function : GetUniqueKey() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

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
            if (cmbCategory.Text == "")
            {
                MessageBox.Show("Please select category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCategory.Focus();
                return;
            }
            if (txtfeatures.Text == "")
            {
                MessageBox.Show("Please enter features", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtfeatures.Focus();
                return;
            }

            if (cmbpdtunit.Text == "")
            {
                MessageBox.Show("Please enter product unit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbpdtunit.Focus();
                return;
            }
            if (txt_Profit.Text == "")
            {
                MessageBox.Show("Please enter product profit percentage", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Profit.Focus();
                return;
            }

            try
            {

                string cb = "insert into tbl_Product(ProductCode,PName,Features,AlertQuantity,ProductUnit,ProductImage,Cid,ProfitPercentage) VALUES ('" + txtproductid.Text + "','" + txtProductName.Text + "','" + txtfeatures.Text + "','" + txt_Quantity.Text + "','" + cmbpdtunit.Text + "','" + FilePath + "','" + CatId + "','" + txt_Profit.Text + "')";
                obj.InsertData(cb, ref isError, ref sqlEx);
                if(isError == false)
                {
                    MessageBox.Show("Successfully Saved", "products Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Product.cs " + Environment.NewLine + "Function : btnSave_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                    MessageBox.Show("Insertion Failed!");
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Product.cs " + Environment.NewLine + "Function : btnSave_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatId = Convert.ToInt32(cmbCategory.SelectedValue);


        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opFile = new OpenFileDialog();
                opFile.Title = "Select a Image";
                opFile.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";

                string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\ProductImages\";
                //string appPath = "~\\Entero_Stock\\Entero_Stock\\ProductImages\\
                if (Directory.Exists(appPath) == false)
                {
                    Directory.CreateDirectory(appPath);
                }
                if (opFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string iName = txtproductid.Text + ".jpg";
                        string filepath = opFile.FileName;

                        File.Copy(filepath, appPath + iName);
                        pictureBox1.Image = new Bitmap(opFile.OpenFile());
                        FilePath = appPath + iName;

                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Unable to open file " + exp.Message);
                    }
                }
                else
                {
                    opFile.Dispose();
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Product.cs " + Environment.NewLine + "Function : btn_Browse_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            this.Hide();


            ProductDetails frm = new ProductDetails("Product");
           // frm.label2.Text = label9.Text;
            frm.Show();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string strDel = "delete from tbl_Product where ProductCode='" + txtproductid.Text + "'";
                obj.InsertData(strDel, ref isError, ref sqlEx);
                if(isError == false)
                {
                    MessageBox.Show("Deleted Successfully");
                    clearFields();
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Product.cs " + Environment.NewLine + "Function : btnDelete_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                    MessageBox.Show("Failed to Delete");
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Product.cs " + Environment.NewLine + "Function : btnDelete_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void clearFields()
        {
            auto();
            txtProductName.Text = "";
            txtfeatures.Text = "";
            txt_Quantity.Text = "";
            txt_Profit.Text = "";
            fillCombo();
            cmbpdtunit.Text = "--select--";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string strupdate = "update tbl_Product set PName='" + txtProductName.Text + "',Features='" + txtfeatures.Text + "',AlertQuantity='" + txt_Quantity.Text + "',ProfitPercentage='" + txt_Profit.Text + "' where ProductCode='" + txtproductid.Text + "'";
                obj.InsertData(strupdate, ref isError, ref sqlEx);
                if (isError == false)
                {
                    MessageBox.Show("Successfully Updated...");
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Product.cs " + Environment.NewLine + "Function : btnUpdate_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                    MessageBox.Show("Updation Failed!");
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Product.cs " + Environment.NewLine + "Function : btnUpdate_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
