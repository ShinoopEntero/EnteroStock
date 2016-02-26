using System;
using System.Data;
using System.Windows.Forms;


namespace Entero_Stock.CrystalReport
{
    public partial class ReportSupplier : Form
    {
        GenericClass obj = new GenericClass();
        public ReportSupplier()
        {
            InitializeComponent();
        }

        private void ReportSupplier_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                SupplierReport rpt = new SupplierReport();

                DataTable dt = obj.GetData("select * from tbl_Supplier order by SName");


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
