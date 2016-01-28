using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace FileUploadUsingTelerik
{
    public partial class FileUploadPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpPostedFile file1 = this.Request.Files["uploadInput"];

            if (file1 == null)
            {
                this.successPanel.Visible = false;
                this.Response.StatusCode = 400;
                return;
            }

            if (!file1.ContentType.Contains("zip"))
            {
                this.successPanel.Visible = false;
                this.Response.StatusCode = 400;
                return;
            }

            // add reference in project : using System.IO.Compression and using System.IO.Compression.FileSystem
            using (ZipArchive zipArchive = new ZipArchive(file1.InputStream))
            {
                foreach (ZipArchiveEntry file in zipArchive.Entries)
                {
                    if (!file.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    /*
                    string extention = Path.GetExtension(file.FullName);
                    if (extention != ".txt")
                    {
                        continue;
                    }
                    */

                    StringBuilder content = new StringBuilder();
                    using (StreamReader fileContent = new StreamReader(file.Open()))
                    {
                        content.AppendLine(fileContent.ReadToEnd());
                    }
                    
                    var context = new TextFilesDbContext();
                    context.TextFiles.Add(
                        new TextFile()
                        {
                            Content = content.ToString(),
                            DateUploaded = DateTime.Now
                        });
                    context.SaveChanges();
                }
            }

            this.successPanel.Visible = true ;

            this.Response.Write("File contents are uploaded to database");
        }
    }
}