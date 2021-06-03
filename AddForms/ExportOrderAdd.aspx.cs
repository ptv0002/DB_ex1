using DB_Models;
using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_ex1.AddForms
{
    public partial class ExportOrderAdd : System.Web.UI.Page
    {
        private static int exInfoId;
        static DB_ex1_Context context = new DB_ex1_Context();
        static DbContextTransaction transaction;
        private static int load = 0;

        static ListModel model = new ListModel();
        static List<Export_Goods> lstExportGoods;
        static List<Export_Info> lstExportInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
        public void BindGoods(List<Import_Goods> list)
        {
            if (list != null)
            {
                gv.DataSource = list;
                gv.DataBind();
            }
            for (int i = 0; i < list.Count(); i++)
            {
                Label label = (Label)gv.Rows[i].FindControl("labelId");
                label.Text = (i + 1).ToString();
            }
        }
        public void BindFooterRow()
        {
            // Load goods into DropDownList on footer row
            DropDownList dd = gv.FooterRow.FindControl("ddGoodsNew") as DropDownList;
            LoadDropdownGood(dd, "-Select-");
        }
        protected void LoadDropdownGood(DropDownList dd, string selected)
        {
            //ListModel model = new ListModel();
            List<Good> list = model.ListAll_Goods();
            if (list != null)
            {
                dd.DataSource = list;
                dd.DataTextField = "goodsName";
                dd.DataBind();
                dd.Items.Insert(0, selected);

            }
        }
    }
}