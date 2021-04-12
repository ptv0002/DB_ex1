using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Models.Framework;

namespace DB_Models
{
    public class CategoryModel
    {
        private DB_ex1_Context context = null;
        public CategoryModel()
        {
            context = new DB_ex1_Context();
        }
        public List<Category> ListAll()
        {
            var list = context.Database.SqlQuery<Category>("Sp_Category_ListAll").ToList();
            return list;
        }       
    }
    
}
