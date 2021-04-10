<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DB_ex1.Register" %>
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
            <asp:TableCell><asp:TextBox ID="firstName" runat="server" ></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="lastName" runat="server" ></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="firstName" ErrorMessage="Please Enter Your First Name" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="lastName" ErrorMessage="Please Enter Your Last Name" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Username" ></asp:TableCell>
            <asp:TableCell Text="Email"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="username" runat="server" ></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="email" runat="server" TextMode="Email" ></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="username" ErrorMessage="Please Enter Your Username" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="email" ErrorMessage="Please Enter Your Email" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Password" ></asp:TableCell>
            <asp:TableCell Text="Confirm Password"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell CssClass="small"><asp:CompareValidator runat="server" ControlToCompare="password" ErrorMessage="Incorrect" ForeColor="Red" ControlToValidate="confirmPassword"></asp:CompareValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="password" runat="server" TextMode="Password" ></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="confirmPassword" runat="server" TextMode="Password"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password" ErrorMessage="Please Enter Your Password" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="confirmPassword" ErrorMessage="Please Confirm Your Password" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>        
        </asp:TableRow>
    </asp:Table>
    <a class="small" href="/Login/ResetPassword.aspx">Forgot Password?</a>
    <div><asp:Button class= "btn btn-primary" ID="RegisterButton" runat="server" Text="Create Account" onclick="btnRegister_Click" Width="253px" /></div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="LoginCardFooter" runat="server">
    <a href="/Login/Login.aspx">Have an account? Go to login</a>
</asp:Content>
