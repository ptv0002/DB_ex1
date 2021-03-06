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
        UpdateModel updateModel = new UpdateModel();
        InsertModel insertModel = new InsertModel();
        BindModel bindModel = new BindModel();
        ListModel listModel = new ListModel();
        CheckModel checkModel = new CheckModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                idCreateErr.Text = null;
            }
        }
        protected void LoadGrid()
        {
            List<Category> list = listModel.ListCategory(0,"");
            if (list != null)
            {
                gv.DataSource = list;
                gv.DataBind();
            }
        }
        protected void btnSave_Add(object sender, EventArgs e)
        {
            string emId = createBy.Text.ToUpper();
            if (checkModel.CheckCharID(emId) == true)
            {
                Category category = new Category
                {
                    // Get info and pass into a Category object before passing into InsertCategory method
                    Name = addName.Text,
                    CreateBy = emId
                };
                insertModel.InsertCategory(category);
                // Redirect to Category Table after successful update.
                Response.Redirect("CategoryManagement.aspx");
            }
            else
            {
                idCreateErr.Text = "Invalid ID";
                Popup(false);
            }
        }
        protected void btnSave_Edit(object sender, EventArgs e)
        {
            string emId = updateBy.Text.ToUpper();
            if (checkModel.CheckCharID(emId) == true)
            {
                Category item = new Category
                {
                    Id = Convert.ToInt32(cId.Text),
                    Name = editName.Text,
                    Status = Convert.ToBoolean(ddStatus.SelectedValue),
                    UpdateBy = emId
                };
                updateModel.UpdateCategory(item);
                Response.Redirect("CategoryManagement.aspx");
            }
            else
            {
                idUpdateErr.Text = "Invalid ID";
                Popup(true);
            }
        }

        protected void Edit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Get DB id
            int id = Convert.ToInt32(e.CommandArgument);
            // Get item info from Database
            var item = listModel.ListCategory(id,"");

            // Bind values into popup
            cId.Text = id.ToString();
            editName.Text = item.ElementAt(0).Name;
            
            bindModel.BindStatus(ddStatus, "Active", "Inactive", item.ElementAt(0).Status);
            // Reset error message for ddUpdateBy
            idUpdateErr.Text = null;

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
    }
}