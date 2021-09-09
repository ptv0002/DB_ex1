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
        InsertModel insertModel = new InsertModel();
        CheckModel checkModel = new CheckModel();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string emId = createBy.Text.ToUpper();
            string con;
            if (contact.Text == null)
            {
                con = "";
            }
            else
            {
                con = contact.Text;
            }
            if (checkModel.CheckCharID(emId) == true)
            {
                Supplier item = new Supplier
                {
                    Name = name.Text,
                    PhoneNumber = phoneNumber.Text,
                    Address = address.Text,
                    ContactInfo = con,
                    CreateBy = emId
                };
                insertModel.InsertSupplier(item);
                // Redirect to Employee Table after successful update.
                Response.Redirect("/Management/SupplierManagement.aspx");
            }
            else
            {
                idErr.Text = "Invalid ID";
            }
        }
    }
}