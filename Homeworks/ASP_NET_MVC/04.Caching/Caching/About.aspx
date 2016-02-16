<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Caching.About" %>


<%@ Register Src="~/CacheableUserControl.ascx" TagPrefix="my" TagName="CacheableUserControl" %>

<%@ OutputCache Duration="60" VaryByParam="none" %>
<script runat="server">
   protected static string GetCurrentTime(HttpContext ctx) {
      return DateTime.Now.ToString();
   }
</script>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
        
   <h3>Page number with Response.WriteSubstitution: <% Response.WriteSubstitution(GetCurrentTime); %></h3>

     <my:CacheableUserControl runat="server" />
</asp:Content>
