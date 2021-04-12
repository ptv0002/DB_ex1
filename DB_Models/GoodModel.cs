using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Models
{
    public class GoodModel
    {
        private DB_ex1_Context context = null;
        public GoodModel()
        {
            context = new DB_ex1_Context();
        }
        public List<Good> ListAll()
        {
            // List all goods' info to Good Table
            var list = context.Database.SqlQuery<Good>("Sp_Good_ListAll").ToList();
            return list;
        }
        public List<Good> ListGood(int goodId)
        {
            // Get good's info to display on GoodEdit form
            var good = context.Database.SqlQuery<Good>("SELECT Goods.goodsId, Category.categoryName, Goods.GoodsName, " +
                "Goods.GoodsStatus, Goods.GoodsCode, Goods.MinQuantity, Goods.GoodsQuantity, Goods.ImportPrice, " +
                "Goods.SalePrice, Goods.TaxPercent, Goods.CreateDate, Goods.CreateBy, Goods.UpdateDate, " +
                "Goods.UpdateBy from Goods inner join Category on Goods.categoryId = Category.categoryId " +
                "where Goods.goodsId = " + goodId).ToList();
            return good;
        }
        public void UpdateGood(Good good, int categoryId)
        {
            // Update info to database
            string cmd = "update Goods set GoodsName = '" + good.GoodsName +
                "',categoryId= " + categoryId + ",GoodsStatus= " + Convert.ToByte(good.GoodsStatus) +
                ",GoodsCode= '" + good.GoodsCode + "',MinQuantity= " + good.MinQuantity +
                ",GoodsQuantity= " + good.GoodsQuantity + ",ImportPrice= " + good.ImportPrice + 
                ",TaxPercent= " + good.TaxPercent + ",UpdateBy= '" + good.UpdateBy + "',UpdateDate = GETDATE()" +
                " where goodsId= " + good.goodsId;
            context.Database.ExecuteSqlCommand(cmd);
        }
        public void InsertGood(Good good, int categoryId)
        {
            // Insert new good into database
            string cmd = "insert into Goods (GoodsName, GoodsStatus, GoodsCode, categoryId," +
                " MinQuantity, GoodsQuantity, ImportPrice, TaxPercent, CreateBy, CreateDate) values ('" +
                good.GoodsName + "', 1, '" + good.GoodsCode + "', " + categoryId + ", " + 
                good.MinQuantity + ", " + good.GoodsQuantity + ", " + good.ImportPrice + ", " + 
                good.TaxPercent + ", '" + good.CreateBy + "', GETDATE());";
            context.Database.ExecuteSqlCommand(cmd);
        }
    }
}
