using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DB_Models
{
    public class CheckModel
    {
        private DB_ex1_Context context = null;
        public CheckModel()
        {
            context = new DB_ex1_Context();
        }
        public bool Login (string userName, string password)
        {
            object[] sqlParams = 
            {
                new SqlParameter("@Username", userName),
                new SqlParameter("@Password", password),
            };
            var res = context.Database.SqlQuery<bool>("Sp_Account_Login @Username, @Password", sqlParams).SingleOrDefault();
            return res;
        }
        public bool CheckEmail (string email, string userName)
        {
            object[] sqlParams =
            {
                new SqlParameter("@Username", userName),
                new SqlParameter("@Email", email),
            };
            var res = context.Database.SqlQuery<bool>("Sp_Account_CheckEmail @Email, @Username", sqlParams).SingleOrDefault();
            return res;
        }
        
        public bool CheckCharID(string id)
        {
            var res = context.Database.SqlQuery<bool>("Sp_Employee_CheckCharID @id", new SqlParameter("@id", id)).SingleOrDefault();
            return res;
        }
    }
}
