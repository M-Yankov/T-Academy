<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TextToImage.aspx.cs" Inherits="WebForms.TextToImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">

                <asp:Label Text="Type Text:" CssClass="control-label" runat="server" />
                <asp:TextBox runat="server" CssClass="form-control" ID="textToBeConvrted"></asp:TextBox>
            </div>

        </div>
        <div class="row text-center">
            <asp:Button Text="Convert to image" runat="server" CssClass="form-control btn btn-warning" OnClick="ConvertImage" />
        </div>
    </div>
</asp:Content>
