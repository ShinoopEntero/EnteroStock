using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
namespace Entero_Stock.Forms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            try
            {
                this.Text = String.Format("About {0}", AssemblyTitle);
                this.labelProductName.Text = AssemblyProduct;
                this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
                this.labelCopyright.Text = string.Format("Entero software solutions Pvt.Ltd . All Rights Reserved", AssemblyCopyright);
                this.labelCompanyName.Text = string.Format("www.entero.co.in", AssemblyCompany);
                this.labelCompanyEmail.Text = string.Format("info@entero.co.in", AssemblyCompanyEmail);
                this.labelcompanyWebsite.Text = string.Format("www.entero.co.in", AssemblyCompany);
                // this.textBoxDescription.Text = string.Format("Warning: Please do not distribute this computer program without permission of its owner", AssemblyDescription);
                this.labeldescription.Text = string.Format("Warning: Please do not distribute this computer program without permission of its owner", AssemblyDescription);
            }
            catch (Exception ex)
            {
                int errCode = GenericClass.assignErrCode(ex);
                GenericClass.errorLogger(errCode, "Class : About.cs " + Environment.NewLine + "Function : About() " + Environment.NewLine + "Date : " + DateTime.Now + Environment.NewLine + "Error Message : " + ex.Message, ex.StackTrace.ToString());
                MessageBox.Show(ex.Message + Environment.NewLine + "Contact Administrator", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;

            }
        }
        public string AssemblyCompanyEmail
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labeldescription_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
