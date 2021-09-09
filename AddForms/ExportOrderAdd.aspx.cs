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

namespace DB_ex1.AddForms
{
    public partial class ExportOrderAdd : System.Web.UI.Page
    {
        private const string Url = "/Management/ExportManagement.aspx";
        private static int infoId;
        static DB_ex1_Context context = new DB_ex1_Context();
        static DbContextTransaction transaction;
        private static int deleteId = 0;

        static ListModel listModel = new ListModel();
        InsertModel insertModel = new InsertModel();
        UpdateModel updateModel = new UpdateModel();
        CheckModel checkModel = new CheckModel();
        DeleteModel deleteModel = new DeleteModel();
        BindModel bindModel = new BindModel();
        static List<Export_Goods> listGoods = new List<Export_Goods>();
        static List<Export_Info> listInfo = new List<Export_Info>();
        static List<Customer> person;
        // List all instance
        static List<Customer> Customers = listModel.ListCustomer(0);
        static List<Good> goods = listModel.ListGood(0, "");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Only list info after the first insert
                listGoods = listModel.ListExportGoods(infoId, context);
                listInfo = listModel.ListExportInfo(infoId, context);
                if (listInfo.Count == 0)
                {
                    transaction = context.Database.BeginTransaction();

                    bindModel.BindInstance(Customers, ddCustomer, "", 0);
                    bindModel.BindStatus(ddPaymentStatus, "Fully paid", "Not paid", false);
                   
                    // Bind empty footer row
                    bindModel.BindInstance(goods, ddGoodsEmpty, "", 0);
                }
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

            deleteModel.DeleteExport(id, context);
            UpdateInfo();
        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            string emId = createBy.Text.ToUpper();
            if (checkModel.CheckCharID(emId) == true)
            {
                idErr.Text = null;

                UpdateInfo();
                context.SaveChanges();
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

            bindModel.BindGoods(listGoods, gv); // Bind Goods list first so that FindControl() could work

            // Load goods into DropDownList on selected row
            DropDownList dd = gv.Rows[gv.EditIndex].FindControl("ddGoods") as DropDownList;
            string selected = listGoods.ElementAt(gv.EditIndex).GoodsName;
            bindModel.BindInstance(goods, dd, selected, 0); // Random value for good's selected id
            bindModel.BindFooterRow(gv); // Rebind footer row
        }
        public void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string emId = createBy.Text.ToUpper();
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
            string emId = createBy.Text.ToUpper();
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

                Export_Goods item = new Export_Goods
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
                updateModel.UpdateExportGood(item, context);

                // -----Done with goods list, below is update of Export info-----
                UpdateInfo();
            }
            else
            {
                idErr.Text = "Invalid ID";
            }
        }
        public void OnAdd_Empty(object sender, EventArgs e)
        {
            string emId = createBy.Text.ToUpper();
            if (checkModel.CheckCharID(emId) == true)
            {
                idErr.Text = null;
                // Get info from the Empty Data Template
                string name = ddGoodsEmpty.SelectedItem.Text;
                int qty = Convert.ToInt32(qtyEmpty.Text);

                // Get info from Info table
                int id = Convert.ToInt32(ddCustomer.SelectedValue);
                bool status = Convert.ToBoolean(ddPaymentStatus.SelectedValue);
                string type = paymentType.Text;
                double dis = Convert.ToDouble(otherDiscount.Text);

                // Insert Info portion for the first page load
                Export_Info item = new Export_Info
                {
                    CustomerId = id,
                    CustomerName = name,
                    Total = 0,
                    CardDiscount = true,
                    TransactionScore = 0,
                    OtherDiscount = dis,
                    PaymentStatus = status,
                    PaymentType = type,
                    CreateBy = emId
                };
                listInfo.Add(item);
                infoId = insertModel.InsertExportInfo(item, context);
                // Get person from id
                person = listModel.ListCustomer(id);

                OnAdd_Share(name, qty);

                // Hide the substitude table
                emptyTable.Visible = false;
            }
            else
            {
                idErr.Text = "Invalid ID";
            }
        }
        public void OnAdd(object sender, EventArgs e)
        {
            string emId = createBy.Text.ToUpper();
            if (checkModel.CheckCharID(emId) == true)
            {
                idErr.Text = null;
                // Get info from footer
                DropDownList dd = gv.FooterRow.FindControl("ddGoodsNew") as DropDownList;
                TextBox text = gv.FooterRow.FindControl("qtyNew") as TextBox;

                // Teporary variable
                string name = dd.SelectedItem.Text;
                int qty = Convert.ToInt32(text.Text);

                OnAdd_Share(name, qty);
            }
            else
            {
                idErr.Text = "Invalid ID";
            }
        }

        public void OnAdd_Share(string name, int qty)
        {
            // Get good's info from good's name
            List<Good> good = listModel.ListGood(0, name);

            // --------------- Extend DB ---------------
            // Add promotion table, check if the good is in any promotion program, if yes apply
            // Use CheckPromo and return discount %/amount and apply to orginal price
            // Default dis = 0
            double dis = 0;
            double price = (double)good.ElementAt(0).SalePrice;
            double total = (double)(qty * (price - dis));


            Export_Goods item = new Export_Goods
            {
                GoodsName = name,
                Quantity = qty,
                Discount = dis,
                // Derive other elements from updated elements
                Barcode = good.ElementAt(0).Barcode,
                Price = price,
                TotalPrice = total,
                ExportInfoId = infoId
            };

            // Save new info database and listGoods
            item.Id = insertModel.InsertExportGood(item, context);
            listGoods.Add(item);

            // -----Done with goods list, below is update of Import info-----
            UpdateInfo();
        }
        public void OnCancel(object sender, EventArgs e)
        {
            gv.EditIndex = -1;
            bindModel.BindGoods(listGoods, gv);
            bindModel.BindFooterRow(gv); // Rebind footer row
        }
        // -------------- Function handle --------------
        public void UpdateInfo()
        {
            double undis = 0;
            double dis = 0;
            for (int i = 0; i < listGoods.Count(); i++)
            {
                if ((double)listGoods.ElementAt(i).Discount == 0)
                {
                    undis += (double)listGoods.ElementAt(i).TotalPrice;
                }
                else
                {
                    dis += (double)listGoods.ElementAt(i).TotalPrice;
                }

            }
            bool card = true;
            if (ddCard.SelectedValue != "")
            {
                card = Convert.ToBoolean(ddCard.SelectedValue);
            }

            double percent = 1;

            // Temporary variables
            double otherDis = Convert.ToDouble(otherDiscount.Text);
            string type = paymentType.Text;
            bool status = Convert.ToBoolean(ddPaymentStatus.SelectedValue);
            string name = ddCustomer.SelectedItem.Text;
            string by = createBy.Text;
            int id = Convert.ToInt32(ddCustomer.SelectedValue);



            // Update customer's membership score

            person.ElementAt(0).MembershipScore -= listInfo.ElementAt(0).TransactionScore;
            // Check if selected Customer is different
            if (id != listInfo.ElementAt(0).CustomerId)
            {
                // Update membership score to old customer id
                updateModel.UpdateCustomer_MembershipScore(listInfo.ElementAt(0).CustomerId, person.ElementAt(0).MembershipScore, context);
                // Assign new customer info to person variable
                person = listModel.ListCustomer(id);
            }

            // Case 1: Apply membership card discount to the final total
            /*
            if (card == true)
            {
                percent = (double)((1 - GetCard().PercentDiscount / 100);
            } // else nothing change
            double sum = percent * (undis + dis) - otherDis;
            */
            // Case 2: Apply membership card discount ONLY to undiscounted goods 
            if (card == true)
            {
                percent = (double) (1 - GetCard().PercentDiscount / 100);
                
            } // else nothing change
            double sum = percent * undis + dis - otherDis;

            double tran = sum * 0.1;
            person.ElementAt(0).MembershipScore += tran;
            updateModel.UpdateCustomer_MembershipScore(id, person.ElementAt(0).MembershipScore, context);

            // Update list
            listInfo.ElementAt(0).CustomerId = id;
            listInfo.ElementAt(0).CustomerName = name;
            listInfo.ElementAt(0).Total = sum;
            listInfo.ElementAt(0).OtherDiscount = otherDis;
            listInfo.ElementAt(0).TransactionScore = tran;
            listInfo.ElementAt(0).CardDiscount = card;
            listInfo.ElementAt(0).PaymentType = type;
            listInfo.ElementAt(0).PaymentStatus = status;
            listInfo.ElementAt(0).UpdateBy = by;


            // Update to Transaction DB
            Export_Info info = new Export_Info
            {
                Id = infoId,
                CustomerId = id,
                CustomerName = name,
                PaymentType = type,
                PaymentStatus = status,
                TransactionScore = tran,
                OtherDiscount = otherDis,
                CardDiscount = card,
                Total = sum,
                CreateBy = by,
                UpdateBy = ""
            };

            updateModel.UpdateExportInfo(info, context);

            // Bind all the info and return the pointer
            gv.EditIndex = -1;


            BindInfo();
            bindModel.BindGoods(listGoods, gv);
            bindModel.BindFooterRow(gv);
        }
        protected void BindInfo()
        {
            // Load other info in the ExportInfo portion
            EoId.Text = listInfo.ElementAt(0).Id.ToString();
            total.Text = listInfo.ElementAt(0).Total.ToString();
            paymentType.Text = listInfo.ElementAt(0).PaymentType;
            orderScore.Text = listInfo.ElementAt(0).TransactionScore.ToString();
            otherDiscount.Text = listInfo.ElementAt(0).OtherDiscount.ToString();
            createBy.Text = listInfo.ElementAt(0).UpdateBy;

            address.Text = person.ElementAt(0).Address;
            phone.Text = person.ElementAt(0).PhoneNumber;
            newScore.Text = person.ElementAt(0).MembershipScore.ToString();

            bindModel.BindInstance(Customers, ddCustomer, listInfo.ElementAt(0).CustomerName, listInfo.ElementAt(0).CustomerId);
            ddCard.Items.Clear();
            string temp = GetCard().Name + " - " + GetCard().PercentDiscount + "%";
            bindModel.BindStatus(ddCard, temp, "None", listInfo.ElementAt(0).CardDiscount);
        }
        public CardType GetCard()
        {
            // Get card discount from membership score
            var cards = listModel.ListCardType(0);
            cards.Sort((x, y) => y.LowerBound.CompareTo(x.LowerBound));
            for (int i = 0; i < cards.Count(); i++)
            {
                if (person.ElementAt(0).MembershipScore >= cards.ElementAt(i).LowerBound)
                {
                    return cards.ElementAt(i);
                }
            }
            return cards.ElementAt(cards.Count - 1);
        }
    }
}