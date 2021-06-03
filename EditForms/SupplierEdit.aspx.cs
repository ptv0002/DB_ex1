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
    public partial class SupplierEdit : System.Web.UI.Page
    {
        private static int supId;
        protected void Page_Load(object sender, EventArgs e)
        {
            supId = Convert.ToInt32(Request.QueryString["Id"].ToString());
            if (!IsPostBack)
            {
                BindControlValues(supId);
            }
        }
        protected void BindControlValues(int Id)
        {
            ListModel model = new ListModel();
            List<Supplier> item = model.ListSingle_Supplier(Id);
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
            sId.Text = Id.ToString();
            name.Text = item.ElementAt(0).SupplierName;           
            phoneNumber.Text = item.ElementAt(0).PhoneNumber;
            address.Text = item.ElementAt(0).SupplierAddress;

            BindStatus(ddStatus, "Active", "Inactive", item.ElementAt(0).SupplierStatus);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateModel model = new UpdateModel();
            Supplier item = new Supplier
            {

                // Get updated info and pass into an Employee object before passing into UpdateEmployee method
                Id = Convert.ToInt32(sId.Text),
                SupplierName = name.Text,
                PhoneNumber = phoneNumber.Text,
                SupplierAddress = address.Text,
                SupplierStatus = Convert.ToBoolean(ddStatus.SelectedValue),
                UpdateBy = ddUpdateBy.SelectedItem.Text
            };
            model.UpdateSupplier(item);
            // Redirect to Employee Table after successful update.
            Response.Redirect("/Management/SupplierManagement.aspx");
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