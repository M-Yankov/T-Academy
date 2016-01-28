<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesPage.aspx.cs" Inherits="Employees.EmployeesPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees - Task 2</title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:SqlDataSource ID="NorthwindEmpls" runat="server"
            ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>" SelectCommand="SELECT * FROM [Employees]"></asp:SqlDataSource>

        <h3>With GridView</h3>
        <div>
            <asp:GridView ID="gridEmployees" runat="server"
                AllowPaging="True"
                PageSize="10"
                AutoGenerateColumns="False"
                DataKeyNames="EmployeeID"
                DataSourceID="NorthwindEmpls"
                GridLines="None"
                CellPadding="3"
                CellSpacing="1"
                BorderStyle="Ridge" OnPageIndexChanging="OnPageIndexChange">
                <PagerStyle ForeColor="Black" HorizontalAlign="Right"
                    BackColor="#C6C3C6"></PagerStyle>
                <HeaderStyle BackColor="#ff6600" />
                <Columns>
                    <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" InsertVisible="False" ReadOnly="True" SortExpression="EmployeeID" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="BirthDate" DataFormatString="{0:dd MMM yyyy}" HeaderText="BirthDate" SortExpression="BirthDate" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                    <asp:HyperLinkField HeaderText="Info" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="/EmpDetails.aspx?id={0}" DataTextField="FirstName" DataTextFormatString="Info About {0}" />
                </Columns>
            </asp:GridView>
            <asp:Label Text="<%# this.gridEmployees.PageCount %>" runat="server" ID="label" />
        </div>

        <hr />
        <h3>With Repeater
        </h3>

        <table border="1" style="border-collapse: collapse">
            <tr>
                <th>ID</th>
                <th>FirstName</th>
                <th>LastName</th>
                <th>Title</th>
                <th>BirthDate</th>
                <th>Address</th>
                <th>City</th>
                <th>Country</th>
            </tr>
            <asp:Repeater DataSourceID="NorthwindEmpls" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "EmployeeID") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "FirstName") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "LastName") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Title") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "BirthDate") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Address") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "City") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Country") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>

        <hr />
        <h3>With List View </h3>

        <asp:ListView runat="server" DataSourceID="NorthwindEmpls">
            <ItemTemplate>
                <div style ="float: left;display:inline-block; width: 20%">
                    ID: <strong><%# DataBinder.Eval(Container.DataItem, "EmployeeID") %></strong>
                    <br />
                    FullName: <strong><%# DataBinder.Eval(Container.DataItem, "FirstName") %> <%# DataBinder.Eval(Container.DataItem, "LastName") %></strong>
                    <br />
                    Title: <strong><%# DataBinder.Eval(Container.DataItem, "Title") %></strong>
                    <br />
                    Born at: <strong><%# DataBinder.Eval(Container.DataItem, "BirthDate") %></strong>
                    <br />
                    Address: <strong><%# DataBinder.Eval(Container.DataItem, "Address") %></strong>
                    <br />
                    City: <strong><%# DataBinder.Eval(Container.DataItem, "City") %></strong>
                    <br />
                    Country: <strong><%# DataBinder.Eval(Container.DataItem, "Country") %></strong>
                    <hr />
                </div>
            </ItemTemplate>
        </asp:ListView>
    </form>
</body>
</html>
