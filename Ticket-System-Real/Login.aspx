<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ticket_System_Real.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="imgcontainer">
    <img src="https://www.pngall.com/wp-content/uploads/12/Avatar-PNG-Image.png" alt="Avatar" class="avatar">
  </div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
  <div class="container">
      <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <label for="uname"><b>
      <br />
      <br />
      Username</b></label>
      <asp:TextBox ID="username"  runat="server" CssClass="hello"></asp:TextBox>
      
    <label for="psw"><b>Password</b></label>
      <asp:TextBox ID="password" TextMode="Password" runat="server" CssClass="hello"> </asp:TextBox>
      <asp:Button ID="Register" runat="server" cssClass="hi" Text="Register" OnClick="Register_Click" />
    <label>
    </label>
  </div>

  <div class="container" style="background-color:#f1f1f1">
  </div>
    </form>
</body>
</html>
