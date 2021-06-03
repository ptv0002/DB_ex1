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
            ListModel model = new ListModel();
            List<Good> item = model.ListSingle_Good(Id," ");
            List<Category> lstCategory = model.ListAll_Category();
            // Display Category dropdown list and show the option from the database as the selected option.
            if (lstCategory != null)
            {
                ddCategory.DataSource = lstCategory;
                ddCategory.DataTextField = "categoryName";
                ddCategory.DataBind();
                ddCategory.Items.Insert(0, item.ElementAt(0).categoryName);

            }
            // List employee option for UpdateBy dropdown
            List<Employee> lstEmployee = model.ListAll_Employee();
            if (lstEmployee != null)
            {
                ddUpdateBy.DataSource = lstEmployee;
                ddUpdateBy.DataTextField = "FullName";
                ddUpdateBy.DataBind();
                ddUpdateBy.Items.Insert(0, "-Select-");
            }

            // Display other good's info into the textboxes 
            gId.Text = Id.ToString();
            goodsName.Text = item.ElementAt(0).GoodsName;
            barcode.Text = item.ElementAt(0).GoodsCode;
            importPrice.Text = item.ElementAt(0).ImportPrice.ToString();
            salePrice.Text = item.ElementAt(0).SalePrice.ToString();
            minQty.Text = item.ElementAt(0).MinQuantity.ToString();
            Qty.Text = item.ElementAt(0).GoodsQuantity.ToString();
            tax.Text = item.ElementAt(0).TaxPercent.ToString();

            BindStatus(ddStatus, "Active", "Inactive", item.ElementAt(0).GoodsStatus);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateModel model = new UpdateModel();
            Good item = new Good
            {

                // Get updated info and pass into an Good object before passing into GoodEmployee method
                Id = Convert.ToInt32(gId.Text),
                GoodsName = goodsName.Text,
                GoodsStatus = Convert.ToBoolean(ddStatus.SelectedValue),
                GoodsCode = barcode.Text,
                ImportPrice = Convert.ToDouble(importPrice.Text),
                SalePrice = Convert.ToDouble(salePrice.Text),
                MinQuantity = Convert.ToInt32(minQty.Text),
                GoodsQuantity = Convert.ToInt32(Qty.Text),
                TaxPercent = Convert.ToDouble(tax.Text),
                UpdateBy = ddUpdateBy.SelectedItem.Text,
                categoryName = ddCategory.SelectedItem.Text
            };

            model.UpdateGood(item);
            // Redirect to Good Table after successful update.
            Response.Redirect("/Management/GoodManagement.aspx");
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