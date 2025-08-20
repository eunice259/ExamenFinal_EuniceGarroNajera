<%@ Page Title="Consulta" MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true"
    CodeBehind="Consulta.aspx.cs" Inherits="ExamenFinal_EuniceGarroNajera.CapaVistas.Consulta" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
  <h2>Consulta por categoría</h2>
  <asp:DropDownList ID="ddlCat" runat="server"></asp:DropDownList>
  <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
  <hr/>
  <asp:GridView ID="gvRes" runat="server" AutoGenerateColumns="true"></asp:GridView>
</asp:Content>
