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
            ListModel model = new ListModel();
            List<Employee> all = model.ListAll_Employee();
            // Load to ddUpdateBy
            if (all != null)
            {
                ddUpdateBy.DataSource = all;
                ddUpdateBy.DataTextField = "FullName";
                ddUpdateBy.DataBind();
                ddUpdateBy.Items.Insert(0, "-Select-");
            }
            // Display the customer's info into the textboxes 
            List<Customer> item = model.ListSingle_Customer(Id);
            cId.Text = Id.ToString();
            firstName.Text = item.ElementAt(0).FirstName;
            lastName.Text = item.ElementAt(0).LastName;
            score.Text = item.ElementAt(0).MembershipScore.ToString();
            citizenId.Text = item.ElementAt(0).CitizenId;
            phoneNumber.Text = item.ElementAt(0).PhoneNumber;
            address.Text = item.ElementAt(0).CustomerAddress;

            BindStatus(ddStatus, "Active", "Inactive", item.ElementAt(0).CustomerStatus);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateModel model = new UpdateModel();
            Customer item = new Customer
            {

                // Get updated info and pass into an Employee object before passing into UpdateEmployee method
                Id = Convert.ToInt32(cId.Text),
                FirstName = firstName.Text,
                LastName = lastName.Text,
                MembershipScore = Convert.ToDouble(score.Text),
                CitizenId = citizenId.Text,
                PhoneNumber = phoneNumber.Text,
                CustomerAddress = address.Text,
                CustomerStatus = Convert.ToBoolean(ddStatus.SelectedValue),
                UpdateBy = ddUpdateBy.SelectedItem.Text
            };
            model.UpdateCustomer(item);
            // Redirect to Employee Table after successful update.
            Response.Redirect("/Management/CustomerManagement.aspx");
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