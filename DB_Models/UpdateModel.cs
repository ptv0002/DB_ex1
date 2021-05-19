using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Models
{
    public class UpdateModel
    {
        private DB_ex1_Context context = null;
        public UpdateModel()
        {
            context = new DB_ex1_Context();
        }
        public void UpdateImportGood(Import_Goods good)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id", good.id),
                new SqlParameter("@goodsName", good.GoodsName),
                new SqlParameter("@qty", good.imQuantity),
                new SqlParameter("@price", good.Price),
                new SqlParameter("@total", good.TotalPrice)
            };
            context.Database.ExecuteSqlCommand("Sp_ImportGoods_Update @id, @goodsName, @price, @total, @qty", sqlParams);
        }
        public void UpdateEmployee(Employee employee)
        {
            // Update info to database
            object[] sqlParams =
            {
                new SqlParameter("@id", employee.id),
                new SqlParameter("@status", Convert.ToByte(employee.EmployeeStatus)),
                new SqlParameter("@first", employee.FirstName),
                new SqlParameter("@last", employee.LastName),
                new SqlParameter("@phone", employee.PhoneNumber),
                new SqlParameter("@address", employee.EmployeeAddress),
                new SqlParameter("@updateby", employee.UpdateBy),
                new SqlParameter("@code", employee.EmployeeCode),
                new SqlParameter("@postion", employee.Position)
            };
            context.Database.ExecuteSqlCommand("Sp_Employee_Update @first, @last, @phone, @address, @updateby, @id, @status, @code, @postion", sqlParams);
        }
        public void UpdateCategory(Category category)
        {
            // Update category into database
            object[] sqlParams =
            {                
                new SqlParameter("@id", category.id),
                new SqlParameter("@name", category.CategoryName),
                new SqlParameter("@status", Convert.ToByte(category.CategoryStatus)),
                new SqlParameter("@updateby", category.UpdateBy)
            };
            context.Database.ExecuteSqlCommand("Sp_Category_Update @id, @name, @status, @updateby", sqlParams);
        }
        public void UpdateGood(Good good)
        {
            // Update good into database
            object[] sqlParams =
            {
                new SqlParameter("@id", good.id),
                new SqlParameter("@name", good.GoodsName),
                new SqlParameter("@cat", good.categoryName),
                new SqlParameter("@status", Convert.ToByte(good.GoodsStatus)),
                new SqlParameter("@code", good.GoodsCode),
                new SqlParameter("@importPrice", good.ImportPrice),
                new SqlParameter("@minQty", good.MinQuantity),
                new SqlParameter("@qty", good.GoodsQuantity),
                new SqlParameter("@tax", good.TaxPercent),
                new SqlParameter("@updateby", good.UpdateBy)
            };
            context.Database.ExecuteSqlCommand("Sp_Goods_Update @id, @name, @cat, @status, @code, @importPrice, @minQty, @qty, @tax, @updateby", sqlParams);
        }

    }
}
