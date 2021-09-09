using System.Threading.Tasks;
using DB_Models;
using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Models
{
    public class BindModel
    {   
        ListModel listModel = new ListModel();
        public void BindInstance<T>(IEnumerable<T> list, DropDownList dd, string text, int value)
        {
            if (list != null)
            {
                dd.DataSource = list;
                dd.DataTextField = "Name";
                dd.DataValueField = "Id";
                dd.DataBind();
                if (text == "")
                {
                    dd.Items.Insert(0, "-Select-");
                }
                else
                {
                    dd.Items.Insert(0, new ListItem(text, value.ToString()));
                }
            }
        }
        public void BindStatus(DropDownList dd, string trueText, string falseText, bool status)
        {
            string text;
            string value;
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
        public void BindGoods<T>(IEnumerable<T> list, GridView gv)
        {
            gv.DataSource = list;
            gv.DataBind();

            if (list != null)
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    Label label = (Label)gv.Rows[i].FindControl("labelId");
                    label.Text = (i + 1).ToString();
                }
            }

        }
        public void BindFooterRow(GridView gridView)
        {
            // Load goods into DropDownList on footer row
            DropDownList dd = gridView.FooterRow.FindControl("ddGoodsNew") as DropDownList;
            List<Good> list = listModel.ListGood(0, "");
            BindInstance(list, dd, "", 0);
        }
        
    }
}
