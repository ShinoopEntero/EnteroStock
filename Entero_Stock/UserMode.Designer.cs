namespace Entero_Stock
{
    partial class UserMode
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
            this.rdb_SingleUser = new System.Windows.Forms.RadioButton();
            this.rdb_MultyUser = new System.Windows.Forms.RadioButton();
            this.btn_SelectUser = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grp_Type = new System.Windows.Forms.GroupBox();
            this.rdb_Client = new System.Windows.Forms.RadioButton();
            this.rdb_Server = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.grp_Type.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdb_SingleUser
            // 
            this.rdb_SingleUser.AutoSize = true;
            this.rdb_SingleUser.Location = new System.Drawing.Point(21, 20);
            this.rdb_SingleUser.Name = "rdb_SingleUser";
            this.rdb_SingleUser.Size = new System.Drawing.Size(79, 17);
            this.rdb_SingleUser.TabIndex = 0;
            this.rdb_SingleUser.TabStop = true;
            this.rdb_SingleUser.Text = "Single User";
            this.rdb_SingleUser.UseVisualStyleBackColor = true;
            // 
            // rdb_MultyUser
            // 
            this.rdb_MultyUser.AutoSize = true;
            this.rdb_MultyUser.Location = new System.Drawing.Point(143, 20);
            this.rdb_MultyUser.Name = "rdb_MultyUser";
            this.rdb_MultyUser.Size = new System.Drawing.Size(75, 17);
            this.rdb_MultyUser.TabIndex = 1;
            this.rdb_MultyUser.TabStop = true;
            this.rdb_MultyUser.Text = "Multy User";
            this.rdb_MultyUser.UseVisualStyleBackColor = true;
            this.rdb_MultyUser.CheckedChanged += new System.EventHandler(this.rdb_MultyUser_CheckedChanged);
            // 
            // btn_SelectUser
            // 
            this.btn_SelectUser.Location = new System.Drawing.Point(136, 162);
            this.btn_SelectUser.Name = "btn_SelectUser";
            this.btn_SelectUser.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectUser.TabIndex = 3;
            this.btn_SelectUser.Text = "Select";
            this.btn_SelectUser.UseVisualStyleBackColor = true;
            this.btn_SelectUser.Click += new System.EventHandler(this.btn_SelectUser_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_MultyUser);
            this.groupBox1.Controls.Add(this.rdb_SingleUser);
            this.groupBox1.Location = new System.Drawing.Point(64, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 54);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select User Mode";
            // 
            // grp_Type
            // 
            this.grp_Type.Controls.Add(this.rdb_Server);
            this.grp_Type.Controls.Add(this.rdb_Client);
            this.grp_Type.Location = new System.Drawing.Point(207, 81);
            this.grp_Type.Name = "grp_Type";
            this.grp_Type.Size = new System.Drawing.Size(120, 75);
            this.grp_Type.TabIndex = 5;
            this.grp_Type.TabStop = false;
            this.grp_Type.Text = "Type";
            // 
            // rdb_Client
            // 
            this.rdb_Client.AutoSize = true;
            this.rdb_Client.Location = new System.Drawing.Point(18, 20);
            this.rdb_Client.Name = "rdb_Client";
            this.rdb_Client.Size = new System.Drawing.Size(51, 17);
            this.rdb_Client.TabIndex = 0;
            this.rdb_Client.TabStop = true;
            this.rdb_Client.Text = "Client";
            this.rdb_Client.UseVisualStyleBackColor = true;
            // 
            // rdb_Server
            // 
            this.rdb_Server.AutoSize = true;
            this.rdb_Server.Location = new System.Drawing.Point(18, 43);
            this.rdb_Server.Name = "rdb_Server";
            this.rdb_Server.Size = new System.Drawing.Size(56, 17);
            this.rdb_Server.TabIndex = 1;
            this.rdb_Server.TabStop = true;
            this.rdb_Server.Text = "Server";
            this.rdb_Server.UseVisualStyleBackColor = true;
            // 
            // UserMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 206);
            this.Controls.Add(this.grp_Type);
            this.Controls.Add(this.btn_SelectUser);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserMode";
            this.Text = "UserMode";
            this.Load += new System.EventHandler(this.UserMode_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grp_Type.ResumeLayout(false);
            this.grp_Type.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdb_SingleUser;
        private System.Windows.Forms.RadioButton rdb_MultyUser;
        private System.Windows.Forms.Button btn_SelectUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grp_Type;
        private System.Windows.Forms.RadioButton rdb_Server;
        private System.Windows.Forms.RadioButton rdb_Client;
    }
}