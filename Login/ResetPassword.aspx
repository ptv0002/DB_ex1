<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="DB_ex1.Login.ResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="LoginLayoutHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginCardHeader" runat="server">
    <h3 class="text-center font-weight-light my-4">Reset Password</h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LoginCardBody" runat="server">
        <div><asp:Label runat="server">Password</asp:Label></div>
        <div><asp:TextBox ID="password" runat="server" width="100%"></asp:TextBox></div>  
        <div class="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="password" ErrorMessage="Please enter a new password" ForeColor="Red"></asp:RequiredFieldValidator></div>
        <div>
            <asp:Label runat="server">Confirm Password </asp:Label>
            <asp:CompareValidator CssClass="small" runat="server" ControlToCompare="password" ErrorMessage="Incorrect" ForeColor="Red" ControlToValidate="confirmPassword"></asp:CompareValidator>
        </div>
        <div><asp:TextBox ID="confirmPassword" TextMode="Password" runat="server" width="100%"></asp:TextBox></div>
        <div class="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="confirmPassword" ErrorMessage="Please confirm your password" ForeColor="Red"></asp:RequiredFieldValidator></div>
        <div><asp:Button class= "btn btn-primary" ID="ResetPWButton" runat="server" Text="Reset Password" onclick="btnReset_Click" width="100%" /></div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="LoginCardFooter" runat="server">
</asp:Content>
