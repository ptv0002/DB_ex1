using DB_Models;
using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Entity;

namespace DB_ex1.EditForms
{
    public partial class ImportOrderEdit : System.Web.UI.Page
    {
        private static int imInfoId;
        static DB_ex1_Context context = new DB_ex1_Context();
        static DbContextTransaction transaction;
        private static int load;

        static ListModel model = new ListModel();
        static List<Import_Goods> lstImportGoods;
        static List<Import_Info> lstImportInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            imInfoId = Convert.ToInt32(Request.QueryString["Id"].ToString());

            if (load == 0)
            {
                transaction = context.Database.BeginTransaction();
                load++;
            }

            lstImportGoods = model.ListImportGoods(imInfoId, context);
            lstImportInfo = model.ListSingle_ImportInfo(imInfoId, context);

            if (!IsPostBack)
            {
                BindImportInfo(lstImportInfo);
                BindGoods(lstImportGoods);
                BindFooterRow();
            }
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
                dd.Items.Insert(0, new ListItem(selected, selected));

            }
        }

        protected void BindImportInfo(List<Import_Info> list)
        {
            // Load other info in the ImportInfo portion
            IoId.Text = list.ElementAt(0).Id.ToString();
            totalImport.Text = list.ElementAt(0).TotalImport.ToString();
            paymentType.Text = list.ElementAt(0).PaymentType;

            BindStatus(ddPaymentStatus, "Fully paid", "Not paid", list.ElementAt(0).PaymentStatus);

            // Load Supplier's name to dropdown
            //ListModel model = new ListModel();
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
                if (list.ElementAt(0).UpdateBy == "")
                {
                    ddUpdateBy.Items.Insert(0, new ListItem("-Select-", "0"));
                }
                else
                {
                    ddUpdateBy.Items.Insert(0, new ListItem(list.ElementAt(0).UpdateBy, "0"));
                }

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
            gv_importGoods.EditIndex = e.NewEditIndex;
            
            BindGoods(lstImportGoods); // Bind Goods list first so that FindControl() could work

            // Load goods into DropDownList on selected row
            DropDownList dd = gv_importGoods.Rows[gv_importGoods.EditIndex].FindControl("ddGoods") as DropDownList;
            string selected = lstImportGoods.ElementAt(gv_importGoods.EditIndex).GoodsName;
            LoadDropdownGood(dd, selected);
            BindFooterRow(); // Rebind footer row
        }
        public void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowId = e.RowIndex; // index start with 0
            // Save new info database and listGoods
            
            int deleteId = lstImportGoods.ElementAt(rowId).Id;

            lstImportGoods.RemoveAt(rowId);

            DeleteModel deleteModel = new DeleteModel();
            deleteModel.DeleteImport(deleteId, context);
            UpdateInfo(lstImportGoods);

        }
        public void OnUpdate(object sender, EventArgs e)
        {
            // Get updated elements
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            DropDownList dd = (DropDownList)row.FindControl("ddGoods");
            string name = dd.SelectedItem.Text;

            TextBox text = row.FindControl("qty") as TextBox;
            int qty = Convert.ToInt32(text.Text);

            TextBox text2 = row.FindControl("price") as TextBox;
            double price = Convert.ToDouble(text2.Text);

            int rowId = row.RowIndex;

            lstImportGoods.ElementAt(rowId).GoodsName = name;
            lstImportGoods.ElementAt(rowId).imQuantity = qty;

            // Derive other elements from updated elements
            ListModel listModel = new ListModel();
            List<Good> good = listModel.ListSingle_Good(0,name);

            lstImportGoods.ElementAt(rowId).Barcode = good.ElementAt(0).GoodsCode;
            lstImportGoods.ElementAt(rowId).Price = price;
            lstImportGoods.ElementAt(rowId).TotalPrice = (double)(qty * price);

            Import_Goods imGood = new Import_Goods
            {
                GoodsName = name,
                imQuantity = qty,

                // Derive other elements from updated elements
                Id = rowId + 1,
                Price = price,
                TotalPrice = (double)(qty * price),
            };
            
            
            // Save edited good to the Transaction DB
            UpdateModel updateModel = new UpdateModel();
            updateModel.UpdateImportGood(imGood,context);

            // -----Done with goods list, below is update of Import info-----
            UpdateInfo(lstImportGoods);
            
        }
        public void OnAdd(object sender, EventArgs e)
        {
            // Get info from footer
            DropDownList dd = gv_importGoods.FooterRow.FindControl("ddGoodsNew") as DropDownList;
            string name = dd.SelectedItem.Text;
            if (name != "-Select-")
            {
                TextBox text = gv_importGoods.FooterRow.FindControl("qtyNew") as TextBox;
                int qty = Convert.ToInt32(text.Text);

                TextBox text2 = gv_importGoods.FooterRow.FindControl("priceNew") as TextBox;
                double price = Convert.ToDouble(text2.Text);

                List<Good> good = model.ListSingle_Good(0, name);
                Import_Goods imGood = new Import_Goods
                {
                    GoodsName = name,
                    imQuantity = qty,

                    // Derive other elements from updated elements
                    Id = lstImportGoods.Count() + 1,
                    Barcode = good.ElementAt(0).GoodsCode,
                    Price = price,
                    TotalPrice = (double)(qty * price),
                    ImportInfoId = imInfoId
                };

                // Save new info database and listGoods
                InsertModel insertModel = new InsertModel();
                insertModel.InsertImportGood(imGood,context);
                lstImportGoods.Add(imGood);

                // -----Done with goods list, below is update of Import info-----
                UpdateInfo(lstImportGoods);
            }
            else
            {
                Label label = gv_importGoods.FooterRow.FindControl("ddNewErr") as Label;
                label.Text = "This field is required";
                label.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void OnCancel(object sender, EventArgs e)
        {
            //List<Import_Goods> listGoods = (List<Import_Goods>)Session["CurrentGoods"];

            gv_importGoods.EditIndex = -1;
            BindGoods(lstImportGoods);
            BindFooterRow(); // Rebind footer row
        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            if (ddUpdateBy.SelectedItem.Text != "-Select-")
            {
                context.SaveChanges();
                if (transaction.UnderlyingTransaction.Connection != null)
                {
                    transaction.Commit();
                }
                Response.Redirect("/Management/ImportManagement.aspx");
            }
            else
            {
                ddError.Text = "This field is required";
                ddError.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void btnCancel_Click(object sender, EventArgs e)
        {
            if (transaction.UnderlyingTransaction.Connection != null)
            {
                transaction.Dispose();
            }
            Response.Redirect("/Management/ImportManagement.aspx");
        }
        public void UpdateInfo(List<Import_Goods> listGoods)
        {
            // Use for loop to calculate total price from all the goods in the list
            double sum = 0;
            for (int i = 0; i < listGoods.Count(); i++)
            {
                sum += (double)listGoods.ElementAt(i).TotalPrice;
            }
            // Update total amount import
            lstImportInfo.ElementAt(0).TotalImport = sum;

            // Update other info in Import_Info portion
            lstImportInfo.ElementAt(0).PaymentType = paymentType.Text;
            lstImportInfo.ElementAt(0).PaymentStatus = Convert.ToBoolean(ddPaymentStatus.SelectedValue);
            lstImportInfo.ElementAt(0).SupplierName = ddSupplier.SelectedItem.Text;
            if (ddUpdateBy.SelectedItem.Text != "-Select-")
            {
                lstImportInfo.ElementAt(0).UpdateBy = ddUpdateBy.SelectedItem.Text;
            }
            else
            {
                lstImportInfo.ElementAt(0).UpdateBy = "";
            }

            // Update to Transaction DB
            Import_Info info = new Import_Info
            {
                Id = imInfoId,
                SupplierName = ddSupplier.SelectedItem.Text,
                PaymentType = paymentType.Text,
                PaymentStatus = Convert.ToBoolean(ddPaymentStatus.SelectedValue),
                TotalImport = sum,
                UpdateBy = lstImportInfo.ElementAt(0).UpdateBy
            };

            UpdateModel model = new UpdateModel();
            model.UpdateImportInfo(info, context);

            // Bind all the info and return the pointer
            gv_importGoods.EditIndex = -1;
            BindImportInfo(lstImportInfo);
            BindGoods(listGoods);
            BindFooterRow();
        }

    }
}