<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="ExportOrderAdd.aspx.cs" Inherits="DB_ex1.AddForms.ExportOrderAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" BorderWidth="10" BorderColor="transparent">Add export order</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Table ID="exportInfo" CellPadding="4" runat="server" BackColor="Transparent" BorderColor="Transparent" BorderWidth="10" width="100%">
        <asp:TableRow>
            <asp:TableCell Text="Export Order ID: ">
                <asp:Label ID="EoId" runat="server"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Customer name</asp:TableCell>
            <asp:TableCell>Phone number</asp:TableCell>
            <asp:TableCell RowSpan="2" Width="50%" HorizontalAlign="Right">    
                <asp:Button Width="50%" class= "btn btn-primary" Text="Save" onClick="btnSave_Click" runat="server" ValidationGroup="info"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:DropDownList ID="ddCustomer" runat="server" width="100%"/></asp:TableCell>
            <asp:TableCell><asp:Label ID="phone" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Address</asp:TableCell>
            <asp:TableCell>Payment status</asp:TableCell>
            <asp:TableCell RowSpan="2" Width="50%" HorizontalAlign="Right">
                <asp:Button Width="50%" class= "btn btn-success" Text="Print" onClick="btnPrint_Click" runat="server" ValidationGroup="info"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="address" runat="server" /></asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="ddPaymentStatus" runat="server" width="100%"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Card discount</asp:TableCell>
            <asp:TableCell>Payment type</asp:TableCell>
            <asp:TableCell RowSpan="2" Width="50%" HorizontalAlign="Right">
                <asp:Button Width="50%" Height="100%" class= "btn btn-secondary" Text="Cancel" onClick="btnCancel_Click" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:DropDownList ID="ddCard" runat="server" width="100%"/></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="paymentType" runat="server" width="100%"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small"  runat="server" ValidationGroup="info" ControlToValidate="paymentType" ErrorMessage="Required field" ForeColor="Red"/></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>Transaction score</asp:TableCell>
            <asp:TableCell>New membership score</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="orderScore" runat="server" /></asp:TableCell>
            <asp:TableCell><asp:Label ID="newScore" runat="server" /></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>Total</asp:TableCell>
            <asp:TableCell>Other discount</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="total" runat="server" /></asp:TableCell>
            <asp:TableCell><asp:Textbox ID="otherDiscount" runat="server" width="100%"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ValidationGroup="info" ControlToValidate="otherDiscount" ErrorMessage="Required field" ForeColor="Red"/></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label Text="Create by (Insert ID)" runat="server"/>&emsp;
                <asp:Label ID="idErr" runat="server" CssClass="small" ForeColor="Red"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="createBy" runat="server" width="100%"/></asp:TableCell>
            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ValidationGroup="info" ControlToValidate="createBy" ErrorMessage="Required field" ForeColor="Red"/></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:GridView style="height:50px;overflow:auto" HeaderStyle-CssClass="FixedHeader" FooterStyle-CssClass="FixedHeader" runat="server" ID="gv" AutoGenerateColumns="False" CellPadding= "4" AllowPaging= "True" ForeColor= "#333333"  Width= "100%" OnRowEditing="OnRowEditing" ShowFooter="True" OnRowDeleting="OnRowDeleting">
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
                    <asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="ddGoodsNew" ValidationGroup="insert" InitialValue="-Select-" ErrorMessage="Required field" ForeColor="Red"/>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField = "Barcode" HeaderText= "Barcode" ReadOnly="true" />
            <asp:TemplateField HeaderText="Quantity">
                <EditItemTemplate>
                    <asp:TextBox ID="qty" runat="server" Text='<%# Bind("Quantity") %>' Width="100%"/>
                    <asp:RequiredFieldValidator CssClass="small" runat="server" ValidationGroup="update" ControlToValidate="qty" ErrorMessage="Required field" ForeColor="Red"/>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Quantity") %>'/>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="qtyNew" runat="server" Width="100%"/>
                    <asp:RequiredFieldValidator CssClass="small" runat="server" ValidationGroup="insert" ControlToValidate="qtyNew" ErrorMessage="Required field" ForeColor="Red"/>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price">
                <EditItemTemplate>
                    <asp:TextBox ID="price" runat="server" Text='<%# Bind("Price") %>' Width="100%"/>
                    <asp:RequiredFieldValidator CssClass="small" runat="server" ValidationGroup="update" ControlToValidate="price" ErrorMessage="Required field" ForeColor="Red"/>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Price") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount">
                <EditItemTemplate>
                    <asp:TextBox ID="discount" runat="server" Text='<%# Bind("Discount") %>' Width="100%"/>
                    <asp:RequiredFieldValidator CssClass="small" runat="server" ValidationGroup="update" ControlToValidate="discount" ErrorMessage="Required field" ForeColor="Red"/>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Discount") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField = "TotalPrice" HeaderText= "Total Price" ReadOnly="true"/>
        </Columns>
        <HeaderStyle BackColor= "#135857" Font-Bold= "True" ForeColor= "White" />
        <PagerStyle BackColor= "#135857" ForeColor= "White" HorizontalAlign= "Center" />
        <FooterStyle BackColor="#26a69a" />
        <EditRowStyle BackColor="#4db6ac" />
        <RowStyle BackColor= "White" />
        <AlternatingRowStyle BackColor = "#9fe9dd" />
    </asp:GridView>
    <asp:Table runat="server" GridLines="Both" Width="100%" CellPadding="4" ID="emptyTable">
        <asp:TableRow BackColor= "#135857" Font-Bold= "True" ForeColor= "White" Width= "100%" >
            <asp:TableHeaderCell></asp:TableHeaderCell>
            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
            <asp:TableHeaderCell>Good's name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Barcode</asp:TableHeaderCell>
            <asp:TableHeaderCell>Quantity</asp:TableHeaderCell>
            <asp:TableHeaderCell>Price</asp:TableHeaderCell>
            <asp:TableHeaderCell>Discount</asp:TableHeaderCell>
            <asp:TableHeaderCell>Total price</asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow BackColor="#26a69a"  ForeColor= "#333333"  Width= "100%" >
            <asp:TableCell><asp:LinkButton ForeColor = "#333333" runat= "server" Text="Add" OnClick="OnAdd_Empty" ValidationGroup="info"/></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddGoodsEmpty" runat="server" Width="100%"/>
                <asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="ddGoodsEmpty" ValidationGroup="info" InitialValue="-Select-" ErrorMessage="Required field" ForeColor="Red"/>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="qtyEmpty" runat="server" Width="100%"/>
                <asp:RequiredFieldValidator CssClass="small" runat="server" ValidationGroup="info" ControlToValidate="qtyEmpty" ErrorMessage="Required field" ForeColor="Red"/>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <div class="modal fade" id="deletePopup" tabindex="-1">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Confirmation</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times</span>
                    </button>
                </div>
                <div class ="modal-body">
                    <div>Are you sure to delete this item?</div>
                </div>
                <div class="modal-footer">
                    <asp:Button class= "btn btn-danger" Text="Delete" onClick="btnDelete_Click" runat="server" ValidationGroup="delete"/>
                    <a class= "btn btn-secondary" data-dismiss="modal">Cancel</a>
                </div>
            </div>
        </div>
    </div>    
    <!--- Modal popup script--->
    <script type="text/javascript" lang="javascript">
        function ShowPopup() {
            $('#deletePopup').modal("show");
        };
    </script>
</asp:Content>
