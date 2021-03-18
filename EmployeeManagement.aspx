<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeManagement.aspx.cs" Inherits="DB_ex1.EmployeeManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="false" Width="100%" CellPadding="4" AllowPaging="false" ForeColor="#333333" GridLines="None">
        <Columns>
            <asp:BoundField DataField="LastName" HeaderText="Last name" ReadOnly="True" />
            <asp:BoundField DataField="FirstName" HeaderText="First name" ReadOnly="True" />
            <asp:BoundField DataField="EmployeeAddress" HeaderText="Employee address" ReadOnly="True" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone number" ReadOnly="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScript" runat="server">
</asp:Content>
