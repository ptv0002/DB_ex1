<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="DB_ex1.ResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="LoginLayoutHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginCardHeader" runat="server">
    <h3 class="text-center font-weight-light my-4">Password Recovery</h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LoginCardBody" runat="server">
    <table class="align-content-center">
        <thead>
            <asp:Label ID="LoginError" runat="server"></asp:Label>
        </thead>
        <tr>
            <td>
                <div class="mb-3 text-muted">Enter your email address and we will send you a link to reset your password.</div>
            </td>
        </tr>
        <tr>
            <td>Email</td>
        </tr> 
        <tr>
            <td>
                <asp:TextBox ID="email" runat="server" ></asp:TextBox>  
            </td>
        </tr>
        <tr>
            <td class="small">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="email" ErrorMessage="Please Enter Your Email" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <a class="small" href="/Login.aspx">Return to login</a>
            </td>
        </tr>
        <tr>
            <td class="align-content-center">
                <asp:Button class= "btn btn-primary" ID="ResetPasswordButton" runat="server" Text="Reset Password" onclick="btnResetPw_Click" Width="233px" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="LoginCardFooter" runat="server">
    <a href="/Register.aspx">Need an account? Sign up!</a>
</asp:Content>
