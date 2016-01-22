<%@ Page Title="" Language="C#" MasterPageFile="~/English/EnglishMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NestedMasterPages.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentEnglish" runat="server">
    <h3>Hot Products:</h3>
    <table>
        <tr>
            <th>Product:</th>
            <th>Category</th>
            <th>Price:</th>
            <th>More:</th>
        </tr>
        <tr>
            <td>Hot Chilly Papers</td>
            <td>Food</td>
            <td>$44</td>
            <td>
                <asp:Button Text="INFO" runat="server" OnClientClick="return false"/>
            </td>
        </tr>
        <tr>
            <td>BMW Z3 - Toy</td>
            <td>Electronics</td>
            <td>$20</td>
            <td><asp:Button Text="INFO" runat="server" OnClientClick="return false"/></td>
        </tr>
        <tr>
            <td>Cowboy hat</td>
            <td>Stuff</td>
            <td>$5</td>
            <td><asp:Button Text="INFO" runat="server" OnClientClick="return false"/></td>
        </tr>
        <tr>
            <td>Optic wireless mouse</td>
            <td>Electronics</td>
            <td>$14</td>
            <td><asp:Button Text="INFO" runat="server" OnClientClick="return false"/></td>
        </tr>
        <tr>
            <td>Wireless keyboard</td>
            <td>Electronics</td>
            <td>$23</td>
            <td><asp:Button Text="INFO" runat="server" OnClientClick="return false"/></td>
        </tr>
        <tr>
            <td>Laptop Lenovo Thinkpad</td>
            <td>Electronics</td>
            <td>$999</td>
            <td><asp:Button Text="INFO" runat="server" OnClientClick="return false"/></td>
        </tr>
    </table>
</asp:Content>
