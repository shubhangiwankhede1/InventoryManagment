<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="InventoryManagment.Department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Department Master</h3>
    <table>
        <tr>
            <td>Department Name</td>
            <td>
                <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDeptName" runat="server" ErrorMessage="Please Enter Department Name"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td>

            </td>
            <td> 
                <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-info" OnClick="btnsave_Click" />
                <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="btn btn-success" OnClick="btnupdate_Click" />
                <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btncancel_Click" />
                
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:GridView ID="GVDepartment" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive" DataKeyNames="Department_id" OnRowDeleting="GVDepartment_RowDeleting" OnRowEditing="GVDepartment_RowEditing" OnPageIndexChanging="GVDepartment_PageIndexChanging" OnRowCancelingEdit="GVDepartment_RowCancelingEdit">
        <Columns>
            
            <asp:BoundField DataField="Department_id" HeaderText="ID" />
            <asp:BoundField DataField="Department_name" HeaderText="Department Name" />
            <asp:ButtonField ButtonType="Button" CommandName="edit" Text="Edit" />
            <asp:TemplateField>
                <ItemTemplate> 

                    <asp:LinkButton runat="server" ID="btndelete" Text="Delete" CommandName="delete" OnClientClick="return confirm('are you sure');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <%--<asp:ButtonField ButtonType="Button" CommandName="delete" Text="Delete"   />--%>

        </Columns>
    </asp:GridView>
    
</asp:Content>
