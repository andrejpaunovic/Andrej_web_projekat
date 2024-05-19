<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Upis_termina.aspx.cs" Inherits="Maturanti_2024_B.Pregledkorisnika" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="div_100">
        <%
        Maturanti_2024_B.maturanti_b svi_korisnic = new Maturanti_2024_B.maturanti_b();
        DataSet ds = new DataSet();

      

   %>Izaberi Datum:
            <asp:DropDownList ID="ddlDate" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OD:
        <asp:DropDownList ID="ddlod" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlod_SelectedIndexChanged" OnTextChanged="ddlod_TextChanged">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp; DO:
        <asp:DropDownList ID="ddldo" runat="server">
        </asp:DropDownList>
        <br />
        Izaberi Studio:
            <asp:DropDownList ID="ddlStudio" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Height="40px" OnClick="Button1_Click" style="margin-top: 0px" Text="Proveri" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnunesi" runat="server" Height="40px" style="margin-top: 0px" Text="Zakazi" Width="70px" OnClick="btnunesi_Click" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Height="159px" Width="746px">
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Webp %>" SelectCommand="Select datum, s10_11 as '10-11', s11_12 as '11-12', s12_13 as '12-13', s13_14 as '13-14', s14_15 as '14-15', s15_16 as'15-16', s16_17 as '16-17', s17_18 as '17-18', s18_19 as '18-19', s19_20 as '19-20', s20_21 as '20-21', s21_22 as '21-22', s22_23 as '22-23', s23_24 as '23-24', ime_studija from Termini join Prostorija on id_prostorije = Prostorija.id join Datum on id_datuma = Datum.id where id_datuma = (select MAX(id) from Datum ) order by id_datuma desc"></asp:SqlDataSource>
        <br />
        </div>
    <div>
            <asp:GridView ID="grid_termini" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="748px">
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Webp %>" SelectCommand="Select datum, s10_11 as '10-11', s11_12 as '11-12', s12_13 as '12-13', s13_14 as '13-14', s14_15 as '14-15', s15_16 as'15-16', s16_17 as '16-17', s17_18 as '17-18', s18_19 as '18-19', s19_20 as '19-20', s20_21 as '20-21', s21_22 as '21-22', s22_23 as '22-23', s23_24 as '23-24', ime_studija from Termini join Prostorija on id_prostorije = Prostorija.id join Datum on id_datuma = Datum.id where datum>GETDATE() order by id_datuma desc"></asp:SqlDataSource>
            <br />
        </div>
</asp:Content>
