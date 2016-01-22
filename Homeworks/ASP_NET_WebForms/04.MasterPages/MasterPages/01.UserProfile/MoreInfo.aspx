<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MoreInfo.aspx.cs" Inherits="UserProfile.MoreInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>Page created at <%= DateTime.Now %></p>
    <p>For more information please visit &nbsp;
        <a href="https://github.com/TelerikAcademy/ASP.NET-Web-Forms/tree/master/04.%20ASP.NET-Master-Pages/Homework">requirements</a>
    </p>
</asp:Content>
