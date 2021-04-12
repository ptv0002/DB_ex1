<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="GoodEdit.aspx.cs" Inherits="DB_ex1.Forms.GoodEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" BorderWidth="10" BorderColor="lightseagreen">Edit Good</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:Table CellPadding="4" runat="server" BackColor="#e6f2f2" BorderColor="LightSeaGreen" BorderWidth="10">
        <asp:TableRow>
            <asp:TableCell Text="Good ID: "><asp:Label ID="gId" runat="server"/></asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableRow><asp:TableRow>
            <asp:TableCell Text="Name" ></asp:TableCell>
            <asp:TableCell Text="Category"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="goodsName" runat="server" ></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="ddCategory" runat="server" ></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Bar Code" ></asp:TableCell>
            <asp:TableCell Text="Import Price"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="barcode" runat="server" ></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="importPrice" runat="server" ></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Min Quantity" ></asp:TableCell>
            <asp:TableCell Text="Quantity"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="minQty" runat="server" ></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="Qty" runat="server" ></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Tax" ></asp:TableCell>
            <asp:TableCell Text="Status"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="tax" runat="server" ></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="status" runat="server" ></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Update By" ></asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="updateBy" runat="server" ></asp:TextBox></asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="updateBy" ErrorMessage="Please enter your name/employeeID" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
            <asp:TableCell></asp:TableCell>        
        </asp:TableRow>
    </asp:Table>
    <asp:Label BorderWidth="3" BorderColor="Transparent" runat="server"></asp:Label>
    <asp:Button class= "btn btn-secondary" ID="SaveButton" Text="Save" onClick="btnSave_Click" runat="server"/>
    <a class= "btn btn-secondary" runat="server" Text="Cancel" href="/Management/GoodManagement.aspx">Cancel</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScript" runat="server">
</asp:Content>
