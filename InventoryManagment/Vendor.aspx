<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vendor.aspx.cs" Inherits="InventoryManagment.Vendor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Vendor Master</h3>
    <table>
        <tr>
            <td>
                Vendor Name
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtvendorname" Text="please enter name" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvendorname" ControlToValidate="txtvendorname" ErrorMessage="please Enter name" ForeColor="Red" Display="Dynamic" ></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button runat="server" ID="btnsave" Text="Add" OnClick="btnsave_Click" CssClass="btn btn-info" />
                <asp:Button runat="server" ID="btnupdate" Text="Update" OnClick="btnupdate_Click" CssClass="btn btn-success" />
                <asp:Button runat="server" ID="btnreset" Text="Reset" OnClick="btnreset_Click"  CssClass="btn btn-danger" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:GridView runat="server" ID="GVVendor" AutoGenerateColumns="false" CssClass="table table-responsive" DataKeyNames="Vendor_id">
        <Columns>
            <asp:TemplateField
        </Columns>
    </asp:GridView>
</asp:Content>
