using DB_Models;
using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_ex1.EditForms
{
    public partial class EmployeeEdit : System.Web.UI.Page
    {
        private int emId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get employee ID from Employee Table and pass to the Edit form
            emId = Convert.ToInt32(Request.QueryString["Id"].ToString());
            if (!IsPostBack)
            {
                BindControlValues(emId);
            }
        }
        protected void BindControlValues (int Id)
        {
            ListModel model = new ListModel();
            List<Employee> lstEmployee = model.ListSingle_Employee(Id);
            List<Employee> all = model.ListAll_Employee();
            // Display the employee's info into the textboxes 
            if (all != null)
            {
                ddUpdateBy.DataSource = all;
                ddUpdateBy.DataTextField = "FullName";
                ddUpdateBy.DataBind();
                ddUpdateBy.Items.Insert(0, new ListItem("-Select-", "0"));
            }
            eId.Text = Id.ToString();
            firstName.Text = lstEmployee.ElementAt(0).FirstName;
            lastName.Text = lstEmployee.ElementAt(0).LastName;
            position.Text = lstEmployee.ElementAt(0).Position;
            code.Text = lstEmployee.ElementAt(0).EmployeeCode;
            phoneNumber.Text = lstEmployee.ElementAt(0).PhoneNumber;
            employeeAddress.Text = lstEmployee.ElementAt(0).EmployeeAddress;

            BindStatus(ddStatus, "Active", "Inactive", lstEmployee.ElementAt(0).EmployeeStatus);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddUpdateBy.SelectedItem.Text != "-Select-")
            {
                UpdateModel model = new UpdateModel();
                Employee employee = new Employee();

                // Get updated info and pass into an Employee object before passing into UpdateEmployee method
                employee.Id = Convert.ToInt32(eId.Text);
                employee.FirstName = firstName.Text;
                employee.LastName = lastName.Text;
                employee.Position = position.Text;
                employee.EmployeeCode = code.Text;
                employee.PhoneNumber = phoneNumber.Text;
                employee.EmployeeAddress = employeeAddress.Text;
                employee.EmployeeStatus = Convert.ToBoolean(ddStatus.SelectedValue);
                employee.UpdateBy = ddUpdateBy.SelectedItem.Text;
                model.UpdateEmployee(employee);
                // Redirect to Employee Table after successful update.
                Response.Redirect("/Management/EmployeeManagement.aspx");
            }
            else
            {
                ddError.Text = "This field is required";
                ddError.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void BindStatus(DropDownList dd, string trueText, string falseText, bool status)
        {
            string text;
            string value;
            // Load PaymentStatus
            if (status == true)
            {
                text = trueText;
                value = "true";
            }
            else
            {
                text = falseText;
                value = "false";
            }

            dd.Items.Insert(0, new ListItem(text, value.ToString()));
            dd.Items.Insert(1, new ListItem(trueText, "true"));
            dd.Items.Insert(2, new ListItem(falseText, "false"));
        }
    }
}