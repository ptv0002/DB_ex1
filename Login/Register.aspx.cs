using DB_Models;
using DB_Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_ex1.Login
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Check if email is in the database
            AccountModel accountModel = new AccountModel();
            var res = accountModel.CheckEmail(email.Text);
            if (res)
            {
                // if res = 1, email is already been registered, new register fails
                LoginError.Text = "Your email is already been registered. Use a different email or reset your password.";
                LoginError.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                // Save new account info to the database
                var newAcc = new Account();
                newAcc.FirstName = firstName.Text;
                newAcc.LastName = lastName.Text;
                newAcc.Username = username.Text;
                newAcc.Email = email.Text;
                newAcc.AccPassword = password.Text;
                accountModel.InsertAccount(newAcc);
                // Redirect user to the login page after saving new account info
                Response.Redirect("Login.aspx");
            }
        }
    }
}