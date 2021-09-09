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
    public partial class GoodEdit : System.Web.UI.Page
    {
        private int gdId = 0;
        UpdateModel updateModel = new UpdateModel();
        ListModel listModel = new ListModel();
        CheckModel checkModel = new CheckModel();
        BindModel bindModel = new BindModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get good ID from Good Table and pass to the Edit form
            gdId = Convert.ToInt32(Request.QueryString["Id"].ToString());
            if (!IsPostBack)
            {
                BindControlValues(gdId);
            }
        }
        protected void BindControlValues(int Id)
        {
            List<Good> item = listModel.ListGood(Id,"");
            List<Category> list = listModel.ListCategory(0,"");
            // Display Category dropdown list and show the option from the database as the selected option.
            bindModel.BindInstance(list, ddCategory, item.ElementAt(0).CategoryName, 0); // Temporary value for selected category name
            
            // Display other good's info into the textboxes 
            gId.Text = Id.ToString();
            goodsName.Text = item.ElementAt(0).Name;
            barcode.Text = item.ElementAt(0).Barcode;
            importPrice.Text = item.ElementAt(0).ImportPrice.ToString();
            salePrice.Text = item.ElementAt(0).SalePrice.ToString();
            minQty.Text = item.ElementAt(0).MinQuantity.ToString();
            Qty.Text = item.ElementAt(0).Quantity.ToString();
            tax.Text = item.ElementAt(0).Tax.ToString();

            bindModel.BindStatus(ddStatus, "Active", "Inactive", item.ElementAt(0).Status);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string emId = updateBy.Text.ToUpper();
            if (checkModel.CheckCharID(emId) == true)
            {
                Good item = new Good
                {

                    // Get updated info and pass into an Good object before passing into GoodEmployee method
                    Id = Convert.ToInt32(gId.Text),
                    Name = goodsName.Text,
                    Status = Convert.ToBoolean(ddStatus.SelectedValue),
                    Barcode = barcode.Text,
                    ImportPrice = Convert.ToDouble(importPrice.Text),
                    SalePrice = Convert.ToDouble(salePrice.Text),
                    MinQuantity = Convert.ToInt32(minQty.Text),
                    Quantity = Convert.ToInt32(Qty.Text),
                    Tax = Convert.ToDouble(tax.Text),
                    UpdateBy = emId,
                    CategoryName = ddCategory.SelectedItem.Text
                };


                updateModel.UpdateGood(item);
            // Redirect to Good Table after successful update.
            Response.Redirect("/Management/GoodManagement.aspx");
        }
            else
            {
                idErr.Text = "Invalid ID";
            }
}
    }
}