namespace Entero_Stock.Forms
{
    partial class Tax
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
            this.lblpercentage = new System.Windows.Forms.Label();
            this.txt_Percentage = new System.Windows.Forms.TextBox();
            this.txt_TaxType = new System.Windows.Forms.TextBox();
            this.lbltaxtype = new System.Windows.Forms.Label();
            this.grd_tax = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_tax)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblpercentage);
            this.groupBox1.Controls.Add(this.txt_Percentage);
            this.groupBox1.Controls.Add(this.txt_TaxType);
            this.groupBox1.Controls.Add(this.lbltaxtype);
            this.groupBox1.Location = new System.Drawing.Point(62, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblpercentage
            // 
            this.lblpercentage.AutoSize = true;
            this.lblpercentage.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpercentage.Location = new System.Drawing.Point(7, 64);
            this.lblpercentage.Name = "lblpercentage";
            this.lblpercentage.Size = new System.Drawing.Size(73, 18);
            this.lblpercentage.TabIndex = 22;
            this.lblpercentage.Text = "Percentage";
            // 
            // txt_Percentage
            // 
            this.txt_Percentage.BackColor = System.Drawing.Color.White;
            this.txt_Percentage.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Percentage.Location = new System.Drawing.Point(116, 64);
            this.txt_Percentage.Name = "txt_Percentage";
            this.txt_Percentage.Size = new System.Drawing.Size(222, 25);
            this.txt_Percentage.TabIndex = 21;
            // 
            // txt_TaxType
            // 
            this.txt_TaxType.BackColor = System.Drawing.Color.White;
            this.txt_TaxType.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TaxType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_TaxType.Location = new System.Drawing.Point(116, 29);
            this.txt_TaxType.Name = "txt_TaxType";
            this.txt_TaxType.Size = new System.Drawing.Size(222, 25);
            this.txt_TaxType.TabIndex = 20;
            // 
            // lbltaxtype
            // 
            this.lbltaxtype.AutoSize = true;
            this.lbltaxtype.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltaxtype.Location = new System.Drawing.Point(7, 36);
            this.lbltaxtype.Name = "lbltaxtype";
            this.lbltaxtype.Size = new System.Drawing.Size(62, 18);
            this.lbltaxtype.TabIndex = 19;
            this.lbltaxtype.Text = "Tax Type";
            // 
            // grd_tax
            // 
            this.grd_tax.AllowUserToAddRows = false;
            this.grd_tax.AllowUserToDeleteRows = false;
            this.grd_tax.AllowUserToResizeColumns = false;
            this.grd_tax.AllowUserToResizeRows = false;
            this.grd_tax.BackgroundColor = System.Drawing.Color.Azure;
            this.grd_tax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_tax.Location = new System.Drawing.Point(493, 76);
            this.grd_tax.MaximumSize = new System.Drawing.Size(327, 194);
            this.grd_tax.MinimumSize = new System.Drawing.Size(327, 194);
            this.grd_tax.Name = "grd_tax";
            this.grd_tax.ReadOnly = true;
            this.grd_tax.Size = new System.Drawing.Size(327, 194);
            this.grd_tax.TabIndex = 11;
            this.grd_tax.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grd_tax_RowHeaderMouseClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Location = new System.Drawing.Point(62, 214);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 56);
            this.panel1.TabIndex = 12;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Blue;
            this.btnUpdate.Location = new System.Drawing.Point(317, 13);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(76, 32);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Blue;
            this.btnDelete.Location = new System.Drawing.Point(215, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 32);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Blue;
            this.btnSave.Location = new System.Drawing.Point(113, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.White;
            this.btnNew.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.Blue;
            this.btnNew.Location = new System.Drawing.Point(8, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(85, 32);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(409, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 26);
            this.label3.TabIndex = 22;
            this.label3.Text = "Add Tax";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Tax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 305);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grd_tax);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(862, 344);
            this.MinimumSize = new System.Drawing.Size(862, 344);
            this.Name = "Tax";
            this.Text = "Add Tax";
            this.Load += new System.EventHandler(this.Tax_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_tax)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblpercentage;
        public System.Windows.Forms.TextBox txt_Percentage;
        public System.Windows.Forms.TextBox txt_TaxType;
        private System.Windows.Forms.Label lbltaxtype;
        private System.Windows.Forms.DataGridView grd_tax;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label3;
    }
}