<%@ Page Title="" Language="C#" MasterPageFile="~/Bulgarian/BulgarianMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NestedMasterPages.Bulgarian.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBulgarian" runat="server">
    <h3>Популярни продукти:</h3>
    <table>
        <tr>
            <th>Продукт:</th>
            <th>Тип:</th>
            <th>Цена:</th>
            <th>Още:</th>
        </tr>
        <tr>
            <td>Люти чушки</td>
            <td>Храни</td>
            <td>1.50лв.</td>
            <td>
                <asp:Button Text="Детайли" runat="server" OnClientClick="return false"/>
            </td>
        </tr>
        <tr>
            <td>BMW Z3 - Кола играчка</td>
            <td>Електроника</td>
            <td>11.99лв.</td>
            <td><asp:Button Text="Детайли" runat="server" OnClientClick="return false"/></td>
        </tr>
        <tr>
            <td>Каубойска шапка</td>
            <td>Предмети</td>
            <td>4.89лв.</td>
            <td><asp:Button Text="Детайли" runat="server" OnClientClick="return false"/></td>
        </tr>
        <tr>
            <td>Оптична мишка Microsoft</td>
            <td>Детайли</td>
            <td>13.58лв.</td>
            <td><asp:Button Text="Детайли" runat="server" OnClientClick="return false"/></td>
        </tr>
        <tr>
            <td>Безжична клавиатура 4Tech</td>
            <td>Детайли</td>
            <td>24.89лв.</td>
            <td><asp:Button Text="Детайли" runat="server" OnClientClick="return false"/></td>
        </tr>
        <tr>
            <td>Лаптоп Lenovo Thinkpad</td>
            <td>Детайли</td>
            <td>999.99лв.</td>
            <td><asp:Button Text="Детайли" runat="server" OnClientClick="return false"/></td>
        </tr>
    </table>
</asp:Content>
