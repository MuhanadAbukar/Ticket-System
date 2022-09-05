<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ticketStatus.aspx.cs" Inherits="Ticket_System_Real.ticketStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <link rel="stylesheet" href="style.css"/>
    <form id="form1" runat="server">
        
<ul>
  <li><a href="Webform.aspx">Create ticket</a></li>
  <li><a class="active"  href="ticketStatus.aspx">View ticket status</a></li>
</ul>
        <asp:TextBox ID="ticketIDTextBox" runat="server" placeholder="Enter ticket ID" Height="21px" Width="191px" CssClass="Header2"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Check ticket status" OnClick="Button1_Click" />
        <br />
        <p>Date: <asp:Label ID="Date" runat="server" Text=""></asp:Label></p>
        <p>Author: <asp:Label ID="Author" runat="server" Text=""></asp:Label></p>
        <p>Status: <asp:Label ID="Status" runat="server" Text=""></asp:Label></p>
        <p>Description: <asp:Label ID="Description" runat="server" Text=""></asp:Label></p>

        <asp:GridView ID="GridView1" Visible="true" runat="server">
        </asp:GridView>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
