namespace Entero_Stock.Forms
{
    partial class ChangePassword
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
            this.btn_ChangePass = new System.Windows.Forms.Button();
            this.txt_ConformPass = new System.Windows.Forms.TextBox();
            this.txt_NewPass = new System.Windows.Forms.TextBox();
            this.txt_OldPassword = new System.Windows.Forms.TextBox();
            this.lblconfpass = new System.Windows.Forms.Label();
            this.lbnewpas = new System.Windows.Forms.Label();
            this.lboldpass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ChangePass
            // 
            this.btn_ChangePass.BackColor = System.Drawing.Color.SeaShell;
            this.btn_ChangePass.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChangePass.ForeColor = System.Drawing.Color.Blue;
            this.btn_ChangePass.Location = new System.Drawing.Point(106, 148);
            this.btn_ChangePass.Name = "btn_ChangePass";
            this.btn_ChangePass.Size = new System.Drawing.Size(170, 31);
            this.btn_ChangePass.TabIndex = 3;
            this.btn_ChangePass.Text = "Change Password";
            this.btn_ChangePass.UseVisualStyleBackColor = false;
            this.btn_ChangePass.Click += new System.EventHandler(this.btn_ChangePass_Click);
            // 
            // txt_ConformPass
            // 
            this.txt_ConformPass.BackColor = System.Drawing.SystemColors.Control;
            this.txt_ConformPass.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ConformPass.ForeColor = System.Drawing.Color.Black;
            this.txt_ConformPass.Location = new System.Drawing.Point(169, 93);
            this.txt_ConformPass.Name = "txt_ConformPass";
            this.txt_ConformPass.PasswordChar = '*';
            this.txt_ConformPass.Size = new System.Drawing.Size(181, 22);
            this.txt_ConformPass.TabIndex = 2;
            // 
            // txt_NewPass
            // 
            this.txt_NewPass.BackColor = System.Drawing.SystemColors.Control;
            this.txt_NewPass.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NewPass.ForeColor = System.Drawing.Color.Black;
            this.txt_NewPass.Location = new System.Drawing.Point(169, 57);
            this.txt_NewPass.Name = "txt_NewPass";
            this.txt_NewPass.PasswordChar = '*';
            this.txt_NewPass.Size = new System.Drawing.Size(181, 22);
            this.txt_NewPass.TabIndex = 1;
            // 
            // txt_OldPassword
            // 
            this.txt_OldPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txt_OldPassword.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_OldPassword.ForeColor = System.Drawing.Color.Black;
            this.txt_OldPassword.Location = new System.Drawing.Point(169, 20);
            this.txt_OldPassword.Name = "txt_OldPassword";
            this.txt_OldPassword.PasswordChar = '*';
            this.txt_OldPassword.Size = new System.Drawing.Size(181, 22);
            this.txt_OldPassword.TabIndex = 0;
            // 
            // lblconfpass
            // 
            this.lblconfpass.AutoSize = true;
            this.lblconfpass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblconfpass.Location = new System.Drawing.Point(17, 96);
            this.lblconfpass.MaximumSize = new System.Drawing.Size(122, 19);
            this.lblconfpass.MinimumSize = new System.Drawing.Size(122, 19);
            this.lblconfpass.Name = "lblconfpass";
            this.lblconfpass.Size = new System.Drawing.Size(122, 19);
            this.lblconfpass.TabIndex = 38;
            this.lblconfpass.Text = "Confirm Password";
            // 
            // lbnewpas
            // 
            this.lbnewpas.AutoSize = true;
            this.lbnewpas.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnewpas.Location = new System.Drawing.Point(16, 61);
            this.lbnewpas.Name = "lbnewpas";
            this.lbnewpas.Size = new System.Drawing.Size(103, 19);
            this.lbnewpas.TabIndex = 37;
            this.lbnewpas.Text = "New Password";
            // 
            // lboldpass
            // 
            this.lboldpass.AutoSize = true;
            this.lboldpass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lboldpass.Location = new System.Drawing.Point(17, 21);
            this.lboldpass.Name = "lboldpass";
            this.lboldpass.Size = new System.Drawing.Size(96, 19);
            this.lboldpass.TabIndex = 36;
            this.lboldpass.Text = "Old Password";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 204);
            this.Controls.Add(this.btn_ChangePass);
            this.Controls.Add(this.txt_ConformPass);
            this.Controls.Add(this.txt_NewPass);
            this.Controls.Add(this.txt_OldPassword);
            this.Controls.Add(this.lblconfpass);
            this.Controls.Add(this.lbnewpas);
            this.Controls.Add(this.lboldpass);
            this.MaximumSize = new System.Drawing.Size(406, 243);
            this.MinimumSize = new System.Drawing.Size(406, 243);
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ChangePass;
        private System.Windows.Forms.TextBox txt_ConformPass;
        private System.Windows.Forms.TextBox txt_NewPass;
        private System.Windows.Forms.TextBox txt_OldPassword;
        private System.Windows.Forms.Label lblconfpass;
        private System.Windows.Forms.Label lbnewpas;
        private System.Windows.Forms.Label lboldpass;
    }
}