using QuanLyNhaHang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class WCheckOut : Form
    { 
        private int idBill;

        public int IdBill
        {
            get { return idBill; }
            set { idBill = value; }
        }
        public WCheckOut(int id)
        {
            InitializeComponent();
            this.IdBill = id;
        }

        private void WCheckOut_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyNhaHangDataSet1.SP_BillCheckOutReportByIdBIll' table. You can move, or remove it, as needed.
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery("EXEC SP_BillCheckOutReportByIdBIll @Billid",new object[] { this.idBill });

            //this.SP_BillCheckOutReportByIdBIllTableAdapter.Fill(this.QuanLyNhaHangDataSet1.SP_BillCheckOutReportByIdBIll, this.IdBill);

           

            lbTable.Text = TableDAO.Instance.GetTableNameByIdBill(this.IdBill);
            double ttprice = BillDAO.Instance.GetTotalPriceByBillId(this.IdBill);
            tbAllTotalPrice.Text = Convert.ToString(ttprice);
            
          

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            int discount = (int)nmDiscount.Value;
            double ttprice = BillDAO.Instance.GetTotalPriceByBillId(this.IdBill);
            float finalprice = (float)ttprice * (100 - discount) / 100;
 

            if (this.IdBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc chắn thanh toán hóa đơn cho {0}\nTổng tiền = {1} đồng ", TableDAO.Instance.GetTableNameByIdBill(this.IdBill), finalprice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(this.IdBill, discount, finalprice);
                    this.Close();
                }
            }
        }

        
    }
}
