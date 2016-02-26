namespace Entero_Stock.Forms
{
    partial class SalesAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_AddToCart = new System.Windows.Forms.Button();
            this.txt_TotalAmount = new System.Windows.Forms.TextBox();
            this.txt_PurchaseQty = new System.Windows.Forms.TextBox();
            this.txt_UnitPrice = new System.Windows.Forms.TextBox();
            this.txt_Aval_Qty = new System.Windows.Forms.TextBox();
            this.txtproductname = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.grd_ProductList = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_CustomerCode = new System.Windows.Forms.TextBox();
            this.txt_CustomerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_CustomerSearch = new System.Windows.Forms.Button();
            this.txt_ReferenceNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_ProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_ProductCode = new System.Windows.Forms.TextBox();
            this.PurchseProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchasePName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PurchaseProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_HidenProdcutCode = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_SubTotal = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_GrandTotal = new System.Windows.Forms.TextBox();
            this.cmb_Tax = new System.Windows.Forms.ComboBox();
            this.txt_HidenProductId = new System.Windows.Forms.TextBox();
            this.grd_PurchaseList = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmb_BillerName = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_ProductList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_PurchaseList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Ivory;
            this.groupBox1.Controls.Add(this.btn_AddToCart);
            this.groupBox1.Controls.Add(this.txt_TotalAmount);
            this.groupBox1.Controls.Add(this.txt_PurchaseQty);
            this.groupBox1.Controls.Add(this.txt_UnitPrice);
            this.groupBox1.Controls.Add(this.txt_Aval_Qty);
            this.groupBox1.Controls.Add(this.txtproductname);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(66, 534);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 160);
            this.groupBox1.TabIndex = 165;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Details";
            // 
            // btn_AddToCart
            // 
            this.btn_AddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddToCart.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddToCart.ForeColor = System.Drawing.Color.Blue;
            this.btn_AddToCart.Location = new System.Drawing.Point(459, 118);
            this.btn_AddToCart.Name = "btn_AddToCart";
            this.btn_AddToCart.Size = new System.Drawing.Size(117, 31);
            this.btn_AddToCart.TabIndex = 14;
            this.btn_AddToCart.Text = "Add to Cart";
            this.btn_AddToCart.UseVisualStyleBackColor = true;
            this.btn_AddToCart.Click += new System.EventHandler(this.btn_AddToCart_Click);
            // 
            // txt_TotalAmount
            // 
            this.txt_TotalAmount.BackColor = System.Drawing.Color.LemonChiffon;
            this.txt_TotalAmount.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalAmount.Location = new System.Drawing.Point(288, 118);
            this.txt_TotalAmount.Name = "txt_TotalAmount";
            this.txt_TotalAmount.Size = new System.Drawing.Size(141, 29);
            this.txt_TotalAmount.TabIndex = 13;
            // 
            // txt_PurchaseQty
            // 
            this.txt_PurchaseQty.BackColor = System.Drawing.Color.White;
            this.txt_PurchaseQty.Location = new System.Drawing.Point(459, 70);
            this.txt_PurchaseQty.Name = "txt_PurchaseQty";
            this.txt_PurchaseQty.Size = new System.Drawing.Size(117, 25);
            this.txt_PurchaseQty.TabIndex = 12;
            this.txt_PurchaseQty.TextChanged += new System.EventHandler(this.txt_PurchaseQty_TextChanged);
            // 
            // txt_UnitPrice
            // 
            this.txt_UnitPrice.BackColor = System.Drawing.Color.White;
            this.txt_UnitPrice.Location = new System.Drawing.Point(112, 67);
            this.txt_UnitPrice.Name = "txt_UnitPrice";
            this.txt_UnitPrice.Size = new System.Drawing.Size(117, 25);
            this.txt_UnitPrice.TabIndex = 11;
            // 
            // txt_Aval_Qty
            // 
            this.txt_Aval_Qty.BackColor = System.Drawing.Color.White;
            this.txt_Aval_Qty.Location = new System.Drawing.Point(459, 32);
            this.txt_Aval_Qty.Name = "txt_Aval_Qty";
            this.txt_Aval_Qty.Size = new System.Drawing.Size(117, 25);
            this.txt_Aval_Qty.TabIndex = 10;
            // 
            // txtproductname
            // 
            this.txtproductname.BackColor = System.Drawing.Color.White;
            this.txtproductname.Location = new System.Drawing.Point(112, 26);
            this.txtproductname.Name = "txtproductname";
            this.txtproductname.Size = new System.Drawing.Size(240, 25);
            this.txtproductname.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(168, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 22);
            this.label10.TabIndex = 4;
            this.label10.Text = "Total Amount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(362, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 18);
            this.label9.TabIndex = 3;
            this.label9.Text = "Available Qty";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(351, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 18);
            this.label8.TabIndex = 2;
            this.label8.Text = "Sales Qty";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "Unit Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Product Name";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.SeaShell;
            this.btn_Cancel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Blue;
            this.btn_Cancel.Location = new System.Drawing.Point(221, 191);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(91, 36);
            this.btn_Cancel.TabIndex = 20;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            // 
            // grd_ProductList
            // 
            this.grd_ProductList.AllowUserToAddRows = false;
            this.grd_ProductList.AllowUserToDeleteRows = false;
            this.grd_ProductList.AllowUserToResizeColumns = false;
            this.grd_ProductList.AllowUserToResizeRows = false;
            this.grd_ProductList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_ProductList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grd_ProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_ProductList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.Column2,
            this.Column3,
            this.Category,
            this.AvailableQuantity,
            this.UnitPrice});
            this.grd_ProductList.Location = new System.Drawing.Point(66, 352);
            this.grd_ProductList.MultiSelect = false;
            this.grd_ProductList.Name = "grd_ProductList";
            this.grd_ProductList.ReadOnly = true;
            this.grd_ProductList.RowHeadersWidth = 30;
            this.grd_ProductList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grd_ProductList.Size = new System.Drawing.Size(622, 153);
            this.grd_ProductList.TabIndex = 8;
            this.grd_ProductList.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grd_ProductList_RowHeaderMouseClick);
            // 
            // ProductId
            // 
            this.ProductId.DataPropertyName = "ProductID";
            this.ProductId.HeaderText = "ProductId";
            this.ProductId.Name = "ProductId";
            this.ProductId.ReadOnly = true;
            this.ProductId.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ProductCode";
            this.Column2.HeaderText = "Product Code";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 90;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "PName";
            this.Column3.HeaderText = "Product Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 170;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "CName";
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 140;
            // 
            // AvailableQuantity
            // 
            this.AvailableQuantity.DataPropertyName = "Quantity";
            this.AvailableQuantity.HeaderText = "Available Quantity";
            this.AvailableQuantity.Name = "AvailableQuantity";
            this.AvailableQuantity.ReadOnly = true;
            this.AvailableQuantity.Width = 90;
            // 
            // UnitPrice
            // 
            this.UnitPrice.DataPropertyName = "Price";
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            // 
            // txt_CustomerCode
            // 
            this.txt_CustomerCode.BackColor = System.Drawing.Color.White;
            this.txt_CustomerCode.Location = new System.Drawing.Point(265, 99);
            this.txt_CustomerCode.Name = "txt_CustomerCode";
            this.txt_CustomerCode.Size = new System.Drawing.Size(142, 26);
            this.txt_CustomerCode.TabIndex = 2;
            this.txt_CustomerCode.Text = "C-";
            // 
            // txt_CustomerName
            // 
            this.txt_CustomerName.BackColor = System.Drawing.Color.White;
            this.txt_CustomerName.Location = new System.Drawing.Point(265, 135);
            this.txt_CustomerName.Name = "txt_CustomerName";
            this.txt_CustomerName.Size = new System.Drawing.Size(229, 26);
            this.txt_CustomerName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(96, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 18);
            this.label4.TabIndex = 152;
            this.label4.Text = "Customer Name";
            // 
            // btn_CustomerSearch
            // 
            this.btn_CustomerSearch.BackColor = System.Drawing.Color.White;
            this.btn_CustomerSearch.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CustomerSearch.Location = new System.Drawing.Point(432, 100);
            this.btn_CustomerSearch.Name = "btn_CustomerSearch";
            this.btn_CustomerSearch.Size = new System.Drawing.Size(62, 27);
            this.btn_CustomerSearch.TabIndex = 3;
            this.btn_CustomerSearch.Text = "<";
            this.btn_CustomerSearch.UseVisualStyleBackColor = false;
            this.btn_CustomerSearch.Click += new System.EventHandler(this.btn_CustomerSearch_Click);
            // 
            // txt_ReferenceNo
            // 
            this.txt_ReferenceNo.BackColor = System.Drawing.Color.White;
            this.txt_ReferenceNo.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ReferenceNo.Location = new System.Drawing.Point(265, 24);
            this.txt_ReferenceNo.Name = "txt_ReferenceNo";
            this.txt_ReferenceNo.ReadOnly = true;
            this.txt_ReferenceNo.Size = new System.Drawing.Size(142, 25);
            this.txt_ReferenceNo.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(95, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 18);
            this.label5.TabIndex = 146;
            this.label5.Text = "Customer Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(98, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 145;
            this.label3.Text = "Sales Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_ProductName);
            this.groupBox2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(66, 276);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 64);
            this.groupBox2.TabIndex = 167;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search by Product Name";
            // 
            // txt_ProductName
            // 
            this.txt_ProductName.BackColor = System.Drawing.Color.White;
            this.txt_ProductName.Location = new System.Drawing.Point(9, 24);
            this.txt_ProductName.Name = "txt_ProductName";
            this.txt_ProductName.Size = new System.Drawing.Size(220, 25);
            this.txt_ProductName.TabIndex = 6;
            this.txt_ProductName.TextChanged += new System.EventHandler(this.txt_ProductName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(98, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 144;
            this.label2.Text = "Reference Number";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.CalendarTitleBackColor = System.Drawing.Color.LemonChiffon;
            this.dtpPurchaseDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpPurchaseDate.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPurchaseDate.Location = new System.Drawing.Point(265, 62);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(229, 25);
            this.dtpPurchaseDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(665, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 26);
            this.label1.TabIndex = 166;
            this.label1.Text = "Sales Admin";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 18);
            this.label13.TabIndex = 1;
            this.label13.Text = "VAT + ST";
            // 
            // txt_ProductCode
            // 
            this.txt_ProductCode.BackColor = System.Drawing.Color.White;
            this.txt_ProductCode.Location = new System.Drawing.Point(8, 24);
            this.txt_ProductCode.Name = "txt_ProductCode";
            this.txt_ProductCode.Size = new System.Drawing.Size(220, 25);
            this.txt_ProductCode.TabIndex = 7;
            this.txt_ProductCode.TextChanged += new System.EventHandler(this.txt_ProductCode_TextChanged);
            // 
            // PurchseProductCode
            // 
            this.PurchseProductCode.DataPropertyName = "ProductCode";
            this.PurchseProductCode.HeaderText = "Product Code";
            this.PurchseProductCode.Name = "PurchseProductCode";
            this.PurchseProductCode.ReadOnly = true;
            this.PurchseProductCode.Width = 90;
            // 
            // PurchasePName
            // 
            this.PurchasePName.DataPropertyName = "PName";
            this.PurchasePName.HeaderText = "Product Name";
            this.PurchasePName.Name = "PurchasePName";
            this.PurchasePName.ReadOnly = true;
            this.PurchasePName.Width = 150;
            // 
            // PurchaseQuantity
            // 
            this.PurchaseQuantity.DataPropertyName = "PurchaseQuantity";
            this.PurchaseQuantity.HeaderText = "Quantity";
            this.PurchaseQuantity.Name = "PurchaseQuantity";
            this.PurchaseQuantity.ReadOnly = true;
            this.PurchaseQuantity.Width = 130;
            // 
            // PurchaseUnitPrice
            // 
            this.PurchaseUnitPrice.DataPropertyName = "PurchaseunitPrice";
            this.PurchaseUnitPrice.HeaderText = "Unit Price";
            this.PurchaseUnitPrice.Name = "PurchaseUnitPrice";
            this.PurchaseUnitPrice.ReadOnly = true;
            this.PurchaseUnitPrice.Width = 90;
            // 
            // PurchaseTotalPrice
            // 
            this.PurchaseTotalPrice.DataPropertyName = "PurchaseTotalPrice";
            this.PurchaseTotalPrice.HeaderText = "Total Price";
            this.PurchaseTotalPrice.Name = "PurchaseTotalPrice";
            this.PurchaseTotalPrice.ReadOnly = true;
            this.PurchaseTotalPrice.Width = 90;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // PurchaseProductID
            // 
            this.PurchaseProductID.DataPropertyName = "ProductId";
            this.PurchaseProductID.HeaderText = "ProductID";
            this.PurchaseProductID.Name = "PurchaseProductID";
            this.PurchaseProductID.ReadOnly = true;
            this.PurchaseProductID.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Maroon;
            this.label14.Location = new System.Drawing.Point(34, 126);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 28);
            this.label14.TabIndex = 2;
            this.label14.Text = "Grand Total";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(38, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 18);
            this.label12.TabIndex = 0;
            this.label12.Text = "Sub Total";
            // 
            // txt_HidenProdcutCode
            // 
            this.txt_HidenProdcutCode.Location = new System.Drawing.Point(944, 651);
            this.txt_HidenProdcutCode.Name = "txt_HidenProdcutCode";
            this.txt_HidenProdcutCode.Size = new System.Drawing.Size(100, 20);
            this.txt_HidenProdcutCode.TabIndex = 173;
            this.txt_HidenProdcutCode.Visible = false;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.SeaShell;
            this.btn_Save.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.Color.Blue;
            this.btn_Save.Location = new System.Drawing.Point(109, 191);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(100, 36);
            this.btn_Save.TabIndex = 19;
            this.btn_Save.Text = "Save ";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_SubTotal
            // 
            this.txt_SubTotal.BackColor = System.Drawing.Color.White;
            this.txt_SubTotal.Location = new System.Drawing.Point(145, 35);
            this.txt_SubTotal.Name = "txt_SubTotal";
            this.txt_SubTotal.Size = new System.Drawing.Size(167, 25);
            this.txt_SubTotal.TabIndex = 16;
            this.txt_SubTotal.TextChanged += new System.EventHandler(this.txt_SubTotal_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Save);
            this.panel2.Controls.Add(this.txt_GrandTotal);
            this.panel2.Controls.Add(this.txt_SubTotal);
            this.panel2.Controls.Add(this.cmb_Tax);
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(879, 264);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 276);
            this.panel2.TabIndex = 170;
            // 
            // txt_GrandTotal
            // 
            this.txt_GrandTotal.BackColor = System.Drawing.Color.White;
            this.txt_GrandTotal.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_GrandTotal.Location = new System.Drawing.Point(174, 126);
            this.txt_GrandTotal.Name = "txt_GrandTotal";
            this.txt_GrandTotal.Size = new System.Drawing.Size(138, 33);
            this.txt_GrandTotal.TabIndex = 18;
            this.txt_GrandTotal.TextChanged += new System.EventHandler(this.txt_GrandTotal_TextChanged);
            // 
            // cmb_Tax
            // 
            this.cmb_Tax.BackColor = System.Drawing.Color.White;
            this.cmb_Tax.FormattingEnabled = true;
            this.cmb_Tax.Location = new System.Drawing.Point(145, 77);
            this.cmb_Tax.Name = "cmb_Tax";
            this.cmb_Tax.Size = new System.Drawing.Size(167, 26);
            this.cmb_Tax.TabIndex = 17;
            this.cmb_Tax.SelectedIndexChanged += new System.EventHandler(this.cmb_Tax_SelectedIndexChanged);
            // 
            // txt_HidenProductId
            // 
            this.txt_HidenProductId.Location = new System.Drawing.Point(850, 651);
            this.txt_HidenProductId.Name = "txt_HidenProductId";
            this.txt_HidenProductId.Size = new System.Drawing.Size(100, 20);
            this.txt_HidenProductId.TabIndex = 164;
            this.txt_HidenProductId.Visible = false;
            // 
            // grd_PurchaseList
            // 
            this.grd_PurchaseList.AllowUserToAddRows = false;
            this.grd_PurchaseList.AllowUserToDeleteRows = false;
            this.grd_PurchaseList.AllowUserToResizeColumns = false;
            this.grd_PurchaseList.AllowUserToResizeRows = false;
            this.grd_PurchaseList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_PurchaseList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grd_PurchaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_PurchaseList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PurchseProductCode,
            this.PurchasePName,
            this.PurchaseQuantity,
            this.PurchaseUnitPrice,
            this.PurchaseTotalPrice,
            this.Delete,
            this.PurchaseProductID});
            this.grd_PurchaseList.Location = new System.Drawing.Point(721, 71);
            this.grd_PurchaseList.MultiSelect = false;
            this.grd_PurchaseList.Name = "grd_PurchaseList";
            this.grd_PurchaseList.ReadOnly = true;
            this.grd_PurchaseList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grd_PurchaseList.Size = new System.Drawing.Size(699, 173);
            this.grd_PurchaseList.TabIndex = 15;
            this.grd_PurchaseList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_PurchaseList_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmb_BillerName);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txt_CustomerCode);
            this.groupBox3.Controls.Add(this.txt_CustomerName);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btn_CustomerSearch);
            this.groupBox3.Controls.Add(this.txt_ReferenceNo);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dtpPurchaseDate);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(66, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(611, 214);
            this.groupBox3.TabIndex = 171;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sales Details";
            // 
            // cmb_BillerName
            // 
            this.cmb_BillerName.BackColor = System.Drawing.Color.White;
            this.cmb_BillerName.FormattingEnabled = true;
            this.cmb_BillerName.Location = new System.Drawing.Point(265, 173);
            this.cmb_BillerName.Name = "cmb_BillerName";
            this.cmb_BillerName.Size = new System.Drawing.Size(229, 27);
            this.cmb_BillerName.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(95, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 18);
            this.label11.TabIndex = 155;
            this.label11.Text = "Biller Name";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_ProductCode);
            this.groupBox4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(317, 276);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(236, 64);
            this.groupBox4.TabIndex = 168;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search by Product Code";
            // 
            // SalesAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1481, 712);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grd_ProductList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_HidenProdcutCode);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txt_HidenProductId);
            this.Controls.Add(this.grd_PurchaseList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.MaximumSize = new System.Drawing.Size(1497, 751);
            this.MinimumSize = new System.Drawing.Size(1497, 751);
            this.Name = "SalesAdmin";
            this.Text = "SalesAdmin";
            this.Load += new System.EventHandler(this.SalesAdmin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_ProductList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_PurchaseList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btn_AddToCart;
        private System.Windows.Forms.TextBox txt_TotalAmount;
        private System.Windows.Forms.TextBox txt_PurchaseQty;
        private System.Windows.Forms.TextBox txt_UnitPrice;
        private System.Windows.Forms.TextBox txt_Aval_Qty;
        private System.Windows.Forms.TextBox txtproductname;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Button btn_Cancel;
        public System.Windows.Forms.DataGridView grd_ProductList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailableQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.TextBox txt_CustomerCode;
        private System.Windows.Forms.TextBox txt_CustomerName;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button btn_CustomerSearch;
        internal System.Windows.Forms.TextBox txt_ReferenceNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_ProductName;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchseProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchasePName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseTotalPrice;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseProductID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_HidenProdcutCode;
        internal System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txt_SubTotal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_GrandTotal;
        private System.Windows.Forms.ComboBox cmb_Tax;
        private System.Windows.Forms.TextBox txt_HidenProductId;
        public System.Windows.Forms.DataGridView grd_PurchaseList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_BillerName;
    }
}