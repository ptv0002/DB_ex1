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
                ddCategory.Items.Insert(0, new ListItem("-Select-", "0"));
            }
            // Load Employee list to CreateBy dropdown
            List<Employee> list = model.ListAll_Employee();
            if (list != null)
            {
                ddCreateBy.DataSource = list;
                ddCreateBy.DataTextField = "FullName";
                ddCreateBy.DataBind();
                ddCreateBy.Items.Insert(0, new ListItem("-Select-", "0"));

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddCategory.SelectedItem.Text != "-Select-" && ddCreateBy.SelectedItem.Text != "-Select-")
            {
                InsertModel model = new InsertModel();
                Good good = new Good();

                // Get info and pass into an Good object before passing into InsertGood method
                good.GoodsName = goodsName.Text;
                good.GoodsCode = barcode.Text;
                good.ImportPrice = Convert.ToDouble(importPrice.Text);
                good.MinQuantity = Convert.ToInt32(minQty.Text);
                good.GoodsQuantity = Convert.ToInt32(Qty.Text);
                good.TaxPercent = Convert.ToDouble(tax.Text);
                good.CreateBy = ddCreateBy.SelectedItem.Text;
                good.categoryName = ddCategory.SelectedItem.Text;
                model.InsertGood(good);

                // Redirect to Good Table after successful update.
                Response.Redirect("/Management/GoodManagement.aspx");
            }
            else if (ddCategory.SelectedItem.Text == "-Select-" && ddCreateBy.SelectedItem.Text != "-Select-")
            {
                ddCatError.Text = "This field is required";
                ddCatError.ForeColor = System.Drawing.Color.Red;
            }
            else if (ddCategory.SelectedItem.Text != "-Select-" && ddCreateBy.SelectedItem.Text == "-Select-")
            {
                ddCreateError.Text = "This field is required";
                ddCreateError.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                ddCatError.Text = "This field is required";
                ddCatError.ForeColor = System.Drawing.Color.Red;
                ddCreateError.Text = "This field is required";
                ddCreateError.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}