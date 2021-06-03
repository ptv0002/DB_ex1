﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SupplierEdit.aspx.cs" Inherits="DB_ex1.EditForms.SupplierEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" BorderWidth="10" BorderColor="Transparent">Edit Supplier</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:Table CellPadding="4" runat="server" BackColor="Transparent" BorderColor="Transparent" BorderWidth="10" width="50%">
        <asp:TableRow>
            <asp:TableCell Text="Supplier ID: "><asp:Label ID="sId" runat="server"/></asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Name</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="name" runat="server" width="100%"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="name" ErrorMessage="Supplier's name is required" ForeColor="Red"/></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>Phone number</asp:TableCell>
            <asp:TableCell>Address</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="phoneNumber" runat="server" width="100%"/></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="address" runat="server" width="100%"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="phoneNumber" ErrorMessage="Phone number is required" ForeColor="Red"/></asp:TableCell>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="address" ErrorMessage="Address is required" ForeColor="Red"/></asp:TableCell>        
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>Update by</asp:TableCell>
            <asp:TableCell>Status</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:DropDownList ID="ddUpdateBy" runat="server" width="100%"/></asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="ddStatus" runat="server" width="100%"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="ddUpdateBy" InitialValue="-Select-" ErrorMessage="This field is required" ForeColor="Red"/></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Label BorderWidth="3" BorderColor="Transparent" runat="server"/>
    <asp:Button class= "btn btn-primary" ID="SaveButton" Text="Save" onClick="btnSave_Click" runat="server"/>
    <a class= "btn btn-secondary" href="/Management/GoodManagement.aspx">Cancel</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScript" runat="server">
</asp:Content>