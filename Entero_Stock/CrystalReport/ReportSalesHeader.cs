using System;
using System.Data;
using System.Windows.Forms;

namespace Entero_Stock.CrystalReport
{
    public partial class ReportSalesHeader : Form
    {
        GenericClass obj = new GenericClass();
        public ReportSalesHeader()
        {
            InitializeComponent();
        }

        private void ReportSalesHeader_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                SalesHeaderReport rpt = new SalesHeaderReport();

                DataTable dt = obj.GetData(@"SELECT SalesID,ReferenceNumber,SDate,CustomerCode as CustomerId,TotalAmount from tbl_SalesHeader sh
inner join tbl_Customer c on c.CustomerId = sh.CustomerId
order by SDate");


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
