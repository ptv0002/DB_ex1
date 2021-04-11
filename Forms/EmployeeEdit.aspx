<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeEdit.aspx.cs" Inherits="DB_ex1.Forms.EmployeeEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">    
    <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" BorderWidth="10" BorderColor="lightseagreen">Edit Employee</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:Label ID="LoginError" runat="server"></asp:Label> 
    <asp:Table CellPadding="4" runat="server" BackColor="#e6f2f2" BorderColor="LightSeaGreen" BorderWidth="10">
        <asp:TableRow>
            <asp:TableCell Text="Employee ID: "><asp:Label ID="eId" runat="server"/></asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="First Name" ></asp:TableCell>
            <asp:TableCell Text="Last Name"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="firstName" runat="server" ></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="lastName" runat="server" ></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Phone Number" ></asp:TableCell>
            <asp:TableCell Text="Address"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="phoneNumber" runat="server" ></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="employeeAddress" runat="server" ></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Update By"></asp:TableCell>
            <asp:TableCell Text="Status"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="updateBy" runat="server" ></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="status" runat="server" ></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="updateBy" ErrorMessage="Please enter your name/employeeID" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>        
            <asp:TableCell></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Label BorderWidth="3" BorderColor="Transparent" runat="server"></asp:Label>
    <asp:Button class= "btn btn-secondary" ID="SaveButton" Text="Save" onClick="btnSave_Click" runat="server"/>
    <a class= "btn btn-secondary" runat="server" Text="Cancel" href="/Management/EmployeeManagement.aspx">Cancel</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScript" runat="server">
</asp:Content>
