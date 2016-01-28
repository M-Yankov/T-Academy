<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageArticle.aspx.cs" Inherits="WebCounter.PageArticle" %>

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
    <p>
        <em>Answer: The counter is reset when server stops!</em>
        <br />
        <strong>This example uses a <code>this.Application</code> for save the page count</strong> 
        <div>
            Go to <a href="/SQLDataBaseCounter.aspx">Database</a> page.
        </div>
    </p>

    <form id="form1" runat="server">
        <div>
            <h3>Tincidunt integer eu augue augue nunc elit dolor
            </h3>
            <p>
                Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.
                Placerat suscipit, orci nisl iaculis eros, a tincidunt nisi odio eget lorem nulla condimentum tempor mattis ut vitae feugiat augue cras ut metus a risus iaculis scelerisque eu ac ante.
            </p>

            <p>
                Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.
                Placerat suscipit, orci nisl iaculis eros, a tincidunt nisi odio eget lorem nulla condimentum tempor mattis ut vitae feugiat augue cras ut metus a risus iaculis scelerisque eu ac ante.
            </p>

            <p>
                Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.
                Placerat suscipit, orci nisl iaculis eros, a tincidunt nisi odio eget lorem nulla condimentum tempor mattis ut vitae feugiat augue cras ut metus a risus iaculis scelerisque eu ac ante.
            </p>
        </div>
        <asp:Image ImageUrl="" ID="image" runat="server" />
    </form>
    <footer>
        <em>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.
        </em>
    </footer>
</body>
</html>
