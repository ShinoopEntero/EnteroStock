using Entero_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Entero_stock
{
    public partial class userRole : Form
    {
        public int RId;
        GenericClass obj = new GenericClass();
        public userRole()
        {
            InitializeComponent();
        }

        private void UserRole_Load(object sender, EventArgs e)
        {
            
            LoadGrid();
            
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            txt_Role.Text = "";
        }

        private void btnreg_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                DataTable dt = new DataTable();
                string selStr = "select * from tbl_UserRole where Role='" + txt_Role.Text + "'";
                dt = obj.GetData(selStr, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Role already in database");
                        txt_Role.Text = "";
                        txt_Role.Focus();
                    }
                    else
                    {
                        string str = "Insert into tbl_UserRole values('" + txt_Role.Text + "')";
                        obj.InsertData(str, ref isError, ref sqlEx);
                        if (isError == false)
                        {
                            MessageBox.Show("Sucessfully Inserted");
                        }
                        else
                        {
                            GenericClass.errorLogger(2, "Class : userRole.cs " + Environment.NewLine + "Function : btnreg_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                            MessageBox.Show("Insertion Failed!" + Environment.NewLine + sqlEx.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : userRole.cs " + Environment.NewLine + "Function : btnreg_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : userRole.cs " + Environment.NewLine + "Function : btnreg_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnup_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                MessageBox.Show(RId.ToString());
                string strUpdate = "Update tbl_UserRole set Role='" + txt_Role.Text + "' where RoleId=" + RId + "";
                obj.InsertData(strUpdate, ref isError, ref sqlEx);
                if(isError == true)
                {
                    GenericClass.errorLogger(2, "Class : userRole.cs " + Environment.NewLine + "Function : btnup_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                    MessageBox.Show("Updation Failed!");
                }
                LoadGrid();
            }

            catch(Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : userRole.cs " + Environment.NewLine + "Function : btnup_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public void LoadGrid()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            btnup.Enabled = false;
            btndel.Enabled = false;
            try
            {
                DataTable dt = new DataTable();
                string str = "Select RoleId,Role from tbl_UserRole";
                dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        grd_Role.DataSource = dt;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : userRole.cs " + Environment.NewLine + "Function : LoadGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : userRole.cs " + Environment.NewLine + "Function : LoadGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grd_Role_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string strDel = "delete from tbl_UserRole where RoleId='" + RId + "'";
                obj.GetData(strDel, ref isError, ref sqlEx);
                if(isError == true)
                {
                    MessageBox.Show("Failed to Delete");
                    GenericClass.errorLogger(2, "Class : userRole.cs " + Environment.NewLine + "Function : btndel_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
                txt_Role.Text = "";
                LoadGrid();
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : userRole.cs " + Environment.NewLine + "Function : btndel_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grd_Role_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnnew.Enabled = false;
            btnreg.Enabled = false;

            try
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow row = grd_Role.Rows[rowIndex];
                RId = Convert.ToInt32(row.Cells[0].Value);
                txt_Role.Text = row.Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : userRole.cs " + Environment.NewLine + "Function : grd_Role_RowHeaderMouseClick() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
