namespace WindowsSumSizeOfFiles
{
    using System.Collections.Generic;

    public class Folder
    {
        public Folder()
            : this("Windows")
        {
        }

        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.SubFolders = new List<Folder>();
        }

        public string Name { get; set; }

        public IList<File> Files { get; set; }

        public IList<Folder> SubFolders { get; set; }
    }
}
