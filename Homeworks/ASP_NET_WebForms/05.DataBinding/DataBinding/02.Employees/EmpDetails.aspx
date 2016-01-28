<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="Employees.EmpDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:LinkButton Text="All" runat="server"
            PostBackUrl="/EmployeesPage.aspx" />
        <strong>←--  This is the back button :D</strong>
        <div>
            <h3>With <em>DetailsView</em></h3>
            <asp:DetailsView runat="server" ID="dvEmployee"
                AutoGenerateRows="False"
                DataKeyNames="EmployeeID"
                DataSourceID="Employees">
                <HeaderTemplate>
                    <h3 style="margin: 0">ID: <%# this.Request.Params["id"] %>
                    </h3>
                </HeaderTemplate>
                <HeaderStyle BackColor="Window"
                    BorderColor="YellowGreen"
                    Font-Size="22"
                    BorderStyle="Double"
                    HorizontalAlign="Center"
                    BorderWidth="5" />
                <Fields>
                    <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" InsertVisible="False" ReadOnly="True" SortExpression="EmployeeID" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy" />
                    <asp:BoundField DataField="BirthDate" DataFormatString="{0:dd-MM-yyyy}" HeaderText="BirthDate" SortExpression="BirthDate" />
                    <asp:BoundField DataField="HireDate" DataFormatString="{0:dd-MM-yyyy}" HeaderText="HireDate" SortExpression="HireDate" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                    <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode" />
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                    <asp:BoundField DataField="HomePhone" HeaderText="HomePhone" SortExpression="HomePhone" />
                    <asp:BoundField DataField="Extension" HeaderText="Extension" SortExpression="Extension" />
                    <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
                    <asp:BoundField DataField="ReportsTo" HeaderText="ReportsTo" SortExpression="ReportsTo" />
                    <asp:BoundField DataField="PhotoPath" HeaderText="PhotoPath" SortExpression="PhotoPath" />
                </Fields>
            </asp:DetailsView>
            <asp:SqlDataSource ID="Employees" runat="server" ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>" SelectCommand="SELECT * FROM [Employees] WHERE ([EmployeeID] = @EmployeeID)">
                <SelectParameters>
                    <asp:QueryStringParameter Name="EmployeeID" QueryStringField="id" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>

        <div>
            <h3>With <em>FormView</em></h3>
            <asp:FormView DataSourceID="Employees" runat="server">
                
                <HeaderStyle BackColor="Window"
                    BorderColor="YellowGreen"
                    Font-Size="22"
                    BorderStyle="Double"
                    HorizontalAlign="Center"
                    BorderWidth="5" />
                <HeaderTemplate>
                    <h3 style="margin: 0">
                        <%# DataBinder.Eval(Container.DataItem, "FirstName") %>
                        <%# DataBinder.Eval(Container.DataItem, "LastName") %>
                    </h3>
                </HeaderTemplate>
                <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem, "BirthDate", "{0: dd-MM-yyyy}") %>
                    <table border="1" style="border-collapse: collapse">
                        <tr>
                            <td></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "EmployeeID") %></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "LastName") %></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "FirstName") %></td>
                        </tr>
                        <tr>
                            <td>Title:</td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Title") %></td>
                        </tr>
                        <tr>
                            <td>TitleOfCourtesy:</td>
                            <td><%# DataBinder.Eval(Container.DataItem, "TitleOfCourtesy") %></td>
                        </tr>
                        <tr>
                            <td>BirthDate:</td>
                            <td><%# DataBinder.Eval(Container.DataItem, "BirthDate") %></td>
                        </tr>
                        <tr>
                            <td>HireDate:</td>
                            <td><%# DataBinder.Eval(Container.DataItem, "HireDate") %></td>
                        </tr>
                        <tr>
                            <td>Address:</td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Address") %></td>
                        </tr>
                        <tr>
                            <td>City:</td>
                            <td><%# DataBinder.Eval(Container.DataItem, "City") %></td>
                        </tr>
                        <tr>
                            <td>Region:</td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Region") %></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "PostalCode") %></td>
                        </tr>
                        <tr>
                            <td>Country:</td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Country") %></td>
                        </tr>
                        <tr>
                            <td>HomePhone:</td>
                            <td><%# DataBinder.Eval(Container.DataItem, "HomePhone") %></td>
                        </tr>
                        <tr>
                            <td>Extension:</td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Extension") %></td>
                        </tr>
                        <tr>
                            <td>Notes:</td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Notes") %></td>
                        </tr>
                        <tr>
                            <td>ReportsTo:</td>
                            <td><%# DataBinder.Eval(Container.DataItem, "ReportsTo") %></td>
                        </tr>
                        <tr>
                            <td>PhotoPath:</td>
                            <td><%# DataBinder.Eval(Container.DataItem, "PhotoPath") %></td>
                        </tr>
                    </table>

                </ItemTemplate>
            </asp:FormView>
        </div>
    </form>
</body>
</html>
