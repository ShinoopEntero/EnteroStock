namespace Entero_stock
{
    partial class userRole
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
            this.txt_Role = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnup = new System.Windows.Forms.Button();
            this.btndel = new System.Windows.Forms.Button();
            this.btnreg = new System.Windows.Forms.Button();
            this.btnnew = new System.Windows.Forms.Button();
            this.grd_Role = new System.Windows.Forms.DataGridView();
            this.RoleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Role)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Role
            // 
            this.txt_Role.BackColor = System.Drawing.Color.White;
            this.txt_Role.Location = new System.Drawing.Point(172, 36);
            this.txt_Role.Name = "txt_Role";
            this.txt_Role.Size = new System.Drawing.Size(222, 26);
            this.txt_Role.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "User Role";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_Role);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 77);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Role";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnup);
            this.panel1.Controls.Add(this.btndel);
            this.panel1.Controls.Add(this.btnreg);
            this.panel1.Controls.Add(this.btnnew);
            this.panel1.Location = new System.Drawing.Point(16, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 67);
            this.panel1.TabIndex = 10;
            // 
            // btnup
            // 
            this.btnup.BackColor = System.Drawing.Color.White;
            this.btnup.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnup.ForeColor = System.Drawing.Color.Blue;
            this.btnup.Location = new System.Drawing.Point(202, 22);
            this.btnup.Name = "btnup";
            this.btnup.Size = new System.Drawing.Size(75, 30);
            this.btnup.TabIndex = 3;
            this.btnup.Text = "Update";
            this.btnup.UseVisualStyleBackColor = false;
            this.btnup.Click += new System.EventHandler(this.btnup_Click);
            // 
            // btndel
            // 
            this.btndel.BackColor = System.Drawing.Color.White;
            this.btndel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndel.ForeColor = System.Drawing.Color.Blue;
            this.btndel.Location = new System.Drawing.Point(294, 22);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(75, 30);
            this.btndel.TabIndex = 2;
            this.btndel.Text = "Delete";
            this.btndel.UseVisualStyleBackColor = false;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // btnreg
            // 
            this.btnreg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnreg.BackColor = System.Drawing.Color.White;
            this.btnreg.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreg.ForeColor = System.Drawing.Color.Blue;
            this.btnreg.Location = new System.Drawing.Point(108, 22);
            this.btnreg.Name = "btnreg";
            this.btnreg.Size = new System.Drawing.Size(75, 30);
            this.btnreg.TabIndex = 1;
            this.btnreg.Text = "Register";
            this.btnreg.UseVisualStyleBackColor = false;
            this.btnreg.Click += new System.EventHandler(this.btnreg_Click);
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.White;
            this.btnnew.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnew.ForeColor = System.Drawing.Color.Blue;
            this.btnnew.Location = new System.Drawing.Point(14, 22);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(75, 30);
            this.btnnew.TabIndex = 0;
            this.btnnew.Text = "New";
            this.btnnew.UseVisualStyleBackColor = false;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // grd_Role
            // 
            this.grd_Role.AllowUserToAddRows = false;
            this.grd_Role.AllowUserToDeleteRows = false;
            this.grd_Role.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grd_Role.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Role.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoleId,
            this.Role});
            this.grd_Role.Location = new System.Drawing.Point(449, 46);
            this.grd_Role.Name = "grd_Role";
            this.grd_Role.ReadOnly = true;
            this.grd_Role.Size = new System.Drawing.Size(199, 157);
            this.grd_Role.TabIndex = 4;
            this.grd_Role.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_Role_CellContentClick);
            this.grd_Role.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grd_Role_RowHeaderMouseClick);
            // 
            // RoleId
            // 
            this.RoleId.DataPropertyName = "RoleId";
            this.RoleId.HeaderText = "RoleId";
            this.RoleId.MinimumWidth = 100;
            this.RoleId.Name = "RoleId";
            this.RoleId.ReadOnly = true;
            this.RoleId.Visible = false;
            // 
            // Role
            // 
            this.Role.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Role.DataPropertyName = "Role";
            this.Role.HeaderText = "User Roles";
            this.Role.MinimumWidth = 100;
            this.Role.Name = "Role";
            this.Role.ReadOnly = true;
            // 
            // userRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 241);
            this.Controls.Add(this.grd_Role);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(711, 280);
            this.MinimumSize = new System.Drawing.Size(711, 280);
            this.Name = "userRole";
            this.Text = "UserRole";
            this.Load += new System.EventHandler(this.UserRole_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_Role)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Role;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnup;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        public System.Windows.Forms.Button btndel;
        public System.Windows.Forms.Button btnreg;
        internal System.Windows.Forms.Button btnnew;
        public System.Windows.Forms.DataGridView grd_Role;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Panel panel1;
    }
}