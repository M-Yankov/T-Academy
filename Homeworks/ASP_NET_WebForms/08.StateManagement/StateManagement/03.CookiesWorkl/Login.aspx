<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CookiesWorkl.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>3.In ASPX page holding a TextBox run a JavaScript code that deletes the ViewState hidden field variable in ASPX page. What happens at postback?</p>
        <p style="font-style:italic">Type what ever in the text boxes.</p>
        <asp:Label Text="Username: "  runat="server" />
        <asp:TextBox runat="server" ID="tbUserName" />
        <br />
        <%-- Passwork  <- OMG :D :) --%>
        <asp:Label Text="Passwork: " runat="server" />        
        <asp:TextBox TextMode="Password" runat="server" />
        <br />
        <asp:Button Text="Login" runat="server" OnClick="Unnamed_Click"/>
    </div>
    </form>
</body>
</html>
