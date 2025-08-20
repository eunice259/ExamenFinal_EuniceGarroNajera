<%@ Page Title="Plantas" MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true"
    CodeBehind="Plantas.aspx.cs" Inherits="ExamenFinal_EuniceGarroNajera.CapaVistas.Plantas" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
  <h2>Plantas</h2>

  <div>
    <asp:TextBox ID="txtNombre" runat="server" Placeholder="Nombre"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="txtNombre" runat="server" ErrorMessage="*" ForeColor="Red" />

    <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
    <asp:RequiredFieldValidator ControlToValidate="ddlCategoria" InitialValue="0" runat="server" ErrorMessage="*" ForeColor="Red" />

    <asp:TextBox ID="txtDesc" runat="server" Placeholder="Descripción" Width="300"></asp:TextBox>
    <asp:Button ID="btnGuardar" runat="server" Text="Agregar" OnClick="btnGuardar_Click" />
    <asp:HiddenField ID="hfId" runat="server" />
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
  </div>
  <hr />

  <asp:GridView ID="gvPlantas" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
      OnRowCommand="gvPlantas_RowCommand">
    <Columns>
      <asp:BoundField DataField="Id" HeaderText="Id" />
      <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
      <asp:BoundField DataField="CategoriaNombre" HeaderText="Categoría" />
      <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
      <asp:ButtonField Text="Editar" CommandName="Editar" />
      <asp:ButtonField Text="Eliminar" CommandName="Eliminar" />
    </Columns>
  </asp:GridView>
</asp:Content>
