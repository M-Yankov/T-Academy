<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Summator.aspx.cs" Inherits="WebForms.Summator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h2 class="text-center">Sum your numbers</h2>
        </div>
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <table class="table table-bordered">
                    <tr>
                        <td> <asp:Label Text="Fist Number:" CssClass="control-label" runat="server" />       </td>
                        <td>
                            <asp:TextBox runat="server" class="form-control" ID="tbFirstNumber"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Second Number:" CssClass="control-label" runat="server" /></td>
                        <td>
                            <asp:TextBox runat="server" class="form-control" ID="tbSecondNumber"/>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="text-center">
                            <asp:Button CssClass="btn btn-info" Text="Calculate" ID="Calculate" runat="server" OnClick="CalculateInputs" />

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Result" CssClass="control-label" runat="server" /></td>
                        <td  >
                            <asp:Label CssClass="has-success" ID="ResultContainer" runat="server">
                                <asp:TextBox runat="server" ID="tbResult" CssClass="form-control has-success" />
                                </asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>

    </div>


</asp:Content>
