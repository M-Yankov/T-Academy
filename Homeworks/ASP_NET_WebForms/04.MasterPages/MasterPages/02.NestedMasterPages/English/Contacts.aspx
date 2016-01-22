<%@ Page Title="" Language="C#" MasterPageFile="~/English/EnglishMaster.Master" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="NestedMasterPages.English.Contacts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentEnglish" runat="server">
    <label>Your mail:</label>
    <input type="email" placeholder="Email">
    <br />
    <label>Category:</label>
    <select>
        <option>Electronics</option>
        <option>Food</option>
        <option>Stuff</option>
    </select>
    <br />
    <label>Comment:</label>
    <textarea name="comment" cols="" placeholder="Your comments" rows="3">
</textarea>
</asp:Content>
