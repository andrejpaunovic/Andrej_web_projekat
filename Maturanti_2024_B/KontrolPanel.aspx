<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="KontrolPanel.aspx.cs" Inherits="Maturanti_2024_B.KontrolPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
       Response.Write(""+Session["korisnik"]);

       %>
</asp:Content>
