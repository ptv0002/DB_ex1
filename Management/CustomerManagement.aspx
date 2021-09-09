<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CustomerManagement.aspx.cs" Inherits="DB_ex1.Management.CustomerManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">        
    <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" BorderWidth="10" BorderColor="Transparent">Customers</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:LinkButton ForeColor = "#333333" BorderWidth= "10" BorderColor= "Transparent" runat= "server" href= "/AddForms/CustomerAdd.aspx" >Add</asp:LinkButton>    
    <asp:GridView ID = "gv" runat= "server" AutoGenerateColumns= "false" Width= "100%" CellPadding= "4" AllowPaging= "true" ForeColor= "#333333" GridLines= "Both" >
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ForeColor = "#333333" runat= "server" href= '<%#"/EditForms/CustomerEdit.aspx?Id="+DataBinder.Eval(Container.DataItem,"Id") %>' Text="Edit" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField = "Id" HeaderText= "ID" ReadOnly="True"/>
            <asp:BoundField DataField = "FirstName" HeaderText= "First name" ReadOnly= "True" />
            <asp:BoundField DataField = "LastName" HeaderText= "Last name" ReadOnly= "True" />
            <asp:BoundField DataField = "Status" HeaderText= "Status" ReadOnly= "True" />
            <asp:BoundField DataField = "PhoneNumber" HeaderText= "Phone number" ReadOnly= "True" />
            <asp:BoundField DataField = "Address" HeaderText= "Address" ReadOnly= "True" />
            <asp:BoundField DataField = "CitizenId" HeaderText= "Citizen ID" ReadOnly= "True" />
            <asp:BoundField DataField = "MembershipScore" HeaderText= "Membership Score" ReadOnly= "True" />
            <asp:BoundField DataField = "CreateDate" HeaderText= "Create date" ReadOnly= "True" />
            <asp:BoundField DataField = "CreateBy" HeaderText= "Create by" ReadOnly= "True" />
            <asp:BoundField DataField = "UpdateDate" HeaderText= "Update date" ReadOnly= "True" />
            <asp:BoundField DataField = "UpdateBy" HeaderText= "Update by" ReadOnly= "True" />
        </Columns>
        <HeaderStyle BackColor= "#135857" Font-Bold= "True" ForeColor= "White" />
        <PagerStyle BackColor= "#135857" ForeColor= "White" HorizontalAlign= "Center" />
        <RowStyle BackColor= "#9fe9dd" />
        <AlternatingRowStyle BackColor = "White" />
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScript" runat="server">
</asp:Content>
