using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entero_Stock.crystalReport
{
    public partial class ProductReport : Form
    {
        GenericClass obj = new GenericClass();
        public ProductReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                //t.Enabled = true;
                ProductCrystalReport rpt = new ProductCrystalReport();
                //The report you created.
                //cmd = new SqlCommand();
                // SqlDataAdapter myDA = new SqlDataAdapter();

                DataTable dt = obj.GetData("SELECT * from tbl_Product order by PName");

                db_Entero_StockDataSet myDS = new db_Entero_StockDataSet();
                //The DataSet you created.
                //con = new SqlConnection();
                //cmd.Connection = con;
                //cmd.CommandText = "SELECT * from tbl_Customer order by FirstName";
                //cmd.CommandType = CommandType.Text;
                //myDA.SelectCommand = cmd;
                //myDA.Fill(myDS," tbl_Customer");
                rpt.SetDataSource(dt);
                ProductReport frm = new ProductReport();
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    

