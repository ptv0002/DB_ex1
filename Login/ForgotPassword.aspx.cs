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
    public partial class ForgotPassword : System.Web.UI.Page
    {
        CheckModel checkModel = new CheckModel();
        UpdateModel updateModel = new UpdateModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnResetPw_Click(object sender, EventArgs e)
        {
            // Check if email has been registered, if not, password recovery fails
            var res = checkModel.CheckEmail(email.Text,username.Text);
            if (res)
            {
                Account item = new Account
                {
                    Username = username.Text,
                    Email = email.Text,
                    AccPassword = password.Text
                };
                updateModel.UpdatePassword(item);
                Response.Redirect("Login.aspx");
            }
            else
            {
                LoginError.Text = "Email is not registered/ Username is incorrect." +
                    "\nPlease create a new account or re-enter your information.";
                LoginError.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}