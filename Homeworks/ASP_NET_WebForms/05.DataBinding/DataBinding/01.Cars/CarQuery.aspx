<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/CarQuery.aspx.cs" Inherits="Cars.CarQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Car Market</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="dropProducer" runat="server"
                ItemType="Cars.Producer"
                AutoPostBack="true"
                DataTextField="Name" AppendDataBoundItems="true">
            </asp:DropDownList>
            <asp:Label Text="<%# this.dropProducer.SelectedItem.Text %>" runat="server" />

            <asp:DropDownList ID="dropModel" runat="server"
                DataTextField="Name"
                DataSource="<%# this.GetModelsFromProducer(this.dropProducer.SelectedItem.Text) %>">
            </asp:DropDownList>
            <asp:RadioButtonList ID="radListEngine" RepeatDirection="Horizontal" runat="server">
            </asp:RadioButtonList>

            <br />
            <asp:Button Text="Filter" runat="server" OnClick="FilterCars_Click" />

            <pre><asp:Literal Text="Results will be shown here" ID="literal" Mode="Transform" runat="server" /></pre>
        </div>
    </form>
</body>
</html>
