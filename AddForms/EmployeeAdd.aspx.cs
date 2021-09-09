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
        InsertModel insertModel = new InsertModel();
        CheckModel checkModel = new CheckModel();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string byId = createBy.Text.ToUpper();
            string emId = code.Text.ToUpper();
            if (checkModel.CheckCharID(byId) == true && checkModel.CheckCharID(emId) == false)
            {
                Employee employee = new Employee
                {

                    // Get info and pass into an Employee object before passing into InsertEmployee method
                    FirstName = firstName.Text,
                    LastName = lastName.Text,
                    Position = position.Text,
                    CharID = emId,
                    PhoneNumber = phoneNumber.Text,
                    Address = employeeAddress.Text,
                    CreateBy = byId
                };
                insertModel.InsertEmployee(employee);
                // Redirect to Employee Table after successful update.
                Response.Redirect("/Management/EmployeeManagement.aspx");
            }
            else if (checkModel.CheckCharID(byId) == false && checkModel.CheckCharID(emId) == false)
            {
                byErr.Text = "Invalid ID";
            }
            else if (checkModel.CheckCharID(byId) == true && checkModel.CheckCharID(emId) == true)
            {
                idErr.Text = "ID is taken";
            }
            else
            {
                byErr.Text = "Invalid ID";
                idErr.Text = "ID is taken";
            }
        }
    }
}