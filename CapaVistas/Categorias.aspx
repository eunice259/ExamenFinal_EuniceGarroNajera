<%@ Page Title="Categorías" MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true"
    CodeBehind="Categorias.aspx.cs" Inherits="ExamenFinal_EuniceGarroNajera.CapaVistas.Categorias" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
  <h2>Categorías</h2>

  <asp:TextBox ID="txtCat" runat="server" Placeholder="Nombre categoría"></asp:TextBox>
  <asp:RequiredFieldValidator ControlToValidate="txtCat" runat="server" ErrorMessage="*" ForeColor="Red" />
  <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
  <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
  <hr />
  <asp:GridView ID="gvCat" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
      OnRowEditing="gvCat_RowEditing" OnRowCancelingEdit="gvCat_RowCancelingEdit"
      OnRowUpdating="gvCat_RowUpdating" OnRowDeleting="gvCat_RowDeleting">
    <Columns>
      <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="true" />
      <asp:BoundField DataField="NombreCategoria" HeaderText="Nombre" />
      <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
    </Columns>
  </asp:GridView>
</asp:Content>
