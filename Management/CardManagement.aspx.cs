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
    public partial class CardManagement : System.Web.UI.Page
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
            }
        }
        protected void LoadGrid()
        {
            List<CardType> list = listModel.ListCardType(0);
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
                CardType item = new CardType
                {
                    // Get info and pass into a CardType object before passing into InsertCardType method
                    Name = addName.Text,
                    LowerBound = Convert.ToDouble(addBound.Text),
                    PercentDiscount = Convert.ToDouble(addPercent.Text),
                    CreateBy = emId
                };
                insertModel.InsertCardType(item);
                // Redirect to CardType Table after successful update.
                Response.Redirect("CardManagement.aspx");
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
                CardType item = new CardType
                {
                    Id = Convert.ToInt32(cId.Text),
                    Name = editName.Text,
                    Status = Convert.ToBoolean(ddStatus.SelectedValue),
                    LowerBound = Convert.ToDouble(editBound.Text),
                    PercentDiscount = Convert.ToDouble(editPercent.Text),
                    UpdateBy = emId
                };
                updateModel.UpdateCardType(item);
                Response.Redirect("CardManagement.aspx");
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
            var item = listModel.ListCardType(id);

            // Bind values into popup
            cId.Text = id.ToString();
            editName.Text = item.ElementAt(0).Name;
            editBound.Text = item.ElementAt(0).LowerBound.ToString();
            editPercent.Text = item.ElementAt(0).PercentDiscount.ToString();

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