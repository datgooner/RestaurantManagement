namespace QuanLyNhaHang
{
    partial class WCheckOut
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
            this.components = new System.ComponentModel.Container();
            this.SP_BillCheckOutReportByIdBIllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLyNhaHangDataSet1 = new QuanLyNhaHang.QuanLyNhaHangDataSet1();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbTable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbAllTotalPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nmDiscount = new System.Windows.Forms.NumericUpDown();
            this.SP_BillCheckOutReportByIdBIllTableAdapter = new QuanLyNhaHang.QuanLyNhaHangDataSet1TableAdapters.SP_BillCheckOutReportByIdBIllTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.SP_BillCheckOutReportByIdBIllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyNhaHangDataSet1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // SP_BillCheckOutReportByIdBIllBindingSource
            // 
            this.SP_BillCheckOutReportByIdBIllBindingSource.DataMember = "SP_BillCheckOutReportByIdBIll";
            this.SP_BillCheckOutReportByIdBIllBindingSource.DataSource = this.QuanLyNhaHangDataSet1;
            // 
            // QuanLyNhaHangDataSet1
            // 
            this.QuanLyNhaHangDataSet1.DataSetName = "QuanLyNhaHangDataSet1";
            this.QuanLyNhaHangDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 454);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbTable);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(868, 50);
            this.panel2.TabIndex = 1;
            // 
            // lbTable
            // 
            this.lbTable.AutoSize = true;
            this.lbTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTable.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbTable.Location = new System.Drawing.Point(256, 15);
            this.lbTable.Name = "lbTable";
            this.lbTable.Size = new System.Drawing.Size(63, 24);
            this.lbTable.TabIndex = 1;
            this.lbTable.Text = "Bàn 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thanh toán hóa đơn cho:";
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(773, 12);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(92, 69);
            this.btnCheckOut.TabIndex = 5;
            this.btnCheckOut.Text = "Thanh toán";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbAllTotalPrice);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.nmDiscount);
            this.panel3.Controls.Add(this.btnCheckOut);
            this.panel3.Location = new System.Drawing.Point(12, 527);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(868, 91);
            this.panel3.TabIndex = 6;
            // 
            // tbAllTotalPrice
            // 
            this.tbAllTotalPrice.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAllTotalPrice.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tbAllTotalPrice.Location = new System.Drawing.Point(562, 53);
            this.tbAllTotalPrice.Name = "tbAllTotalPrice";
            this.tbAllTotalPrice.ReadOnly = true;
            this.tbAllTotalPrice.Size = new System.Drawing.Size(165, 28);
            this.tbAllTotalPrice.TabIndex = 15;
            this.tbAllTotalPrice.Text = "0";
            this.tbAllTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(588, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tổng tiền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(430, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 24);
            this.label3.TabIndex = 13;
            this.label3.Text = "Giảm giá";
            // 
            // nmDiscount
            // 
            this.nmDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmDiscount.Location = new System.Drawing.Point(430, 53);
            this.nmDiscount.Name = "nmDiscount";
            this.nmDiscount.Size = new System.Drawing.Size(92, 28);
            this.nmDiscount.TabIndex = 12;
            this.nmDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SP_BillCheckOutReportByIdBIllTableAdapter
            // 
            this.SP_BillCheckOutReportByIdBIllTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.totalPriceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.SP_BillCheckOutReportByIdBIllBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(865, 451);
            this.dataGridView1.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 200F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Tên món";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 15;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = "count";
            this.countDataGridViewTextBoxColumn.HeaderText = "count";
            this.countDataGridViewTextBoxColumn.MinimumWidth = 15;
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.ReadOnly = true;
            this.countDataGridViewTextBoxColumn.Width = 125;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "price";
            this.priceDataGridViewTextBoxColumn.MinimumWidth = 15;
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Width = 125;
            // 
            // totalPriceDataGridViewTextBoxColumn
            // 
            this.totalPriceDataGridViewTextBoxColumn.DataPropertyName = "totalPrice";
            this.totalPriceDataGridViewTextBoxColumn.HeaderText = "totalPrice";
            this.totalPriceDataGridViewTextBoxColumn.MinimumWidth = 15;
            this.totalPriceDataGridViewTextBoxColumn.Name = "totalPriceDataGridViewTextBoxColumn";
            this.totalPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalPriceDataGridViewTextBoxColumn.Width = 125;
            // 
            // WCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 630);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "WCheckOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán";
            this.Load += new System.EventHandler(this.WCheckOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SP_BillCheckOutReportByIdBIllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyNhaHangDataSet1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
       
        private System.Windows.Forms.Label lbTable;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmDiscount;
        private System.Windows.Forms.TextBox tbAllTotalPrice;
        private System.Windows.Forms.BindingSource SP_BillCheckOutReportByIdBIllBindingSource;
        private QuanLyNhaHangDataSet1 QuanLyNhaHangDataSet1;
        private QuanLyNhaHangDataSet1TableAdapters.SP_BillCheckOutReportByIdBIllTableAdapter SP_BillCheckOutReportByIdBIllTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPriceDataGridViewTextBoxColumn;
    }
}