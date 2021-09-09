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
using System.Text;

namespace DB_ex1.EditForms
{
    public partial class ImportOrderEdit : System.Web.UI.Page
    {
        private const string Url = "/Management/ImportManagement.aspx";
        private static int infoId;
        static DB_ex1_Context context = new DB_ex1_Context();
        static DbContextTransaction transaction;
        private static bool first = true;
        private static int deleteId = 0;

        static ListModel listModel = new ListModel();
        InsertModel insertModel = new InsertModel();
        UpdateModel updateModel = new UpdateModel();
        CheckModel checkModel = new CheckModel();
        DeleteModel deleteModel = new DeleteModel();
        BindModel bindModel = new BindModel();
        static List<Import_Goods> listGoods;
        static List<Import_Info> listInfo;
        // List all instance
        static List<Supplier> suppliers = listModel.ListSupplier(0);
        static List<Good> goods = listModel.ListGood(0, "");
        protected void Page_Load(object sender, EventArgs e)
        {
            infoId = Convert.ToInt32(Request.QueryString["Id"].ToString());

            
            if (!IsPostBack)
            {
                if (first == true)
                {
                    transaction = context.Database.BeginTransaction();
                    first = false;
                }
                listGoods = listModel.ListImportGoods(infoId, context);
                listInfo = listModel.ListImportInfo(infoId, context);
                listInfo.ElementAt(0).UpdateBy = "";
                BindInfo();
                bindModel.BindStatus(ddPaymentStatus, "Fully paid", "Not paid", listInfo.ElementAt(0).PaymentStatus);
                bindModel.BindGoods(listGoods,gv);
                bindModel.BindFooterRow(gv);
            }
        }
        // -------------- Button handle --------------
        public void btnPrint_Click(object sender, EventArgs e)
        {

        }
        public void btnDelete_Click(object sender, EventArgs e)
        {
            // Get id of the delete item
            int id = listGoods.ElementAt(deleteId).Id;

            listGoods.RemoveAt(deleteId);

            deleteModel.DeleteImport(id, context);
            UpdateInfo();
        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            string emId = updateBy.Text.ToUpper();
            if (checkModel.CheckCharID(emId) == true)
            {
                idErr.Text = null;
                UpdateInfo();
                if (transaction.UnderlyingTransaction.Connection != null)
                {
                    transaction.Commit();
                }
                Response.Redirect(Url);
            }
            else
            {
                idErr.Text = "Invalid ID";
            }
        }
        public void btnCancel_Click(object sender, EventArgs e)
        {
            transaction.Dispose();
            Response.Redirect(Url);
        }
        // -------------- Link Button handle --------------
        public void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            idErr.Text = null;
            gv.EditIndex = e.NewEditIndex;

            bindModel.BindGoods(listGoods,gv); // Bind Goods list first so that FindControl() could work

            // Load goods into DropDownList on selected row
            DropDownList dd = gv.Rows[gv.EditIndex].FindControl("ddGoods") as DropDownList;
            string selected = listGoods.ElementAt(gv.EditIndex).GoodsName;
            bindModel.BindInstance(goods, dd, selected, 0); // Random value for good's selected id
            bindModel.BindFooterRow(gv); // Rebind footer row
        }
        public void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string emId = updateBy.Text.ToUpper();
            if (checkModel.CheckCharID(emId) == true)
            {
                idErr.Text = null;
                deleteId = e.RowIndex; // index start with 0
                StringBuilder builder = new StringBuilder();
                builder.Append("<script language=JavaScript> ShowPopup(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopup", builder.ToString());
            }
            else
            {
                idErr.Text = "Invalid ID";
            }
        }
        public void OnUpdate(object sender, EventArgs e)
        {
            string emId = updateBy.Text.ToUpper();
            if (checkModel.CheckCharID(emId) == true)
            {
                idErr.Text = null;
                // Get updated elements
                GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
                DropDownList dd = (DropDownList)row.FindControl("ddGoods");

                TextBox text = row.FindControl("qty") as TextBox;
                TextBox text2 = row.FindControl("price") as TextBox;
                TextBox text3 = row.FindControl("discount") as TextBox;
                int rowId = row.RowIndex;

                // Teporary variable
                string name = dd.SelectedItem.Text;
                int qty = Convert.ToInt32(text.Text);
                double price = Convert.ToDouble(text2.Text);
                double dis = Convert.ToDouble(text3.Text);
                double tot = (double)(qty * (price - dis));
                int id = listGoods.ElementAt(rowId).Id;

               

                // Derive other elements from updated elements
                List<Good> good = listModel.ListGood(0, name);
                listGoods.ElementAt(rowId).Barcode = good.ElementAt(0).Barcode;

                listGoods.ElementAt(rowId).GoodsName = name;
                listGoods.ElementAt(rowId).Quantity = qty;
                listGoods.ElementAt(rowId).Price = price;
                listGoods.ElementAt(rowId).Discount = dis;
                listGoods.ElementAt(rowId).TotalPrice = tot;

                Import_Goods item = new Import_Goods
                {
                    GoodsName = name,
                    Quantity = qty,

                    // Derive other elements from updated elements
                    Id = id,
                    Price = price,
                    Discount = dis,
                    TotalPrice = tot,
                };

                // Save edited good to the Transaction DB
                updateModel.UpdateImportGood(item, context);

                // -----Done with goods list, below is update of Import info-----
                UpdateInfo();

            }
            else
            {
                idErr.Text = "Invalid ID";
            }

        }
        public void OnAdd(object sender, EventArgs e)
        {
            string emId = updateBy.Text.ToUpper();
            if (checkModel.CheckCharID(emId) == true)
            {
                idErr.Text = null;
                // Get info from footer
                DropDownList dd = gv.FooterRow.FindControl("ddGoodsNew") as DropDownList;
                TextBox text = gv.FooterRow.FindControl("qtyNew") as TextBox;
                TextBox text2 = gv.FooterRow.FindControl("priceNew") as TextBox;
                TextBox text3 = gv.FooterRow.FindControl("discountNew") as TextBox;

                // Teporary variable
                string name = dd.SelectedItem.Text;
                int qty = Convert.ToInt32(text.Text);
                double price = Convert.ToDouble(text2.Text);
                double dis = Convert.ToDouble(text3.Text);
                double tot = (double)(qty * (price - dis));

                List<Good> good = listModel.ListGood(0, name);
                Import_Goods item = new Import_Goods
                {
                    GoodsName = name,
                    Quantity = qty,

                    // Derive other elements from updated elements
                    Barcode = good.ElementAt(0).Barcode,
                    Price = price,
                    Discount = dis,
                    TotalPrice = tot,
                    ImportInfoId = infoId
                };

                // Save new info database and listGoods
                item.Id = insertModel.InsertImportGood(item, context);
                listGoods.Add(item);

                // -----Done with goods list, below is update of Import info-----
                UpdateInfo();
            }
            else
            {
                idErr.Text = "Invalid ID";
            }
        }
        public void OnCancel(object sender, EventArgs e)
        {
            gv.EditIndex = -1;
            bindModel.BindGoods(listGoods,gv);
            bindModel.BindFooterRow(gv); // Rebind footer row
        }
        // -------------- Function handle --------------
        public void UpdateInfo()
        {
            // Use for loop to calculate total price from all the goods in the list
            double sum = 0;
            for (int i = 0; i < listGoods.Count(); i++)
            {
                sum += (double)listGoods.ElementAt(i).TotalPrice;
            }
            // Temporary variables
            double dis = Convert.ToDouble(otherDiscount.Text);
            string type = paymentType.Text;
            bool status = Convert.ToBoolean(ddPaymentStatus.SelectedValue);
            int id = Convert.ToInt32(ddSupplier.SelectedValue);
            string name = ddSupplier.SelectedItem.Text;
            string by = updateBy.Text;
            sum -= dis;

            // Update list
            listInfo.ElementAt(0).Total = sum;
            listInfo.ElementAt(0).OtherDiscount = dis;
            listInfo.ElementAt(0).PaymentType = type;
            listInfo.ElementAt(0).PaymentStatus = status;
            listInfo.ElementAt(0).SupplierId = id;
            listInfo.ElementAt(0).SupplierName = name;
            listInfo.ElementAt(0).UpdateBy = by;

            // Update to Transaction DB
            Import_Info info = new Import_Info
            {
                Id = infoId,
                SupplierId = id,
                SupplierName = name,
                PaymentType = type,
                PaymentStatus = status,
                OtherDiscount = dis,
                Total = sum,
                CreateBy = "",
                UpdateBy = by
            };

            updateModel.UpdateImportInfo(info, context);

            // Bind all the info and return the pointer
            gv.EditIndex = -1;
            BindInfo();
            bindModel.BindGoods(listGoods,gv);
            bindModel.BindFooterRow(gv);
        }
        protected void BindInfo()
        {
            // Load other info in the ImportInfo portion
            IoId.Text = listInfo.ElementAt(0).Id.ToString();
            total.Text = listInfo.ElementAt(0).Total.ToString();
            paymentType.Text = listInfo.ElementAt(0).PaymentType;
            otherDiscount.Text = listInfo.ElementAt(0).OtherDiscount.ToString();
            updateBy.Text = listInfo.ElementAt(0).UpdateBy;

            var item = listModel.ListSupplier(listInfo.ElementAt(0).SupplierId);
            address.Text = item.ElementAt(0).Address;
            phone.Text = item.ElementAt(0).PhoneNumber;

            bindModel.BindInstance(suppliers,ddSupplier, listInfo.ElementAt(0).SupplierName, listInfo.ElementAt(0).SupplierId);
        }
    }
}