<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CategoryManagement.aspx.cs" Inherits="DB_ex1.Management.CategoryManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <asp:Label Font-Bold="true" ForeColor="Black" Font-Size="XX-Large" runat="server" BorderWidth="10" BorderColor="Transparent">Categories</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:LinkButton ForeColor="#333333" BorderWidth="10" BorderColor="Transparent" runat="server" data-target="#addPopup" data-toggle="modal" Text="Add" />    
    <asp:GridView ID="gvCategory" runat="server" AutoGenerateColumns="false" Width="100%" CellPadding="4" AllowPaging="true" ForeColor="#333333" GridLines="Both" OnRowCommand="Edit_RowCommand" DataKeys="categoryId">
        <AlternatingRowStyle BackColor="White"/>
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ForeColor = "#333333" runat= "server" Text="Edit" CommandName="Edit" data-target="#editPopup" data-toggle="modal"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="categoryName" HeaderText="Category" ReadOnly="True" />
            <asp:BoundField DataField="categoryStatus" HeaderText="Status" ReadOnly="True" />
            <asp:BoundField DataField="CreateDate" HeaderText="Create date" ReadOnly="True" />
            <asp:BoundField DataField="CreateBy" HeaderText="Create by" ReadOnly="True" />
            <asp:BoundField DataField="UpdateDate" HeaderText="Update date" ReadOnly="True" />
            <asp:BoundField DataField="UpdateBy" HeaderText="Update by" ReadOnly="True" />
        </Columns>
        <HeaderStyle BackColor="#135857" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#135857" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#9fe9dd" />
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
                    <div><asp:Label runat="server" Text="Category Name"></asp:Label></div>
                    <div><asp:TextBox ID="addCatName" runat="server"></asp:TextBox></div>
                    <div class="small">
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="addCatName" ErrorMessage="Category name is required" ForeColor="Red" ValidationGroup="addGroup"></asp:RequiredFieldValidator>
                    </div>
                    <div><asp:Label runat="server" Text="Create By"></asp:Label></div>
                    <div><asp:DropDownList ID="ddCreateBy" runat="server"></asp:DropDownList></div>
                    <div class="small">
                        <asp:Label runat="server" id="ddCreateError"></asp:Label></div>              
                </div>
                <div class="modal-footer">
                    <asp:Button class= "btn btn-primary" ID="AddSaveButton" Text="Save" onClick="btnSave_Add" runat="server" ValidationGroup="addGroup"/>
                    <a class= "btn btn-secondary" data-dismiss="modal" >Cancel</a>
                </div>
            </div>
        </div>
    </div>

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
                        <asp:Label runat="server" Text="Category ID: "><asp:Label runat="server" ID="cId" Text='<%# Bind("id") %>'></asp:Label></asp:Label>
                    </div>
                    <div><asp:Label runat="server" Text="Category Name"></asp:Label></div>
                    <div><asp:TextBox ID="editCatName" runat="server" Text='<%# Bind("categoryName") %>'></asp:TextBox></div>
                    <div><asp:Label runat="server" Text="Status"></asp:Label></div>
                    <div><asp:DropDownList ID="ddStatus" runat="server"></asp:DropDownList></div> 
                    <div><asp:Label runat="server" Text="Update By"></asp:Label></div>
                    <div><asp:DropDownList ID="ddUpdateBy" runat="server"></asp:DropDownList></div>
                    <div class="small"><asp:Label runat ="server" ID="ddUpdateError"></asp:Label></div>              
                </div>
                <div class="modal-footer">
                    <asp:Button class= "btn btn-primary" ID="EditSaveButton" Text="Save" onClick="btnSave_Edit" runat="server" ValidationGroup="editGroup"/>
                    <a class= "btn btn-secondary" data-dismiss="modal" >Cancel</a>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScript" runat="server">
</asp:Content>
