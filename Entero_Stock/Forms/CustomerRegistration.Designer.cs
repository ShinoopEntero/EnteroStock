namespace Entero_Stock.Forms
{
    partial class CustomerRegistration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbstate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Pin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_City = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.txt_LName = new System.Windows.Forms.TextBox();
            this.txt_FName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_Phone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btngetdata = new System.Windows.Forms.Button();
            this.btnup = new System.Windows.Forms.Button();
            this.btndel = new System.Windows.Forms.Button();
            this.btnreg = new System.Windows.Forms.Button();
            this.btnnew = new System.Windows.Forms.Button();
            this.grd_CustomerDetails = new System.Windows.Forms.DataGridView();
            this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_CustomerDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Snow;
            this.groupBox1.Controls.Add(this.cmbstate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txt_Pin);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txt_City);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_Address);
            this.groupBox1.Controls.Add(this.txt_LName);
            this.groupBox1.Controls.Add(this.txt_FName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_Email);
            this.groupBox1.Controls.Add(this.txt_Phone);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(60, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 453);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // cmbstate
            // 
            this.cmbstate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbstate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbstate.BackColor = System.Drawing.SystemColors.Control;
            this.cmbstate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbstate.FormattingEnabled = true;
            this.cmbstate.Items.AddRange(new object[] {
            "Andaman & Nicobar",
            "Andhra Pradesh",
            "Arunachal Pradesh",
            "Assam",
            "Bihar",
            "Chandigarh",
            "Chhattisgarh",
            "Goa",
            "Gujarat",
            "Haryana",
            "Himachal Pradesh",
            "Jammu and Kashmir",
            "Jharkhand",
            "Karnataka",
            "Kerala",
            "Madhya Pradesh",
            "Maharashtra",
            "Manipur",
            "Meghalaya",
            "Mizoram",
            "Nagaland",
            "New Delhi",
            "Orissa",
            "Puducherry",
            "Rajasthan",
            "Sikkim",
            "Tamil Nadu",
            "Tripura",
            "Uttar Pradesh",
            "Uttarakhand",
            "West Bengal",
            "Dadra and Nagar Haveli",
            "Daman and Diu",
            "Lakshadweep"});
            this.cmbstate.Location = new System.Drawing.Point(156, 257);
            this.cmbstate.Name = "cmbstate";
            this.cmbstate.Size = new System.Drawing.Size(259, 28);
            this.cmbstate.TabIndex = 119;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 24;
            this.label1.Text = "State";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(27, 306);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 18);
            this.label10.TabIndex = 22;
            this.label10.Text = "Pin";
            // 
            // txt_Pin
            // 
            this.txt_Pin.BackColor = System.Drawing.SystemColors.Control;
            this.txt_Pin.Location = new System.Drawing.Point(157, 303);
            this.txt_Pin.Name = "txt_Pin";
            this.txt_Pin.Size = new System.Drawing.Size(258, 25);
            this.txt_Pin.TabIndex = 21;
            this.txt_Pin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Pin_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(27, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "City";
            // 
            // txt_City
            // 
            this.txt_City.BackColor = System.Drawing.SystemColors.Control;
            this.txt_City.Location = new System.Drawing.Point(157, 203);
            this.txt_City.Name = "txt_City";
            this.txt_City.Size = new System.Drawing.Size(258, 25);
            this.txt_City.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "Address";
            // 
            // txt_Address
            // 
            this.txt_Address.BackColor = System.Drawing.SystemColors.Control;
            this.txt_Address.Location = new System.Drawing.Point(156, 112);
            this.txt_Address.Multiline = true;
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(259, 66);
            this.txt_Address.TabIndex = 17;
            // 
            // txt_LName
            // 
            this.txt_LName.BackColor = System.Drawing.SystemColors.Control;
            this.txt_LName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_LName.Location = new System.Drawing.Point(155, 65);
            this.txt_LName.Name = "txt_LName";
            this.txt_LName.Size = new System.Drawing.Size(260, 25);
            this.txt_LName.TabIndex = 15;
            // 
            // txt_FName
            // 
            this.txt_FName.BackColor = System.Drawing.SystemColors.Control;
            this.txt_FName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_FName.Location = new System.Drawing.Point(155, 20);
            this.txt_FName.Name = "txt_FName";
            this.txt_FName.Size = new System.Drawing.Size(260, 25);
            this.txt_FName.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 356);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 18);
            this.label8.TabIndex = 13;
            this.label8.Text = "Phone";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Last Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "First Name";
            // 
            // txt_Email
            // 
            this.txt_Email.BackColor = System.Drawing.SystemColors.Control;
            this.txt_Email.Location = new System.Drawing.Point(157, 403);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(258, 25);
            this.txt_Email.TabIndex = 9;
            this.txt_Email.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Email_Validating);
            // 
            // txt_Phone
            // 
            this.txt_Phone.BackColor = System.Drawing.SystemColors.Control;
            this.txt_Phone.Location = new System.Drawing.Point(156, 353);
            this.txt_Phone.Name = "txt_Phone";
            this.txt_Phone.Size = new System.Drawing.Size(259, 25);
            this.txt_Phone.TabIndex = 8;
            this.txt_Phone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Phone_KeyPress);
            this.txt_Phone.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Phone_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 403);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btngetdata);
            this.panel1.Controls.Add(this.btnup);
            this.panel1.Controls.Add(this.btndel);
            this.panel1.Controls.Add(this.btnreg);
            this.panel1.Controls.Add(this.btnnew);
            this.panel1.Location = new System.Drawing.Point(12, 525);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 58);
            this.panel1.TabIndex = 15;
            // 
            // btngetdata
            // 
            this.btngetdata.BackColor = System.Drawing.Color.SeaShell;
            this.btngetdata.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngetdata.ForeColor = System.Drawing.Color.Blue;
            this.btngetdata.Location = new System.Drawing.Point(455, 14);
            this.btngetdata.Name = "btngetdata";
            this.btngetdata.Size = new System.Drawing.Size(87, 31);
            this.btngetdata.TabIndex = 4;
            this.btngetdata.Text = "Get Data";
            this.btngetdata.UseVisualStyleBackColor = false;
            this.btngetdata.Click += new System.EventHandler(this.btngetdata_Click);
            // 
            // btnup
            // 
            this.btnup.BackColor = System.Drawing.Color.SeaShell;
            this.btnup.Enabled = false;
            this.btnup.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnup.ForeColor = System.Drawing.Color.Blue;
            this.btnup.Location = new System.Drawing.Point(233, 14);
            this.btnup.Name = "btnup";
            this.btnup.Size = new System.Drawing.Size(87, 33);
            this.btnup.TabIndex = 3;
            this.btnup.Text = "Update";
            this.btnup.UseVisualStyleBackColor = false;
            this.btnup.Click += new System.EventHandler(this.btnup_Click);
            // 
            // btndel
            // 
            this.btndel.BackColor = System.Drawing.Color.SeaShell;
            this.btndel.Enabled = false;
            this.btndel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndel.ForeColor = System.Drawing.Color.Blue;
            this.btndel.Location = new System.Drawing.Point(338, 14);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(90, 32);
            this.btndel.TabIndex = 2;
            this.btndel.Text = "Delete";
            this.btndel.UseVisualStyleBackColor = false;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // btnreg
            // 
            this.btnreg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnreg.BackColor = System.Drawing.Color.SeaShell;
            this.btnreg.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreg.ForeColor = System.Drawing.Color.Blue;
            this.btnreg.Location = new System.Drawing.Point(122, 13);
            this.btnreg.Name = "btnreg";
            this.btnreg.Size = new System.Drawing.Size(86, 33);
            this.btnreg.TabIndex = 1;
            this.btnreg.Text = "Register";
            this.btnreg.UseVisualStyleBackColor = false;
            this.btnreg.Click += new System.EventHandler(this.btnreg_Click);
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.SeaShell;
            this.btnnew.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnew.ForeColor = System.Drawing.Color.Blue;
            this.btnnew.Location = new System.Drawing.Point(15, 14);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(89, 31);
            this.btnnew.TabIndex = 0;
            this.btnnew.Text = "New";
            this.btnnew.UseVisualStyleBackColor = false;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // grd_CustomerDetails
            // 
            this.grd_CustomerDetails.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grd_CustomerDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_CustomerDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerId,
            this.FirstName,
            this.LastName,
            this.Address,
            this.City,
            this.Email,
            this.Phone});
            this.grd_CustomerDetails.Location = new System.Drawing.Point(1091, 116);
            this.grd_CustomerDetails.MultiSelect = false;
            this.grd_CustomerDetails.Name = "grd_CustomerDetails";
            this.grd_CustomerDetails.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.grd_CustomerDetails.Size = new System.Drawing.Size(193, 150);
            this.grd_CustomerDetails.TabIndex = 16;
            this.grd_CustomerDetails.Visible = false;
            this.grd_CustomerDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_CustomerDetails_CellContentClick);
            this.grd_CustomerDetails.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grd_CustomerDetails_RowHeaderMouseClick);
            // 
            // CustomerId
            // 
            this.CustomerId.DataPropertyName = "CustomerId";
            this.CustomerId.HeaderText = "CustomerId";
            this.CustomerId.Name = "CustomerId";
            this.CustomerId.Visible = false;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            // 
            // City
            // 
            this.City.DataPropertyName = "City";
            this.City.HeaderText = "City";
            this.City.Name = "City";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(915, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(173, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 26);
            this.label3.TabIndex = 18;
            this.label3.Text = "Add New Customer";
            // 
            // CustomerRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 608);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grd_CustomerDetails);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(603, 647);
            this.MinimumSize = new System.Drawing.Size(603, 647);
            this.Name = "CustomerRegistration";
            this.Text = "CustomerRegistration";
            this.Load += new System.EventHandler(this.CustomerRegistration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_CustomerDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.Button btngetdata;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txt_Pin;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txt_City;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txt_Address;
        public System.Windows.Forms.TextBox txt_LName;
        public System.Windows.Forms.TextBox txt_FName;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txt_Email;
        public System.Windows.Forms.TextBox txt_Phone;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cmbstate;
        public System.Windows.Forms.DataGridView grd_CustomerDetails;
        internal System.Windows.Forms.Button btnup;
        public System.Windows.Forms.Button btndel;
        public System.Windows.Forms.Button btnreg;
        private System.Windows.Forms.Label label3;
    }
}