using DB_Models;
using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_ex1.Management
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
            ListModel model = new ListModel();
            List<Good> list = model.ListGood(0, ""); // List all Goods
            if (list != null)
            {
                gv.DataSource = list;
                gv.DataBind();
            }
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for ( int i = 0; i < gv.Rows.Count; i++)
            {
                int min = Convert.ToInt32(gv.Rows[i].Cells[6].Text);
                int qty = Convert.ToInt32(gv.Rows[i].Cells[7].Text);
                if (min >= qty)
                {
                    gv.Rows[i].BackColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}