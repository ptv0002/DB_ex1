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
    public partial class SupplierAdd : System.Web.UI.Page
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
            Supplier item = new Supplier
            {
                SupplierName = name.Text,
                PhoneNumber = phoneNumber.Text,
                SupplierAddress = address.Text,
                CreateBy = ddCreateBy.SelectedItem.Text
            };
            model.InsertSupplier(item);
            // Redirect to Employee Table after successful update.
            Response.Redirect("/Management/SupplierManagement.aspx");
        }
    }
}