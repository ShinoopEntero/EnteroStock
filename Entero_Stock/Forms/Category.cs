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
    public partial class Category : Form
    {
        GenericClass obj = new GenericClass();
        public int CatId = 0;
        public Category()
        {
            InitializeComponent();
            btnDelete.Enabled = false;
            btnDelete.BackColor = Color.Silver;
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Silver;
            btnNew.Visible = false;
            btnNew.BackColor = Color.Silver;

            txtCategoryName.KeyPress += new KeyPressEventHandler(txtGenerate_Responds);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Return)
                return true;
            return base.IsInputKey(keyData);
        }

        private void txtGenerate_Responds(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8 && txtCategoryName.Text.Length <= 1 && CatId != 0) //The  character represents a backspace
            {
                btnDelete.Enabled = false;
                btnDelete.BackColor = Color.Silver;
                btnUpdate.Enabled = false;
                btnUpdate.BackColor = Color.Silver;
            }
            if (e.KeyChar != (char)8 && txtCategoryName.Text == "" && CatId != 0)
            {
                btnDelete.Enabled = true;
                btnDelete.BackColor = Color.White;
                btnUpdate.Enabled = true;
                btnUpdate.BackColor = Color.White;
            }
        }
        private void Category_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void FillGrid()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select CName, Cid from tbl_Category order by CName asc";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        grd_Catergory.DataSource = dt;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Category.cs " + Environment.NewLine + "Function : FillGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
                //else
                //    MessageBox.Show("Grid not rendered");
                //    grd_Catergory.Rows[0].Cells[0].Value = "Error!!! Grid not rendered";
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Category.cs " + Environment.NewLine + "Function : FillGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            if (txtCategoryName.Text == "")
            {
                MessageBox.Show("Please enter Category name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCategoryName.Focus();
                return;
            }


            try
            {

                string ct = "select CName from tbl_Category where CName='" + txtCategoryName.Text + "'";
                DataTable dt = obj.GetData(ct, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Category Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCategoryName.Focus();
                    }
                    else
                    {
                        string cb = "insert into tbl_Category(CName) VALUES ('" + txtCategoryName.Text + "')";
                        obj.InsertData(cb, ref isError, ref sqlEx);
                        if (isError == false)
                        {
                            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillGrid();
                            btnDelete.Enabled = false;
                            btnDelete.BackColor = Color.Silver;
                            btnUpdate.Enabled = false;
                            btnUpdate.BackColor = Color.Silver;
                            txtCategoryName.Text = "";
                        }
                        else
                        {
                            GenericClass.errorLogger(2, "Class : Category.cs " + Environment.NewLine + "Function : btnSave_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                            MessageBox.Show("Insertion Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Category.cs " + Environment.NewLine + "Function : btnSave_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Category.cs " + Environment.NewLine + "Function : btnSave_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grd_Catergory_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow row = grd_Catergory.Rows[rowIndex];
                CatId = Convert.ToInt32(row.Cells[1].Value);
                txtCategoryName.Text = row.Cells[0].Value.ToString();
                btnUpdate.Enabled = true;
                btnUpdate.BackColor = Color.White;
                btnDelete.Enabled = true;
                btnDelete.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Category.cs " + Environment.NewLine + "Function : grd_Catergory_RowHeaderMouseClick() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "update tbl_Category set CName='" + txtCategoryName.Text + "' where Cid='" + CatId + "'";
                obj.InsertData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillGrid();
                    btnDelete.Enabled = false;
                    btnDelete.BackColor = Color.Silver;
                    btnUpdate.Enabled = false;
                    btnUpdate.BackColor = Color.Silver;
                    CatId = 0;
                    txtCategoryName.Text = "";
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Category.cs " + Environment.NewLine + "Function : btnUpdate_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                    MessageBox.Show("Updation Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Category.cs " + Environment.NewLine + "Function : btnUpdate_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string strDel = "delete from tbl_Category where Cid='" + CatId + "'";
                obj.InsertData(strDel, ref isError, ref sqlEx);
                if (isError == false)
                {
                    MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillGrid();
                    btnDelete.Enabled = false;
                    btnDelete.BackColor = Color.Silver;
                    btnUpdate.Enabled = false;
                    btnUpdate.BackColor = Color.Silver;
                    CatId = 0;
                    txtCategoryName.Text = "";
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Category.cs " + Environment.NewLine + "Function : btnDelete_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                    MessageBox.Show("Failed to Delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Category.cs " + Environment.NewLine + "Function : btnDelete_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
