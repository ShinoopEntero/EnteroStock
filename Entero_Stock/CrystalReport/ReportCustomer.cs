using System;
using System.Data;
using System.Windows.Forms;

namespace Entero_Stock.CrystalReport
{
    public partial class ReportCustomer : Form
    {
        GenericClass obj = new GenericClass();
        public ReportCustomer()
        {
            InitializeComponent();
        }

        private void ReportCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                CustomerReport rpt = new CustomerReport();

                DataTable dt = obj.GetData("select CustomerCode,FirstName,LastName,Address,City,State,PostalCode,Email,Phone from tbl_Customer order by FirstName");
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
