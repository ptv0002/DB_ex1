using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DB_Models
{
    public class AccountModel
    {
        private DB_ex1_Context context = null;
        public AccountModel()
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
    }
}
