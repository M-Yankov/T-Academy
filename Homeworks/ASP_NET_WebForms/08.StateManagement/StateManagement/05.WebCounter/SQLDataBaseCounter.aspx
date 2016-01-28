<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SQLDataBaseCounter.aspx.cs" Inherits="WebCounter.SQLDataBaseCounter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <p>
        5. Implement a graphical Web counter. It should display as JPEG image the total number of visitors of the requested .aspx page since the start of the Web application. Keep the number of visitors in the Application object. What happens when the Web server is stopped?
        <ul>
            <li>Re-implement the previous task to keep the total number of visitors in SQL Server database.
            </li>
        </ul>
    </p>
    <em>Answer: The counter is reset when server stops!</em>
        <br />
        <strong>This example uses a <code>MS SQL Database</code> for save th page count. Data is persistent</strong>
    <form id="form1" runat="server">
    <div>
         <asp:Image ID="image" runat="server" />
    </div>
    </form>
</body>
</html>
