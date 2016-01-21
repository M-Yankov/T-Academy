<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterStudent.aspx.cs" Inherits="StudentsAndCourses.RegisterStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <fieldset>
            <legend>Register student</legend>
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:Label Text="First name:" runat="server" /></td>
                        <td>
                            <asp:TextBox required="required" ID="tbFirstName" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Last name:" runat="server" /></td>
                        <td>
                            <asp:TextBox required="required" ID="tbLastName" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Faculty:" runat="server" /></td>
                        <td>
                            <asp:TextBox ID="tbFaculty" required="required" type="number" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="University:" runat="server" /></td>
                        <td>
                            <asp:DropDownList ID="listUni" runat="server">
                                <asp:ListItem Text="Telerik Academy" />
                                <asp:ListItem Text="Software University" />
                                <asp:ListItem Text="New Bulgarian University" />
                                <asp:ListItem Text="Sofia University" />
                                <asp:ListItem Text="National Sport Academy" />
                                <asp:ListItem Text="University of... abe UNSS" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Specialty:" runat="server" /></td>
                        <td>
                            <asp:DropDownList ID="listSpec" runat="server">
                                <asp:ListItem Text="Information Technologies" />
                                <asp:ListItem Text="Biotechnologies" />
                                <asp:ListItem Text="Programing" />
                                <asp:ListItem Text="Economics" />
                                <asp:ListItem Text="High class Maths" />
                                <asp:ListItem Text="Biotechnologies" />
                                <asp:ListItem Text="Administrator" />
                                <asp:ListItem Text="Sport Trainer" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Courses:" runat="server" /></td>
                        <td>
                            <asp:ListBox ID="listCourses" SelectionMode="Multiple" runat="server">
                                <asp:ListItem Text="Football" />
                                <asp:ListItem Text="C# programing" />
                                <asp:ListItem Text="C++ programing" />
                                <asp:ListItem Text="Object Oriented programing" />
                                <asp:ListItem Text="Government administration" />
                                <asp:ListItem Text="Network structures & router management" />
                                <asp:ListItem Text="Tennis" />
                                <asp:ListItem Text="Bioengineering" />
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button Text="Submit" runat="server" OnClick="SubmitStudent_Click" /></td>
                    </tr>
                </table>
                <div id="panelResult" runat="server">
                </div>

            </div>
        </fieldset>
    </form>
</body>
</html>
