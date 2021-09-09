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
        private static int employeeId;
        UpdateModel updateModel = new UpdateModel();
        ListModel listModel = new ListModel();
        CheckModel checkModel = new CheckModel();
        BindModel bindModel = new BindModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get employee ID from Employee Table and pass to the Edit form
            employeeId = Convert.ToInt32(Request.QueryString["Id"].ToString());
            if (!IsPostBack)
            {
                BindControlValues(employeeId);
            }
        }
        protected void BindControlValues (int Id)
        {
            ListModel model = new ListModel();
            List<Employee> item = model.ListEmployee(Id);   
            
            // Display the employee's info into the textboxes 
            eId.Text = item.ElementAt(0).CharID;
            firstName.Text = item.ElementAt(0).FirstName;
            lastName.Text = item.ElementAt(0).LastName;
            position.Text = item.ElementAt(0).Position;
            phoneNumber.Text = item.ElementAt(0).PhoneNumber;
            address.Text = item.ElementAt(0).Address;

            bindModel.BindStatus(ddStatus, "Active", "Inactive", item.ElementAt(0).Status);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string emId = updateBy.Text.ToUpper();
            if (checkModel.CheckCharID(emId) == true)
            {
                Employee item = new Employee
                {

                    // Get updated info and pass into an Employee object before passing into UpdateEmployee method
                    Id = employeeId,
                    FirstName = firstName.Text,
                    LastName = lastName.Text,
                    Position = position.Text,
                    CharID = eId.Text,
                    PhoneNumber = phoneNumber.Text,
                    Address = address.Text,
                    Status = Convert.ToBoolean(ddStatus.SelectedValue),
                    UpdateBy = emId
                };
                updateModel.UpdateEmployee(item);
                // Redirect to Employee Table after successful update.
                Response.Redirect("/Management/EmployeeManagement.aspx");
            }
            else
            {
                idErr.Text = "Invalid ID";
            }
        }
    }
}