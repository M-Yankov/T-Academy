<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="WebCalculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Calculator</title>
    <link rel="stylesheet" type="text/css" href="Main.css" />
</head>
<body>
    <form id="form1" runat="server">
        <fieldset>
            <legend>Calculator</legend>

            <div id="calc">
                <asp:Panel runat="server">
                    <asp:Label Text="" runat="server" ID="lblFirstNum" />
                    <asp:Label Text="" runat="server" ID="lblSign" />
                    <asp:TextBox Enabled="false" ID="tbInput" MaxLength="13" runat="server" />
                    <%-- This will not work --%>
                    <%--<asp:RequiredFieldValidator id="RequiredFieldValidator2"
                    ControlToValidate="tbInput"
                    Display="Static"
                    ErrorMessage="*"
                    runat="server"/>--%>
                </asp:Panel>
                <asp:Panel runat="server">
                    <asp:Button Text="1" OnClick="AddToInput" runat="server" />
                    <asp:Button Text="2" OnClick="AddToInput" runat="server" />
                    <asp:Button Text="3" OnClick="AddToInput" runat="server" />
                    <asp:Button Text="+" runat="server" CommandName="Addition" OnCommand="ProcessCommand" />
                    <asp:Button Text="4" OnClick="AddToInput" runat="server" />
                    <asp:Button Text="5" OnClick="AddToInput" runat="server" />
                    <asp:Button Text="6" OnClick="AddToInput" runat="server" />
                    <asp:Button Text="─" runat="server" CommandName="Subtraction" OnCommand="ProcessCommand" />
                    <asp:Button Text="7" OnClick="AddToInput" runat="server" />
                    <asp:Button Text="8" OnClick="AddToInput" runat="server" />
                    <asp:Button Text="9" OnClick="AddToInput" runat="server" />
                    <asp:Button Text="X" runat="server" CommandName="Multiplication" OnCommand="ProcessCommand" />
                    <asp:Button Text="Clear" ID="btnClear" OnClick="ClearInput" runat="server" />
                    <asp:Button Text="0" OnClick="AddToInput" runat="server" />
                    <asp:Button Text="/" runat="server" CommandName="Division" OnCommand="ProcessCommand" />
                    <asp:Button Text="√" runat="server" OnClick="CalculateSquare" />
                </asp:Panel>
                <asp:Panel runat="server">
                    <asp:Button Text="=" ID="btnResult" runat="server" OnClick="CalculateOnClick" />
                </asp:Panel>

            </div>
        </fieldset>
    </form>
</body>
</html>
