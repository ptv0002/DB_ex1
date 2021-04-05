<%@ Page Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DB_ex1.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LoginLayoutHead" runat="server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LoginCardHeader" runat="server">
    <h3 class="text-center font-weight-light my-4">Login</h3>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="LoginCardFooter" runat="server">
    <a href="/Register.aspx">Need an account? Sign up!</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginCardBody" runat="server">
    <table class="align-content-center">
        <thead><asp:Label ID="LoginError" runat="server"></asp:Label></thead>
                
        <tr>
            <td>Username</td>
        </tr> 
        <tr>
            <td>
                <asp:TextBox ID="username" runat="server" ></asp:TextBox>  
            </td>
        </tr>
        <tr>
            <td class="small">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="username" ErrorMessage="Please Enter Your Username" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Password</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="password" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="small">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="password" ErrorMessage="Please Enter Your Password" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="custom-checkbox">
                <asp:CheckBox Text="Remember Me" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <a class="small" href="/ResetPassword.aspx">Forgot Password?</a>
            </td>
        </tr>
        <tr>
            <td class="align-content-center">
                <asp:Button class= "btn btn-primary" ID="LoginButton" runat="server" Text="Log In" onclick="btnLogin_Click" Width="126px" />
            </td>
        </tr>
        </table> 
</asp:Content>


<%--<body>
    <form id="form1" runat="server">
        <div>
        
        <div class="form-group">
            <label class="small mb-1" for="inputUsername">Username</label>

            @Html.TextBoxFor(model => model.Username, new { @class = "form-control py-4", @placeholder = "Enter username" })
            @*<input class="form-control py-4" id="inputEmailAddress" type="email" placeholder="Enter email address">*@
        </div>
        <div class="form-group">
            <label class="small mb-1" for="inputPassword">Password</label>
            @Html.TextBoxFor(model => model.Password, new { @class = "form-control py-4", @placeholder = "Enter password", @type = "password" })

            @*<input class="form-control py-4" id="inputPassword" type="password" placeholder="Enter password">*@
        </div>

        <div class="checkbox">
            <label>
                @Html.CheckBoxFor(model => model.RememberMe)
                Remember Me
            </label>
        </div>

        @*
        <div class="form-group">
            <div class="custom-control custom-checkbox">
                <input class="custom-control-input" id="rememberPasswordCheck" type="checkbox">
                <label class="custom-control-label" for="rememberPasswordCheck">Remember password</label>
            </div>
        </div>
        *@

        <div class="form-group d-flex align-items-center justify-content-between mt-4 mb-0">
            <a class="small" href="@Url.Action("ResetPassword","Login")">Forgot Password?</a>
            <button class="btn btn-primary" type ="submit">Login</button>

</html>--%>
