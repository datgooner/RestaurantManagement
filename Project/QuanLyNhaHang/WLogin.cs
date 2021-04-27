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
    public partial class WLogin : Form
    {
        public WLogin()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text;
            string passWord = tbPassWord.Text;
            if (login(userName, passWord))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                WTableManager f = new WTableManager(loginAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }
        
        bool login(string userName, string passWord)
        {
            return AccountDAO.Instance.login(userName, passWord) ;
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void WLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
