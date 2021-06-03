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
    public partial class ImportOrderAdd : System.Web.UI.Page
    {
        private static int imInfoId;
        static DB_ex1_Context context = new DB_ex1_Context();
        static DbContextTransaction transaction;
        private static int load = 0;

        static ListModel model = new ListModel();
        static List<Import_Goods> lstImportGoods = new List<Import_Goods>();
        static List<Import_Info> lstImportInfo = new List<Import_Info>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (lstImportInfo.Count == 0)
                //{
                //    BindNewPage();
                //}
                //else
                //{
                // Only list import info after the first insert
                // ------------ ERROR ------------ 
                // If Add form is accessed twice without finishing the form 1st time, error for not reset LOAD == 1
                lstImportGoods = model.ListImportGoods(imInfoId, context);
                lstImportInfo = model.ListSingle_ImportInfo(imInfoId, context);
                if (lstImportInfo.Count == 0)
                {
                    transaction = context.Database.BeginTransaction();
                    BindGoods(lstImportGoods);
                    BindSupplierEmployee("", "");
                    BindStatus(ddPaymentStatus, "Fully paid", "Not paid", false);
                    // Bind empty footer row
                    DropDownList dd = gv.Controls[0].Controls[0].FindControl("ddGoodsEmpty") as DropDownList;
                    LoadDropdownGood(dd, "-Select-");
                }
                else
                {
                    lstImportInfo.ElementAt(0).CreateBy = "";
                    BindImportInfo(lstImportInfo);
                    BindStatus(ddPaymentStatus, "Fully paid", "Not paid", lstImportInfo.ElementAt(0).PaymentStatus);
                    BindGoods(lstImportGoods);
                    BindFooterRow();
                }


            }
        }
        public void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gv.EditIndex = e.NewEditIndex;

            BindGoods(lstImportGoods); // Bind Goods list first so that FindControl() could work

            // Load goods into DropDownList on selected row
            DropDownList dd = gv.Rows[gv.EditIndex].FindControl("ddGoods") as DropDownList;
            string selected = lstImportGoods.ElementAt(gv.EditIndex).GoodsName;
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
            List<Good> good = listModel.ListSingle_Good(0, name);

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
            updateModel.UpdateImportGood(imGood, context);

            // -----Done with goods list, below is update of Import info-----
            UpdateInfo(lstImportGoods);
        }
        public void OnAdd_Empty(object sender, EventArgs e)
        {
            // Insert Import Info for the first page load
            Import_Info item = new Import_Info
            {
                SupplierName = ddSupplier.SelectedItem.Text,
                TotalImport = 0,
                PaymentStatus = Convert.ToBoolean(ddPaymentStatus.SelectedValue),
                PaymentType = paymentType.Text,
                CreateBy = ddCreateBy.SelectedItem.Text
            };
            lstImportInfo.Add(item);
            InsertModel insert = new InsertModel();
            imInfoId = insert.InsertImportInfo(item, context);
            load++;

            // Get info from the Empty Data Template
            DropDownList dd = gv.Controls[0].Controls[0].FindControl("ddGoodsEmpty") as DropDownList;
            string name = dd.SelectedItem.Text;
            TextBox text = gv.Controls[0].Controls[0].FindControl("qtyEmpty") as TextBox;
            int qty = Convert.ToInt32(text.Text);
            TextBox text2 = gv.Controls[0].Controls[0].FindControl("priceEmpty") as TextBox;
            double price = Convert.ToDouble(text2.Text);

            OnAdd_Share(name, qty, price);
        }
        public void OnAdd(object sender, EventArgs e)
        {
            // Get info from footer
            DropDownList dd = gv.FooterRow.FindControl("ddGoodsNew") as DropDownList;
            string name = dd.SelectedItem.Text;
            TextBox text = gv.FooterRow.FindControl("qtyNew") as TextBox;
            int qty = Convert.ToInt32(text.Text);

            TextBox text2 = gv.FooterRow.FindControl("priceNew") as TextBox;
            double price = Convert.ToDouble(text2.Text);

            OnAdd_Share(name, qty, price);
        }
        public void OnAdd_Share(string name, int qty, double price)
        {
            // Get good's info from good's name
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
            insertModel.InsertImportGood(imGood, context);
            lstImportGoods.Add(imGood);

            // -----Done with goods list, below is update of Import info-----
            UpdateInfo(lstImportGoods);
        }
        public void OnCancel(object sender, EventArgs e)
        {
            gv.EditIndex = -1;
            BindGoods(lstImportGoods);
            BindFooterRow(); // Rebind footer row
        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            UpdateInfo(lstImportGoods);
            context.SaveChanges();
            if (transaction.UnderlyingTransaction.Connection != null)
            {
                transaction.Commit();
            }
            Response.Redirect("/Management/ImportManagement.aspx");
        }
        public void btnCancel_Click(object sender, EventArgs e)
        {
            transaction.Dispose();
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
            if (ddCreateBy.SelectedItem.Text != "-Select-")
            {
                lstImportInfo.ElementAt(0).CreateBy = ddCreateBy.SelectedItem.Text;
            }
            else
            {
                lstImportInfo.ElementAt(0).CreateBy = "";
            }

            // Update to Transaction DB
            Import_Info info = new Import_Info
            {
                Id = imInfoId,
                SupplierName = ddSupplier.SelectedItem.Text,
                PaymentType = paymentType.Text,
                PaymentStatus = Convert.ToBoolean(ddPaymentStatus.SelectedValue),
                TotalImport = sum,
                CreateBy = lstImportInfo.ElementAt(0).CreateBy,
                UpdateBy = ""
            };

            UpdateModel model = new UpdateModel();
            model.UpdateImportInfo(info, context);

            // Bind all the info and return the pointer
            gv.EditIndex = -1;
            BindImportInfo(lstImportInfo);
            BindGoods(listGoods);
            BindFooterRow();
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
        protected void BindImportInfo(List<Import_Info> list)
        {
            // Load other info in the ImportInfo portion
            IoId.Text = list.ElementAt(0).Id.ToString();
            totalImport.Text = list.ElementAt(0).TotalImport.ToString();
            paymentType.Text = list.ElementAt(0).PaymentType;

            // Load Supplier's name to dropdown
            List<Supplier> lstSupplier = model.ListAll_Supplier();
            if (lstSupplier != null)
            {
                ddSupplier.DataSource = lstSupplier;
                ddSupplier.DataTextField = "supplierName";
                ddSupplier.DataBind();
                ddSupplier.Items.Insert(0, list.ElementAt(0).SupplierName);
            }
            // Load Employee's name to CreateBy dropdown
            List<Employee> lstEmployee = model.ListAll_Employee();
            if (lstEmployee != null)
            {
                ddCreateBy.DataSource = lstEmployee;
                ddCreateBy.DataTextField = "FullName";
                ddCreateBy.DataBind();
                if (list.ElementAt(0).CreateBy == "")
                {
                    ddCreateBy.Items.Insert(0, "-Select-");
                }
                else
                {
                    ddCreateBy.Items.Insert(0, list.ElementAt(0).CreateBy);
                }

            }
        }
        public void BindGoods(List<Import_Goods> list)
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
        protected void BindSupplierEmployee(string supplierName, string employeeName)
        {
            // Load Supplier's name to dropdown
            List<Supplier> lstSupplier = model.ListAll_Supplier();
            if (lstSupplier != null)
            {
                ddSupplier.DataSource = lstSupplier;
                ddSupplier.DataTextField = "supplierName";
                ddSupplier.DataBind();
                if (supplierName == "")
                {
                    ddSupplier.Items.Insert(0, "-Select-");
                }
                else
                {
                    ddSupplier.Items.Insert(0, supplierName);
                }
            }
            // Load Employee's name to By dropdown
            List<Employee> lstEmployee = model.ListAll_Employee();
            if (lstEmployee != null)
            {
                ddCreateBy.DataSource = lstEmployee;
                ddCreateBy.DataTextField = "FullName";
                ddCreateBy.DataBind();
                if (employeeName == "")
                {
                    ddCreateBy.Items.Insert(0, "-Select-");
                }
                else
                {
                    ddCreateBy.Items.Insert(0, employeeName);
                }

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