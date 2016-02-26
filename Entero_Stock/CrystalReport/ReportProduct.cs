using System;
using System.Data;
using System.Windows.Forms;

namespace Entero_Stock.CrystalReport
{
    public partial class ReportProduct : Form
    {

        GenericClass obj = new GenericClass();
        public ReportProduct()
        {
            InitializeComponent();
        }

        private void ReportProduct_Load(object sender, EventArgs e)
        {

            try
            {
                Cursor = Cursors.WaitCursor;

                ProductReport rpt = new ProductReport();

                DataTable dt = obj.GetData(@"select ProductCode,PName,Features,AlertQuantity,ProductUnit,CName from tbl_Product p
                    inner join tbl_Category c on c.Cid=p.Cid");
                rpt.SetDataSource(dt);

                crystalReportViewer1.ReportSource = rpt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
    }
}
