using DB_Models;
using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_ex1
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

        public void LoadGridEmployee()
        {
            EmployeeModel emplyeeModel = new EmployeeModel();
            List<Employee> lstEmployee = emplyeeModel.ListAll();
            if(lstEmployee != null)
            {
                gvEmployee.DataSource = lstEmployee;
                gvEmployee.DataBind();
            }
        }
    }
}