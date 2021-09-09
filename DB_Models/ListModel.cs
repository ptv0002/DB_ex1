using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Models
{
    public class ListModel
    {
        private DB_ex1_Context context = null;
        public ListModel()
        {
            context = new DB_ex1_Context();
        }
        public List<Good> ListGood(int id, string name)
        {
            object[] sqlParams =
           {
                new SqlParameter("@id", id),
                new SqlParameter("@name", name)
            };
            var item = context.Database.SqlQuery<Good>("Sp_Goods_List @id, @name", sqlParams).ToList();
            return item;
        }
        public List<Employee> ListEmployee(int id)
        {
            // Get employee's info to display on EmployeeEdit form
            var item = context.Database.SqlQuery<Employee>("Sp_Employee_List @id", new SqlParameter("@id",id)).ToList();
            return item;
        }
        public List<Account> ListAccount()
        {
            var list = context.Database.SqlQuery<Account>("select * from Account").ToList();
            return list;
        }
        public List<CardType> ListCardType(int id)
        {
            var item = context.Database.SqlQuery<CardType>("Sp_CardType_List @id", new SqlParameter("@id", id)).ToList();
            return item;
        }
        public List<Category> ListCategory(int id, string name)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id", id),
                new SqlParameter("@name", name)
            };
            var item = context.Database.SqlQuery<Category>("Sp_Category_List @id, @name", sqlParams).ToList();
            return item;
        }
        public List<Customer> ListCustomer(int id)
        {
            var customer = context.Database.SqlQuery<Customer>("Sp_Customer_List @id", new SqlParameter("@id", id)).ToList();
            return customer;
        }
        public List<Supplier> ListSupplier(int id)
        {
            var item = context.Database.SqlQuery<Supplier>("Sp_Supplier_List @id", new SqlParameter("@id", id)).ToList();
            return item;
        }
        public List<Import_Goods> ListImportGoods(int id, DB_ex1_Context con)
        {
            var list = con.Database.SqlQuery<Import_Goods>("Sp_ImportGoods_List @infoId", new SqlParameter("@infoId", id)).ToList();
            return list;
        }
        public List<Export_Goods> ListExportGoods(int id, DB_ex1_Context con)
        {
            var list = con.Database.SqlQuery<Export_Goods>("Sp_ExportGoods_List @infoId", new SqlParameter("@infoId", id)).ToList();
            return list;
        }
        public List<Import_Info> ListImportInfo(int id, DB_ex1_Context con)
        {
            if (con == null)
            {
                return context.Database.SqlQuery<Import_Info>("Sp_ImportInfo_List @id", new SqlParameter("@id", id)).ToList();
            }
            else
            {
                return con.Database.SqlQuery<Import_Info>("Sp_ImportInfo_List @id", new SqlParameter("@id", id)).ToList();
            }
        }
        public List<Export_Info> ListExportInfo(int id, DB_ex1_Context con)
        {
            if (con == null)
            {
                return context.Database.SqlQuery<Export_Info>("Sp_ExportInfo_List @id", new SqlParameter("@id", id)).ToList();
            }
            else
            {
                return con.Database.SqlQuery<Export_Info>("Sp_ExportInfo_List @id", new SqlParameter("@id", id)).ToList();
            }
        }
    }
}
