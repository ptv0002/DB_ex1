<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CardManagement.aspx.cs" Inherits="DB_ex1.Management.CardManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
        <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" BorderWidth="10" BorderColor="Transparent">Card types</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:LinkButton ForeColor="#333333" BorderWidth="10" BorderColor="Transparent" runat="server" Text="Add" data-target="#addPopup" data-toggle="modal" />    
    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" Width="100%" CellPadding="4" AllowPaging="true" ForeColor="#333333" GridLines="Both" OnRowCommand="Edit_RowCommand" DataKeys="categoryId">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ForeColor = "#333333" runat= "server" Text="Edit" CommandName="EditItem" CommandArgument='<%#Eval("Id") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="Name" HeaderText="Card type" ReadOnly="True" />
            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" />
            <asp:BoundField DataField="LowerBound" HeaderText="Lower bound" ReadOnly="True" />
            <asp:BoundField DataField="PercentDiscount" HeaderText="Percent discount" ReadOnly="True" />
            <asp:BoundField DataField="CreateDate" HeaderText="Create date" ReadOnly="True" />
            <asp:BoundField DataField="CreateBy" HeaderText="Create by" ReadOnly="True" />
            <asp:BoundField DataField="UpdateDate" HeaderText="Update date" ReadOnly="True" />
            <asp:BoundField DataField="UpdateBy" HeaderText="Update by" ReadOnly="True" />
        </Columns>
        <HeaderStyle BackColor="#135857" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#135857" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor= "#9fe9dd" />
        <AlternatingRowStyle BackColor = "White" />
    </asp:GridView>

    <!---Popup for Add--->
    <div class="modal fade" id="addPopup" tabindex="-1">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Add card type</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times</span>
                    </button>
                </div>
                <div class ="modal-body">
                    <asp:Table runat="server" Width="100%">
                        <asp:TableRow>
                            <asp:TableCell>Card name</asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="addName" runat="server" Width="100%"/></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Width="40%"></asp:TableCell>
                            <asp:TableCell><asp:RequiredFieldValidator CSSClass="small" runat="server" ControlToValidate="addName" ErrorMessage="Required field" ForeColor="Red" ValidationGroup="add"/></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Lower bound </asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="addBound" runat="server" Width="100%"/></asp:TableCell>
                        </asp:TableRow>       
                        <asp:TableRow>
                            <asp:TableCell></asp:TableCell>
                            <asp:TableCell><asp:RequiredFieldValidator CSSClass="small" runat="server" ControlToValidate="addBound" ValidationGroup="add" ErrorMessage="Required field" ForeColor="Red"/></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Percent discount</asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="addPercent" runat="server" Width="100%"/></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell></asp:TableCell>
                            <asp:TableCell><asp:RequiredFieldValidator CSSClass="small" runat="server" ControlToValidate="addPercent" ValidationGroup="add" ErrorMessage="Required field" ForeColor="Red"/></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Create by (Insert ID)</asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="createBy" runat="server" width="100%"/></asp:TableCell>
                        </asp:TableRow>  
                        <asp:TableRow>
                            <asp:TableCell><asp:Label ID="idCreateErr" runat="server" CssClass="small" ForeColor="Red" /></asp:TableCell>
                            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="createBy" ErrorMessage="Required field" ForeColor="Red" ValidationGroup="add" /></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table> 
                </div>
                <div class="modal-footer">
                    <asp:Button class= "btn btn-primary" ID="AddSaveButton" Text="Save" onClick="btnSave_Add" runat="server" ValidationGroup="add"/>
                    <a class= "btn btn-secondary" data-dismiss="modal" >Cancel</a>
                </div>
            </div>
        </div>
    </div>
    <!--- Modal popup script--->
    <script type="text/javascript" lang="javascript">
        function ShowPopup(string) {
            $(string).modal('show');
        };
    </script>
    
    <!---Popup for Edit--->
    <div class="modal fade" id="editPopup" tabindex="-1">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Edit card type</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times</span>
                    </button>
                </div>
                <div class ="modal-body">
                    <asp:Label runat="server" Text="Card ID: "><asp:Label runat="server" ID="cId"/></asp:Label>
                    <asp:Table runat="server" Width="100%">
                        <asp:TableRow>
                            <asp:TableCell>Card name</asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="editName" runat="server" Width="100%"/></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Width="40%"></asp:TableCell>
                            <asp:TableCell><asp:RequiredFieldValidator CSSClass="small" runat="server" ControlToValidate="editName" ErrorMessage="Required field" ForeColor="Red" ValidationGroup="edit"/></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Lower bound </asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="editBound" runat="server" Width="100%"/></asp:TableCell>
                        </asp:TableRow>       
                        <asp:TableRow>
                            <asp:TableCell></asp:TableCell>
                            <asp:TableCell><asp:RequiredFieldValidator CSSClass="small" runat="server" ControlToValidate="editBound" ValidationGroup="edit" ErrorMessage="Required field" ForeColor="Red"/></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Percent discount</asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="editPercent" runat="server" Width="100%"/></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell></asp:TableCell>
                            <asp:TableCell><asp:RequiredFieldValidator CSSClass="small" runat="server" ControlToValidate="editPercent" ValidationGroup="edit" ErrorMessage="Required field" ForeColor="Red"/></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Status</asp:TableCell>
                            <asp:TableCell><asp:DropDownList ID="ddStatus" runat="server" Width="100%"/></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow><asp:TableCell>&nbsp</asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Update by (Insert ID)</asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="updateBy" runat="server" width="100%"/></asp:TableCell>
                        </asp:TableRow>  
                        <asp:TableRow>
                            <asp:TableCell><asp:Label ID="idUpdateErr" runat="server" CssClass="small" ForeColor="Red" /></asp:TableCell>
                            <asp:TableCell><asp:RequiredFieldValidator CssClass="small" runat="server" ControlToValidate="updateBy" ErrorMessage="Required field" ForeColor="Red" ValidationGroup="edit" /></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <div class="modal-footer">
                    <asp:Button class= "btn btn-primary" ID="EditSaveButton" Text="Save" onClick="btnSave_Edit" runat="server" ValidationGroup="edit"/>
                    <a class= "btn btn-secondary" data-dismiss="modal">Cancel</a>
                </div>
            </div>
        </div>
    </div>    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScript" runat="server">
</asp:Content>
