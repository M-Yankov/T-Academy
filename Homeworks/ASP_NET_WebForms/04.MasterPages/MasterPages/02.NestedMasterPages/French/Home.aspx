<%@ Page Title="" Language="C#" MasterPageFile="~/French/FrenchMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NestedMasterPages.French.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentFrench" runat="server">
    <h3>Produits phares: </h3>
    <table>
        <tr>
            <th>produit: </th>
            <th>Catégorie </th>
            <th>Prix: </th>
            <th>Plus: </th>
        </tr>
        <tr>
            <td>Hot Chilly Papers </td>
            <td>Alimentation </td>
            <td>44 € </td>
            <td>
                <asp:Button Text="Détail" runat="server" OnClientClick="return false" />
            </td>
        </tr>
        <tr>
            <td>BMW Z3 - Toy </td>
            <td>Électronique </td>
            <td>20 € </td>
            <td>
                <asp:Button Text="Détail" runat="server" OnClientClick="return false" />
            </td>
        </tr>
        <tr>
            <td>Cowboy chapeau </td>
            <td>Des trucs </td>
            <td>5 € </td>
            <td>
                <asp:Button
                    Text="Détail" runat="server" OnClientClick="return false" />

            </td>
        </tr>
        <tr>
            <td>souris sans fil optique </td>
            <td>Électronique </td>
            <td>14 € </td>
            <td>
                <asp:Button Text="Détail" runat="server" OnClientClick="return false" />

            </td>
        </tr>
        <tr>
            <td>Clavier sans fil </td>
            <td>Électronique </td>
            <td>23 € </td>
            <td>
                <asp:Button
                    Text="Détail" runat="server" OnClientClick="return false" />

            </td>
        </tr>
        <tr>
            <td>Ordinateur portable Lenovo Thinkpad </td>
            <td>Électronique </td>
            <td>999 € </td>
            <td>
                <asp:Button
                    Text="Détail" runat="server" OnClientClick="return false" />

            </td>
        </tr>
    </table>
</asp:Content>
