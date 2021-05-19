using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Models
{
    public class OtherModel
    {   
        private DB_ex1_Context context = null;
        public OtherModel()
        {
            context = new DB_ex1_Context();
        }
        public DbContextTransaction BeginTransaction()
        {
            return context.Database.BeginTransaction();
        }
    }
}
