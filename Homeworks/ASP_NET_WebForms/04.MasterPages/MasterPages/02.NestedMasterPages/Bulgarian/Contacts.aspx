<%@ Page Title="" Language="C#" MasterPageFile="~/Bulgarian/BulgarianMaster.Master" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="NestedMasterPages.Bulgarian.Contacts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBulgarian" runat="server">
    
    <label>Е-мейл:</label>
    <input type="email" placeholder="Мейлът ви">
    <br />
    <label>Категория:</label>
    <select>
        <option>Електроника</option>
        <option>Храни</option>
        <option>Предмети</option>
    </select>
    <br />

    <label>Коментар:</label>
    <textarea name="comment" cols="" placeholder="пиши тука..." rows="3">
</textarea>
</asp:Content>
