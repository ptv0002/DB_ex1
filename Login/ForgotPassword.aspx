<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="DB_ex1.Login.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="LoginLayoutHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginCardHeader" runat="server">
    <h3 class="text-center font-weight-light my-4">Password Recovery</h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LoginCardBody" runat="server">
    <div class="align-content-center">
        <div><asp:Label ID="LoginError" runat="server"></asp:Label></div>
        <div class="mb-3 text-muted">Enter your username, email address and your new password.</div>
        <asp:TableRow>
            <asp:TableCell Text="Username" ></asp:TableCell>
            <asp:TableCell Text="Email"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="username" runat="server" width="100%"></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="email" runat="server" TextMode="Email" width="100%" ></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="username" ErrorMessage="Username is required" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="email" ErrorMessage="Email is required" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Password" ></asp:TableCell>
            <asp:TableCell Text="Confirm Password "><asp:CompareValidator CssClass="small" runat="server" ControlToCompare="password" ErrorMessage="Incorrect" ForeColor="Red" ControlToValidate="confirmPassword"></asp:CompareValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="password" runat="server" TextMode="Password" width="100%"></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="confirmPassword" runat="server" TextMode="Password" width="100%"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="password" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="confirmPassword" ErrorMessage="Confirm password is required" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>        
        </asp:TableRow>
        <a class="small" href="/Login/Login.aspx">Return to login</a>
        <div><asp:Button class= "btn btn-primary" ID="ResetPasswordButton" runat="server" Text="Reset Password" onclick="btnResetPw_Click" width="100%" /></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="LoginCardFooter" runat="server">
    <a href="/Login/Register.aspx">Need an account? Sign up!</a>
</asp:Content>
