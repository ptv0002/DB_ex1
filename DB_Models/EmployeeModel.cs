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
            // List all employees' info to Employee Table
            var list = context.Database.SqlQuery<Employee>("Sp_Employee_ListAll").ToList();
            return list;
        }
        public List<Employee> ListEmployee(int employeeId)
        {
            // Get employee's info to display on EmployeeEdit form
            var employee = context.Database.SqlQuery<Employee> ("select * from Employee where employeeId =" + employeeId).ToList();
            return employee;
        }
        public void UpdateEmployee(Employee employee)
        {
            // Update info to database
            string cmd = "update Employee set FirstName = '" + employee.FirstName +
                "',LastName= '" + employee.LastName + "',PhoneNumber= '" + employee.PhoneNumber +
                "',EmployeeAddress= '" + employee.EmployeeAddress + 
                "',EmployeeStatus= " + Convert.ToByte(employee.EmployeeStatus) +
                ",UpdateBy= '" + employee.UpdateBy + "',UpdateDate = GETDATE()" +
                " where employeeId= " + employee.employeeId + ";";
            context.Database.ExecuteSqlCommand(cmd);
        }
        public void InsertEmployee(Employee employee)
        {
            // Insert new employee into database
            string cmd = "insert into Employee (FirstName, LastName, EmployeeStatus, PhoneNumber," +
                " EmployeeAddress, CreateBy, CreateDate) values ('" + employee.FirstName +
                "', '" + employee.LastName + "', 1, '" + employee.PhoneNumber +
                "', '" + employee.EmployeeAddress + "', '" + employee.CreateBy + "', GETDATE());";
            context.Database.ExecuteSqlCommand(cmd);
        }
    }
}
