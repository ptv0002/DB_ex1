<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ImportManagement.aspx.cs" Inherits="DB_ex1.Management.ImportManagement" %>
<asp:Content ID = "Content1" ContentPlaceHolderID="cpHead" runat="server">
    <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" BorderWidth="10" BorderColor="Transparent">Import Orders</asp:Label>
</asp:Content>
<asp:Content ID = "Content2" ContentPlaceHolderID= "cpMain" runat= "server" >
    <asp:LinkButton ForeColor = "#333333" BorderWidth= "10" BorderColor= "Transparent" runat= "server" href= "/AddForms/ImportOrderAdd.aspx" >Add</asp:LinkButton>    
    <asp:GridView ID = "gvImport" runat= "server" AutoGenerateColumns= "false" Width= "100%" CellPadding= "4" AllowPaging= "true" ForeColor= "#333333" GridLines= "Both">
        <AlternatingRowStyle BackColor = "White" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ForeColor = "#333333" runat= "server" href= '<%#"/EditForms/ImportOrderEdit.aspx?id="+DataBinder.Eval(Container.DataItem,"id") %>' Text="Edit" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField = "id" HeaderText= "ID" ReadOnly="True"/>
            <asp:BoundField DataField = "SupplierName" HeaderText= "Supplier name" ReadOnly= "True" />
            <asp:BoundField DataField = "TotalImport" HeaderText= "Total import" ReadOnly= "True" />
            <asp:BoundField DataField = "PaymentStatus" HeaderText= "Payment status" ReadOnly= "True" />
            <asp:BoundField DataField = "PaymentType" HeaderText= "Payment type" ReadOnly= "True" />
            <asp:BoundField DataField = "CreateDate" HeaderText= "Create date" ReadOnly= "True" />
            <asp:BoundField DataField = "CreateBy" HeaderText= "Create by" ReadOnly= "True" />
            <asp:BoundField DataField = "UpdateDate" HeaderText= "Update date" ReadOnly= "True" />
            <asp:BoundField DataField = "UpdateBy" HeaderText= "Update by" ReadOnly= "True" />
        </Columns>
        <HeaderStyle BackColor= "#135857" Font-Bold= "True" ForeColor= "White" />
        <PagerStyle BackColor= "#135857" ForeColor= "White" HorizontalAlign= "Center" />
        <RowStyle BackColor= "#9fe9dd" />
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScript" runat="server">
</asp:Content>
