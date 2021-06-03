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
        // ------------------- Goods -------------------
        public List<Good> ListAll_Goods()
        {
            // List all goods' info to Good Table
            var list = context.Database.SqlQuery<Good>("Sp_Goods_ListAll").ToList();
            return list;
        }
        public List<Good> ListSingle_Good(int? id, string name)
        {
            object[] sqlParams =
           {
                new SqlParameter("@id", id),
                new SqlParameter("@name", name)
            };
            // Get good's info with good's id given
            var item = context.Database.SqlQuery<Good>("Sp_Goods_ListGood @id, @name", sqlParams).ToList();
            return item;
        }
        // ------------------- Customer -------------------
        public List<Customer> ListAll_Customer()
        {
            // List all customers' info to Customer Table
            var list = context.Database.SqlQuery<Customer>("Sp_Customer_ListAll").ToList();
            return list;
        }
        public List<Customer> ListSingle_Customer(int id)
        {
            var customer = context.Database.SqlQuery<Customer>("Sp_Customer_ListCustomer @id", new SqlParameter("@id", id)).ToList();
            return customer;
        }
        // ------------------- Employee -------------------
        public List<Employee> ListAll_Employee()
        {
            // List all employees' info to Employee Table
            var list = context.Database.SqlQuery<Employee>("Sp_Employee_ListAll").ToList();
            return list;
        }
        public List<Employee> ListSingle_Employee(int id)
        {
            // Get employee's info to display on EmployeeEdit form
            var item = context.Database.SqlQuery<Employee>("Sp_Employee_ListEmployee @id", new SqlParameter("@id",id)).ToList();
            return item;
        }
        // ------------------- Category -------------------
        public List<Category> ListAll_Category()
        {
            var list = context.Database.SqlQuery<Category>("Sp_Category_ListAll").ToList();
            return list;
        }
        public List<Category> ListSingle_Category(int id, string name)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id", id),
                new SqlParameter("@name", name)
            };
            var item = context.Database.SqlQuery<Category>("Sp_Category_ListCategory @id, @name", sqlParams).ToList();
            return item;
        }
        // ------------------- Supplier -------------------
        public List<Supplier> ListAll_Supplier()
        {
            var list = context.Database.SqlQuery<Supplier>("Sp_Supplier_ListAll").ToList();
            return list;
        }
        public List<Supplier> ListSingle_Supplier(int id)
        {
            // Get employee's info to display on EmployeeEdit form
            var item = context.Database.SqlQuery<Supplier>("Sp_Supplier_ListSupplier @id", new SqlParameter("@id", id)).ToList();
            return item;
        }
        // ------------------- Import Info -------------------
        public List<Import_Info> ListAll_ImportInfo()
        {
            // List all orders' info to Import Orders Table
            var list = context.Database.SqlQuery<Import_Info>("Sp_ImportInfo_ListAll").ToList();
            return list;
        }
        public List<Import_Info> ListSingle_ImportInfo(int id, DB_ex1_Context con)
        {
            var item = con.Database.SqlQuery<Import_Info>("Sp_ImportInfo_ListImportInfo @id", new SqlParameter("@id", id)).ToList();
            return item;
        }
        // ------------------- Import Goods -------------------
        public List<Import_Goods> ListImportGoods(int id, DB_ex1_Context con)
        {
            var list = con.Database.SqlQuery<Import_Goods>("Sp_ImportGoods_ListImportGoods @infoId", new SqlParameter("@infoId", id)).ToList();
            return list;
        }
        // ------------------- Export Info -------------------
        public List<Export_Info> ListAll_ExportInfo()
        {
            var list = context.Database.SqlQuery<Export_Info>("Sp_ExportInfo_ListAll").ToList();
            return list;
        }
        public List<Export_Info> ListSingle_ExportInfo(int id, DB_ex1_Context con)
        {
            var item = con.Database.SqlQuery<Export_Info>("Sp_ExportInfo_ListExportInfo @id", new SqlParameter("@id", id)).ToList();
            return item;
        }
        // ------------------- Export Goods -------------------
        public List<Export_Goods> ListExportGoods(int id, DB_ex1_Context con)
        {
            var list = con.Database.SqlQuery<Export_Goods>("Sp_ExportGoods_ListExportGoods @infoId", new SqlParameter("@infoId", id)).ToList();
            return list;
        }
    }
}
