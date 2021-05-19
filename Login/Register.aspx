<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DB_ex1.Login.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="LoginLayoutHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginCardHeader" runat="server">
    <h3 class="text-center font-weight-light my-4">Create Account</h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LoginCardBody" runat="server">
    <asp:Label ID="LoginError" runat="server"></asp:Label> 
    <asp:Table CellPadding="4" runat="server">
        <asp:TableRow>
            <asp:TableCell Text="First Name" ></asp:TableCell>
            <asp:TableCell Text="Last Name"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="firstName" runat="server" width="100%"></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="lastName" runat="server" width="100%"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="firstName" ErrorMessage="First name is required" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="lastName" ErrorMessage="Last name is required" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>        
        </asp:TableRow>
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
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="confirmPassword" ErrorMessage="Confirm password is required" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>        
        </asp:TableRow>
    </asp:Table>
    <a class="small" href="/Login/ForgotPassword.aspx">Forgot password?</a>
    <div><asp:Button class= "btn btn-primary" ID="RegisterButton" runat="server" Text="Create Account" onclick="btnRegister_Click" width="100%"/></div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="LoginCardFooter" runat="server">
    <a href="/Login/Login.aspx">Have an account? Go to login</a>
</asp:Content>
