
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="redirectWhenCreated.aspx.cs" Inherits="Ticket_System_Real.redirectWhenCreated" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <ul>
  <li><a href="Webform.aspx">Create ticket</a></li>
  <li><a  href="ticketStatus.aspx">View ticket status</a></li>
</ul>
    <link rel="stylesheet" href="style.css"/>
    <form id="form1" runat="server">
        <br />
                <br />
                <br />
                <br />



            <asp:Label ID="Ticketnr" runat="server" Text="Label" CssClass="Header"></asp:Label>
            <br />
        <br />
        <br />
        <br />

    </form>
</body>
</html>
