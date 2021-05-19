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
        public List<Good> ListSingle_Good(int? goodId, string goodsName)
        {
            object[] sqlParams =
           {
                new SqlParameter("@id", goodId),
                new SqlParameter("@name", goodsName)
            };
            // Get good's info with good's id given
            var good = context.Database.SqlQuery<Good>("Sp_Goods_ListGood @id, @name", sqlParams).ToList();
            return good;
        }
        // ------------------- Employee -------------------
        public List<Employee> ListAll_Employee()
        {
            // List all employees' info to Employee Table
            var list = context.Database.SqlQuery<Employee>("Sp_Employee_ListAll").ToList();
            return list;
        }
        public List<Employee> ListSingle_Employee(int employeeId)
        {
            // Get employee's info to display on EmployeeEdit form
            var employee = context.Database.SqlQuery<Employee>("Sp_Employee_ListEmployee @id", new SqlParameter("@id",employeeId)).ToList();
            return employee;
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
            // Get good's info with good's id given
            var category = context.Database.SqlQuery<Category>("Sp_Goods_ListCategory @id, @name", sqlParams).ToList();
            return category;
        }
        // ------------------- Supplier -------------------
        public List<Supplier> ListAll_Supplier()
        {
            var list = context.Database.SqlQuery<Supplier>("Sp_Supplier_ListAll").ToList();
            return list;
        }
        // ------------------- Import Info -------------------
        public List<Import_Info> ListAll_ImportInfo()
        {
            // List all orders' info to Import Orders Table
            var list = context.Database.SqlQuery<Import_Info>("Sp_ImportInfo_ListAll").ToList();
            return list;
        }
        public List<Import_Info> ListSingle_ImportInfo(int importInfoId, DB_ex1_Context con)
        {
            var info = con.Database.SqlQuery<Import_Info>("Sp_ImportInfo_ListImportInfo @id", new SqlParameter("@id", importInfoId)).ToList();
            return info;
        }
        // ------------------- Import Goods -------------------
        public List<Import_Goods> ListImportGoods(int importInfoId, DB_ex1_Context con)
        {
            var importGoods = con.Database.SqlQuery<Import_Goods>("Sp_ImportGoods_ListImportGoods @infoId", new SqlParameter("@infoId", importInfoId)).ToList();
            return importGoods;
        }
    }
}
