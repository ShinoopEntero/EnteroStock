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

    public partial class ChangePassword : Form
    {
        GenericClass obj = new GenericClass();
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btn_ChangePass_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                if (txt_OldPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter old Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_OldPassword.Focus();
                }
                if (txt_NewPass.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter New password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (txt_ConformPass.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter confrom password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (txt_NewPass.Text != txt_ConformPass.Text)
                {
                    MessageBox.Show("Please enter New password and confrom password carefully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    string strSel = "select * from tbl_Login where LoginName='" + GenericClass.iniVar.LoginName + "' and Password='" + txt_OldPassword.Text + "'";
                    DataTable dt = obj.GetData(strSel, ref isError, ref sqlEx);
                    if(isError == true)
                    {
                        GenericClass.errorLogger(2, "Class : ChangePassword.cs " + Environment.NewLine + "Function : btn_ChangePass_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                        MessageBox.Show("Failed to fetch Username & Password" + Environment.NewLine + sqlEx, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string strUpdate = "update tbl_Login set Password='" + txt_NewPass.Text + "' where LoginName='" + GenericClass.iniVar.LoginName + "'";
                            obj.InsertData(strUpdate, ref isError, ref sqlEx);
                            if (isError == false)
                            {
                                MessageBox.Show("Password Updated successfully");
                            }
                            else
                            {
                                GenericClass.errorLogger(2, "Class : ChangePassword.cs " + Environment.NewLine + "Function : btn_ChangePass_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                                MessageBox.Show("Failed to Set Password" + Environment.NewLine + sqlEx, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please enter correct old password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : ChangePassword.cs " + Environment.NewLine + "Function : btn_ChangePass_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
