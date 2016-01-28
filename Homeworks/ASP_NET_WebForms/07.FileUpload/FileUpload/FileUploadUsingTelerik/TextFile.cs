namespace FileUploadUsingTelerik
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TextFile
    {
        public int Id { get; set; }

        [MaxLength(10000)]
        public string Content { get; set; }

        public DateTime DateUploaded { get; set; }
    }
}