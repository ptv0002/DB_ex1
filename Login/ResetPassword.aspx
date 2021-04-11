<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="DB_ex1.ResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="LoginLayoutHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginCardHeader" runat="server">
    <h3 class="text-center font-weight-light my-4">Password Recovery</h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LoginCardBody" runat="server">
    <div class="align-content-center">
        <div><asp:Label ID="LoginError" runat="server"></asp:Label></div>
        <div class="mb-3 text-muted">Enter your email address and we will send you a link to reset your password.</div>
        <div><asp:Label runat="server">Email</asp:Label></div>
        <div><asp:TextBox ID="email" runat="server" ></asp:TextBox></div>  
        <div class="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="email" ErrorMessage="Please enter your email" ForeColor="Red"></asp:RequiredFieldValidator></div>
        <a class="small" href="/Login/Login.aspx">Return to login</a>
        <div><asp:Button class= "btn btn-primary" ID="ResetPasswordButton" runat="server" Text="Reset Password" onclick="btnResetPw_Click" Width="233px" /></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="LoginCardFooter" runat="server">
    <a href="/Login/Register.aspx">Need an account? Sign up!</a>
</asp:Content>
