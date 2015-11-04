namespace WindowsSumSizeOfFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Task 3. Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders } and using them build 
    /// a tree keeping all files and folders on the hard drive starting from C:\WINDOWS. Implement a method that calculates the sum of the file sizes 
    /// in given subtree of the tree and test it accordingly. Use recursive DFS traversal.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// H means Homework. you know about the restriction of 260 symbols for file path length in windows.
        /// </summary>
        private const string HomeworkPath = "C:\\H";
        private const string Writing = "Writing...";
        private const string Reading = "Reading...";
        private const string ErrorMessage = "Error in the algorithm.";
        private const string DirectoryToSearch = "C:\\Windows\\SysWOW64";
        private static readonly Random Generator = new Random();

        public static void Main()
        {
            CreateHomeworkFolder(HomeworkPath);
            Folder root = new Folder();
            FillFolderWithDirectoriesAndFiles("C:\\Windows", root);

            WriteRootFolder(HomeworkPath, root);
            long result = FindSizeOfSubFolder(DirectoryToSearch);
            Console.WriteLine("Directory {0} has ~{1:N0} bytes", DirectoryToSearch, result);
        }

        private static long FindSizeOfSubFolder(string directoy)
        {
            Console.WriteLine("Calculate files size in directory... {0}", directoy);
            return FindSizeOfSubFolder(directoy, 0);
        }

        private static long FindSizeOfSubFolder(string directoy, long size = 0)
        {
            if (size < 0)
            {
                throw new ArgumentNullException(ErrorMessage);
            }

            string[] dirs;
            try
            {
                //// Unauthorized exception.
                dirs = Directory.GetDirectories(directoy).Union(Directory.GetFiles(directoy)).ToArray();
            }
            catch (Exception)
            {
                return 0;
            }

            for (int i = 0; i < dirs.Length; i++)
            {
                if (Directory.Exists(dirs[i]))
                {
                    size = FindSizeOfSubFolder(dirs[i], size);
                }
                else if (System.IO.File.Exists(dirs[i]))
                {
                    size += new FileInfo(dirs[i]).Length;
                }
            }

            return size;
        }

        private static void WriteRootFolder(string pathToWrite, Folder folder)
        {
            string root = pathToWrite + "\\" + folder.Name;
            Directory.CreateDirectory(root);

            WriteFolderContentsToDisk(root, folder);
        }

        private static void CreateHomeworkFolder(string path)
        {
            Directory.CreateDirectory(path);
            Console.WriteLine("HomeWork is on: {0}", path);
        }

        private static void WriteFolderContentsToDisk(string pathToWrite, Folder folder)
        {
            var dirs = folder.SubFolders;
            var files = folder.Files;

            //// The Root
            for (int i = 0; i < dirs.Count; i++)
            {
                PrintCurrentLocation(Writing, dirs[i].Name);
                string path = pathToWrite + "\\" + dirs[i].Name;
                Directory.CreateDirectory(path);

                WriteFolderContentsToDisk(path, dirs[i]);
            }

            for (int i = 0; i < files.Count; i++)
            {
                PrintCurrentLocation(Writing, files[i].Name);
                string path = pathToWrite + "\\" + files[i].Name;
                System.IO.File.Create(path);
            }
        }

        private static void FillFolderWithDirectoriesAndFiles(string path, Folder rootToFill)
        {
            PrintCurrentLocation(Reading, path);

            if (rootToFill == null)
            {
                throw new ArgumentNullException(ErrorMessage);
            }

            string[] dirs;
            try
            {
                //// Unauthorized exception.
                dirs = Directory.GetDirectories(path).Union(Directory.GetFiles(path)).ToArray();
            }
            catch (Exception)
            {
                return;
            }

            for (int i = 0; i < dirs.Length; i++)
            {
                string correctName = dirs[i].Substring(dirs[i].IndexOf(":") + 1);
                string fileNameOnly = dirs[i].Substring(dirs[i].LastIndexOf("\\") + 1);

                if (Directory.Exists(dirs[i]))
                {
                    rootToFill.SubFolders.Add(new Folder(fileNameOnly));
                    Folder innerSubFolder = rootToFill.SubFolders.Where(x => x.Name == fileNameOnly).FirstOrDefault();
                    if (rootToFill == null)
                    {
                        throw new ArgumentNullException(ErrorMessage);
                    }

                    //// Directory.CreateDirectory(homeworkPath + correctName);
                    FillFolderWithDirectoriesAndFiles(dirs[i], innerSubFolder);
                }
                else if (System.IO.File.Exists(dirs[i]))
                {
                    rootToFill.Files.Add(new File(fileNameOnly));
                    //// System.IO.File.Create(homeworkPath + correctName + fileNameOnly);
                }
            }
        }

        private static void PrintCurrentLocation(string operation, string path)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = (ConsoleColor)Generator.Next(0, 16);
            Console.WriteLine(new string(' ', 500));
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("{0}... {1}", operation, path);
        }
    }
}
