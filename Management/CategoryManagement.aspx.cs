using DB_Models;
using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_ex1.Management
{
    public partial class CategoryManagement : System.Web.UI.Page
    {
        static ListModel model = new ListModel();
        static List<Employee> employees = model.ListAll_Employee();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get employee ID from Category Table and pass to the Edit form
            //catId = Convert.ToInt32(Request.QueryString["categoryId"].ToString());
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }
        protected void LoadGrid()
        {
            List<Category> list = model.ListAll_Category();
            if (list != null)
            {
                gv.DataSource = list;
                gv.DataBind();
            }
        }
        protected void btnAdd(object sender, EventArgs e)
        {
            if (employees != null)
            {
                ddCreateBy.DataSource = employees;
                ddCreateBy.DataTextField = "FullName";
                ddCreateBy.DataBind();
                ddCreateBy.Items.Insert(0, new ListItem("-Select-", "0"));
            }
            ddCreateErr.Text = null;
            Popup(false);
        }
        protected void btnSave_Add(object sender, EventArgs e)
        {
            if(ddCreateBy.SelectedItem.Text != "-Select-")
            {
                InsertModel model = new InsertModel();
                Category category = new Category
                {
                    // Get info and pass into a Category object before passing into InsertCategory method
                    CategoryName = addCatName.Text,
                    CreateBy = ddCreateBy.SelectedItem.Text
                };
                model.InsertCategory(category);
                // Redirect to Category Table after successful update.
                Response.Redirect("/Management/CategoryManagement.aspx");
            }
            else
            {
                ddCreateErr.Text = "This field is required";
                Popup(false);
            }
        }
        protected void btnSave_Edit(object sender, EventArgs e)
        {
            if (ddUpdateBy.SelectedItem.Text != "-Select-")
            {
                UpdateModel model = new UpdateModel();
                Category item = new Category
                {
                    Id = Convert.ToInt32(cId.Text),
                    CategoryName = editCatName.Text,
                    CategoryStatus = Convert.ToBoolean(ddStatus.SelectedValue),
                    UpdateBy = ddUpdateBy.SelectedItem.Text
                };
                model.UpdateCategory(item);
                Response.Redirect("/Management/CategoryManagement.aspx");
            }
            else
            {
                ddUpdateErr.Text = "This field is required";
                Popup(true);
            }
        }

        protected void Edit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Get row id
            int rowId = Convert.ToInt32(e.CommandArgument);
            // Get item info from Database
            List<Category> item = model.ListSingle_Category(rowId,"");

            // Bind values into popup
            cId.Text = rowId.ToString();
            editCatName.Text = item.ElementAt(0).CategoryName;
            if (employees != null)
            {
                ddUpdateBy.DataSource = employees;
                ddUpdateBy.DataTextField = "FullName";
                ddUpdateBy.DataBind();
                ddUpdateBy.Items.Insert(0, new ListItem("-Select-", "0"));
            }
            BindStatus(ddStatus, "Active", "Inactive", item.ElementAt(0).CategoryStatus);
            // Reset error message for ddUpdateBy
            ddUpdateErr.Text = null;

            Popup(true);
        }
        public void Popup(bool isEdit)
        {
            StringBuilder builder = new StringBuilder();
            if (isEdit == true)
            {
                builder.Append("<script language=JavaScript> ShowPopup('#editPopup'); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopup", builder.ToString());
            }
            else
            {
                builder.Append("<script language=JavaScript> ShowPopup('#addPopup'); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopup", builder.ToString());
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