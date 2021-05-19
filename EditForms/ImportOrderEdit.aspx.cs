using DB_Models;
using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DB_ex1.EditForms
{
    public partial class ImportOrderEdit : System.Web.UI.Page
    {
        private int imInfoId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            imInfoId = Convert.ToInt32(Request.QueryString["id"].ToString());
            
            
            // Use Session for temporary saves
            ListModel model = new ListModel();
            List<Import_Goods> lstImportGoods = model.ListImportGoods(imInfoId);
            
            Session["CurrentGoods"] = lstImportGoods;

            List<Import_Info> lstImportInfo = model.ListSingle_ImportInfo(imInfoId);
            Session["CurrentInfo"] = lstImportInfo;

            if (!IsPostBack)
            {
                BindImportInfo(lstImportInfo);
                BindGoods(lstImportGoods);
                BindFooterRow();
            }
        }
        protected void LoadDropdownGood(DropDownList dd, string selected)
        {
            ListModel model = new ListModel();
            List<Good> list = model.ListAll_Goods();
            if (list != null)
            {
                dd.DataSource = list;
                dd.DataTextField = "goodsName";
                dd.DataBind();
                dd.Items.Insert(0, new ListItem(selected, selected));

            }
        }

        protected void BindImportInfo(List<Import_Info> list)
        {
            // Load other info in the ImportInfo portion
            IoId.Text = list.ElementAt(0).id.ToString();
            totalImport.Text = list.ElementAt(0).TotalImport.ToString();
            paymentType.Text = list.ElementAt(0).PaymentType;

            BindStatus(ddPaymentStatus, "Fully paid", "Not paid", list.ElementAt(0).PaymentStatus);

            // Load Supplier's name to dropdown
            ListModel model = new ListModel();
            List<Supplier> lstSupplier = model.ListAll_Supplier();
            if (lstSupplier != null)
            {
                ddSupplier.DataSource = lstSupplier;
                ddSupplier.DataTextField = "supplierName";
                ddSupplier.DataBind();
                ddSupplier.Items.Insert(0, new ListItem(list.ElementAt(0).SupplierName, "0"));
            }
            // Load Employee's name to UpdateBy dropdown
            List<Employee> lstEmployee = model.ListAll_Employee();
            if (lstEmployee != null)
            {
                ddUpdateBy.DataSource = lstEmployee;
                ddUpdateBy.DataTextField = "FullName";
                ddUpdateBy.DataBind();
            }
        }
        public void BindStatus(DropDownList dd, string trueText, string falseText, bool status)
        {
            string text;
            string value;
            // Load PaymentStatus
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
                gv_importGoods.DataSource = list;
                gv_importGoods.DataBind();
            }
            for (int i = 0; i < list.Count(); i++)
            {
                Label label = (Label)gv_importGoods.Rows[i].FindControl("labelId");
                label.Text = (i+1).ToString();
            }
        }
        public void BindFooterRow()
        {
            // Load goods into DropDownList on footer row
            DropDownList dd = gv_importGoods.FooterRow.FindControl("ddGoodsNew") as DropDownList;
            LoadDropdownGood(dd, "-Select-");
        }
        public void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            // ------------Error: Kept reloading data from database, not from previous state------------
            gv_importGoods.EditIndex = e.NewEditIndex;
            // Convert Session back to list and Bind Goods' info
            
            List<Import_Goods> list = (List<Import_Goods>) (Session["CurrentGoods"]);
            BindGoods(list); // Bind Goods list first so that FindControl() could work

            // Load goods into DropDownList on selected row
            DropDownList dd = gv_importGoods.Rows[gv_importGoods.EditIndex].FindControl("ddGoods") as DropDownList;
            string selected = list.ElementAt(gv_importGoods.EditIndex).GoodsName;
            LoadDropdownGood(dd, selected);
            BindFooterRow(); // Rebind footer row
            
        }
        public void OnUpdate(object sender, EventArgs e)
        {
            // Get updated elements
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            DropDownList dd = (DropDownList)row.FindControl("ddGoods");
            string name = dd.SelectedItem.Text;
            TextBox text = row.FindControl("qty") as TextBox;
            int qty = Convert.ToInt32(text.Text);
            int rowId = row.RowIndex;
            // Get info from temporary table
            List<Import_Goods> listGoods = (List<Import_Goods>)(Session["CurrentGoods"]);

            listGoods.ElementAt(rowId).GoodsName = name;
            listGoods.ElementAt(rowId).imQuantity = qty;

            // Derive other elements from updated elements
            ListModel listModel = new ListModel();
            List<Good> good = listModel.ListSingle_Good(null,name);

            listGoods.ElementAt(rowId).Barcode = good.ElementAt(0).GoodsCode;
            listGoods.ElementAt(rowId).Price = (double)good.ElementAt(0).SalePrice;
            listGoods.ElementAt(rowId).TotalPrice = (double)(qty * good.ElementAt(0).SalePrice);

            Import_Goods imGood = new Import_Goods
            {
                GoodsName = name,
                imQuantity = qty,

                // Derive other elements from updated elements
                id = rowId + 1,
                Price = (double) good.ElementAt(0).SalePrice,
                TotalPrice = (double)(qty * good.ElementAt(0).SalePrice),
            };
            // Save edited good the DB
            UpdateModel updateModel = new UpdateModel();
            updateModel.UpdateImportGood(imGood);

            // Update back to the temporary Session list
            Session.Remove("CurrentGoods");
            Session["CurrentGoods"] = listGoods;

            // -----Done with goods list, below is update of Import info-----
            UpdateInfo(listGoods);
            
        }
        public void OnAdd(object sender, EventArgs e)
        {
            // Get info from footer
            DropDownList dd = gv_importGoods.FooterRow.FindControl("ddGoodsNew") as DropDownList;
            string name = dd.SelectedItem.Text;
            TextBox text = gv_importGoods.FooterRow.FindControl("qtyNew") as TextBox;
            int qty = Convert.ToInt32(text.Text);

            List<Import_Goods> listGoods = (List<Import_Goods>)Session["CurrentGoods"];

            // Get updated elements and put back in the Session list            
            ListModel listModel = new ListModel();
            List<Good> good = listModel.ListSingle_Good(null,name);
            Import_Goods imGood = new Import_Goods
            {
                GoodsName = name,
                imQuantity = qty,

                // Derive other elements from updated elements
                id = listGoods.Count() + 1,
                Barcode = good.ElementAt(0).GoodsCode,
                Price = (double)good.ElementAt(0).SalePrice,
                TotalPrice = (double)(qty * good.ElementAt(0).SalePrice),
                ImportInfoId = imInfoId
            };

            // Save new info database and listGoods
            InsertModel insertModel = new InsertModel();
            insertModel.InsertImportGood(imGood);
            listGoods.Add(imGood);

            // Update back to the temporary Session list
            Session.Remove("CurrentGoods");
            Session["CurrentGoods"] = listGoods;


            // -----Done with goods list, below is update of Import info-----
            UpdateInfo(listGoods);
        }
        public void OnCancel(object sender, EventArgs e)
        {
            List<Import_Goods> listGoods = (List<Import_Goods>)Session["CurrentGoods"];

            gv_importGoods.EditIndex = -1;
            BindGoods(listGoods);
            BindFooterRow(); // Rebind footer row
        }
        public void OnDelete(object sender, EventArgs e)
        {

        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            List<Import_Goods> listGoods = (List<Import_Goods>)Session["CurrentGoods"];
            UpdateInfo(listGoods);
            Response.Redirect("/Management/ImportManagement.aspx");
        }
        public void UpdateInfo(List<Import_Goods> listGoods)
        {
            List<Import_Info> listInfo = (List<Import_Info>)(Session["CurrentInfo"]);

            // Use for loop to calculate total price from all the goods in the list
            double sum = 0;
            for (int i = 0; i < listGoods.Count(); i++)
            {
                sum += (double)listGoods.ElementAt(i).TotalPrice;
            }
            // Update total amount import
            listInfo.ElementAt(0).TotalImport = sum;

            // Update other info in Import_Info portion
            listInfo.ElementAt(0).PaymentType = paymentType.Text;
            listInfo.ElementAt(0).PaymentStatus = Convert.ToBoolean(ddPaymentStatus.SelectedValue);
            listInfo.ElementAt(0).SupplierName = ddSupplier.SelectedItem.Text;
            listInfo.ElementAt(0).UpdateBy = ddUpdateBy.SelectedItem.Text;
            // Update back to the temporary Session list
            Session.Remove("CurrentInfo");
            Session["CurrentInfo"] = listInfo;
            // Update to DB


            // Bind all the info and return the pointer
            gv_importGoods.EditIndex = -1;
            BindImportInfo(listInfo);
            BindGoods(listGoods);
            BindFooterRow();
        }

    }
}