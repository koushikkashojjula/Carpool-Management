<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarpoolManagementSystem.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home : Carpool Management</title>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div>
        <asp:TextBox ID="NameTextBox" placeholder="What is your name?" runat="server"></asp:TextBox>
        <asp:Button ID="OKButton" runat="server" Text="Ok" onClick="SubmitNameMethod"/>

    </div>
        <br />
        <br />
        <br />
        <asp:Label ID="NameLabel" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
