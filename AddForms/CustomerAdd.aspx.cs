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
    public partial class CustomerAdd : System.Web.UI.Page
    {
        InsertModel insertModel = new InsertModel();
        CheckModel checkModel = new CheckModel();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string emId = createBy.Text.ToUpper();
            if (checkModel.CheckCharID(emId) == true)
            {
                Customer customer = new Customer
                {
                    // Get info and pass into an Employee object before passing into InsertEmployee method
                    FirstName = firstName.Text,
                    LastName = lastName.Text,
                    CitizenId = citizenId.Text,
                    MembershipScore = Convert.ToDouble(score.Text),
                    PhoneNumber = phoneNumber.Text,
                    Address = address.Text,
                    Company = "",
                    CreateBy = emId
                };
                insertModel.InsertCustomer(customer);
                // Redirect to Customer Table after successful update.
                Response.Redirect("/Management/CustomerManagement.aspx");
            }
            else
            {
                idErr.Text = "Invalid ID";
            }
            
        }
    }
}