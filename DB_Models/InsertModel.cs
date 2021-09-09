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
        public void InsertAccount(Account account)
        {
            // Insert new account into database
            string cmd = "insert into Account (FirstName, LastName, Username, AccPassword," +
                " Email, CreateBy, CreateDate) values ('" + account.FirstName +
                "', '" + account.LastName + "', '" + account.Username + "', '" +
                account.AccPassword + "', '" + account.Email + "', 'Self-Registered', GETDATE());";
            context.Database.ExecuteSqlCommand(cmd);
        }
        public int InsertImportInfo(Import_Info item, DB_ex1_Context con)
        {
            object[] sqlParams =
            {
                new SqlParameter("@supplier", item.SupplierId),
                new SqlParameter("@payStatus", Convert.ToByte(item.PaymentStatus)),
                new SqlParameter("@payType", item.PaymentType),
                new SqlParameter("@creatby", item.CreateBy),
                new SqlParameter("@discount", item.OtherDiscount)
            };
            var id = con.Database.SqlQuery<int>("Sp_ImportInfo_Insert @supplier, @payStatus, @payType, @creatby, @discount", sqlParams).SingleOrDefault();
            return id;
        }
        public int InsertExportInfo(Export_Info item, DB_ex1_Context con)
        {
            object[] sqlParams =
            {
                new SqlParameter("@customer", item.CustomerId),
                new SqlParameter("@payStatus", Convert.ToByte(item.PaymentStatus)),
                new SqlParameter("@payType", item.PaymentType),
                new SqlParameter("@creatby", item.CreateBy),
                new SqlParameter("@discount", item.OtherDiscount),
                new SqlParameter("@card", Convert.ToByte(item.CardDiscount))
            };
            var id = con.Database.SqlQuery<int>("Sp_ExportInfo_Insert @customer, @payStatus, @payType, @creatby, @discount, @card", sqlParams).SingleOrDefault();
            return id;
        }
        public int InsertImportGood(Import_Goods item, DB_ex1_Context con)
        {
            object[] sqlParams =
            {
                new SqlParameter("@infoId", item.ImportInfoId),
                new SqlParameter("@goodsName", item.GoodsName),
                new SqlParameter("@qty", item.Quantity),
                new SqlParameter("@price", item.Price),
                new SqlParameter("@discount", item.Discount),
                new SqlParameter("@total", item.TotalPrice)
            };
            var id = con.Database.SqlQuery<int>("Sp_ImportGoods_Insert @infoId, @goodsName, @price, @total, @qty, @discount", sqlParams).SingleOrDefault();
            return id;
        }
        public int InsertExportGood(Export_Goods item, DB_ex1_Context con)
        {
            object[] sqlParams =
            {
                new SqlParameter("@infoId", item.ExportInfoId),
                new SqlParameter("@goodsName", item.GoodsName),
                new SqlParameter("@qty", item.Quantity),
                new SqlParameter("@price", item.Price),
                new SqlParameter("@discount", item.Discount),
                new SqlParameter("@total", item.TotalPrice)
            };
            var id = con.Database.SqlQuery<int>("Sp_ExportGoods_Insert @infoId, @goodsName, @price, @total, @qty, @discount", sqlParams).SingleOrDefault();
            return id;
        }
        public void InsertEmployee(Employee item)
        {
            object[] sqlParams =
            {
                new SqlParameter("@first", item.FirstName),
                new SqlParameter("@last", item.LastName),
                new SqlParameter("@phone", item.PhoneNumber),
                new SqlParameter("@address", item.Address),
                new SqlParameter("@createby", item.CreateBy),
                new SqlParameter("@code", item.CharID),
                new SqlParameter("@position", item.Position)
            };
            context.Database.ExecuteSqlCommand("Sp_Employee_Insert @first, @last, @phone, @address, @createby, @code, @position",sqlParams);
        }
        public void InsertSupplier(Supplier item)
        {
            object[] sqlParams =
            {
                new SqlParameter("@name", item.Name),
                new SqlParameter("@phone", item.PhoneNumber),
                new SqlParameter("@address", item.Address),
                new SqlParameter("@contact", item.ContactInfo),
                new SqlParameter("@createby", item.CreateBy)
            };
            context.Database.ExecuteSqlCommand("Sp_Supplier_Insert @name, @phone, @address, @createby, @contact", sqlParams);
        }
        public void InsertCustomer(Customer item)
        {
            object[] sqlParams =
            {
                new SqlParameter("@first", item.FirstName),
                new SqlParameter("@last", item.LastName),
                new SqlParameter("@phone", item.PhoneNumber),
                new SqlParameter("@address", item.Address),
                new SqlParameter("@company", item.Company),
                new SqlParameter("@createby", item.CreateBy),
                new SqlParameter("@score", item.MembershipScore),
                new SqlParameter("@citizenId", item.CitizenId)
            };
            context.Database.ExecuteSqlCommand("Sp_Customer_Insert @first, @last, @phone, @address, @createby, @score, @citizenId, @company", sqlParams);
        }
        public void InsertGood(Good item)
        {
            // Insert new good into database
            object[] sqlParams =
            {
                new SqlParameter("@name", item.Name),
                new SqlParameter("@cat", item.CategoryName),
                new SqlParameter("@code", item.Barcode),
                new SqlParameter("@importPrice", item.ImportPrice),
                new SqlParameter("@minQty", item.MinQuantity),
                new SqlParameter("@qty", item.Quantity),
                new SqlParameter("@tax", item.Tax),
                new SqlParameter("@createby", item.CreateBy)
            };
            // Insert new good into database
            context.Database.ExecuteSqlCommand("Sp_Goods_Insert @name, @cat, @code, @importPrice, @minQty, @qty, @tax, @createby",sqlParams);
        }
        public void InsertCategory(Category item)
        {
            object[] sqlParams =
            {
                new SqlParameter("@name", item.Name),
                new SqlParameter("@createby", item.CreateBy)
            };
            context.Database.ExecuteSqlCommand("Sp_Category_Insert @name, @createby",sqlParams);
        }
        public void InsertCardType(CardType item)
        {
            object[] sqlParams =
            {
                new SqlParameter("@name", item.Name),
                new SqlParameter("@createby", item.CreateBy),
                new SqlParameter("@bound", item.LowerBound),
                new SqlParameter("@percent", item.PercentDiscount)
            };
            context.Database.ExecuteSqlCommand("Sp_CardType_Insert @name, @createby, @bound, @percent", sqlParams);
        }
    }
}
