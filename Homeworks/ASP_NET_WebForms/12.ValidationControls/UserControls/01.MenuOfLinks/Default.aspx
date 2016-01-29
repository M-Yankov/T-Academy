<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MenuOfLinks.Default" %>

<%@ Register Src="~/MenuLinks.ascx" TagName="MenuLinks" TagPrefix="userControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <userControls:MenuLinks ID="linkMenu" Color="PaleVioletRed" Font="Consolas" runat="server" />
    </div>
    </form>
</body>
</html>
