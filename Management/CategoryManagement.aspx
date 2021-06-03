<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CategoryManagement.aspx.cs" Inherits="DB_ex1.Management.CategoryManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" BorderWidth="10" BorderColor="Transparent">Categories</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:LinkButton ForeColor="#333333" BorderWidth="10" BorderColor="Transparent" runat="server" Text="Add" OnClick="btnAdd"/>    
    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" Width="100%" CellPadding="4" AllowPaging="true" ForeColor="#333333" GridLines="Both" OnRowCommand="Edit_RowCommand" DataKeys="categoryId">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ForeColor = "#333333" runat= "server" Text="Edit" CommandName="EditItem" CommandArgument='<%#Eval("Id") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="categoryName" HeaderText="Category" ReadOnly="True" />
            <asp:BoundField DataField="categoryStatus" HeaderText="Status" ReadOnly="True" />
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
                    <h5 class="modal-title">Add Category</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times</span>
                    </button>
                </div>
                <div class ="modal-body">
                    <div><asp:Label runat="server" Text="Category Name"/></div>
                    <div><asp:TextBox ID="addCatName" runat="server"/></div>
                    <div><asp:RequiredFieldValidator CSSClass="small" runat="server" ControlToValidate="addCatName" ValidationGroup="add" ErrorMessage="Category name is required" ForeColor="Red"/></div>
                    <div><asp:Label runat="server" Text="Create By"/></div>
                    <div><asp:DropDownList ID="ddCreateBy" runat="server"/></div>
                    <div><asp:Label runat="server" ID="ddCreateErr" ForeColor="Red" CssClass="small"/></div>
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
            $(string).modal();
        };
    </script>
    
    <!---Popup for Edit--->
    <div class="modal fade" id="editPopup" tabindex="-1">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Edit Category</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times</span>
                    </button>
                </div>
                <div class ="modal-body">
                    <div>
                        <asp:Label runat="server" Text="Category ID: "><asp:Label runat="server" ID="cId"/></asp:Label>
                    </div>
                    <div><asp:Label runat="server" Text="Category Name"/></div>
                    <div><asp:TextBox ID="editCatName" runat="server"/></div>
                    <div><asp:RequiredFieldValidator CSSClass="small" runat="server" ControlToValidate="editCatName" ErrorMessage="Category name is required" ForeColor="Red" ValidationGroup="edit"/></div>
                    <div><asp:Label runat="server" Text="Status"/></div>
                    <div><asp:DropDownList ID="ddStatus" runat="server"/></div> 
                    <div><asp:Label runat="server" Text="Update By"/></div>
                    <div><asp:DropDownList ID="ddUpdateBy" runat="server"/></div>
                    <div><asp:Label runat="server" ID="ddUpdateErr" ForeColor="Red" CssClass="small"/></div>
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
