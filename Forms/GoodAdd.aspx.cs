using DB_Models;
using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_ex1.Forms
{
    public partial class GoodAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropdownCategory();
            }

        }
        protected void LoadDropdownCategory()
        {
            CategoryModel categoryModel = new CategoryModel();
            List<Category> lstCategory = categoryModel.ListAll();
            if (lstCategory != null)
            {
                ddCategory.DataSource = lstCategory;
                ddCategory.DataTextField = "categoryName";
                ddCategory.DataValueField = "categoryId";
                ddCategory.DataBind();
                ddCategory.Items.Insert(0, new ListItem("-Select-", "0"));

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            GoodModel goodModel = new GoodModel();
            Good good = new Good();

            // Get info and pass into an Good object before passing into InsertGood method
            good.GoodsName = goodsName.Text;
            good.GoodsCode = barcode.Text;
            good.ImportPrice = Convert.ToDouble(importPrice.Text);
            good.MinQuantity = Convert.ToInt32(minQty.Text);
            good.GoodsQuantity = Convert.ToInt32(Qty.Text);
            good.TaxPercent = Convert.ToInt32(tax.Text);
            good.CreateBy = createBy.Text;

            // Get categoryId
            int catId = Convert.ToInt32(ddCategory.SelectedValue);
            goodModel.InsertGood(good, catId);

            // Redirect to Good Table after successful update.
            Response.Redirect("/Management/GoodManagement.aspx");
        }
    }
}