using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;
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
    public partial class WTableManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }


        public WTableManager(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
        
            LoadTable();
            LoadCategory();
        }
        #region Method

        void ChangeAccount (int type)
        {
            quảnLýToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbFoodCategory.DataSource = listCategory;
            cbFoodCategory.DisplayMember = "name";

        }
        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "name";

        }


        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> tablelist = TableDAO.Instance.LoadTableList();
            foreach (Table item in tablelist)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status ;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.LightBlue;
                        break;
                    default:
                        btn.BackColor = Color.HotPink;
                        break;
                }

                flpTable.Controls.Add(btn);

            }
        }
       
        void ShowBill(int id)
        {
            listViewBill.Items.Clear();
            List<QuanLyNhaHang.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float AllTotalPrice = 0;
            foreach (QuanLyNhaHang.DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                AllTotalPrice += item.TotalPrice;

                listViewBill.Items.Add(lsvItem);
            }
            object obj = DataProvider.Instance.ExecuteScalar("SELECT name FROM dbo.TableFood WHERE id = " + id);
            LbTabel.Text = (string)obj;

            CultureInfo cul = new CultureInfo("vi-VI");

            tbAllTotalPrice.Text = AllTotalPrice.ToString("c", cul);
            
        }
       
        #endregion

        #region Events
        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            listViewBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        private void đăngXuấtThoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WAccProfile f = new WAccProfile(LoginAccount);
            f.UpdateAccount += f_UpdateAccount;
            f.ShowDialog();
        }
        void f_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }
        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WAdmin f = new WAdmin();
            f.loginAccount = LoginAccount;
            f.InsertFood += f_InsertFood;
            f.DeleteFood += f_DeleteFood;
            f.UpdateFood += f_UpdateFood;
            f.ShowDialog();
            LoadTable();
            LoadCategory();

        }
        void f_UpdateFood(object sender, EventArgs e)
        {

            LoadFoodListByCategoryID((cbFoodCategory.SelectedItem as Category).ID);
            if (listViewBill.Tag != null)
                ShowBill((listViewBill.Tag as Table).ID);
        }
        
        void f_DeleteFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbFoodCategory.SelectedItem as Category).ID);
            if (listViewBill.Tag != null)
                ShowBill((listViewBill.Tag as Table).ID);
            LoadTable();
        }

        void f_InsertFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbFoodCategory.SelectedItem as Category).ID);
            if (listViewBill.Tag != null)
                ShowBill((listViewBill.Tag as Table).ID);
        }
        private void WTableManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        

        private void cbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) return;
            Category selected = cb.SelectedItem as Category;
            id = selected.ID;
            LoadFoodListByCategoryID(id);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = listViewBill.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int foodID = (cbFood.SelectedItem as Food).ID;
            int count = (int)nmFoodCout.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
            }
            LoadTable();
            ShowBill(table.ID);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = listViewBill.Tag as Table;
            double allTotalPrice = Convert.ToDouble(tbAllTotalPrice.Text.Split(',')[0]);
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            if (idBill != -1)
            {
                  WCheckOut f = new WCheckOut(idBill);
                  f.ShowDialog();
                  ShowBill(table.ID);
                  LoadTable();
            }
            else
            {
                MessageBox.Show("Bàn vẫn đang trống");
            }
         
        }


        #endregion

     
    }
}
