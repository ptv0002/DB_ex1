using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Models
{
    public class InsertModel
    {
        private DB_ex1_Context context = null;
        public InsertModel()
        {
            context = new DB_ex1_Context();
        }

        public void InsertImportGood(Import_Goods good)
        {
            object[] sqlParams =
            {
                    new SqlParameter("@infoId", good.ImportInfoId),
                    new SqlParameter("@goodsName", good.GoodsName),
                    new SqlParameter("@qty", good.imQuantity),
                    new SqlParameter("@price", good.Price),
                    new SqlParameter("@total", good.TotalPrice)
                };
            context.Database.ExecuteSqlCommand("Sp_ImportGoods_Insert @infoId, @goodsName, @price, @total, @qty", sqlParams);

        }
        public void InsertImportGood(Import_Goods good, DB_ex1_Context con)
        {
            object[] sqlParams =
            {
                    new SqlParameter("@infoId", good.ImportInfoId),
                    new SqlParameter("@goodsName", good.GoodsName),
                    new SqlParameter("@qty", good.imQuantity),
                    new SqlParameter("@price", good.Price),
                    new SqlParameter("@total", good.TotalPrice)
                };
            con.Database.ExecuteSqlCommand("Sp_ImportGoods_Insert @infoId, @goodsName, @price, @total, @qty", sqlParams);
        }
        public void InsertEmployee(Employee employee)
        {
            // Insert new employee into database
            object[] sqlParams =
            {
                new SqlParameter("@first", employee.FirstName),
                new SqlParameter("@last", employee.LastName),
                new SqlParameter("@phone", employee.PhoneNumber),
                new SqlParameter("@address", employee.EmployeeAddress),
                new SqlParameter("@createby", employee.CreateBy),
                new SqlParameter("@code", employee.EmployeeCode),
                new SqlParameter("@position", employee.Position)
            };
            context.Database.ExecuteSqlCommand("Sp_Employee_Insert @first, @last, @phone, @address, @createby, @code, @position",sqlParams);
        }
        public void InsertGood(Good good)
        {
            // Insert new good into database
            object[] sqlParams =
            {
                new SqlParameter("@name", good.GoodsName),
                new SqlParameter("@cat", good.categoryName),
                new SqlParameter("@code", good.GoodsCode),
                new SqlParameter("@importPrice", good.ImportPrice),
                new SqlParameter("@minQty", good.MinQuantity),
                new SqlParameter("@qty", good.GoodsQuantity),
                new SqlParameter("@tax", good.TaxPercent),
                new SqlParameter("@createby", good.CreateBy)
            };
            // Insert new good into database
            context.Database.ExecuteSqlCommand("Sp_Goods_Insert @name, @cat, @code, @importPrice, @minQty, @qty, @tax, @createby",sqlParams);
        }
        public void InsertCategory(Category category)
        {
            // Insert new category into database
            object[] sqlParams =
            {
                new SqlParameter("@name", category.CategoryName),
                new SqlParameter("@createby", category.CreateBy)
            };
            // Insert new category into database
            context.Database.ExecuteSqlCommand("Sp_Category_Insert @name, @createby",sqlParams);
        }
    }
}
