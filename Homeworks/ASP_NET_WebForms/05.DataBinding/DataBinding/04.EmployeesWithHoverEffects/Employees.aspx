<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesWithHoverEffects.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hover effect Over grid Task - 4</title>
    <style>
        tr.hidden {
            position: relative;
        }

            tr.hidden td:last-of-type {
                display: none;
            }

            tr.hidden:hover td:last-of-type {
                display: block;
                position: absolute;
                margin-left: 10px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView runat="server" ID="gridEmployees"
                AutoGenerateColumns="False"
                DataKeyNames="EmployeeID"
                DataSourceID="Northwind"
                AllowPaging="true"
                AllowSorting="true"
                PageSize="10"
                OnRowDataBound="OnRowDataBind">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div style="width: 150px">
                                <div style="text-align: center">
                                    <img src="Original-Facebook-Geek-Profile-Avatar-6.jpg" alt="Profile" width="50" />
                                </div>
                                Address:
                                <em>
                                    <%# DataBinder.Eval(Container.DataItem, "Address") %>
                                </em>
                                <br />
                                Phone:
                                <em>
                                    <%# DataBinder.Eval(Container.DataItem, "HomePhone") %>
                                </em>
                                <hr />
                                Position:
                                <em>
                                    <%# DataBinder.Eval(Container.DataItem, "Title") %>
                                </em>
                                <hr />
                                Notes:
                                <br />
                                <%# DataBinder.Eval(Container.DataItem, "Notes") %>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
            <asp:SqlDataSource ID="Northwind" runat="server"
                ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>"
                SelectCommand="SELECT * FROM [Employees]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
