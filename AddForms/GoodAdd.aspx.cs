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
    public partial class GoodAdd : System.Web.UI.Page
    {
        ListModel listModel = new ListModel();
        InsertModel insertModel = new InsertModel();
        CheckModel checkModel = new CheckModel();
        BindModel bindModel = new BindModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropdown();
            }

        }
        protected void LoadDropdown()
        {
            List<Category> list = listModel.ListCategory(0,"");
            bindModel.BindInstance(list, ddCategory, "", 0);            
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string emId = createBy.Text.ToUpper();
            if (checkModel.CheckCharID(emId) == true)
            {

                Good good = new Good
                {

                    // Get info and pass into an Good object before passing into InsertGood method
                    Name = goodsName.Text,
                    Barcode = barcode.Text,
                    ImportPrice = Convert.ToDouble(importPrice.Text),
                    MinQuantity = Convert.ToInt32(minQty.Text),
                    Quantity = Convert.ToInt32(Qty.Text),
                    Tax = Convert.ToDouble(tax.Text),
                    CreateBy = emId,
                    CategoryName = ddCategory.SelectedItem.Text
                };
                insertModel.InsertGood(good);

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