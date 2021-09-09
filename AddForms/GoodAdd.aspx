<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="GoodAdd.aspx.cs" Inherits="DB_ex1.AddForms.GoodAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" BorderWidth="10" BorderColor="Transparent">Add Good</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:Table CellPadding="4" runat="server" BackColor="Transparent" BorderColor="Transparent" BorderWidth="10" width="100%">
        <asp:TableRow>
            <asp:TableCell>Name</asp:TableCell>
            <asp:TableCell>Category</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="goodsName" runat="server" width="100%"/></asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="ddCategory" runat="server" width="100%"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="goodsName" ErrorMessage="Required field" ForeColor="Red"/></asp:TableCell>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="ddCategory" InitialValue="-Select-" ErrorMessage="Required field" ForeColor="Red"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Bar code</asp:TableCell>
            <asp:TableCell>Import price</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="barcode" runat="server" width="100%"/></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="importPrice" runat="server" width="100%"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="barcode" ErrorMessage="Required field" ForeColor="Red"/></asp:TableCell>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="importPrice" ErrorMessage="Required field" ForeColor="Red"/></asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Min quantity</asp:TableCell>
            <asp:TableCell>Quantity</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="minQty" runat="server" width="100%"/></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="Qty" runat="server" width="100%"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="minQty" ErrorMessage="Required field" ForeColor="Red"/></asp:TableCell>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="Qty" ErrorMessage="Required field" ForeColor="Red"/></asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Tax</asp:TableCell>
            <asp:TableCell>
                <asp:Label Text="Create by (Insert ID)" runat="server"/>&emsp;
                <asp:Label ID="idErr" runat="server" CssClass="small" ForeColor="Red"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="tax" runat="server" width="100%"/></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="createBy" runat="server" width="100%"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="tax" ErrorMessage="Required field" ForeColor="Red"/></asp:TableCell>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="createBy" ErrorMessage="Required field" ForeColor="Red"/></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    &ensp;
    <asp:Button class= "btn btn-primary" ID="SaveButton" Text="Save" onClick="btnSave_Click" runat="server"/>
    <a class= "btn btn-secondary" href="/Management/GoodManagement.aspx">Cancel</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScript" runat="server">
</asp:Content>
