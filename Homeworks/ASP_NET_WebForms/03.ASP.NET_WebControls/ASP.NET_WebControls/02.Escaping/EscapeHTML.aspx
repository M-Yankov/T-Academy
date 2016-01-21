<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EscapeHTML.aspx.cs" Inherits="EscapingTask.EscapeHTML" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label Text="Enter text:" runat="server" />
        <asp:TextBox ID="tbTextToEscape" runat="server" />
        <asp:Button ID="btnEscape" Text="Click" runat="server" OnClick="TransferText_Click" />
        <hr />
        <h3>Results:</h3>
        <asp:TextBox ID="tbResult" runat="server" />  
        <br />
        <asp:Literal Text="I'am a literal" Mode="Encode" ID="litResult" runat="server" />
        <br />
        <asp:Label Text="Mode=&quot;Encode&quot; don't helps on labels!" Mode="Encode" ID="lblResult"  runat="server" />
    </div>
    </form>
</body>
</html>
