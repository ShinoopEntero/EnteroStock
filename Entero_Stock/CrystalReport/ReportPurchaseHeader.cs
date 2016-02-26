using System;
using System.Data;
using System.Windows.Forms;

namespace Entero_Stock.CrystalReport
{
    public partial class ReportPurchaseHeader : Form
    {
        GenericClass obj = new GenericClass();
        public ReportPurchaseHeader()
        {
            InitializeComponent();
        }

        private void ReportPurchaseHeader_Load(object sender, EventArgs e)
        {

            try
            {
                Cursor = Cursors.WaitCursor;

                PurchaseHeaderReport rpt = new PurchaseHeaderReport();

                DataTable dt = obj.GetData("SELECT ReferenceNumber,PDate,SName as SupplierName,TotalAmount from tbl_PurchaseHeader ph inner join tbl_Supplier s on s.SupplierId=ph.SupplierId order by PDate");

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
