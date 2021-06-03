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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropdowns();
            }

        }
        protected void LoadDropdowns()
        {
            ListModel model = new ListModel();
            List<Category> cat = model.ListAll_Category();
            if (cat != null)
            {
                ddCategory.DataSource = cat;
                ddCategory.DataTextField = "categoryName";
                ddCategory.DataBind();
                ddCategory.Items.Insert(0,"-Select-");
            }
            // Load Employee list to CreateBy dropdown
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
            Good good = new Good
            {

                // Get info and pass into an Good object before passing into InsertGood method
                GoodsName = goodsName.Text,
                GoodsCode = barcode.Text,
                ImportPrice = Convert.ToDouble(importPrice.Text),
                MinQuantity = Convert.ToInt32(minQty.Text),
                GoodsQuantity = Convert.ToInt32(Qty.Text),
                TaxPercent = Convert.ToDouble(tax.Text),
                CreateBy = ddCreateBy.SelectedItem.Text,
                categoryName = ddCategory.SelectedItem.Text
            };
            model.InsertGood(good);

            // Redirect to Good Table after successful update.
            Response.Redirect("/Management/GoodManagement.aspx");
        }
    }
}