<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="InventoryManagment.Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Employee Details</h3>
    <table class="table table-info">
        <tr>
            <td>Employee Name</td>
            <td> 
                <asp:TextBox runat="server" ID="txtname" CssClass="form-control" ></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="save" ID="RequiredFieldValidator1" ForeColor="Red" Display="Dynamic" runat="server"  ControlToValidate="txtname" ErrorMessage="please enter name"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Phone</td>
            <td>
                <asp:TextBox runat="server" ID="txtphone" CssClass="form-control" ></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="save" ID="RequiredFieldValidator2" ForeColor="Red" Display="Dynamic" runat="server"  ControlToValidate="txtphone" ErrorMessage="please enter Phone Number"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td>

            </td>
            <td>
                <asp:Button runat="server" ID="btnsave" ValidationGroup="save" CssClass="btn btn-success" Text="Add" OnClick="btnsave_Click" />
                <asp:Button runat="server" ID="btnupdate" CssClass="btn btn-info" Text="Update" OnClick="btnupdate_Click" />
                <asp:Button runat="server" ID="btnreset" CssClass="btn btn-danger" Text="Reset" OnClick="btnreset_Click" />

            </td>
        </tr>
    </table>
    <br />
    <br />
  <table class="table table-responsive">
      <thead>
          <tr>
              <th>Employee ID</th>
            <th>Employee Name</th>
            <th>Employee Phone</th>
              <th>Action</th>
          </tr>

      </thead>
      <tbody>
          <asp:Repeater runat="server" ID="RPEmployee"  >
              <ItemTemplate>
                  <tr>
                      <td>
    
                        <asp:Label runat="server" ID="lblid" Text=<%# Eval("ID") %>></asp:Label>
                        </td>
                      <td>
                          
                          <asp:Label runat="server" ID="lblname" Text=<%# Eval("Name") %>></asp:Label>
                      </td>
                      <td>
                          <asp:Label runat="server" ID="lblphone" Text=<%# Eval("Phone") %>></asp:Label>
                      </td>
                      <td>
                          <asp:linkbutton runat="server" ID="btnedit" CssClass="btn btn-info" CommandName="Edit" OnCommand="btnedit_Command" CommandArgument='<%# Eval("ID") %>' Text="edit" />
                          <asp:linkbutton runat="server" ID="btndelete" CssClass="btn btn-danger" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' OnCommand="btndelete_Command" OnClientClick="return confirm('are you sure')" Text="Delete" />
                      </td>
                  </tr>
              </ItemTemplate>
          </asp:Repeater>
      </tbody>
  </table>
</asp:Content>
