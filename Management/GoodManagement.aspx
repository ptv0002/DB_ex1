<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="GoodManagement.aspx.cs" Inherits="DB_ex1.GoodManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
        <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" BorderWidth="10" BorderColor="lightseagreen">Goods</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:LinkButton runat="server" ForeColor="#333333" BorderWidth="10" BorderColor="lightseagreen" href="/Forms/GoodAdd.aspx">Add</asp:LinkButton>
    <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="false" Width="100%" CellPadding="4" AllowPaging="true" ForeColor="#333333" GridLines="Both">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="goodsId" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="GoodsGroupId" HeaderText="Group ID" ReadOnly="True" />
            <asp:BoundField DataField="GoodsName" HeaderText="Name" ReadOnly="True" />
            <asp:BoundField DataField="GoodsStatus" HeaderText="Status" ReadOnly="True" />
            <asp:BoundField DataField="GoodsCode" HeaderText="Bar Code" ReadOnly="True" />
            <asp:BoundField DataField="MinQuantity" HeaderText="Min Quantity" ReadOnly="True" />
            <asp:BoundField DataField="GoodsQuantity" HeaderText="Quantity" ReadOnly="True" />
            <asp:BoundField DataField="ImportPrice" HeaderText="Import Price" ReadOnly="True" />
            <asp:BoundField DataField="SalePrice" HeaderText="Sale Price" ReadOnly="True" />
            <asp:BoundField DataField="TaxPercent" HeaderText="Tax Percent" ReadOnly="True" />
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
