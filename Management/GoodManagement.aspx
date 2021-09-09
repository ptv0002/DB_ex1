<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="GoodManagement.aspx.cs" Inherits="DB_ex1.Management.GoodManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" BorderWidth="10" BorderColor="Transparent">Goods</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:LinkButton runat="server" ForeColor="#333333" BorderWidth="10" BorderColor="Transparent" href="/AddForms/GoodAdd.aspx">Add</asp:LinkButton>
    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" Width="100%" CellPadding="4" AllowPaging="true" ForeColor="#333333" GridLines="Both" OnRowDataBound="gv_RowDataBound">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ForeColor="#333333" runat="server" href='<%#"/EditForms/GoodEdit.aspx?Id="+DataBinder.Eval(Container.DataItem,"Id") %>'>Edit</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
            <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="True" />
            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" />
            <asp:BoundField DataField="Barcode" HeaderText="Barcode" ReadOnly="True" />
            <asp:BoundField DataField="MinQuantity" HeaderText="Min Quantity" ReadOnly="True" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="True" />
            <asp:BoundField DataField="ImportPrice" HeaderText="Import Price" ReadOnly="True" />
            <asp:BoundField DataField="SalePrice" HeaderText="Sale Price" ReadOnly="True" />
            <asp:BoundField DataField="Tax" HeaderText="Tax" ReadOnly="True" />
            <asp:BoundField DataField="CreateDate" HeaderText="Create date" ReadOnly="True" />
            <asp:BoundField DataField="CreateBy" HeaderText="Create by" ReadOnly="True" />
            <asp:BoundField DataField="UpdateDate" HeaderText="Update date" ReadOnly="True" />
            <asp:BoundField DataField="UpdateBy" HeaderText="Update by" ReadOnly="True" />
        </Columns>
        <HeaderStyle BackColor="#135857" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#135857" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor= "#9fe9dd" />
        <AlternatingRowStyle BackColor = "White" />  
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScript" runat="server">
</asp:Content>
