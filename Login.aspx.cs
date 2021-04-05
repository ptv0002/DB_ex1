using DB_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_ex1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            AccountModel accountModel = new AccountModel();
            var res = accountModel.Login(username.Text,password.Text);
            if (res)
            {
                Response.Redirect("Default.aspx");
            } else {  
                LoginError.Text = "Your username or Password is incorrect";  
                LoginError.ForeColor = System.Drawing.Color.Red;  
  
            }
        }
    }
}