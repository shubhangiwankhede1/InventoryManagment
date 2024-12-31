<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemMaster.aspx.cs" Inherits="InventoryManagment.ItemMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
      <h2>Item Management</h2>
    <table class="table table-info">
        <tr>
            <td>Item_name</td>
            <td>
                <asp:TextBox runat="server" ID="txtitemname" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validatorname" runat="server" ControlToValidate="txtitemname"  Display="Dynamic" ForeColor="Red" ErrorMessage="please Enter Item Name"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Category</td>
            <td>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlcategory">
                    <asp:ListItem Value="0" Text="---Select Category---"></asp:ListItem>
                    <asp:ListItem Value="Electronics" Text="Electronics"></asp:ListItem>
                    <asp:ListItem Value="Consumable" Text="Consumable"></asp:ListItem>
                    <asp:ListItem Value="Furniture" Text="Furniture"></asp:ListItem>
                    <asp:ListItem Value="Stationary" Text="Stationary"></asp:ListItem>
                                                
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="0" runat="server" ControlToValidate="ddlcategory" ErrorMessage="please select Category" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

            </td>
        </tr>
         <tr>
            <td>Rate</td>
            <td>
                <asp:TextBox runat="server" ID="txtrate" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtrate" ErrorMessage="please Enter Rate" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtrate" ValidationExpression="^[1-9][0-9]*$"  ErrorMessage="RegularExpressionValidator"></asp:RegularExpressionValidator>
            </td>
        </tr>
         <tr>
            <td>Balance_quantity</td>
            <td>
                <asp:TextBox runat="server" ID="txtqty" CssClass="form-control"></asp:TextBox>

            </td>
       </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button runat="server" ID="btnsave" CssClass="btn btn-success" Text="Save" OnClick="btnsave_Click" />
                <asp:Button runat="server" ID="btnupdate" CssClass="btn btn-primary" Text="Update" OnClick="btnupdate_Click" />
                <asp:Button runat="server" ID="btncancel" CssClass="btn btn-danger" Text="Cancel" OnClick="btncancel_Click" />

            </td>
        </tr>

    </table>
        <br />
        <br />
        <div class="row">
            <div class="col col-6">
                 <asp:TextBox runat="server" placeholder="Search here" ID="txtsearch" CssClass="form-control" ></asp:TextBox>
            </div>
             <div class="col-6">
             <asp:Button runat="server" ID="btnsearch" Text="Search" CssClass="btn btn-info" OnClick="btnsearch_Click" />

             </div>
            
        </div>
       
        <asp:GridView runat="server" ID="gvItem" CssClass="table table-responsive" DataKeyNames="Item_id" OnRowEditing="gvItem_RowEditing" OnRowDeleting="gvItem_RowDeleting" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Item_id" HeaderText="Id"  />
                <asp:BoundField DataField="Item_name" HeaderText="Name"  />
                <asp:BoundField DataField="Category" HeaderText="Category"  />
                <asp:BoundField DataField="Rate" HeaderText="Rate"  />
                <asp:BoundField DataField="Balance_quantity" HeaderText="Quantity"  />
                
                <asp:ButtonField ControlStyle-CssClass="btn btn-info" ButtonType="Button" Text="edit" CommandName="edit" />
                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-danger" Text="Delete" CommandName="delete" />

            </Columns>
        </asp:GridView>
</div>
</asp:Content>
