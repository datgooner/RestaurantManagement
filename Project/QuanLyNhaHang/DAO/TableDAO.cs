using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }
        private TableDAO() { }

        public static int TableWidth = 150;
        public static int TableHeight = 150;

        public List<Table> LoadTableList()
        {
            List<Table> tablelist = new List<Table>();
            
            DataTable data =  DataProvider.Instance.ExecuteQuery("dbo.SP_GetTableList");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                
                tablelist.Add(table);
            }
                    
            return tablelist;
        }

        public List<Table> GetListTable()
        {
            List<Table> list = new List<Table>();

            string query = "select * from TableFood";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                list.Add(table);
            }

            return list;
        }

        public bool InsertTable(string name)
        {
            string query = string.Format("INSERT dbo.TableFood ( name, status ) VALUES  ( N'{0}', N'Trống')", name);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateTable(int idTable, string name)
        {
            string query = string.Format("UPDATE dbo.TableFood SET name = N'{0}' WHERE id = {1}", name, idTable);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteTable(int idTable)
        {
            BillDAO.Instance.DeleteBillInfoAnhBillByTableID(idTable);

            string query = string.Format("Delete dbo.TableFood where id = {0}", idTable);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        public string GetTableNameByIdBill(int id)
        {
            object obj = DataProvider.Instance.ExecuteScalar("SELECT t.name FROM dbo.TableFood AS t,dbo.Bill AS b WHERE b.idTable = t.id AND b.id = " + id);
            return (string)obj;
        }

    }
}
