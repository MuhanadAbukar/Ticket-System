﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Webform.aspx.cs" Inherits="Ticket_System_Real.Webform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
            <p>Full navn:</p>
            <asp:TextBox ID="TicketAuthor" runat="server"></asp:TextBox>
            <br />
            <p>Beskrivelse av feilen</p>
            <asp:TextBox ID="TicketDescription" runat="server" Height="173px" Width="345px" TextMode="MultiLine"></asp:TextBox>
            <br />
            <p>Type problem</p>
            <asp:DropDownList ID="TicketType" runat="server">
                     <asp:ListItem Text="Server" Value="0" />
                <asp:ListItem Text="Internet" Value="1" />
                <asp:ListItem Text="Office" Value="2" />
                <asp:ListItem Text="PC" Value="3" />
                <asp:ListItem Text="Other" Value="4" />
            </asp:DropDownList>
            <br />
        <br />
            <asp:Button ID="CreateTicket" runat="server" Text="Lag ticket" OnClick="Button1_Click" />
    </form>
</body>
</html>