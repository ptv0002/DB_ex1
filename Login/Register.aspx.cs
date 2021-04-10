using DB_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_ex1
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {

            AccountModel accountModel = new AccountModel();
            var res = accountModel.CheckEmail(email.Text);
            if (res)
            {
                LoginError.Text = "Your email is already been registered. Use a different email or reset your password.";
                LoginError.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                
                Response.Redirect("Login.aspx");
            }
        }
    }
}