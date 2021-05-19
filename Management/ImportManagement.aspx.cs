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
    public partial class ImportManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridImportOrder();
            }
        }
        protected void LoadGridImportOrder()
        {
            ListModel model = new ListModel();
            List<Import_Info> list = model.ListAll_ImportInfo();
            if (list != null)
            {
                gvImport.DataSource = list;
                gvImport.DataBind();
            }
        }
    }
}