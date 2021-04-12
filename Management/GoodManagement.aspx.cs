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
    public partial class GoodManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridGood();
            }
        }
        protected void LoadGridGood()
        {
            GoodModel goodModel = new GoodModel();
            List<Good> lstGood = goodModel.ListAll();
            if (lstGood != null)
            {
                gvGood.DataSource = lstGood;
                gvGood.DataBind();
            }
        }
    }
}