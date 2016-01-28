using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FileUploadUsingTelerik
{
    public class TextFilesDbContext : DbContext
    {
        public TextFilesDbContext()
            :base("FileUpload")
        {
        }
       
        public IDbSet<TextFile> TextFiles { get; set; }
    }
}