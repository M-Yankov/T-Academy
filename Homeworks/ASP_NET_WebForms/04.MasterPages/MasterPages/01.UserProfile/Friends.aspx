<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="UserProfile.Friends" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Your Friends</h2>
    <asp:GridView ID="gridFriends" ItemType="UserProfile.User" AllowSorting="true" AutoGenerateColumns="false"
         runat="server" PageSize="5" AllowPaging="true" OnSorting="OnSorting" OnPageIndexChanging="OnChangePageIndex">
        <Columns>
            <asp:ImageField DataImageUrlField="ImageUrl" ControlStyle-Width="50" HeaderText="Avatar"/>
            <asp:DynamicField  HeaderText="First name" DataField="FirstName"/>
            <asp:BoundField  HeaderText="Last name" DataField="LastName"/>
            <asp:DynamicField  HeaderText="Age" DataField="Age"/>
            <asp:DynamicField  HeaderText="Rating" DataFormatString="{0:F2}" DataField="Rating"/>
            <asp:BoundField  HeaderText="Friends" DataField="Friends"/>
            <asp:BoundField  HeaderText="Date of birth" DataFormatString="{0:dd MMM yyyy}" DataField="BirthDay"/>
        </Columns>
    </asp:GridView>
</asp:Content>
