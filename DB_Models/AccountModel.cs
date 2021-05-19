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
        public bool CheckEmail (string email)
        {
            var res = context.Database.SqlQuery<bool>("Sp_Account_CheckEmail @Email", new SqlParameter("@Email", email)).SingleOrDefault();
            return res;
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
        public List<Account> ListAll()
        {
            var list = context.Database.SqlQuery<Account>("select * from Account").ToList();
            return list;
        }
    }
}
