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
    public partial class SupplierRegistration : Form
    {
        public int SId;
        GenericClass obj = new GenericClass();
        public SupplierRegistration()
        {
            InitializeComponent();
        }

        private void SupplierRegistration_Load(object sender, EventArgs e)
        {

            LoadGrid();
            btndel.Enabled = false;
            btnup.Enabled = false;

        }

        
        public void clear()
        {
            txt_FName.Text = "";
            txt_company.Text = "" ;
            txt_Address.Text = "";
            txt_City.Text = "";
            cmbstate.Text = "";
            txt_Pin.Text = "";
            txt_Email.Text = "";
            txt_Phone.Text = "";

        }

      

   

        private void LoadGrid()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string strSel = "select SupplierId,SName,SCompany,SAddress,City,State,PostalCode,Email,Phone from tbl_Supplier";
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
                    GenericClass.errorLogger(2, "Class : SupplierRegistration.cs " + Environment.NewLine + "Function : LoadGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SupplierRegistration.cs " + Environment.NewLine + "Function : LoadGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

      

        private void grd_CustomerDetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           

        }

        private void FillTextField()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select * from tbl_Supplier where SupplierId='" + SId + "'";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        txt_FName.Text = dt.Rows[0]["SName"].ToString();
                        txt_company.Text = dt.Rows[0]["SCompany"].ToString();
                        txt_Address.Text = dt.Rows[0]["SAddress"].ToString();
                        txt_City.Text = dt.Rows[0]["City"].ToString();
                        cmbstate.Text = dt.Rows[0]["State"].ToString();
                        txt_Pin.Text = dt.Rows[0]["PostalCode"].ToString();
                        txt_Email.Text = dt.Rows[0]["Email"].ToString();
                        txt_Phone.Text = dt.Rows[0]["Phone"].ToString();
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : SupplierRegistration.cs " + Environment.NewLine + "Function : FillTextField() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SupplierRegistration.cs " + Environment.NewLine + "Function : FillTextField() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string strDel = "delete from tbl_Supplier where SupplierId='" + SId + "'";
                obj.InsertData(strDel, ref isError, ref sqlEx);
                if (isError == false)
                {
                    MessageBox.Show("Deleted Successfully.");
                    clearFields();
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : SupplierRegistration.cs " + Environment.NewLine + "Function : btndel_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                    MessageBox.Show("Failed to Delete");
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SupplierRegistration.cs " + Environment.NewLine + "Function : btndel_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearFields()
        {
            txt_Address.Text = "";
            txt_City.Text = "";
            txt_company.Text="";
            txt_Email.Text = "";
            txt_FName.Text = "";
            txt_Phone.Text = "";
            txt_Pin.Text = "";

        }

        private void btnnew_Click_1(object sender, EventArgs e)
        {
            clear();
            btnreg.Enabled = true;
            btnup.Enabled = false;
            btndel.Enabled = false;
        }

        private void btnreg_Click_1(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();

            if (txt_FName.Text == "")
            {
                MessageBox.Show("Please enter first name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_FName.Focus();
                return;
            }

          
            if (txt_Phone.Text == "")
            {
                MessageBox.Show("Please enter phone number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txt_Phone.Focus();
                return;
            }
            if (txt_Email.Text == "")
            {
                MessageBox.Show("Please enter emailid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Email.Focus();
                return;
            }
            if (txt_company.Text.Trim()==""||  txt_Address.Text.Trim() == "" || txt_City.Text.Trim() == "" || txt_Email.Text.Trim() == "" || txt_FName.Text.Trim() == "" || txt_Phone.Text.Trim() == "" || txt_Pin.Text.Trim() == "" || cmbstate.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter all the fields");
            }

            else
            {
                try
                {
                    string strIns = "insert into tbl_Supplier values('" + txt_FName.Text + "','"+txt_company.Text+"','" + txt_Address.Text + "','" + txt_City.Text + "','" + cmbstate.Text + "','" + txt_Pin.Text + "','" + txt_Email.Text + "','" + txt_Phone.Text + "')";
                    obj.InsertData(strIns, ref isError, ref sqlEx);
                    if (isError == false)
                    {
                        MessageBox.Show("Successfully Inserted");
                        LoadGrid();
                        clearFields();
                    }
                    else
                    {
                        GenericClass.errorLogger(2, "Class : SupplierRegistration.cs " + Environment.NewLine + "Function : btnreg_Click_1() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                        MessageBox.Show("Insertion Failed!");
                    }
                }
                catch (Exception ex)
                {
                    int errCode = GenericClass.assignErrCode(ex);
                    GenericClass.errorLogger(errCode, "Class : SupplierRegistration.cs " + Environment.NewLine + "Function : btnreg_Click_1() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                    MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void btnup_Click_1(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string strUpdate = "update tbl_Supplier set SName='" + txt_FName.Text + "',SCompany='" + txt_company.Text + "',SAddress='" + txt_Address.Text + "',City='" + txt_City.Text + "',State='" + cmbstate.Text + "',PostalCode='" + txt_Pin.Text + "',Email='" + txt_Email.Text + "',Phone='" + txt_Phone.Text + "' where SupplierId='" + SId + "'";
                obj.InsertData(strUpdate, ref isError, ref sqlEx);
                if (isError == false)
                {
                    MessageBox.Show("Updated Successfully.");
                    LoadGrid();
                    clearFields();
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : SupplierRegistration.cs " + Environment.NewLine + "Function : btnup_Click_1() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                    MessageBox.Show("Updation Failed!");
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SupplierRegistration.cs " + Environment.NewLine + "Function : btnup_Click_1() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grd_SupplierDetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow row = grd_SupplierDetails.Rows[rowIndex];
                SId = Convert.ToInt16(row.Cells[0].Value);
                FillTextField();
                btnup.Enabled = true;
                btndel.Enabled = true;
                btnreg.Enabled = false;
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : SupplierRegistration.cs " + Environment.NewLine + "Function : grd_SupplierDetails_RowHeaderMouseClick() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btngetdata_Click(object sender, EventArgs e)
        {
            this.Hide();


            SupplierDetails frm = new SupplierDetails();
            frm.label1.Text = label2.Text;
            frm.Show();
        }

        private void txt_Email_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txt_Email.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txt_Email.Text))
                {
                    MessageBox.Show("invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Email
                        .SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void txt_Phone_Validating(object sender, CancelEventArgs e)
        {
            if (txt_Phone.TextLength > 10)
            {
                MessageBox.Show("Only 10 digits are allowed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Phone.Focus();
            }
        }

        private void txt_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_Pin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
