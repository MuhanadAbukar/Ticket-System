 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Webform.aspx.cs" Inherits="Ticket_System_Real.Webform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create a ticket</title>
</head>
<body>
         <link rel="stylesheet" href="style.css"/>
       
<ul>
  <li><a class="active" href="Webform.aspx">Create ticket</a></li>
  <li><a  href="ticketStatus.aspx">View ticket status</a></li>
</ul>
    <form id="form1" runat="server">
       
            <p>Full navn:</p>
            <asp:TextBox ID="TicketAuthor" runat="server" CssClass="TextBox23" ></asp:TextBox>
            <br />
        <p>Epost:</p>
            <asp:TextBox ID="TicketEmail" runat="server" CssClass="TextBox23" ></asp:TextBox>
            <br />
            <p>Beskrivelse av feilen</p>
            <asp:TextBox ID="TicketDescription" runat="server" CssClass="TextBox23" Height="173px" Width="345px" TextMode="MultiLine"  AutoPostBack="True" OnTextChanged="TicketDescription_TextChanged"></asp:TextBox>
            <asp:Label ID="Label1" runat="server"></asp:Label>
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
