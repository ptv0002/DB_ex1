<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="GoodEdit.aspx.cs" Inherits="DB_ex1.EditForms.GoodEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" BorderWidth="10" BorderColor="Transparent">Edit Good</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:Table CellPadding="4" runat="server" BackColor="Transparent" BorderColor="Transparent" BorderWidth="10" width="50%">
        <asp:TableRow>
            <asp:TableCell Text="Good ID: "><asp:Label ID="gId" runat="server"/></asp:TableCell>
        </asp:TableRow><asp:TableRow>
            <asp:TableCell>Name</asp:TableCell>
            <asp:TableCell>Category</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="goodsName" runat="server" width="100%"/></asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="ddCategory" runat="server" width="100%"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="goodsName" ErrorMessage="Good's name is required" ForeColor="Red"/></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>Bar code</asp:TableCell>
            <asp:TableCell>Tax</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="barcode" runat="server" width="100%"/></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="tax" runat="server" width="100%"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="barcode" ErrorMessage="Bar code is required" ForeColor="Red"/></asp:TableCell>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="tax" ErrorMessage="Tax percent is required" ForeColor="Red"/></asp:TableCell>
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
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="minQty" ErrorMessage="Min quantity is required" ForeColor="Red"/></asp:TableCell>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="Qty" ErrorMessage="Quantity is required" ForeColor="Red"/></asp:TableCell>        
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>Import price</asp:TableCell>
            <asp:TableCell>Sale price</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="importPrice" runat="server" width="100%"/></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="salePrice" runat="server" width="100%"/></asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="importPrice" ErrorMessage="Import price is required" ForeColor="Red"/> </asp:TableCell>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="salePrice" ErrorMessage="Sale price is required" ForeColor="Red"/></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>Update By</asp:TableCell>     
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
