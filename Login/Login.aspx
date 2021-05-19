<%@ Page Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DB_ex1.Login.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LoginLayoutHead" runat="server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LoginCardHeader" runat="server">
    <h3 class="text-center font-weight-light my-4">Login</h3>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginCardBody" runat="server">
    <div class="align-content-center">
        <div><asp:Label ID="LoginError" runat="server"></asp:Label></div>
        <div><asp:Label runat="server">Username</asp:Label></div>
        <div><asp:TextBox ID="username" runat="server" width="100%"></asp:TextBox></div>  
        <div class="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="username" ErrorMessage="Username is required" ForeColor="Red"></asp:RequiredFieldValidator></div>
        <div><asp:Label runat="server">Password</asp:Label></div>
        <div><asp:TextBox ID="password" TextMode="Password" runat="server" width="100%"></asp:TextBox></div>
        <div class="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="password" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator></div>
        <div class="custom-checkbox"><asp:CheckBox Text="Remember Me" runat="server" /></div>
        <a class="small" href="/Login/ForgotPassword.aspx">Forgot password?</a>
        <div><asp:Button class= "btn btn-primary" ID="LoginButton" runat="server" Text="Log In" onclick="btnLogin_Click" width="100%" /></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="LoginCardFooter" runat="server">
    <a href="/Login/Register.aspx">Need an account? Sign up!</a>
</asp:Content>


