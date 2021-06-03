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
    public partial class EmployeeManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridEmployee();
            }
        }

        protected void LoadGridEmployee()
        {
            ListModel model = new ListModel();
            List<Employee> list = model.ListAll_Employee();
            if(list != null)
            {
                gv.DataSource = list;
                gv.DataBind();
            }
        }
    }
}