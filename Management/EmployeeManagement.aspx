<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeManagement.aspx.cs" Inherits="DB_ex1.EmployeeManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" >Employees</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:LinkButton ForeColor="#333333" BorderWidth="10" BorderColor="lightseagreen" runat="server" href="/Forms/EmployeeAdd.aspx">Add</asp:LinkButton>    
    <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="false" Width="100%" CellPadding="4" AllowPaging="true" ForeColor="#333333" GridLines="Both">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="employeeId" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="LastName" HeaderText="Last name" ReadOnly="True" />
            <asp:BoundField DataField="FirstName" HeaderText="First name" ReadOnly="True" />
            <asp:BoundField DataField="EmployeeStatus" HeaderText="Status" ReadOnly="True" />
            <asp:BoundField DataField="EmployeeAddress" HeaderText="Employee address" ReadOnly="True" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone number" ReadOnly="True" />
            <asp:BoundField DataField="CreateDate" HeaderText="Create date" ReadOnly="True" />
            <asp:BoundField DataField="CreateBy" HeaderText="Create by" ReadOnly="True" />
            <asp:BoundField DataField="UpdateDate" HeaderText="Update date" ReadOnly="True" />
            <asp:BoundField DataField="UpdateBy" HeaderText="Update by" ReadOnly="True" />
        </Columns>
        <HeaderStyle BackColor="#135857" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#135857" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#e6f2f2" />
        
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScript" runat="server">
</asp:Content>
