<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ImportOrderAdd.aspx.cs" Inherits="DB_ex1.AddForms.ImportOrderAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" BorderWidth="10" BorderColor="Transparent"> Add import orders</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:Table ID="importInfo" CellPadding="4" runat="server" BackColor="Transparent" BorderColor="Transparent" BorderWidth="10" width="50%">
        <asp:TableRow>
            <asp:TableCell Text="Supplier Name" ></asp:TableCell>
            <asp:TableCell Text="Employee Name"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:DropDownList ID="ddSupplier" runat="server" width="100%"></asp:DropDownList></asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="ddEmployee" runat="server" width="100%"></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Payment status" ></asp:TableCell>
            <asp:TableCell Text="Payment type"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:DropDownList ID="ddPaymentStatus" runat="server" width="100%"></asp:DropDownList></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="paymentType" runat="server" width="100%"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="info" ControlToValidate="paymentType" ErrorMessage="Payment type is required" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Total import" ></asp:TableCell>
            <asp:TableCell Text="Update By"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="totalImport" runat="server" ></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="updateBy" runat="server" width="100%"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell CssClass="small"><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="info" ControlToValidate="updateBy" ErrorMessage="Name/employeeID is required" ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>        
        </asp:TableRow>
    </asp:Table>
    <asp:GridView runat="server" ID="gv_importGoods" AutoGenerateColumns="False" CellPadding= "4" ForeColor= "#333333"  Width= "100%" OnRowEditing="OnRowEditing" ShowFooter="True" BorderColor="#e6f2f2" BorderWidth="10px" >
        <AlternatingRowStyle BackColor = "White" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ForeColor = "#333333" runat= "server" Text="Edit" CommandName="Edit" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ForeColor = "#333333" Text="Update" runat="server" OnClick="OnUpdate" />
                    <asp:LinkButton ForeColor = "#333333" Text="Cancel" runat="server" OnClick="OnCancel" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ForeColor = "#333333" runat= "server" Text="Add" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField = "importGoodsId" HeaderText= "ID" ReadOnly= "True"/>
            <asp:TemplateField HeaderText="Good's name">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddGoods" runat="server" Text='<%# Bind("GoodsName") %>'></asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("GoodsName") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddGoodsNew" runat="server"></asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField = "Barcode" HeaderText= "Barcode" ReadOnly="true" />
            <asp:TemplateField HeaderText="Quantity">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("imQuantity") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("imQuantity") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("imQuantity") %>'></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField = "Price" HeaderText= "Price" ReadOnly="true" />
            <asp:BoundField DataField = "TotalPrice" HeaderText= "Total Price" ReadOnly="True"/>
        </Columns>
        <HeaderStyle BackColor= "#135857" Font-Bold= "True" ForeColor= "White" />
        <PagerStyle BackColor= "#135857" ForeColor= "White" HorizontalAlign= "Center" />
        <FooterStyle BackColor="#26a69a" />
        <EditRowStyle BackColor="#4db6ac" />
        <RowStyle BackColor= "#9fe9dd" />
    </asp:GridView>
    <asp:Label BorderWidth="3" BorderColor="Transparent" runat="server"></asp:Label>
    <asp:Button class= "btn btn-primary" ID="SaveButton" Text="Save" onClick="btnSave_Click" runat="server"/>
    <a class= "btn btn-secondary" href="/Management/ImportManagement.aspx">Cancel</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScript" runat="server">
</asp:Content>
