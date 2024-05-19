<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Adminova_strana.aspx.cs" Inherits="Maturanti_2024_B.Primer2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txt_Datum" runat="server" ReadOnly="True"></asp:TextBox>
&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Napravi nov datum" />
    <br />
    <br />
    <br />
    <asp:DropDownList ID="ddlDate" runat="server">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Izaberi" />
    <br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Width="986px">
        <Columns>
            <asp:BoundField DataField="ime_studija" HeaderText="ime_studija" SortExpression="ime_studija" />
            <asp:BoundField DataField="pocetak_termina" HeaderText="pocetak_termina" SortExpression="pocetak_termina" />
            <asp:BoundField DataField="kraj_termina" HeaderText="kraj_termina" SortExpression="kraj_termina" />
            <asp:BoundField DataField="ime" HeaderText="ime" SortExpression="ime" />
            <asp:BoundField DataField="broj_telefona" HeaderText="broj_telefona" SortExpression="broj_telefona" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Webp %>" SelectCommand="Select ime_studija,pocetak_termina,kraj_termina,ime, broj_telefona from Zakazivanje join Prostorija on id_prostorije=Prostorija.id join Datum on id_datuma=Datum.id join Osoba on id_osoba= Osoba.id order by id_datuma desc"></asp:SqlDataSource>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="datum" HeaderText="datum" SortExpression="datum" />
            <asp:CheckBoxField DataField="10-11" HeaderText="10-11" SortExpression="10-11" />
            <asp:CheckBoxField DataField="11-12" HeaderText="11-12" SortExpression="11-12" />
            <asp:CheckBoxField DataField="12-13" HeaderText="12-13" SortExpression="12-13" />
            <asp:CheckBoxField DataField="13-14" HeaderText="13-14" SortExpression="13-14" />
            <asp:CheckBoxField DataField="14-15" HeaderText="14-15" SortExpression="14-15" />
            <asp:CheckBoxField DataField="15-16" HeaderText="15-16" SortExpression="15-16" />
            <asp:CheckBoxField DataField="16-17" HeaderText="16-17" SortExpression="16-17" />
            <asp:CheckBoxField DataField="17-18" HeaderText="17-18" SortExpression="17-18" />
            <asp:CheckBoxField DataField="18-19" HeaderText="18-19" SortExpression="18-19" />
            <asp:CheckBoxField DataField="19-20" HeaderText="19-20" SortExpression="19-20" />
            <asp:CheckBoxField DataField="20-21" HeaderText="20-21" SortExpression="20-21" />
            <asp:CheckBoxField DataField="21-22" HeaderText="21-22" SortExpression="21-22" />
            <asp:CheckBoxField DataField="22-23" HeaderText="22-23" SortExpression="22-23" />
            <asp:CheckBoxField DataField="23-24" HeaderText="23-24" SortExpression="23-24" />
            <asp:BoundField DataField="ime_studija" HeaderText="ime_studija" SortExpression="ime_studija" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Webp %>" SelectCommand="Select datum, s10_11 as '10-11', s11_12 as '11-12', s12_13 as '12-13', s13_14 as '13-14', s14_15 as '14-15', s15_16 as'15-16', s16_17 as '16-17', s17_18 as '17-18', s18_19 as '18-19', s19_20 as '19-20', s20_21 as '20-21', s21_22 as '21-22', s22_23 as '22-23', s23_24 as '23-24', ime_studija from Termini join Prostorija on id_prostorije = Prostorija.id join Datum on id_datuma = Datum.id  order by id_datuma desc"></asp:SqlDataSource>
    <br />
&nbsp;
</asp:Content>
