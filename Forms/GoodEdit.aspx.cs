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
    public partial class GoodEdit : System.Web.UI.Page
    {
        private int gdId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get good ID from Good Table and pass to the Edit form
            gdId = Convert.ToInt32(Request.QueryString["goodsId"].ToString());
            if (!IsPostBack)
            {
                BindControlValues(gdId);
            }
        }
        protected void BindControlValues(int Id)
        {
            GoodModel goodModel = new GoodModel();
            List<Good> lstGood = goodModel.ListGood(Id);
            CategoryModel categoryModel = new CategoryModel();
            List<Category> lstCategory = categoryModel.ListAll();
            // Display Category dropdown list and show the option from the database as the selected option.
            if (lstCategory != null)
            {
                ddCategory.DataSource = lstCategory;
                ddCategory.DataTextField = "categoryName";
                ddCategory.DataValueField = "categoryId";
                ddCategory.DataBind();
                ddCategory.Items.Insert(0, new ListItem(lstGood.ElementAt(0).categoryName, "0"));

            }
            // Display other good's info into the textboxes 
            gId.Text = Id.ToString();
            goodsName.Text = lstGood.ElementAt(0).GoodsName;
            barcode.Text = lstGood.ElementAt(0).GoodsCode;
            importPrice.Text = lstGood.ElementAt(0).ImportPrice.ToString();
            minQty.Text = lstGood.ElementAt(0).MinQuantity.ToString();
            Qty.Text = lstGood.ElementAt(0).GoodsQuantity.ToString();
            tax.Text = lstGood.ElementAt(0).TaxPercent.ToString();
            status.Text = lstGood.ElementAt(0).GoodsStatus.ToString();
            updateBy.Text = lstGood.ElementAt(0).UpdateBy;

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //gdId = Convert.ToInt32(Request.QueryString["goodId"]);
            GoodModel goodModel = new GoodModel();
            Good good = new Good();

            // Get updated info and pass into an Good object before passing into GoodEmployee method
            good.goodsId = Convert.ToInt32(gId.Text);
            good.GoodsName = goodsName.Text;
            good.GoodsStatus = Convert.ToBoolean(status.Text); ;
            good.GoodsCode = barcode.Text;
            good.ImportPrice = Convert.ToDouble(importPrice.Text);
            good.MinQuantity = Convert.ToInt32(minQty.Text);
            good.GoodsQuantity = Convert.ToInt32(Qty.Text);
            good.TaxPercent = Convert.ToInt32(tax.Text);
            good.UpdateBy = updateBy.Text;


            int catId = Convert.ToInt32(ddCategory.SelectedValue);

            goodModel.UpdateGood(good, catId);
            // Redirect to Good Table after successful update.
            Response.Redirect("/Management/GoodManagement.aspx");
        }
    }
}