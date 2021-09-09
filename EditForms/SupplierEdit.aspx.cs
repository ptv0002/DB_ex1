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
        UpdateModel updateModel = new UpdateModel();
        ListModel listModel = new ListModel();
        CheckModel checkModel = new CheckModel();
        BindModel bindModel = new BindModel();
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
            List<Supplier> item = listModel.ListSupplier(Id);
            
            // Display the employee's info into the textboxes 
            sId.Text = Id.ToString();
            name.Text = item.ElementAt(0).Name;           
            phoneNumber.Text = item.ElementAt(0).PhoneNumber;
            address.Text = item.ElementAt(0).Address;
            contact.Text = item.ElementAt(0).ContactInfo;
            bindModel.BindStatus(ddStatus, "Active", "Inactive", item.ElementAt(0).Status);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string emId = updateBy.Text.ToUpper();
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

                    // Get updated info and pass into an Employee object before passing into UpdateEmployee method
                    Id = Convert.ToInt32(sId.Text),
                    Name = name.Text,
                    PhoneNumber = phoneNumber.Text,
                    Address = address.Text,
                    ContactInfo = con,
                    Status = Convert.ToBoolean(ddStatus.SelectedValue),
                    UpdateBy = emId
                };
                updateModel.UpdateSupplier(item);
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