<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Maturanti_2024_B.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Ime i prezime<lablel>:</lablel>
            <asp:TextBox ID="txtemail" runat="server" TextMode="SingleLine" ></asp:TextBox>
            <br />
            Broj telefona<label>: </label>&nbsp;<asp:TextBox ID="txtlozinka" runat="server" TextMode="Phone" OnTextChanged="txtlozinka_TextChanged"></asp:TextBox>

            <br />

        </div>
        <p style="margin-left: 250px">

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Dalje" />

        </p>
    </form>
</body>
</html>
