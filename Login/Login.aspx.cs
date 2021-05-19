using DB_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_ex1.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            AccountModel accountModel = new AccountModel();
            // Check if combo of username and password is in the database
            var res = accountModel.Login(username.Text,password.Text);
            if (res)
            {
                // Redirect to default page if login is successful
                Response.Redirect("/Default.aspx");
            } else {  
                // Display error message if login fails
                LoginError.Text = "Your username or password is incorrect";  
                LoginError.ForeColor = System.Drawing.Color.Red;  
            }
        }
    }
}