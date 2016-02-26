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
    public partial class DamageProduct : Form
    {
        public int DId;
        GenericClass obj = new GenericClass();
        DataTable dt = new DataTable();
        public DamageProduct()
        {
            InitializeComponent();
        }

        private void DamageProduct_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "SELECT (ProductID) as [ProductID],(Date) as [Date],(ProductCode) as [Product Code],(PName) as [Product Name],(DamageQuantity) as [Damage Quantity]  from tbl_DamageProductDetails where PName like '" + txtProductName.Text + "%' order by PName";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        grd_DamageProductDetails.DataSource = dt;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : DamageProduct.cs " + Environment.NewLine + "Function :groupBox1_Enter() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + " Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : DamageProduct.cs " + Environment.NewLine + "Function :groupBox1_Enter() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + " Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grd_DamageProductDetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Hide();
            try
            {
                DamageProductDetails frm = new DamageProductDetails();
                frm.Show();
                int rowIndex = e.RowIndex;
                DataGridViewRow row = grd_DamageProductDetails.Rows[rowIndex];
                DId = Convert.ToInt16(row.Cells[0].Value);
                frm.txt_DP_PrimaryKey.Text = row.Cells[0].Value.ToString();
               // frm.dtpdamgepdtDate.Text = row.Cells[1].Value.ToString();
                frm.txtproductid.Text = row.Cells[2].Value.ToString();
                frm.txtProductName.Text = row.Cells[3].Value.ToString();
                frm.txtdamagequantity.Text = row.Cells[4].Value.ToString();
                frm.btnUpdate.Enabled = true;
                frm.btnDelete.Enabled = true;
                frm.btnSave.Enabled = false;
                frm.btnNew.Enabled = false;


            }

            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : DamageProduct.cs " + Environment.NewLine + "Function :FillTextField() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + " Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DamageProduct_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void LoadGrid()
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string strSel = "select  ProductID,Date,ProductCode,PName,DamageQuantity from tbl_DamageProductDetails";
                DataTable dt = obj.GetData(strSel, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 1)
                    {
                        grd_DamageProductDetails.DataSource = dt;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : DamageProduct.cs " + Environment.NewLine + "Function : LoadGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + " Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : DamageProduct.cs " + Environment.NewLine + "Function :LoadGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + " Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "select Date,ProductCode,PName,DamageQuantity from tbl_DamageProductDetails  where PName like '" + txtProductName.Text + "%' order by PName";
                DataTable dt = obj.GetData(str, ref isError, ref sqlEx);
                if (isError == false)
                {
                    if (dt.Rows.Count > 0)
                    {
                        grd_DamageProductDetails.DataSource = dt;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : DamageProduct.cs " + Environment.NewLine + "Function :txtProductName_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + " Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : DamageProduct.cs " + Environment.NewLine + "Function :txtProductName_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + " Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grd_DamageProductDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (grd_DamageProductDetails.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                grd_DamageProductDetails.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));

        }

        private void grd_DamageProductDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("working");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void grd_DamageProductDetails_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grd_DamageProductDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //int rowIndex = e.RowIndex;
            //DataGridViewRow dataGV = grd_DamageProductDetails.Rows[rowIndex];
            //string value1 = dataGV.Cells[2].Value.ToString(); 
            //MessageBox.Show("cell changed , " + rowIndex + " , " + value1);
        }
    }
}
