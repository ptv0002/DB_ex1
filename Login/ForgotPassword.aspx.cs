﻿using DB_Models;
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnResetPw_Click(object sender, EventArgs e)
        {
            // Check if email has been registered, if not, password recovery fails
            AccountModel accountModel = new AccountModel();
            var res = accountModel.CheckEmail(email.Text);
            if (res)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                LoginError.Text = "Your email is not registered. Please create new an account.";
                LoginError.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}