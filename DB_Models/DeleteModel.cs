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
        public void DeleteImport(int id, DB_ex1_Context con)
        {
            con.Database.ExecuteSqlCommand("Sp_ImportGoods_Delete @id", new SqlParameter("@id", id));
        }
        public void DeleteExport(int id, DB_ex1_Context con)
        {
            con.Database.ExecuteSqlCommand("Sp_ExportGoods_Delete @id", new SqlParameter("@id", id));
        }
    }
}
