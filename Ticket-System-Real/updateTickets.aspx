<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateTickets.aspx.cs" Inherits="Ticket_System_Real.updateTickets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="ticketnr" HeaderText="Ticket ID" />
        <asp:BoundField DataField="tickettype" HeaderText="Ticket type" />
        <asp:BoundField DataField="ticketdate" HeaderText="Date created" />
            <asp:TemplateField>
            <ItemTemplate>
            <asp:Button ID = "btnSelect" runat = "server" Text = "View ticket" OnClick="Row_Selected" CommandName = '<%# Eval("ticketnr") %>' />
            </ItemTemplate>
        </asp:TemplateField>                </Columns>
            </asp:GridView>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
