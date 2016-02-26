using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entero_Stock.Forms;

namespace Entero_Stock
{
    public partial class UserRegister : Form
    {
        static int Flag = 0;
        public int Rid, UId;

        GenericClass obj = new GenericClass();
        DataTable dt = new DataTable();
        public UserRegister()
        {
            InitializeComponent();
        }

        private void UserRegister_Load(object sender, EventArgs e)
        {
            btndel.Enabled = false;
            btnup.Enabled = false;
            cmbstate.SelectedIndex = 0;
            fillComboRole();
            fillGrid();

        }

        private void fillGrid()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                DataTable dt = new DataTable();
                string str = "Select u.UserId,FirstName,LastName,Address,City,State,Pin,Phone,Email,LoginName as UserName,Role from tbl_User u inner join tbl_login l on l.UserId=u.UserId inner join tbl_UserRole ur on ur.RoleId=l.RoleId";
                dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        grd_UserDetals.DataSource = dt;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : UserRegister.cs " + Environment.NewLine + "Function : fillGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : UserRegister.cs " + Environment.NewLine + "Function : fillGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void fillComboRole()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string strSel = "Select * from tbl_UserRole";
                dt = obj.GetData(strSel, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        cbb_Role.DisplayMember = "Role";
                        cbb_Role.ValueMember = "RoleId";
                        cbb_Role.DataSource = dt;

                        DataRow dr = dt.NewRow();
                        dr["Role"] = "--Select--";
                        dr["RoleId"] = 0;
                        dt.Rows.InsertAt(dr, 0);
                        cbb_Role.SelectedIndex = 0;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : UserRegister.cs " + Environment.NewLine + "Function : fillComboRole() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : UserRegister.cs " + Environment.NewLine + "Function : fillComboRole() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {

            Clear();
        }

        private void Clear()
        {
            txt_FName.Text = "";
            txt_LName.Text = "";
            txt_Email.Text = "";
            txt_Phone.Text = "";
            txt_Username.Text = "";
            cmbstate.Text = "";
        }

        private void btncheck_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                Flag = 1;
                string strSel = "select * from tbl_Login where LoginName='" + txt_Username.Text + "'";
                dt = obj.GetData(strSel, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("UserName not available");

                    }
                    else
                    {
                        MessageBox.Show("UserName available");
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : UserRegister.cs " + Environment.NewLine + "Function : btncheck_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : UserRegister.cs " + Environment.NewLine + "Function : btncheck_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnreg_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                if (txt_FName.Text == "")
                {
                    MessageBox.Show("Please enter first name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_FName.Focus();
                    return;
                }

                if (txt_LName.Text == "")
                {
                    MessageBox.Show("Please enter last name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_LName.Focus();
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
                if (Flag == 0)
                {
                    MessageBox.Show("Check userName availability");
                }
                else
                {
                    DataTable dtt = new DataTable();
                    string strIns = "insert into tbl_User values('" + txt_FName.Text + "','" + txt_LName.Text + "','" + txt_Address.Text + "','" + txt_City.Text + "','" + cmbstate.Text + "','" + txt_Pin.Text + "','" + txt_Phone.Text + "','" + txt_Email.Text + "')";
                    obj.InsertData(strIns, ref isError, ref sqlEx);
                    if (isError == false)
                    {
                        string strSel = "select Max(UserId) from tbl_User";
                        dtt = obj.GetData(strSel, ref isError, ref sqlEx);
                        if (isError == false)
                        {
                            if (dtt.Rows.Count > 0)
                            {
                                UId = Convert.ToInt32(dtt.Rows[0][0].ToString());

                                strIns = "insert into tbl_Login values('" + txt_Username.Text + "','password','" + Rid + "','" + UId + "')";
                                obj.InsertData(strIns, ref isError, ref sqlEx);
                                if (isError == false)
                                {
                                    Flag = 0;
                                    MessageBox.Show("Successfully Inserted");
                                    Clear();
                                }
                                else
                                {
                                    GenericClass.errorLogger(2, "Class : UserRegister.cs " + Environment.NewLine + "Function : btnreg_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                                }
                            }
                        }
                        else
                        {
                            GenericClass.errorLogger(2, "Class : UserRegister.cs " + Environment.NewLine + "Function : btnreg_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                        }
                    }
                    else
                    {
                        GenericClass.errorLogger(2, "Class : UserRegister.cs " + Environment.NewLine + "Function : btnreg_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                        MessageBox.Show("Insertion Failed!");
                    }
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : UserRegister.cs " + Environment.NewLine + "Function : btnreg_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbb_Role_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Rid = Convert.ToInt32(cbb_Role.SelectedValue);
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : UserRegister.cs " + Environment.NewLine + "Function : cbb_Role_SelectedIndexChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{


        //}

        private void grd_UserDetals_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow row = grd_UserDetals.Rows[rowIndex];
                UId = Convert.ToInt16(row.Cells[0].Value);
                txt_FName.Text = row.Cells[1].Value.ToString();
                txt_LName.Text = row.Cells[2].Value.ToString();
                txt_Address.Text = row.Cells[3].Value.ToString();
                txt_City.Text = row.Cells[4].Value.ToString();
                cmbstate.Text = row.Cells[5].Value.ToString();
                txt_Pin.Text = row.Cells[6].Value.ToString();
                txt_Phone.Text = row.Cells[7].Value.ToString();
                txt_Email.Text = row.Cells[8].Value.ToString();

                txt_Username.Text = row.Cells[9].Value.ToString();
                cbb_Role.ResetText();
                cbb_Role.SelectedText = row.Cells[10].Value.ToString();
                btnup.Enabled = true;
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : UserRegister.cs " + Environment.NewLine + "Function : grd_UserDetals_RowHeaderMouseClick() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void txt_SearchFN_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string str = "Select u.UserId,FirstName,LastName,Phone,Email,LoginName as UserName,Role from tbl_User u inner join tbl_login l on l.UserId=u.UserId inner join tbl_UserRole ur on ur.RoleId=l.RoleId where FirstName like '" + txt_SearchFN.Text + "%' order by FirstName";
        //        dt = obj.GetData(str);
        //        grd_UserDetals.DataSource = dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        int errCode = GenericClass.assignErrCode(ex);
        //        GenericClass.errorLogger(errCode, "Class : UserRegister.cs " + Environment.NewLine + "Function : txt_SearchFN_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
        //        MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}

        private void btndel_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string strDel = "delete from tbl_User where UserId='" + UId + "'";
                obj.InsertData(strDel, ref isError, ref sqlEx);
                if (isError == false)
                {
                    MessageBox.Show("Deleted successfully");
                    Clear();
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : UserRegister.cs " + Environment.NewLine + "Function : btndel_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                    MessageBox.Show("Failed to Delete!");
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : UserRegister.cs " + Environment.NewLine + "Function : btndel_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btngetdata_Click(object sender, EventArgs e)
        {

            //this.Hide();


            UserDetails frm = new UserDetails();
            frm.label1.Text = label12.Text;
            frm.Show();
            btnreg.Enabled = false;
            this.Hide();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt_Email_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txt_Email.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txt_Email.Text))
                {
                    MessageBox.Show("invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Email.SelectAll();
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

        private void btnup_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
             
                string strUpdate = "update tbl_User set FirstName='" + txt_FName.Text + "',LastName='" + txt_LName.Text + "',Address='" + txt_Address.Text + "',City='" + txt_City.Text + "',State='" + cmbstate.Text + "',Pin='" + txt_Pin.Text + "',Phone='" + txt_Phone.Text + "',Email='" + txt_Email.Text + "' where UserId='" + UId + "'";

              
                obj.InsertData(strUpdate, ref isError, ref sqlEx);
                if (isError == false)
                {
                    MessageBox.Show("Successfully Updated");


                    fillGrid();
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : UserRegister.cs " + Environment.NewLine + "Function : btnup_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                    MessageBox.Show("Updation Failed!");
                }

            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : UserRegister.cs " + Environment.NewLine + "Function : btnup_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
