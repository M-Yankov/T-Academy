<%@ Page Title="" Language="C#" MasterPageFile="~/French/FrenchMaster.Master" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="NestedMasterPages.French.Contacts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentFrench" runat="server">
    <label>Votre mail:</label>
    <input type="email" placeholder="Email">
    <br />
    <label>Catégorie:</label>
    <select>
        <option>Électronique</option>
        <option>Aliments</option>
        <option>Des trucs</option>
    </select>
    <br />
    <label>Commentaire:</label>
    <textarea name="comment" cols="" placeholder="Vos commentaires" rows="3">
</textarea>
</asp:Content>
