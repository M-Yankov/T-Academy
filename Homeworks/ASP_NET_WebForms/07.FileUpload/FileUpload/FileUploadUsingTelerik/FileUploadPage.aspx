<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUploadPage.aspx.cs" Inherits="FileUploadUsingTelerik.FileUploadPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Homework</title>
    <link rel="stylesheet" href="http://kendo.cdn.telerik.com/2016.1.112/styles/kendo.common.min.css" type="text/css" />
    <link rel="stylesheet" href="http://kendo.cdn.telerik.com/2016.1.112/styles/kendo.highcontrast.min.css" type="text/css" />
    <script src="https://code.jquery.com/jquery-2.2.0.min.js"></script>
    <script src="http://kendo.cdn.telerik.com/2016.1.112/js/kendo.core.min.js"></script>
    <script src="http://kendo.cdn.telerik.com/2016.1.112/js/kendo.upload.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload runat="server" ID="uploadInput" accept=".zip" type="file" />
        </div>
        <asp:Panel runat="server" ID="successPanel" Visible="false" >
            <h2>File contents uploaded! Check database.</h2>
        </asp:Panel>
    </form>
    <script>
        $(document).ready(function () {
            $("#uploadInput").kendoUpload({
                theme: "highcontrast",
                async: {
                    saveUrl: "FileUploadPage.aspx",
                    autoUpload: false
                },
                multiple: false
            });
        });
    </script>
</body>
</html>
