using DB_Models;
using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_ex1.EditForms
{
    public partial class ExportOrderEdit : System.Web.UI.Page
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
            exInfoId = Convert.ToInt32(Request.QueryString["Id"].ToString());

            if (load == 0)
            {
                transaction = context.Database.BeginTransaction();
                load++;
            }

            lstExportGoods = model.ListExportGoods(exInfoId, context);
            lstExportInfo = model.ListSingle_ExportInfo(exInfoId, context);
            lstExportInfo.ElementAt(0).UpdateBy = "";

            if (!IsPostBack)
            {
                BindExportInfo(lstExportInfo);
                BindStatus(ddPaymentStatus, "Fully paid", "Not paid", lstExportInfo.ElementAt(0).PaymentStatus);
                BindGoods(lstExportGoods);
                BindFooterRow();
            }
        }
        protected void BindExportInfo(List<Export_Info> list)
        {
            // Load other info in the ExportInfo portion
            EoId.Text = list.ElementAt(0).Id.ToString();
            totalExport.Text = list.ElementAt(0).TotalExport.ToString();
            paymentType.Text = list.ElementAt(0).PaymentType;

            // Load Customer's name to dropdown
            List<Customer> lstCustomer = model.ListAll_Customer();
            if (lstCustomer != null)
            {
                ddCustomer.DataSource = lstCustomer;
                ddCustomer.DataTextField = "FullName";
                ddCustomer.DataBind();
                ddCustomer.Items.Insert(0, list.ElementAt(0).CustomerFullName);
            }
            // Load Employee's name to UpdateBy dropdown
            List<Employee> lstEmployee = model.ListAll_Employee();
            if (lstEmployee != null)
            {
                ddUpdateBy.DataSource = lstEmployee;
                ddUpdateBy.DataTextField = "FullName";
                ddUpdateBy.DataBind();
                if (list.ElementAt(0).UpdateBy == "")
                {
                    ddUpdateBy.Items.Insert(0, "-Select-");
                }
                else
                {
                    ddUpdateBy.Items.Insert(0, list.ElementAt(0).UpdateBy);
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
        public void BindGoods(List<Export_Goods> list)
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