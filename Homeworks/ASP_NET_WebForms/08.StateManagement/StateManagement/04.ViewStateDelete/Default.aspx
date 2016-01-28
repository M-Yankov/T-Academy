<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ViewStateDelete.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Task - 4</title>
    <script src="http://code.jquery.com/jquery-1.12.0.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>4.In ASPX page holding a TextBox run a JavaScript code that deletes the ViewState hidden field variable in ASPX page. What happens at postback?</p>
            <p style="font-style:italic">Answer: If view states are removed, page loses it's state (i.e. where user was clicked), postbacks not work well .</p>

            <%-- Just some controls to generate view state --%>
            <asp:DropDownList runat="server">
                <asp:ListItem>Pesho</asp:ListItem>
                <asp:ListItem>Stamat</asp:ListItem>
                <asp:ListItem>Ivan</asp:ListItem>
                <asp:ListItem>Hallow</asp:ListItem>
                <asp:ListItem>Pa</asp:ListItem>
            </asp:DropDownList>

            <asp:Calendar runat="server"></asp:Calendar>

            <asp:CheckBoxList runat="server">
                <asp:ListItem>Beer</asp:ListItem>
                <asp:ListItem>Whiskey</asp:ListItem>
                <asp:ListItem>Wine</asp:ListItem>
                <asp:ListItem>Vodka</asp:ListItem>
            </asp:CheckBoxList>

            <asp:TextBox runat="server" />
            <asp:Button runat="server" Text="Press" />
        </div>
    </form>
    <script>
        $(document).ready(function () {
            var collectionOfViewStates = $("input[type=hidden]");
            for (var i = 0; i < collectionOfViewStates.length; i++) {
                collectionOfViewStates[i].remove();
            }
        })
    </script>
</body>
</html>
