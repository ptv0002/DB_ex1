using DB_Models;
using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_ex1.AddForms
{
    public partial class EmployeeAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropDown();
            }
        }
        protected void LoadDropDown()
        {
            ListModel model = new ListModel();
            List<Employee> list = model.ListAll_Employee();
            if (list != null)
            {
                ddCreateBy.DataSource = list;
                ddCreateBy.DataTextField = "FullName";
                ddCreateBy.DataBind();
                ddCreateBy.Items.Insert(0, "-Select-");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            InsertModel model = new InsertModel();
            Employee employee = new Employee
            {

                // Get info and pass into an Employee object before passing into InsertEmployee method
                FirstName = firstName.Text,
                LastName = lastName.Text,
                Position = position.Text,
                EmployeeCode = code.Text,
                PhoneNumber = phoneNumber.Text,
                EmployeeAddress = employeeAddress.Text,
                CreateBy = ddCreateBy.SelectedItem.Text
            };
            model.InsertEmployee(employee);
            // Redirect to Employee Table after successful update.
            Response.Redirect("/Management/EmployeeManagement.aspx");
        }
    }
}