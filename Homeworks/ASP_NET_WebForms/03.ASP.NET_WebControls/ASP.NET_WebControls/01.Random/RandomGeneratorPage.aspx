<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomGeneratorPage.aspx.cs" Inherits="GetRandomNumber.RandomGeneratorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>First Task - Random</title>
</head>
<body>

    <form id="form1" runat="server">
        <div id="errContainer" runat="server">
            <h3 id="errTitle" runat="server"></h3>
            <p id="errMessage" runat="server"></p>
        </div>
        <fieldset>
            <legend>Generate Random Number With HTML server controls</legend>
            <div>
                <label>Min Number: </label>
                <input id="tbMinNumber" type="number" runat="server" />
                <label>Max Number: </label>
                <input id="tbMaxNumber" type="number" runat="server" />
                <input id="generateRandom" type="button"
                    runat="server" value="Generate"
                    onserverclick="ButtonSubmit_Click" />
            </div>
            <div id="result" runat="server"></div>
        </fieldset>

        <fieldset>
            <legend>Generate Random number with Web server controls</legend>
            <div>
                <asp:Label Text="Min Number" runat="server" />
                <asp:TextBox ID="tbWebMinNumber" runat="server" type="number" />
                <asp:Label Text="Max Number" runat="server" />
                <asp:TextBox ID="tbWebMaxNumber" runat="server" type="number" />
                <asp:Button Text="Generate" runat="server" OnClick="ButtonSubmit_Click" />
                <br />
                <asp:Label Text="" ID="lblWebResult" runat="server" />
            </div>
        </fieldset>
    </form>
</body>
</html>
