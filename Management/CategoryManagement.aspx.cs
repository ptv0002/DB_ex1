using DB_Models;
using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_ex1.Management
{
    public partial class CategoryManagement : System.Web.UI.Page
    {
        private int catId = 0;
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
            ListModel model = new ListModel();
            List<Category> list = model.ListAll_Category();
            if (list != null)
            {
                gvCategory.DataSource = list;
                gvCategory.DataBind();
            }

            List<Employee> employees = model.ListAll_Employee();
            if (employees != null)
            {
                ddCreateBy.DataSource = employees;
                ddCreateBy.DataTextField = "FullName";
                ddCreateBy.DataBind();
                ddCreateBy.Items.Insert(0, new ListItem("-Select-", "0"));
            }
        }
        protected void btnSave_Add(object sender, EventArgs e)
        {
            InsertModel model = new InsertModel();
            Category category = new Category();

            // Get info and pass into a Category object before passing into InsertCategory method
            category.CategoryName = addCatName.Text;
            category.CreateBy = ddCreateBy.SelectedItem.Text;
            model.InsertCategory(category);
            // Redirect to Category Table after successful update.
            Response.Redirect("/Management/CategoryManagement.aspx");
        }
        protected void btnSave_Edit(object sender, EventArgs e)
        {
            Response.Redirect("/Management/EmployeeManagement.aspx");
        }

        protected void Edit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(sender as LinkButton).NamingContainer;
            //catId = row.RowIndex + 1;
                //catId = Convert.ToInt32(Request.QueryString["categoryId"].ToString());
                //Button btndetails = (Button)e.CommandSource;
                //GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                //cId.Text = gvCategory.DataKeys[gvrow.RowIndex].Value.ToString();
                //// DataRow dr = dt.Select("CustomerID=" + GridViewData.DataKeys[gvrow.RowIndex].Value.ToString())[0];
                //editCatName.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
                //editStatus.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
            // Bind Categories for edit popup
            ListModel model = new ListModel();
            List<Category> lstCategory = model.ListSingle_Category(catId,null);
            // Display the employee's info into the textboxes 
            //cId.Text = catId.ToString();
            editCatName.Text = lstCategory.ElementAt(0).CategoryName;
            ddStatus.SelectedItem.Text = lstCategory.ElementAt(0).CategoryStatus.ToString();
        }

    }
}