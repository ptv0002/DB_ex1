using DB_Models;
using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_ex1.Forms
{
    public partial class EmployeeAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            Employee employee = new Employee();

            // Get info and pass into an Employee object before passing into InsertEmployee method
            employee.FirstName = firstName.Text;
            employee.LastName = lastName.Text;
            employee.PhoneNumber = phoneNumber.Text;
            employee.EmployeeAddress = employeeAddress.Text;
            employee.CreateBy = createBy.Text;
            employeeModel.InsertEmployee(employee);
            // Redirect to Employee Table after successful update.
            Response.Redirect("/Management/EmployeeManagement.aspx");
        }
        
    }
}