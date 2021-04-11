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
    public partial class EmployeeEdit : System.Web.UI.Page
    {
        private int emId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get employee ID from Employee Table and pass to the Edit form
            emId = Convert.ToInt32(Request.QueryString["employeeId"].ToString());
            if (!IsPostBack)
            {
                BindControlValues(emId);
            }
        }
        protected void BindControlValues (int Id)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            List<Employee> lstEmployee = employeeModel.ListEmployee(Id);
            // Display the employee's info into the textboxes 
            eId.Text = Id.ToString();
            firstName.Text = lstEmployee.ElementAt(0).FirstName;
            lastName.Text = lstEmployee.ElementAt(0).LastName;
            phoneNumber.Text = lstEmployee.ElementAt(0).PhoneNumber;
            employeeAddress.Text = lstEmployee.ElementAt(0).EmployeeAddress;
            status.Text = lstEmployee.ElementAt(0).EmployeeStatus.ToString();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            emId = Convert.ToInt32(Request.QueryString["employeeId"].ToString());
            EmployeeModel employeeModel = new EmployeeModel();
            Employee employee = new Employee();

            // Get updated info and pass into an Employee object before passing into UpdateEmployee method
            employee.employeeId = Convert.ToInt32(eId.Text);
            employee.FirstName = firstName.Text;
            employee.LastName = lastName.Text;
            employee.PhoneNumber = phoneNumber.Text;
            employee.EmployeeAddress = employeeAddress.Text;
            employee.EmployeeStatus = Convert.ToBoolean(status.Text);
            employee.UpdateBy = updateBy.Text;
            employeeModel.UpdateEmployee(employee);
            // Redirect to Employee Table after successful update.
            Response.Redirect("/Management/EmployeeManagement.aspx");
        }
    }
}