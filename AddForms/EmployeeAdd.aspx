<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeAdd.aspx.cs" Inherits="DB_ex1.AddForms.EmployeeAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" BorderWidth="10" BorderColor="Transparent">Add Employee</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:Table CellPadding="4" runat="server" BackColor="Transparent" BorderColor="Transparent" BorderWidth="10" width="50%">
        <asp:TableRow>
            <asp:TableCell Text="First Name" ></asp:TableCell>
            <asp:TableCell Text="Last Name"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="firstName" runat="server" width="100%"></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="lastName" runat="server" width="100%"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator runat="server" ControlToValidate="firstName" ErrorMessage="First name is required" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator runat="server" ControlToValidate="lastName" ErrorMessage="Last name is required" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Position" ></asp:TableCell>
            <asp:TableCell Text="Code"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="position" runat="server" width="100%"></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="code" runat="server" width="100%"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator runat="server" ControlToValidate="position" ErrorMessage="Position is required" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator runat="server" ControlToValidate="code" ErrorMessage="Code is required" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Phone Number" ></asp:TableCell>
            <asp:TableCell Text="Address"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="phoneNumber" runat="server" width="100%"></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="employeeAddress" runat="server" width="100%"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator runat="server" ControlToValidate="phoneNumber" ErrorMessage="Phone number is required" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator runat="server" ControlToValidate="employeeAddress" ErrorMessage="Address is required" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Create By"></asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:DropDownList ID="ddCreateBy" runat="server" width="100%"></asp:DropDownList></asp:TableCell>
            <asp:TableCell CssClass="small"><asp:Label runat="server" ID="ddError"></asp:Label></asp:TableCell>
        </asp:TableRow>   
    </asp:Table>
    <asp:Label BorderWidth="3" BorderColor="Transparent" runat="server"></asp:Label>
    <asp:Button class= "btn btn-primary" ID="SaveButton" Text="Save" onClick="btnSave_Click" runat="server"/>
    <a class= "btn btn-secondary" href="/Management/EmployeeManagement.aspx">Cancel</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScript" runat="server">
</asp:Content>
