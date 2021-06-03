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
        public void UpdateImportGood(Import_Goods item, DB_ex1_Context con)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id", item.Id),
                new SqlParameter("@goodsName", item.GoodsName),
                new SqlParameter("@qty", item.imQuantity),
                new SqlParameter("@price", item.Price),
                new SqlParameter("@total", item.TotalPrice)
            };
            con.Database.ExecuteSqlCommand("Sp_ImportGoods_Update @id, @goodsName, @price, @total, @qty", sqlParams);
        }
        public void UpdateImportInfo(Import_Info item, DB_ex1_Context con)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id", item.Id),
                new SqlParameter("@supplier", item.SupplierName),
                new SqlParameter("@total", item.TotalImport),
                new SqlParameter("@payStatus", Convert.ToByte(item.PaymentStatus)),
                new SqlParameter("@payType", item.PaymentType),
                new SqlParameter("@createby", item.CreateBy),
                new SqlParameter("@updateby", item.UpdateBy)
            };
            con.Database.ExecuteSqlCommand("Sp_ImportInfo_Update @id, @supplier, @total, @payStatus, @payType, @createby, @updateby", sqlParams);
        }
        public void UpdateEmployee(Employee item)
        {
            // Update info to database
            object[] sqlParams =
            {
                new SqlParameter("@id", item.Id),
                new SqlParameter("@status", Convert.ToByte(item.EmployeeStatus)),
                new SqlParameter("@first", item.FirstName),
                new SqlParameter("@last", item.LastName),
                new SqlParameter("@phone", item.PhoneNumber),
                new SqlParameter("@address", item.EmployeeAddress),
                new SqlParameter("@updateby", item.UpdateBy),
                new SqlParameter("@code", item.EmployeeCode),
                new SqlParameter("@postion", item.Position)
            };
            context.Database.ExecuteSqlCommand("Sp_Employee_Update @first, @last, @phone, @address, @updateby, @id, @status, @code, @postion", sqlParams);
        }
        public void UpdateSupplier(Supplier item)
        {
            // Update info to database
            object[] sqlParams =
            {
                new SqlParameter("@id", item.Id),
                new SqlParameter("@status", Convert.ToByte(item.SupplierStatus)),
                new SqlParameter("@name", item.SupplierName),
                new SqlParameter("@phone", item.PhoneNumber),
                new SqlParameter("@address", item.SupplierAddress),
                new SqlParameter("@updateby", item.UpdateBy)
            };
            context.Database.ExecuteSqlCommand("Sp_Supplier_Update @name, @phone, @address, @updateby, @id, @status", sqlParams);
        }
        public void UpdateCustomer(Customer item)
        {
            // Update info to database
            object[] sqlParams =
            {
                new SqlParameter("@id", item.Id),
                new SqlParameter("@status", Convert.ToByte(item.CustomerStatus)),
                new SqlParameter("@first", item.FirstName),
                new SqlParameter("@last", item.LastName),
                new SqlParameter("@phone", item.PhoneNumber),
                new SqlParameter("@address", item.CustomerAddress),
                new SqlParameter("@updateby", item.UpdateBy),
                new SqlParameter("@score", item.MembershipScore),
                new SqlParameter("@citizenId", item.CitizenId)
            };
            context.Database.ExecuteSqlCommand("Sp_Customer_Update @first, @last, @phone, @address, @updateby, @score, @citizenId, @id, @status", sqlParams);
        }
        public void UpdateCategory(Category item)
        {
            // Update category into database
            object[] sqlParams =
            {                
                new SqlParameter("@id", item.Id),
                new SqlParameter("@name", item.CategoryName),
                new SqlParameter("@status", Convert.ToByte(item.CategoryStatus)),
                new SqlParameter("@updateby", item.UpdateBy)
            };
            context.Database.ExecuteSqlCommand("Sp_Category_Update @id, @name, @status, @updateby", sqlParams);
        }
        public void UpdateGood(Good item)
        {
            // Update good into database
            object[] sqlParams =
            {
                new SqlParameter("@id", item.Id),
                new SqlParameter("@name", item.GoodsName),
                new SqlParameter("@cat", item.categoryName),
                new SqlParameter("@status", Convert.ToByte(item.GoodsStatus)),
                new SqlParameter("@code", item.GoodsCode),
                new SqlParameter("@importPrice", item.ImportPrice),        
                new SqlParameter("@salePrice", item.SalePrice),
                new SqlParameter("@minQty", item.MinQuantity),
                new SqlParameter("@qty", item.GoodsQuantity),
                new SqlParameter("@tax", item.TaxPercent),
                new SqlParameter("@updateby", item.UpdateBy)
            };
            context.Database.ExecuteSqlCommand("Sp_Goods_Update @id, @name, @cat, @status, @code, @importPrice, @salePrice, @minQty, @qty, @tax, @updateby", sqlParams);
        }

    }
}
