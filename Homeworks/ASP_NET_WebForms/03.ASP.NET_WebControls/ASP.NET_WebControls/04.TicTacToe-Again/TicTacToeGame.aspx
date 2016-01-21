<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicTacToeGame.aspx.cs" Inherits="TicTacToe_Again.TicTacToeGame" %>

<%-- OMG! --%>
<%@ Register Assembly="TicTacToe-Again" TagPrefix="tttGame" Namespace="TicTacToe_AgainControls"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TTT-Game</title>
    <link rel="stylesheet" href="Site.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        
        <h2>Please open this shit in chrome!</h2>
        <p>You play with "X"</p>
        <div>
            <%-- Somehow magically this works --%>
            <tttGame:MyCustomListBox runat="server" ID="gameBoard" CssClass="big-text board">
                <asp:ListItem Value="0" Text="" />
                <asp:ListItem Value="1" Text="" />
                <asp:ListItem Value="2" Text="" />
                <asp:ListItem Value="3" Text="" />
                <asp:ListItem Value="4" Text="" />
                <asp:ListItem Value="5" Text="" />
                <asp:ListItem Value="6" Text="" />
                <asp:ListItem Value="7" Text="" />
                <asp:ListItem Value="8" Text="" />
            </tttGame:MyCustomListBox>
        </div>
        <br />
        <asp:Label Text="" Visible="false" ID="lblError" CssClass="big-text error" runat="server" />
        <br />
        <asp:Label Text="" Visible="false" ID="lblInfo" CssClass="big-text joint-color" runat="server" />
        <br />
        <div>
            <asp:Button Text="PLAY" OnClick="btnPlay_Click" runat="server" ID="btnPlay" />
        </div>
        <div>
            <a href="/TicTacToeGame.aspx" visible="false" id="linkTryAgain" runat="server">Try again?</a>
        </div>
    </form>
</body>
</html>
