<%@ Page Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DB_ex1.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LoginLayoutHead" runat="server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LoginCardHeader" runat="server">
    <h3 class="text-center font-weight-light my-4">Login</h3>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginCardBody" runat="server">
    <div class="align-content-center">
        <div><asp:Label ID="LoginError" runat="server"></asp:Label></div>
        <div><asp:Label runat="server">Username</asp:Label></div>
        <div><asp:TextBox ID="username" runat="server" ></asp:TextBox></div>  
        <div class="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="username" ErrorMessage="Please Enter Your Username" ForeColor="Red"></asp:RequiredFieldValidator></div>
        <div><asp:Label runat="server">Password</asp:Label></div>
        <div><asp:TextBox ID="password" TextMode="Password" runat="server"></asp:TextBox></div>
        <div class="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="password" ErrorMessage="Please Enter Your Password" ForeColor="Red"></asp:RequiredFieldValidator></div>
        <div class="custom-checkbox"><asp:CheckBox Text="Remember Me" runat="server" /></div>
        <a class="small" href="/Login/ResetPassword.aspx">Forgot Password?</a>
        <div><asp:Button class= "btn btn-primary" ID="LoginButton" runat="server" Text="Log In" onclick="btnLogin_Click" Width="126px" /></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="LoginCardFooter" runat="server">
    <a href="/Login/Register.aspx">Need an account? Sign up!</a>
</asp:Content>


