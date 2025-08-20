<%@ Page Title="Reporte" MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true"
    CodeBehind="Reporte.aspx.cs" Inherits="ExamenFinal_EuniceGarroNajera.CapaVistas.Reporte" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
  <h2>Reporte: Plantas por categoría</h2>
  <asp:GridView ID="gvRep" runat="server" AutoGenerateColumns="true"></asp:GridView>
</asp:Content>
