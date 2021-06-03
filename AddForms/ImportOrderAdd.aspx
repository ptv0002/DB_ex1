<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ImportOrderAdd.aspx.cs" Inherits="DB_ex1.AddForms.ImportOrderAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" BorderWidth="10" BorderColor="Transparent"> Add import order</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:Table ID="importInfo" CellPadding="4" runat="server" BackColor="Transparent" BorderColor="Transparent" BorderWidth="10" width="50%">
        <asp:TableRow>
            <asp:TableCell Text="Import Order ID: ">
                <asp:Label ID="IoId" runat="server"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Supplier name</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:DropDownList ID="ddSupplier" runat="server" width="100%"/></asp:TableCell>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small"  runat="server" ValidationGroup="info" ControlToValidate="ddSupplier" ErrorMessage="Supplier name is required" InitialValue="-Select-" ForeColor="Red"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Payment status</asp:TableCell>
            <asp:TableCell>Payment type</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:DropDownList ID="ddPaymentStatus" runat="server" width="100%"/></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="paymentType" runat="server" width="100%"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small"  runat="server" ValidationGroup="info" ControlToValidate="ddPaymentStatus" ErrorMessage="Payment status is required" InitialValue="-Select-" ForeColor="Red"/></asp:TableCell>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small"  runat="server" ValidationGroup="info" ControlToValidate="paymentType" ErrorMessage="Payment type is required" ForeColor="Red"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Total import</asp:TableCell>
            <asp:TableCell>Create by</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="totalImport" runat="server" /></asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="ddCreateBy" runat="server" width="100%"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="ddCreateBy" ValidationGroup="info" InitialValue="-Select-" ErrorMessage="This field is required" ForeColor="Red"/></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:GridView style="height:50px;overflow:auto" HeaderStyle-CssClass="FixedHeader" FooterStyle-CssClass="FixedHeader" runat="server" ID="gv" AutoGenerateColumns="False" AllowPaging= "True" ForeColor= "#333333"  Width= "100%" OnRowEditing="OnRowEditing" ShowFooter="True" OnRowDeleting="OnRowDeleting" GridLines="Both">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ForeColor = "#333333" runat= "server" Text="Edit" CommandName="Edit" />
                    <asp:LinkButton ForeColor = "#333333" runat= "server" Text="Delete" CommandName="Delete" />
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
                    <asp:DropDownList ID="ddGoods" runat="server" Width="100%"/>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("GoodsName") %>'/>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddGoodsNew" runat="server" Width="100%"/>
                    <asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="ddGoodsNew" ValidationGroup="insert" InitialValue="-Select-" ErrorMessage="This field is required" ForeColor="Red"/>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField = "Barcode" HeaderText= "Barcode" ReadOnly="true" />
            <asp:TemplateField HeaderText="Quantity">
                <EditItemTemplate>
                    <asp:TextBox ID="qty" runat="server" Text='<%# Bind("imQuantity") %>' Width="100%"/>
                    <asp:RequiredFieldValidator CssClass="small" runat="server" ValidationGroup="update" ControlToValidate="qty" ErrorMessage="Quanity is required" ForeColor="Red"/>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("imQuantity") %>'/>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="qtyNew" runat="server"  Width="100%"/>
                    <asp:RequiredFieldValidator CssClass="small" runat="server" ValidationGroup="insert" ControlToValidate="qtyNew" ErrorMessage="Quanity is required" ForeColor="Red"/>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price">
                <EditItemTemplate>
                    <asp:TextBox ID="price" runat="server" Text='<%# Bind("Price") %>' Width="100%"/>
                    <asp:RequiredFieldValidator CssClass="small" runat="server" ValidationGroup="update" ControlToValidate="price" ErrorMessage="Price is required" ForeColor="Red"/>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Price") %>'/>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="priceNew" runat="server" Width="100%"/>
                    <asp:RequiredFieldValidator CssClass="small" runat="server" ValidationGroup="insert" ControlToValidate="priceNew" ErrorMessage="Price is required" ForeColor="Red"/>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField = "TotalPrice" HeaderText= "Total Price" ReadOnly="true"/>
        </Columns>
        <HeaderStyle BackColor= "#135857" Font-Bold= "True" ForeColor= "White" />
        <PagerStyle BackColor= "#135857" ForeColor= "White" HorizontalAlign= "Center" />
        <FooterStyle BackColor="#26a69a" />
        <EditRowStyle BackColor="#4db6ac" />
        <RowStyle BackColor= "White" />
        <AlternatingRowStyle BackColor = "#9fe9dd" />
        <EmptyDataTemplate>
            <asp:Table runat="server" GridLines="Both" Width="100%">
                <asp:TableRow BackColor= "#135857" Font-Bold= "True" ForeColor= "White" Width= "100%" >
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell>ID</asp:TableCell>
                    <asp:TableCell>Good's name</asp:TableCell>
                    <asp:TableCell>Barcode</asp:TableCell>
                    <asp:TableCell>Quantity</asp:TableCell>
                    <asp:TableCell>Price</asp:TableCell>
                    <asp:TableCell>Total price</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow BackColor="#26a69a"  ForeColor= "#333333"  Width= "100%" >
                    <asp:TableCell>
                        <asp:LinkButton ForeColor = "#333333" runat= "server" Text="Add" OnClick="OnAdd_Empty" ValidationGroup="info"/>
                    </asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddGoodsEmpty" runat="server" Width="100%"/>
                        <asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="ddGoodsEmpty" ValidationGroup="info" InitialValue="-Select-" ErrorMessage="This field is required" ForeColor="Red"/>
                    </asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="qtyEmpty" runat="server" Width="100%"/>
                        <asp:RequiredFieldValidator CssClass="small" runat="server" ValidationGroup="info" ControlToValidate="qtyEmpty" ErrorMessage="Quanity is required" ForeColor="Red"/>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="priceEmpty" runat="server"  Width="100%"/>
                        <asp:RequiredFieldValidator CssClass="small" runat="server" ValidationGroup="info" ControlToValidate="priceEmpty" ErrorMessage="Price is required" ForeColor="Red"/>
                    </asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:Label BorderWidth="3" BorderColor="Transparent" runat="server"/>
    <asp:Button class= "btn btn-primary" ID="SaveButton" Text="Save" onClick="btnSave_Click" runat="server" ValidationGroup="info"/>
    <asp:Button class= "btn btn-secondary" ID="CancelButton" Text="Cancel" onClick="btnCancel_Click" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScript" runat="server">
</asp:Content>
