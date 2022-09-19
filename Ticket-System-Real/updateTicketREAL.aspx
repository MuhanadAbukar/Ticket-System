<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateTicketREAL.aspx.cs" Inherits="Ticket_System_Real.updateTicketREAL" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View specific ticket</title>
</head>
<body>
             <link rel="stylesheet" href="style.css"/>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Height="145px" Width="815px">
                <Columns>
                    <asp:BoundField DataField="ticketnr" HeaderText="Ticket ID" />
                    <asp:BoundField DataField="ticketdescription" HeaderText="Ticket Description" />
                    <asp:BoundField DataField="ticketauthor" HeaderText="Ticket Author" />
                    <asp:BoundField DataField="ticketemail" HeaderText="Author Email" />
                    <asp:BoundField DataField="ticketdate" HeaderText="Date created" />
                    
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
            <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Text="Ikke startet" Value="0" />
                <asp:ListItem Text="Startet" Value="1" />
                <asp:ListItem Text="Fikset ferdig" Value="2" />
               
            </asp:DropDownList>

            <br />
            <asp:Button ID="btnSelect" runat="server" Text="Update ticket status" OnClick="btnSelect_Click" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"  Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
