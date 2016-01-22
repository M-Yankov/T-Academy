<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="UserProfile.Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DetailsView runat="server" ID="viewInfo" AutoGenerateRows="false">
        <Fields>
            <asp:ImageField DataImageUrlField="ImageUrl" ControlStyle-Width="200" HeaderText="Avatar:" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="FirstName" HeaderText="First name:" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="LastName" HeaderText="Last name:" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Age" HeaderText="Age:" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Rating" HeaderText="Rating:" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Friends" HeaderText="Number of friends:" />
            <asp:BoundField  ItemStyle-HorizontalAlign="Center"  DataFormatString="{0:dd MMM yyyy}" ReadOnly="true" DataField="BirthDay" HeaderText="Born at:" />
        </Fields>
    </asp:DetailsView>
</asp:Content>
