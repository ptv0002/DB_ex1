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
    public partial class CustomerManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }
        protected void LoadGrid()
        {
            ListModel model = new ListModel();
            List<Customer> list = model.ListCustomer(0);
            if (list != null)
            {
                gv.DataSource = list;
                gv.DataBind();
            }
        }
    }
}