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
    public partial class Tax : Form
    {
        GenericClass obj = new GenericClass();
        public int TaxId;
        public Tax()
        {
            InitializeComponent();
        }

        private void Tax_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void FillGrid()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select * from tbl_Tax";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        grd_tax.DataSource = dt;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Tax.cs " + Environment.NewLine + "Function : FillGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Tax.cs " + Environment.NewLine + "Function : FillGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();

            if (txt_TaxType.Text == "")
            {
                MessageBox.Show("Please enter  Tax Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_TaxType.Focus();
                return;
            }
            if (txt_Percentage.Text == "")
            {
                MessageBox.Show("Please enter percentage", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_TaxType.Focus();
                return;
            }

            try
            {
                string ct = "select * from tbl_Tax where TaxType='" + txt_TaxType.Text + "' and Percentage='" + txt_Percentage.Text + "'";

                DataTable dt = obj.GetData(ct, ref isError, ref sqlEx);
                if (isError == false)
                {
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Tax.cs " + Environment.NewLine + "Function : btnSave_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }

                string cb = "insert into tbl_Tax VALUES ('" + txt_TaxType.Text + "','" + txt_Percentage.Text + "')";
                obj.InsertData(cb, ref isError, ref sqlEx);
                if (isError == false)
                {
                    MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Tax.cs " + Environment.NewLine + "Function : btnSave_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                    MessageBox.Show("Failed to Save!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Tax.cs " + Environment.NewLine + "Function : btnSave_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grd_tax_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow row = grd_tax.Rows[rowIndex];
                TaxId = Convert.ToInt32(row.Cells[0].Value);
                txt_TaxType.Text = row.Cells[1].Value.ToString();
                txt_Percentage.Text = row.Cells[2].Value.ToString();
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Tax.cs " + Environment.NewLine + "Function : grd_tax_RowHeaderMouseClick() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "update tbl_Tax set TaxType='" + txt_TaxType.Text + "' ,Percentage='"+txt_Percentage.Text+"' where TaxId='" + TaxId + "'";
                obj.InsertData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillGrid();
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Tax.cs " + Environment.NewLine + "Function : btnUpdate_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Tax.cs " + Environment.NewLine + "Function : btnUpdate_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string strDel = "delete from tbl_Tax where TaxId='" + TaxId + "'";
                obj.InsertData(strDel, ref isError, ref sqlEx);
                if (isError == false)
                {
                    MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillGrid();
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Tax.cs " + Environment.NewLine + "Function : btnDelete_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                    MessageBox.Show("Failed to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : Tax.cs " + Environment.NewLine + "Function : btnDelete_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

    
    

