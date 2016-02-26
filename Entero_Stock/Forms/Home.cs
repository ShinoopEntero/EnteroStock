using Entero_stock;
using Entero_Stock.CrystalReport;
using Entero_Stock.Forms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace Entero_Stock
{
    public partial class Home : Form
    {
        GenericClass obj = new GenericClass();
        public Home()
        {
            InitializeComponent();



        }



        private void Home_Load(object sender, EventArgs e)
        {
            BindChart();


            ToolStripStatusLabel4.Text = System.DateTime.Now.ToString();
            if (GenericClass.iniVar.URole == "Admin")
            {

            }
            menuStrip4.Renderer = new ToolStripProfessionalRenderer(new MenuColorTable());
            menuStrip3.Renderer = new ToolStripProfessionalRenderer(new MenuColorTable());
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new MenuColorTable());
        }
        private void BindChart()
        {
            bool isError = false;
            Exception sqlEx = new Exception();


            try
            {
                // SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_Product", con); //MessageBox.Show(" 2";
                string str = "SELECT * FROM tbl_PurchaseHeader";

                DataSet dt = obj.GetDataChartPurchase(str, ref isError, ref sqlEx);

                //DataSet ds = new DataSet();

                //sda.SelectCommand = cmd;

                // db_Entero_StockDataSet myDS = new db_Entero_StockDataSet ();
                // db_Entero_StockDataSet myDs = new db_Entero_StockDataSet();

                if (isError == false)
                {
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        chart3.DataSource = dt.Tables["Purchase"];
                        chart3.Series["Series1"].XValueMember = "PDate";
                        chart3.Series["Series1"].YValueMembers = "TotalAmount";
                        chart3.Series["Series1"].ChartType = SeriesChartType.Column;
                        chart3.Series["Series1"].IsValueShownAsLabel = true;
                    }
                }
                else
                {
                    GenericClass.errorLogger(2, "Class : Home.cs " + Environment.NewLine + "Function : BindChart() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + " Error Message : " + sqlEx.Message, sqlEx.StackTrace.ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                // SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_Product", con); //MessageBox.Show(" 2";
                string st = "SELECT * FROM tbl_SalesHeader";
                //string str = @" select sum(TotalAmount)from tbl_PurchaseHeader WHERE Year(PDate) = Year(CURRENT_TIMESTAMP)
                //  AND Month(PDate) = Month(CURRENT_TIMESTAMP)";
                DataSet dt = obj.GetDataChartSales(st);


                //DataSet ds = new DataSet();

                //sda.SelectCommand = cmd;

                //db_Entero_StockDataSet myDS = new db_Entero_StockDataSet();


                chart2.DataSource = dt.Tables["Sales"];
                chart2.Series["Series1"].XValueMember = "SDate";
                chart2.Series["Series1"].YValueMembers = "TotalAmount";
                // Set the chart title
                // this.chart1.Titles.Add("Sales";
                // Set chart type like Bar chart, Pie chart 
                chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                // To show chart value           
                chart2.Series["Series1"].IsValueShownAsLabel = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        class MenuColorTable : ProfessionalColorTable
        {
            public MenuColorTable()
            {
                // see notes
                base.UseSystemColors = false;
            }
            public override System.Drawing.Color MenuBorder
            {
                get { return Color.Fuchsia; }
            }
            public override System.Drawing.Color MenuItemBorder
            {
                get { return Color.DeepSkyBlue; }
            }
            public override Color MenuItemSelected
            {
                get { return Color.Cornsilk; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.LightSteelBlue; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.DeepSkyBlue; }
            }
            public override Color MenuStripGradientBegin
            {
                get { return Color.AliceBlue; }
            }
            public override Color MenuStripGradientEnd
            {
                get { return Color.DodgerBlue; }
            }
        }

        private void newcustomertoolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerRegistration frm = new CustomerRegistration();
            // frm.MdiParent = this;
            frm.Show();
        }

        private void changepasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword frm = new ChangePassword();
            frm.Show();
        }

        private void NewSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierRegistration frm = new SupplierRegistration();
            //frm.MdiParent = this;
            frm.Show();
        }


        private void bILLERDETAILSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //BillerDetails frm = new BillerDetails();
            //frm.MdiParent = this;
            // frm.Show();
        }

        private void newproducttoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product frm = new Product();
            //frm.MdiParent = this;
            frm.Show();
        }


        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userRole frm = new userRole();
            frm.Show();
        }




        private void newBillersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //BillerRegistration frm = new BillerRegistration();
            //frm.Show();
        }




        private void customerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void toolStripMenuItem1_Click_3(object sender, EventArgs e)
        {
            UserDetails frm = new UserDetails();
            frm.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            UserRegister frm = new UserRegister();
            frm.Show();
        }

        private void salestoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lblUser.Text == "Admin")
            {
                SalesAdmin frm = new SalesAdmin();
                frm.Show();
            }
            else
            {
                Sales frm = new Sales();
                frm.Show();
            }

        }

        private void purchasetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase frm = new Purchase();
            frm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UserDetails frm = new UserDetails();
            frm.Show();

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            UserRegister frm = new UserRegister();
            frm.Show();
        }





        private void taxToolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            Tax frm = new Tax();
            frm.Show();
        }

        private void categoryToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Category frm = new Category();
            frm.Show();
        }

        private void listCustomersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            customerDetails frm = new customerDetails();
            frm.Show();
        }

        private void newCustomersToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            CustomerRegistration frm = new CustomerRegistration();
            frm.Show();
        }

        private void listUsersToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            UserDetails frm = new UserDetails();
            frm.Show();
        }

        private void newUsersToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            UserRegister frm = new UserRegister();
            frm.Show();
        }

        private void userRoleToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            userRole frm = new userRole();
            frm.Show();
        }

        private void listBillersToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            //    BillerDetails frm = new BillerDetails();
            //    frm.Show();
        }

        private void newBillersToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            //    BillerRegistration frm = new BillerRegistration();
            //    frm.Show();
        }

        private void listSuppliersToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            SupplierDetails frm = new SupplierDetails();
            frm.Show();
        }

        private void newSuppliersToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            SupplierRegistration frm = new SupplierRegistration();
            frm.Show();
        }

        private void userRoleToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            userRole frm = new userRole();
            frm.Show();
        }

        private void listUserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UserDetails frm = new UserDetails();
            frm.Show();

        }

        private void newUserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UserRegister frm = new UserRegister();
            frm.Show();
        }

        private void listSaleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sales frm = new Sales();
            frm.Show();
        }

        private void notepadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void calculatorToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void wordpadToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Wordpad.exe");
        }

        private void taskManagerToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("TaskMgr.exe");
        }

        private void mSWordToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Winword.exe");
        }

        private void producttoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductDetails frm = new ProductDetails();
            frm.Show();
        }

        private void logouttoolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login frm = new Login();
            frm.Show();
            frm.txt_UserName.Text = "";
            frm.txt_Password.Text = "";
            frm.txt_UserName.Focus();
        }



        private void suppliertoolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierDetails frm = new SupplierDetails();
            frm.Show();
        }

        private void pRODUCTALERTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProductAlert frm = new ProductAlert();
            frm.Show();
        }

        private void customerstoolStripMenuItem_Click(object sender, EventArgs e)
        {
            customerDetails frm = new customerDetails();
            frm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //BillerRegistration frm = new BillerRegistration();
            //frm.Show();
        }

        private void productReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stocktoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock frm = new Stock();
            frm.Show();
        }

        private void purchaseDetailsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //private void purchaseHeaderReportToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Cursor = Cursors.WaitCursor;

        //        customerCrystalReport rpt = new customerCrystalReport();


        //        DataTable dt = obj.GetData("SELECT * from tbl_PurchaseHeader order by ReferenceNumber");

        //        db_Entero_StockDataSet myDS = new db_Entero_StockDataSet();

        //        rpt.SetDataSource(dt);
        //        PurchaseHeaderReportcs frm = new PurchaseHeaderReportcs();
        //        frm.crystalReportViewer1.ReportSource = rpt;
        //        frm.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void setIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetIP frm = new SetIP();
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ToolStripStatusLabel4.Text = System.DateTime.Now.ToString();
        }

        private void frmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportSupplier frm = new ReportSupplier();
            frm.Show();
        }

        private void reportStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listDamageProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DamageProduct frm = new DamageProduct();

            frm.Show();
        }

        private void damageProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DamageProductDetails frm = new DamageProductDetails();
            frm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.Show();
        }

        private void productReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportProduct frm = new ReportProduct();
            frm.Show();

        }
        int count = 0;
        private void Home_Activated(object sender, EventArgs e)
        {
            if (count == 0)
            {
                this.Refresh();
                BindChart();
                this.Refresh();
                count = 1;
            }
        }

        private void Home_Deactivate(object sender, EventArgs e)
        {
            count = 0;
        }

        private void listProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductDetails frm = new ProductDetails();

            frm.Show();
        }

        private void newProductToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Product frm = new Product();

            frm.Show();
        }

        private void listPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase frm = new Purchase();

            frm.Show();
        }

        private void salesHeaderReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportSalesHeader frm = new ReportSalesHeader();
            frm.Show();
        }

        private void purchaseHeaerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportPurchaseHeader frm = new ReportPurchaseHeader();
            frm.Show();
        }

        private void customerReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ReportCustomer frm = new ReportCustomer();
            frm.Show();


        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}





