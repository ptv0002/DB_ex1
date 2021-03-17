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
            var list = context.Database.SqlQuery<Good>("Sp_Good_ListAll").ToList();
            return list;
        }
    }
}
