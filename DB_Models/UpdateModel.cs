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
        public void UpdatePassword(Account item)
        {
            object[] sqlParams =
            {
                new SqlParameter("@Email", item.Email),
                new SqlParameter("@Username", item.Username),
                new SqlParameter("@Password", item.AccPassword)
            };
            context.Database.ExecuteSqlCommand("Sp_Account_UpdatePassword @Email, @Username, @Password", sqlParams);
        }


        public void UpdateImportInfo(Import_Info item, DB_ex1_Context con)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id", item.Id),
                new SqlParameter("@supplier", item.SupplierId),
                new SqlParameter("@total", item.Total),
                new SqlParameter("@payStatus", Convert.ToByte(item.PaymentStatus)),
                new SqlParameter("@payType", item.PaymentType),
                new SqlParameter("@createby", item.CreateBy),
                new SqlParameter("@updateby", item.UpdateBy),
                new SqlParameter("@discount", item.OtherDiscount)
            };
            con.Database.ExecuteSqlCommand("Sp_ImportInfo_Update @id, @supplier, @total, @payStatus, @payType, @createby, @updateby, @discount", sqlParams);
        }
        public void UpdateExportInfo(Export_Info item, DB_ex1_Context con)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id", item.Id),
                new SqlParameter("@customer", item.CustomerId),
                new SqlParameter("@total", item.Total),
                new SqlParameter("@payStatus", Convert.ToByte(item.PaymentStatus)),
                new SqlParameter("@payType", item.PaymentType),
                new SqlParameter("@createby", item.CreateBy),
                new SqlParameter("@updateby", item.UpdateBy),
                new SqlParameter("@discount", item.OtherDiscount),
                new SqlParameter("@transaction", item.TransactionScore),
                new SqlParameter("@card", Convert.ToByte(item.CardDiscount))
            };
            con.Database.ExecuteSqlCommand("Sp_ExportInfo_Update @id, @customer, @total, @payStatus, @payType, @createby, @updateby, @discount, @transaction, @card", sqlParams);
        }
        public void UpdateEmployee(Employee item)
        {
            // Update info to database
            object[] sqlParams =
            {
                new SqlParameter("@id", item.Id),
                new SqlParameter("@status", Convert.ToByte(item.Status)),
                new SqlParameter("@first", item.FirstName),
                new SqlParameter("@last", item.LastName),
                new SqlParameter("@phone", item.PhoneNumber),
                new SqlParameter("@address", item.Address),
                new SqlParameter("@updateby", item.UpdateBy),
                new SqlParameter("@code", item.CharID),
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
                new SqlParameter("@status", Convert.ToByte(item.Status)),
                new SqlParameter("@name", item.Name),
                new SqlParameter("@phone", item.PhoneNumber),
                new SqlParameter("@address", item.Address),
                new SqlParameter("@contact", item.ContactInfo),
                new SqlParameter("@updateby", item.UpdateBy)
            };
            context.Database.ExecuteSqlCommand("Sp_Supplier_Update @name, @phone, @address, @updateby, @id, @status, @contact", sqlParams);
        }
        public void UpdateCustomer(Customer item)
        {
            // Update info to database
            object[] sqlParams =
            {
                new SqlParameter("@id", item.Id),
                new SqlParameter("@status", Convert.ToByte(item.Status)),
                new SqlParameter("@first", item.FirstName),
                new SqlParameter("@last", item.LastName),
                new SqlParameter("@phone", item.PhoneNumber),
                new SqlParameter("@address", item.Address),
                new SqlParameter("@company", item.Company),
                new SqlParameter("@updateby", item.UpdateBy),
                new SqlParameter("@score", item.MembershipScore),
                new SqlParameter("@citizenId", item.CitizenId)
            };
            context.Database.ExecuteSqlCommand("Sp_Customer_Update @first, @last, @phone, @address, @updateby, @score, @citizenId, @id, @status, @company", sqlParams);
        }
        public void UpdateCustomer_MembershipScore(int id, double score, DB_ex1_Context con)
        {
            // Update info to database
            object[] sqlParams =
            {
                new SqlParameter("@id", id),
                new SqlParameter("@score", score)
            };

            con.Database.ExecuteSqlCommand("Sp_Customer_UpdateMembershipScore @score, @id", sqlParams);
        }
        public void UpdateCategory(Category item)
        {
            // Update category into database
            object[] sqlParams =
            {                
                new SqlParameter("@id", item.Id),
                new SqlParameter("@name", item.Name),
                new SqlParameter("@status", Convert.ToByte(item.Status)),
                new SqlParameter("@updateby", item.UpdateBy)
            };
            context.Database.ExecuteSqlCommand("Sp_Category_Update @id, @name, @status, @updateby", sqlParams);
        }
        public void UpdateCardType(CardType item)
        {
            // Update category into database
            object[] sqlParams =
            {
                new SqlParameter("@id", item.Id),
                new SqlParameter("@name", item.Name),
                new SqlParameter("@status", Convert.ToByte(item.Status)),
                new SqlParameter("@updateby", item.UpdateBy),
                new SqlParameter("@bound", item.LowerBound),
                new SqlParameter("@percent", item.PercentDiscount)
            };
            context.Database.ExecuteSqlCommand("Sp_CardType_Update @id, @name, @status, @updateby, @bound, @percent", sqlParams);
        }
        public void UpdateGood(Good item)
        {
            // Update good into database
            object[] sqlParams =
            {
                new SqlParameter("@id", item.Id),
                new SqlParameter("@name", item.Name),
                new SqlParameter("@cat", item.CategoryName),
                new SqlParameter("@status", Convert.ToByte(item.Status)),
                new SqlParameter("@code", item.Barcode),
                new SqlParameter("@importPrice", item.ImportPrice),        
                new SqlParameter("@salePrice", item.SalePrice),
                new SqlParameter("@minQty", item.MinQuantity),
                new SqlParameter("@qty", item.Quantity),
                new SqlParameter("@tax", item.Tax),
                new SqlParameter("@updateby", item.UpdateBy)
            };
            context.Database.ExecuteSqlCommand("Sp_Goods_Update @id, @name, @cat, @status, @code, @importPrice, @salePrice, @minQty, @qty, @tax, @updateby", sqlParams);
        }
        public void UpdateImportGood(Import_Goods item, DB_ex1_Context con)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id", item.Id),
                new SqlParameter("@goodsName", item.GoodsName),
                new SqlParameter("@qty", item.Quantity),
                new SqlParameter("@price", item.Price),
                new SqlParameter("@discount", item.Discount),
                new SqlParameter("@total", item.TotalPrice)
            };
            con.Database.ExecuteSqlCommand("Sp_ImportGoods_Update @id, @goodsName, @price, @total, @qty, @discount", sqlParams);
        }
        public void UpdateExportGood(Export_Goods item, DB_ex1_Context con)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id", item.Id),
                new SqlParameter("@goodsName", item.GoodsName),
                new SqlParameter("@qty", item.Quantity),
                new SqlParameter("@price", item.Price),
                new SqlParameter("@discount", item.Discount),
                new SqlParameter("@total", item.TotalPrice)
            };
            con.Database.ExecuteSqlCommand("Sp_ExportGoods_Update @id, @goodsName, @price, @total, @qty, @discount", sqlParams);
        }
    }
}
