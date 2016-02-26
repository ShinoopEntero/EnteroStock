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
using Excel = Microsoft.Office.Interop.Excel;
namespace Entero_Stock.Forms
{
    public partial class UserDetails : Form
    {
      
        public int Rid, UId;

        GenericClass obj = new GenericClass();
        DataTable dt = new DataTable();
        public UserDetails()
        {
            InitializeComponent();
        }

        private void txt_SearchFN_TextChanged(object sender, EventArgs e)
        {
            bool isError = false;
            Exception sqlEx = new Exception();
            try
            {
                string str = "Select u.UserId,FirstName,LastName,Phone,Email,LoginName as UserName,Role from tbl_User u inner join tbl_login l on l.UserId=u.UserId inner join tbl_UserRole ur on ur.RoleId=l.RoleId where FirstName like '" + txt_SearchFN.Text + "%' order by FirstName";
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
                    GenericClass.errorLogger(2, "Class : UserDetails.cs " + Environment.NewLine + "Function : txt_SearchFN_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : UserDetails.cs " + Environment.NewLine + "Function : txt_SearchFN_TextChanged() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

      

        private void UserDetails_Load(object sender, EventArgs e)
        {
           
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
                    GenericClass.errorLogger(2, "Class : UserDetails.cs " + Environment.NewLine + "Function : fillGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : UserDetails.cs " + Environment.NewLine + "Function : fillGrid() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (grd_UserDetals.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = grd_UserDetals.RowCount - 1;
                colsTotal = grd_UserDetals.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = grd_UserDetals.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = grd_UserDetals.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "regular";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : UserDetails.cs " + Environment.NewLine + "Function : Button3_Click() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

       

        private void grd_UserDetals_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Hide();
           
            try
            {

                UserRegister frm = new UserRegister();
                frm.Show();
                int rowIndex = e.RowIndex;
                DataGridViewRow row = grd_UserDetals.Rows[rowIndex];
                frm.UId = Convert.ToInt16(row.Cells[0].Value);
                frm.txt_FName.Text = row.Cells[1].Value.ToString();
                frm.txt_LName.Text = row.Cells[2].Value.ToString();
                frm.txt_Address.Text = row.Cells[3].Value.ToString();
                frm.txt_City.Text = row.Cells[4].Value.ToString();
                frm.cmbstate.Text = row.Cells[5].Value.ToString();
                frm.txt_Pin.Text = row.Cells[6].Value.ToString();
                frm.txt_Phone.Text = row.Cells[7].Value.ToString();
                frm.txt_Email.Text = row.Cells[8].Value.ToString();

                frm.txt_Username.Text = row.Cells[9].Value.ToString();
                frm .cbb_Role.ResetText();
              frm.  cbb_Role.SelectedText = row.Cells[10].Value.ToString();
             frm.   btnup.Enabled = true;
                frm.btnreg.Enabled = false;
                frm.btnnew.Enabled = false;
               
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : UserDetails.cs " + Environment.NewLine + "Function : grd_UserDetals_RowHeaderMouseClick() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
        
    }
    }

