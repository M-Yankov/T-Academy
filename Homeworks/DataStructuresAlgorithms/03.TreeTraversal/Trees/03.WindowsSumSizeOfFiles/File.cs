namespace WindowsSumSizeOfFiles
{
    public class File
    {
        public File(string fileNameWithExtension)
        {
            this.Name = fileNameWithExtension;
        }

        public string Name { get; set; }

        public long Size { get; set; }
    }
}
