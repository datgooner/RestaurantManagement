namespace QuanLyNhaHang
{
    partial class WTableManager
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtThoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nmFoodCout = new System.Windows.Forms.NumericUpDown();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.cbFoodCategory = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LbTabel = new System.Windows.Forms.Label();
            this.listViewBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAllTotalPrice = new System.Windows.Forms.TextBox();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCout)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1028, 28);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            this.quảnLýToolStripMenuItem.Click += new System.EventHandler(this.quảnLýToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtThoátToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtThoátToolStripMenuItem
            // 
            this.đăngXuấtThoátToolStripMenuItem.Name = "đăngXuấtThoátToolStripMenuItem";
            this.đăngXuấtThoátToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.đăngXuấtThoátToolStripMenuItem.Text = "Đăng xuất ";
            this.đăngXuấtThoátToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtThoátToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nmFoodCout);
            this.panel2.Controls.Add(this.btnAddFood);
            this.panel2.Controls.Add(this.cbFood);
            this.panel2.Controls.Add(this.cbFoodCategory);
            this.panel2.Location = new System.Drawing.Point(611, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(405, 98);
            this.panel2.TabIndex = 2;
            // 
            // nmFoodCout
            // 
            this.nmFoodCout.Location = new System.Drawing.Point(350, 40);
            this.nmFoodCout.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmFoodCout.Name = "nmFoodCout";
            this.nmFoodCout.Size = new System.Drawing.Size(52, 22);
            this.nmFoodCout.TabIndex = 3;
            this.nmFoodCout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(252, 19);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(92, 63);
            this.btnAddFood.TabIndex = 2;
            this.btnAddFood.Text = "Thêm món";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // cbFood
            // 
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(3, 58);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(243, 24);
            this.cbFood.TabIndex = 1;
            // 
            // cbFoodCategory
            // 
            this.cbFoodCategory.FormattingEnabled = true;
            this.cbFoodCategory.Location = new System.Drawing.Point(3, 18);
            this.cbFoodCategory.Name = "cbFoodCategory";
            this.cbFoodCategory.Size = new System.Drawing.Size(243, 24);
            this.cbFoodCategory.TabIndex = 0;
            this.cbFoodCategory.SelectedIndexChanged += new System.EventHandler(this.cbFoodCategory_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LbTabel);
            this.panel3.Controls.Add(this.listViewBill);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel3.Location = new System.Drawing.Point(611, 135);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(405, 406);
            this.panel3.TabIndex = 3;
            // 
            // LbTabel
            // 
            this.LbTabel.AutoSize = true;
            this.LbTabel.Location = new System.Drawing.Point(3, 11);
            this.LbTabel.Name = "LbTabel";
            this.LbTabel.Size = new System.Drawing.Size(0, 24);
            this.LbTabel.TabIndex = 1;
            // 
            // listViewBill
            // 
            this.listViewBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewBill.GridLines = true;
            this.listViewBill.Location = new System.Drawing.Point(3, 33);
            this.listViewBill.Name = "listViewBill";
            this.listViewBill.Size = new System.Drawing.Size(399, 359);
            this.listViewBill.TabIndex = 0;
            this.listViewBill.UseCompatibleStateImageBehavior = false;
            this.listViewBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 126;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 79;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 91;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 98;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.tbAllTotalPrice);
            this.panel4.Controls.Add(this.btnCheckOut);
            this.panel4.Location = new System.Drawing.Point(611, 544);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(405, 94);
            this.panel4.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(178, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tổng";
            // 
            // tbAllTotalPrice
            // 
            this.tbAllTotalPrice.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAllTotalPrice.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tbAllTotalPrice.Location = new System.Drawing.Point(130, 55);
            this.tbAllTotalPrice.Name = "tbAllTotalPrice";
            this.tbAllTotalPrice.ReadOnly = true;
            this.tbAllTotalPrice.Size = new System.Drawing.Size(165, 28);
            this.tbAllTotalPrice.TabIndex = 9;
            this.tbAllTotalPrice.Text = "0";
            this.tbAllTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(310, 16);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(92, 69);
            this.btnCheckOut.TabIndex = 4;
            this.btnCheckOut.Text = "Thanh toán";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Location = new System.Drawing.Point(9, 31);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(592, 607);
            this.flpTable.TabIndex = 5;
            // 
            // WTableManager
            // 
            this.ClientSize = new System.Drawing.Size(1028, 650);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "WTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý nhà hàng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WTableManager_FormClosing);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCout)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtThoátToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.ComboBox cbFoodCategory;
        private System.Windows.Forms.NumericUpDown nmFoodCout;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView listViewBill;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAllTotalPrice;
        private System.Windows.Forms.Label LbTabel;
    }
}