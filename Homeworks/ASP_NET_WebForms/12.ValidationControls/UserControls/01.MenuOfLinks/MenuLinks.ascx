
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuLinks.ascx.cs" Inherits="MenuOfLinks.MenuLinks" %>


<style runat="server" id="style"></style>
<asp:DataList ID="dataList" runat="server" >
    <ItemTemplate >        
        <asp:HyperLink Font-Names='<%# new string[] { this.Font } %>' ForeColor='<%# this.Color %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Url") %>' 
            Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>'
            runat="server" />
    </ItemTemplate>
</asp:DataList>
