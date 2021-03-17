using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Models
{
    public class EmployeeModel
    {
        private DB_ex1_Context context = null;
        public EmployeeModel()
        {
            context = new DB_ex1_Context();
        }
        public List<Employee> ListAll()
        {
            var list = context.Database.SqlQuery<Employee>("Sp_Employee_ListAll").ToList();
            return list;
        }
    }
}
