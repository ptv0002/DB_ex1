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
            List<Good> lstGood = model.ListSingle_Good(Id," ");
            List<Category> lstCategory = model.ListAll_Category();
            // Display Category dropdown list and show the option from the database as the selected option.
            if (lstCategory != null)
            {
                ddCategory.DataSource = lstCategory;
                ddCategory.DataTextField = "categoryName";
                ddCategory.DataBind();
                ddCategory.Items.Insert(0, new ListItem(lstGood.ElementAt(0).categoryName, "0"));

            }
            // List employee option for UpdateBy dropdown
            List<Employee> lstEmployee = model.ListAll_Employee();
            if (lstEmployee != null)
            {
                ddUpdateBy.DataSource = lstEmployee;
                ddUpdateBy.DataTextField = "FullName";
                ddUpdateBy.DataBind();
                ddUpdateBy.Items.Insert(0, new ListItem("-Select-", "0"));
            }

            // Display other good's info into the textboxes 
            gId.Text = Id.ToString();
            goodsName.Text = lstGood.ElementAt(0).GoodsName;
            barcode.Text = lstGood.ElementAt(0).GoodsCode;
            importPrice.Text = lstGood.ElementAt(0).ImportPrice.ToString();
            minQty.Text = lstGood.ElementAt(0).MinQuantity.ToString();
            Qty.Text = lstGood.ElementAt(0).GoodsQuantity.ToString();
            tax.Text = lstGood.ElementAt(0).TaxPercent.ToString();

            BindStatus(ddStatus, "Active", "Inactive", lstGood.ElementAt(0).GoodsStatus);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddUpdateBy.SelectedItem.Text != "-Select-")
            {
                UpdateModel model = new UpdateModel();
                Good good = new Good();

                // Get updated info and pass into an Good object before passing into GoodEmployee method
                good.Id = Convert.ToInt32(gId.Text);
                good.GoodsName = goodsName.Text;
                good.GoodsStatus = Convert.ToBoolean(ddStatus.SelectedValue);
                good.GoodsCode = barcode.Text;
                good.ImportPrice = Convert.ToDouble(importPrice.Text);
                good.MinQuantity = Convert.ToInt32(minQty.Text);
                good.GoodsQuantity = Convert.ToInt32(Qty.Text);
                good.TaxPercent = Convert.ToDouble(tax.Text);
                good.UpdateBy = ddUpdateBy.SelectedItem.Text;
                good.categoryName = ddCategory.SelectedItem.Text;

                model.UpdateGood(good);
                // Redirect to Good Table after successful update.
                Response.Redirect("/Management/GoodManagement.aspx");
            }
            else
            {
                ddError.Text = "This field is required";
                ddError.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void BindStatus(DropDownList dd, string trueText, string falseText, bool status)
        {
            string text;
            string value;
            // Load PaymentStatus
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