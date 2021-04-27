using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class WAdmin : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource ctgList = new BindingSource();
        BindingSource tableList = new BindingSource();
        BindingSource accountList = new BindingSource();

        public Account loginAccount;

        public WAdmin()
        {
            InitializeComponent();
            Loadwindow();
        }
        #region methods

        void Loadwindow()
        {
            dataFood.DataSource = foodList;
            dataCtg.DataSource = ctgList;
            dataTable.DataSource = tableList;
            dataAccount.DataSource = accountList;

          
            LoadDateTimePickerBill();
            LoadListBillByDate(timeFrom.Value, timeTo.Value);
            LoadListFood();
            LoadListCtg();
            LoadListTable();
            LoadAccount();

            LoadCategoryIntoCombobox(cbCtg);
            AddFoodBinding();
            AddCtgBinding();
            AddTableBinding();
            AddAccountBinding();

        }

        
        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            timeFrom.Value = new DateTime(today.Year, today.Month, 1);
            timeTo.Value = timeFrom.Value.AddMonths(1).AddDays(-1);
        }

       

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dataBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }

 
        //Binding
        void AddAccountBinding()
        {
            tbUsername.DataBindings.Add(new Binding("Text", dataAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            tbDisplayname.DataBindings.Add(new Binding("Text", dataAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nmAccType.DataBindings.Add(new Binding("Value", dataAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        void AddFoodBinding()
        {
            tbFoodName.DataBindings.Add(new Binding("Text", dataFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            tbFoodID.DataBindings.Add(new Binding("Text", dataFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dataFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }

        void AddCtgBinding()
        {
            tbCtgName.DataBindings.Add(new Binding("Text", dataCtg.DataSource, "Name", true, DataSourceUpdateMode.Never));
            tbCtgID.DataBindings.Add(new Binding("Text", dataCtg.DataSource, "ID", true, DataSourceUpdateMode.Never));
        }

        void AddTableBinding()
        {
            tbTableName.DataBindings.Add(new Binding("Text", dataTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
            tbTableID.DataBindings.Add(new Binding("Text", dataTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            tbTableStatus.DataBindings.Add(new Binding("Text", dataTable.DataSource, "Status", true, DataSourceUpdateMode.Never));
        }

        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }
        
        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }
        void LoadListCtg()
        {
            ctgList.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        void LoadListTable()
        {
            tableList.DataSource = TableDAO.Instance.GetListTable();
        }

        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }


        void AddAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }

            LoadAccount();
        }

        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccountt(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }

            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Không thể xóa tài khoản đang đăng nhập");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            LoadAccount();
        }

        void ResetPass(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }
        }

        #endregion


        #region events



        //Bill
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(timeFrom.Value, timeTo.Value);
        }


        ///Food

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void tbFoodID_TextChanged(object sender, EventArgs e)
        {
            try
            {
            if (dataFood.SelectedCells.Count > 0)
            {
                int id = (int)dataFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                cbCtg.SelectedItem = cateogory;

                int index = -1;
                int i = 0;
                foreach (Category item in cbCtg.Items)
                {
                    if (item.ID == cateogory.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cbCtg.SelectedIndex = index;
            }
            }
            catch { }
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(tbSearchFood.Text);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = tbFoodName.Text;
            int categoryID = (cbCtg.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn");
            }
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            
            string name = tbFoodName.Text;
            int categoryID = (cbCtg.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(tbFoodID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");
            }

        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbFoodID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }

        //Category
        private void btnAddCtg_Click(object sender, EventArgs e)
        {
            string name = tbCtgName.Text;
            if (CategoryDAO.Instance.InsertCtg(name))
            {
                MessageBox.Show("Thêm danh mục thức ăn thành công");
                LoadListCtg();
                LoadCategoryIntoCombobox(cbCtg);

                if (insertCtg != null)
                    insertCtg(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm danh mục thức ăn");
            }
        }

        private void btnShowCtg_Click(object sender, EventArgs e)
        {
            LoadListCtg();
        }

        private void btnEditCtg_Click(object sender, EventArgs e)
        {
            string name = tbCtgName.Text;
            int id = Convert.ToInt32(tbCtgID.Text);

            if (CategoryDAO.Instance.UpdateCtg(id, name))
            {
                MessageBox.Show("Sửa danh mục thức ăn thành công");
                LoadListCtg();
                LoadCategoryIntoCombobox(cbCtg);
                if (updateCtg != null)
                    updateCtg(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa danh mục thức ăn");
            }
        }

        private void btnDeleteCtg_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbCtgID.Text);

            if (CategoryDAO.Instance.DeleteCtg(id))
            {
                MessageBox.Show("Xóa danh mục thức ăn thành công");
                LoadListCtg();
                LoadCategoryIntoCombobox(cbCtg);
                if (deleteCtg != null)
                    deleteCtg(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa danh mục thức ăn");
            }
        }

        //Table

        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string name = tbTableName.Text;
            if (TableDAO.Instance.InsertTable(name))
            {
                MessageBox.Show("Thêm bàn thành công");
                LoadListTable();
                if (insertTable != null)
                    insertTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm bàn");
            }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            string name = tbTableName.Text;
            int id = Convert.ToInt32(tbTableID.Text);

            if (TableDAO.Instance.UpdateTable(id,name))
            {
                MessageBox.Show("Sửa bàn thành công");
                LoadListTable();
                if (updateTable != null)
                    updateTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa bàn");
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbTableID.Text);

            if (TableDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xóa bàn thành công");
                LoadListTable();
                if (deleteTable != null)
                    deleteTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa bàn");
            }
        }


        //Make event
        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private event EventHandler insertCtg;
        public event EventHandler InsertCtg
        {
            add { insertCtg += value; }
            remove { insertCtg -= value; }
        }

        private event EventHandler deleteCtg;
        public event EventHandler DeleteCtg
        {
            add { deleteCtg += value; }
            remove { deleteCtg -= value; }
        }

        private event EventHandler updateCtg;
        public event EventHandler UpdateCtg
        {
            add { updateCtg += value; }
            remove { updateCtg -= value; }
        }

        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }

        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }

        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }


        private void btnShowAcc_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnAddAcc_Click(object sender, EventArgs e)
        {
            string userName = tbUsername.Text;
            string displayName = tbDisplayname.Text;
            int type = (int)nmAccType.Value;

            AddAccount(userName, displayName, type);
        }

        private void btnEditAcc_Click(object sender, EventArgs e)
        {
            string userName = tbUsername.Text;
            string displayName = tbDisplayname.Text;
            int type = (int)nmAccType.Value;

            EditAccount(userName, displayName, type);
        }

        private void btnDeleteAcc_Click(object sender, EventArgs e)
        {
            string userName = tbUsername.Text;

            DeleteAccount(userName);
        }

        private void btnPassReset_Click(object sender, EventArgs e)
        {
            string userName = tbUsername.Text;

            ResetPass(userName);
        }



      

        private void WAdmin_Load(object sender, EventArgs e)
        {
      

          
        }



        #endregion



 
    }
}
