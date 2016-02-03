### Similarities
They use ASP.NET framework to handle whole life cycle of the application. 
It is easy to add module and handlers. They can be written on same language - C#.
The structure architecture of the template projects which Visual Studio creates are
almost same. Common folders and files, App_Start, App_Data, Scripts, Content, Fonts,
Global.asax, StartUp.cs. Same identity system for user authentication coming from ASP.NET.
They can use same render engine Razor.

### Differences
 WebForms using code behind, MVC - model view controller pattern. Each part is separated in folder
and with good architecture. Controllers handles the main logic of the application. It also can be
extracted in separate .dll class library. Views - represents results from actions (response) to the
client. Models can be used in the views or for gather information when user makes registration (input models)
MVC architecture is testable instead of WebForms (there are only tests for UI). Using dependency injection
It's easy to test the behavior of the controller. Intellisence is better in MVC - less magic strings.
 
*There are more but... if I missed someone just place in your feedback.*