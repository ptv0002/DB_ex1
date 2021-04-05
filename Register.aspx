<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DB_ex1.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="LoginLayoutHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginCardHeader" runat="server">
    <h3 class="text-center font-weight-light my-4">Create Account</h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LoginCardBody" runat="server">
    <table class="align-content-center">
        <thead>
                <asp:Label ID="LoginError" runat="server"></asp:Label>

        </thead>

        <tr>
            <td>First Name</td>
            <td>Last Name</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="firstName" runat="server" ></asp:TextBox>  
            </td>
            <td>
                <asp:TextBox ID="lastName" runat="server" ></asp:TextBox>  
            </td>
        </tr>
        <tr>
            <td class="small">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="firstName" ErrorMessage="Please Enter Your First Name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="small">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="lastName" ErrorMessage="Please Enter Your Last Name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Username</td>
            <td>Email</td>
        </tr> 
        <tr>
            <td>
                <asp:TextBox ID="username" runat="server" ></asp:TextBox>  
            </td>
            <td>
                <asp:TextBox ID="email" runat="server" ></asp:TextBox>  
            </td>
        </tr>
        <tr>
            <td class="small">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="username" ErrorMessage="Please Enter Your Username" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="small">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="email" ErrorMessage="Please Enter Your Email" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Password<div class="small"></div></td>
            <td>Confirm Password
                <div class="small"><asp:CompareValidator runat="server" ControlToCompare="password" ErrorMessage="Incorrect" ForeColor="Red" ControlToValidate="confirmPassword"></asp:CompareValidator></div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="password" TextMode="Password" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="confirmPassword" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="small">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="password" ErrorMessage="Please Enter Your Password" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="small">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="confirmPassword" ErrorMessage="Please Confirm Your Password" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="align-content-center">
                <asp:Button class= "btn btn-primary" ID="RegisterButton" runat="server" Text="Create Account" onclick="btnRegister_Click" Width="253px" />
            </td>
        </tr>
    </table> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="LoginCardFooter" runat="server">
    <a href="/Login.aspx">Have an account? Go to login</a>
</asp:Content>
