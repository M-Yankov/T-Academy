<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelloUser.aspx.cs" Inherits="HelloWorldWebForms.HelloUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="What's your name?:" runat="server" />
            <asp:TextBox runat="server" ID="tbName" />
            <asp:Button Text="Submit" runat="server" ID="btnSubmit" OnClick="ButtonOK_Click" OnInit="ButtonOK_Init" OnLoad="ButtonOK_Load" OnPreRender="ButtonOK_PreRender" OnUnload="ButtonOK_Unload" />
        </div>

        <div>
            <h3>Result:</h3>
            <p>
                <asp:Label Text="" ID="lbResult" runat="server" />
            </p>
        </div>
        <hr />
        <div>
            <h3>Result:</h3>
            <p>
                <asp:Label Text="Hello ASP.NET from aspx code" runat="server" />
                <br />
                <asp:Label Text="" ID="helloFromCSharpCode" runat="server" />
            </p>
        </div>
        <hr />
        <div>
            <h3>Page Events</h3>
            <p>
                <asp:BulletedList ID="listPageEvents" runat="server"></asp:BulletedList>
            </p>
        </div>
        <hr />
        <div>
            <h3>Current assembly</h3>
            <p>
                <asp:Label Text="" ID="lbCurrentAssembly" runat="server" />
            </p>
        </div>
        <hr />
    </form>
</body>
</html>
