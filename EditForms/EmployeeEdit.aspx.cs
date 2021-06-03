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
        private static int emId;
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
            List<Employee> item = model.ListSingle_Employee(Id);
            List<Employee> all = model.ListAll_Employee();
            // Load to ddUpdateBy
            if (all != null)
            {
                ddUpdateBy.DataSource = all;
                ddUpdateBy.DataTextField = "FullName";
                ddUpdateBy.DataBind();
                ddUpdateBy.Items.Insert(0, "-Select-");
            }     
            
            // Display the employee's info into the textboxes 
            eId.Text = Id.ToString();
            firstName.Text = item.ElementAt(0).FirstName;
            lastName.Text = item.ElementAt(0).LastName;
            position.Text = item.ElementAt(0).Position;
            code.Text = item.ElementAt(0).EmployeeCode;
            phoneNumber.Text = item.ElementAt(0).PhoneNumber;
            address.Text = item.ElementAt(0).EmployeeAddress;

            BindStatus(ddStatus, "Active", "Inactive", item.ElementAt(0).EmployeeStatus);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateModel model = new UpdateModel();
            Employee item = new Employee
            {

                // Get updated info and pass into an Employee object before passing into UpdateEmployee method
                Id = Convert.ToInt32(eId.Text),
                FirstName = firstName.Text,
                LastName = lastName.Text,
                Position = position.Text,
                EmployeeCode = code.Text,
                PhoneNumber = phoneNumber.Text,
                EmployeeAddress = address.Text,
                EmployeeStatus = Convert.ToBoolean(ddStatus.SelectedValue),
                UpdateBy = ddUpdateBy.SelectedItem.Text
            };
            model.UpdateEmployee(item);
            // Redirect to Employee Table after successful update.
            Response.Redirect("/Management/EmployeeManagement.aspx");
        }
        public void BindStatus(DropDownList dd, string trueText, string falseText, bool status)
        {
            string text;
            string value;
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