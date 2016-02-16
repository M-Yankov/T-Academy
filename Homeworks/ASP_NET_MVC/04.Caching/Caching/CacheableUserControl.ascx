<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CacheableUserControl.ascx.cs" Inherits="Caching.CacheableUserControl" %>
<%@ OutputCache Duration="10" VaryByParam="none" Shared="true" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="Caching" %>
<div style="outline: 3px solid black; padding: 10px;">
    <h1>This is cachable user control</h1>
    <h1>time : <%= DateTime.Now.ToString(CultureInfo.InvariantCulture) %></h1>
    <h1>num: <%= GlobalCounter.Next() %></h1>
</div>