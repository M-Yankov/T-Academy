<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="SessionLife.Messages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>2.Create a ASP.NET Web Form which appends the input of a text field when a button is clicked in the Session object and then prints it in a &lt;asp:Label&gt; control. Use List&lt;string&gt; to keep all the text lines entered in the page during the session lifetime.</p>
        <asp:TextBox runat="server" ID="tbMessage" MaxLength="100" />
        <asp:Button Text="Submit" runat="server" OnClick="Unnamed_Click" />
        <br />
        <asp:Label Text="" runat="server" ID="outPut" />
    </div>
    </form>
</body>
</html>
