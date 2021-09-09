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
    public partial class CustomerEdit : System.Web.UI.Page
    {
        private static int cusId;
        UpdateModel updateModel = new UpdateModel();
        ListModel listModel = new ListModel();
        CheckModel checkModel = new CheckModel();
        BindModel bindModel = new BindModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            cusId = Convert.ToInt32(Request.QueryString["Id"].ToString());
            if (!IsPostBack)
            {
                BindControlValues(cusId);
            }
        }
        protected void BindControlValues(int Id)
        {
            // Display the customer's info into the textboxes 
            List<Customer> item = listModel.ListCustomer(Id);
            cId.Text = Id.ToString();
            firstName.Text = item.ElementAt(0).FirstName;
            lastName.Text = item.ElementAt(0).LastName;
            score.Text = item.ElementAt(0).MembershipScore.ToString();
            citizenId.Text = item.ElementAt(0).CitizenId;
            phoneNumber.Text = item.ElementAt(0).PhoneNumber;
            address.Text = item.ElementAt(0).Address;

            bindModel.BindStatus(ddStatus, "Active", "Inactive", item.ElementAt(0).Status);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string emId = updateBy.Text.ToUpper();
            if (checkModel.CheckCharID(emId) == true)
            {
                Customer item = new Customer
                {
                    // Get updated info and pass into an Employee object before passing into UpdateEmployee method
                    Id = Convert.ToInt32(cId.Text),
                    FirstName = firstName.Text,
                    LastName = lastName.Text,
                    MembershipScore = Convert.ToDouble(score.Text),
                    CitizenId = citizenId.Text,
                    PhoneNumber = phoneNumber.Text,
                    Address = address.Text,
                    Status = Convert.ToBoolean(ddStatus.SelectedValue),
                    UpdateBy = emId,
                    // Extend ---------- Add company info
                    Company=""
                };
                updateModel.UpdateCustomer(item);
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