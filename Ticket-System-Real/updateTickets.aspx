<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateTickets.aspx.cs" Inherits="Ticket_System_Real.updateTickets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View all tickets</title>
</head>
<body>
    <link rel="stylesheet" href="style.css" />
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Height="166px" Width="872px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ticketnr" HeaderText="Ticket ID" />
                    <asp:BoundField DataField="tickettype" HeaderText="Ticket type" />
                    <asp:BoundField DataField="ticketdate" HeaderText="Date created" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnSelect" runat="server" Text="View ticket" OnClick="Row_Selected"  CommandName='<%# Eval("ticketnr") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    </form>
</body>
</html>
