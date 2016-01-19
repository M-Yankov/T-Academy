# ASP.NET Component Files

I decided that i no need a whole ASP.NET WebForms project for this homework, but will describe a 
common files for simple project. 

* _APP_Start_ folder:  - It's a special folder where, it holds configuration of the application.
In most cases there are static classes, (Maybe it's only one place where static is used. **Do not use static!!!**)
    * _BundleConfig_ - Manages .js and .css files. All javaScript files are in one minimized, and CSS styles are in one.
    It's make better performance, when sends to the client. Because it's only one file. (And another one for CSS)
    * _RouteConfig_ - the routing configure is little strange here not like (web API). This file makes
    routes friendly - instead of `/About.aspx` it makes the same page to look like `/About`
* _App_data_ folder: - if the connection string in web.congfig is not changed, the Application uses a local 
    database stored in this folder. It's perfect for fast examples and temporary projects.
* _Content_ folder: - there are all .css styles stores.
* _Properties_ folder: - AssemblyInfo.cs holds information about the assembly.
* _Scripts_ folder: - contains all javaScripts files. It's good practice to be in one folder.
* _Fonts_ folder: - contains some fonts for UI. Most frequency installed by bootstrap.

* _.aspx_ files: Each .aspx file is consist of three files: `.aspx`, `.aspx.cs` and `designer` file
    * .aspx - is the page file with HTML elements and ASP.NET components. each  &lt;asp: should have attribute `runat="server"` and 
    should be inside a &lt;form tag, which also have a `runat="server"` attribute. There are more tags:
    CssClass, Text, Value e.t.c. Most used is `ID`. The value of the ID is the name of the designer filed control component
    which can accessed in .aspx.cs file. This page file can extend the _Master page_.
    * .aspx.cs - partial page class inherits `System.Web.UI.Page`. is called `code behinde` where you can access &lt;asp: controls on the page that have an `ID` attribute.
    There the logic of the page with all events of the controls. Page has many events like `On_Load`, `Pre_Render`, controls may have
    events like a `OnClick`, `OnTextChange` e.t.c.;
    * .aspx.designer.cs - there are the other part of the partial class where fields are defined.
* _master_ page: - the main layout of the application. It's good practice navigation, footer and aside elements to be
    same on each page, but only the content to be different.
* _web.config_ file: - custom handlers and modules can be registered there. It's all configuration about the server.