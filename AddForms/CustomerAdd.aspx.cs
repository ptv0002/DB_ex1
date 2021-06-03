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
            Customer customer = new Customer
            {
                // Get info and pass into an Employee object before passing into InsertEmployee method
                FirstName = firstName.Text,
                LastName = lastName.Text,
                CitizenId = citizenId.Text,
                MembershipScore = Convert.ToDouble(score.Text),
                PhoneNumber = phoneNumber.Text,
                CustomerAddress = address.Text,
                CreateBy = ddCreateBy.SelectedItem.Text
            };
            model.InsertCustomer(customer);
            // Redirect to Employee Table after successful update.
            Response.Redirect("/Management/CustomerManagement.aspx");
        }
    }
}