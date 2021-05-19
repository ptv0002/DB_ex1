<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ImportOrderEdit.aspx.cs" Inherits="DB_ex1.EditForms.ImportOrderEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
        <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" BorderWidth="10" BorderColor="transparent">View import orders</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server" EnableViewState="false">
    <asp:Table ID="importInfo" CellPadding="4" runat="server" BackColor="Transparent" BorderColor="Transparent" BorderWidth="10" width="50%">
        <asp:TableRow>
            <asp:TableCell Text="Import Order ID: ">
                <asp:Label ID="IoId" runat="server"/>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Supplier Name" ></asp:TableCell>
            <asp:TableCell ></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:DropDownList ID="ddSupplier" runat="server" width="100%"></asp:DropDownList></asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Payment status" ></asp:TableCell>
            <asp:TableCell Text="Payment type ">
                <asp:RequiredFieldValidator CssClass="small"  runat="server" ValidationGroup="update,insert,info" ControlToValidate="paymentType" ErrorMessage="Payment type is required" ForeColor="Red"></asp:RequiredFieldValidator>
        </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:DropDownList ID="ddPaymentStatus" runat="server" width="100%"></asp:DropDownList></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="paymentType" runat="server" width="100%"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Total import" ></asp:TableCell>
            <asp:TableCell Text="Update By"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="totalImport" runat="server" ></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="ddUpdateBy" runat="server" width="100%"></asp:DropDownList><asp:Label CssClass="small" runat="server" ID="ddError"></asp:Label></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <style>
        fixedHeader{
            position:absolute;
        }
    </style>
    <asp:GridView style="height:50px;overflow:auto" HeaderStyle-CssClass="fixedHeader" runat="server" ID="gv_importGoods" AutoGenerateColumns="False" CellPadding= "4" AllowPaging= "True" ForeColor= "#333333"  Width= "100%" OnRowEditing="OnRowEditing" ShowFooter="True" >
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ForeColor = "#333333" runat= "server" Text="Edit" CommandName="Edit" />
                    <asp:LinkButton ForeColor = "#333333" runat= "server" Text="Delete" OnClick="OnDelete" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ForeColor = "#333333" Text="Update" runat="server" OnClick="OnUpdate" ValidationGroup ="update"/>
                    <asp:LinkButton ForeColor = "#333333" Text="Cancel" runat="server" OnClick="OnCancel" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ForeColor = "#333333" runat= "server" Text="Add" OnClick="OnAdd" ValidationGroup="insert"/>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label id = "labelId" runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Good's name">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddGoods" runat="server" Width="100%"></asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("GoodsName") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddGoodsNew" runat="server" Width="100%"></asp:DropDownList>
                    <asp:Label CssClass="small" runat="server" ID="ddNewErr"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField = "Barcode" HeaderText= "Barcode" ReadOnly="true" />
            <asp:TemplateField HeaderText="Quantity">
                <EditItemTemplate>
                    <asp:TextBox ID="qty" runat="server" Text='<%# Bind("imQuantity") %>' Width="100%"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="small" runat="server" ValidationGroup="update" ControlToValidate="qty" ErrorMessage="Quanity is required" ForeColor="Red"/>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("imQuantity") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="qtyNew" runat="server" Text='<%# Bind("imQuantity") %>'  Width="100%"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="small" runat="server" ValidationGroup="insert" ControlToValidate="qtyNew" ErrorMessage="Quanity is required" ForeColor="Red"/>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField = "Price" HeaderText= "Price" ReadOnly="true" />
            <asp:BoundField DataField = "TotalPrice" HeaderText= "Total Price" ReadOnly="true"/>
        </Columns>
        <HeaderStyle BackColor= "#135857" Font-Bold= "True" ForeColor= "White" />
        <PagerStyle BackColor= "#135857" ForeColor= "White" HorizontalAlign= "Center" />
        <FooterStyle BackColor="#26a69a" />
        <EditRowStyle BackColor="#4db6ac" />
        <RowStyle BackColor= "#9fe9dd" />
        <AlternatingRowStyle BackColor = "White" />
    </asp:GridView>
    <asp:Label BorderWidth="3" BorderColor="Transparent" runat="server"></asp:Label><asp:Button class= "btn btn-primary" ID="SaveButton" Text="Save" onClick="btnSave_Click" runat="server" ValidationGroup="info"/>
    <a class= "btn btn-secondary" href="/Management/ImportManagement.aspx">Cancel</a> </asp:Content><asp:Content ID="Content3" ContentPlaceHolderID="cpScript" runat="server">
</asp:Content>
