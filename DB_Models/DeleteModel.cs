using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Models
{
    public class DeleteModel
    {
        private DB_ex1_Context context = null;
        public DeleteModel()
        {
            context = new DB_ex1_Context();
        }
        public void DeleteImport(int id)
        {
            context.Database.ExecuteSqlCommand("Sp_ImportGoods_Delete @id", new SqlParameter("@id", id));
        }
    }
}
