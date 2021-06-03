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

        public int InsertImportInfo(Import_Info item, DB_ex1_Context con)
        {
            object[] sqlParams =
            {
                new SqlParameter("@supplier", item.SupplierName),
                new SqlParameter("@total", item.TotalImport),
                new SqlParameter("@payStatus", Convert.ToByte(item.PaymentStatus)),
                new SqlParameter("@payType", item.PaymentType),
                new SqlParameter("@creatby", item.CreateBy)
            };
            var id = con.Database.SqlQuery<int>("Sp_ImportInfo_Insert @supplier, @total, @payStatus, @payType, @creatby", sqlParams).SingleOrDefault();
            return id;
        }
        public void InsertImportGood(Import_Goods item, DB_ex1_Context con)
        {
            object[] sqlParams =
            {
                new SqlParameter("@infoId", item.ImportInfoId),
                new SqlParameter("@goodsName", item.GoodsName),
                new SqlParameter("@qty", item.imQuantity),
                new SqlParameter("@price", item.Price),
                new SqlParameter("@total", item.TotalPrice)
            };
            con.Database.ExecuteSqlCommand("Sp_ImportGoods_Insert @infoId, @goodsName, @price, @total, @qty", sqlParams);
        }
        public void InsertEmployee(Employee item)
        {
            object[] sqlParams =
            {
                new SqlParameter("@first", item.FirstName),
                new SqlParameter("@last", item.LastName),
                new SqlParameter("@phone", item.PhoneNumber),
                new SqlParameter("@address", item.EmployeeAddress),
                new SqlParameter("@createby", item.CreateBy),
                new SqlParameter("@code", item.EmployeeCode),
                new SqlParameter("@position", item.Position)
            };
            context.Database.ExecuteSqlCommand("Sp_Employee_Insert @first, @last, @phone, @address, @createby, @code, @position",sqlParams);
        }
        public void InsertSupplier(Supplier item)
        {
            object[] sqlParams =
            {
                new SqlParameter("@name", item.SupplierName),
                new SqlParameter("@phone", item.PhoneNumber),
                new SqlParameter("@address", item.SupplierAddress),
                new SqlParameter("@createby", item.CreateBy)
            };
            context.Database.ExecuteSqlCommand("Sp_Supplier_Insert @name, @phone, @address, @createby", sqlParams);
        }
        public void InsertCustomer(Customer item)
        {
            object[] sqlParams =
            {
                new SqlParameter("@first", item.FirstName),
                new SqlParameter("@last", item.LastName),
                new SqlParameter("@phone", item.PhoneNumber),
                new SqlParameter("@address", item.CustomerAddress),
                new SqlParameter("@createby", item.CreateBy),
                new SqlParameter("@score", item.MembershipScore),
                new SqlParameter("@citizenId", item.CitizenId)
            };
            context.Database.ExecuteSqlCommand("Sp_Customer_Insert @first, @last, @phone, @address, @createby, @score, @citizenId", sqlParams);
        }
        public void InsertGood(Good item)
        {
            // Insert new good into database
            object[] sqlParams =
            {
                new SqlParameter("@name", item.GoodsName),
                new SqlParameter("@cat", item.categoryName),
                new SqlParameter("@code", item.GoodsCode),
                new SqlParameter("@importPrice", item.ImportPrice),
                new SqlParameter("@minQty", item.MinQuantity),
                new SqlParameter("@qty", item.GoodsQuantity),
                new SqlParameter("@tax", item.TaxPercent),
                new SqlParameter("@createby", item.CreateBy)
            };
            // Insert new good into database
            context.Database.ExecuteSqlCommand("Sp_Goods_Insert @name, @cat, @code, @importPrice, @minQty, @qty, @tax, @createby",sqlParams);
        }
        public void InsertCategory(Category item)
        {
            object[] sqlParams =
            {
                new SqlParameter("@name", item.CategoryName),
                new SqlParameter("@createby", item.CreateBy)
            };
            context.Database.ExecuteSqlCommand("Sp_Category_Insert @name, @createby",sqlParams);
        }
    }
}
