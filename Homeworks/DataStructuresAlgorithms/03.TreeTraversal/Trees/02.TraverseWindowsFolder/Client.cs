namespace TraverseWindowsFolder
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.AccessControl;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Task 3. Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to display all files matching the mask *.exe. 
    /// Use the class System.IO.Directory.
    /// </summary>
    public class Client
    {
        public static void Main()
        {
            TraversePath("C:\\Windows", 0);
        }

        private static void TraversePath(string path, int deepLevel)
        {
            string[] dirs;
            try
            {
                dirs = Directory.GetDirectories(path).Union(Directory.GetFiles(path)).ToArray();
            }
            catch (Exception ex)
            {
                ShowPathWithNoAccess(path, ex);
                return;
            }

            bool hasExeFile = false;
            for (int i = 0; i < dirs.Length; i++)
            {
                string lastFourSymbols = dirs[i].Substring(dirs[i].Length - 4);

                //// obviously a folder name can contains a dot.
                if (Directory.Exists(dirs[i]))
                {
                    TraversePath(dirs[i], deepLevel + 1);
                }
                else if (File.Exists(dirs[i]) && lastFourSymbols == ".exe")
                {
                    if (!hasExeFile)
                    {
                        Console.WriteLine("{0} {1}", new string('-', deepLevel), path);
                    }

                    hasExeFile = true;
                    string fileNameOnly = dirs[i].Substring(dirs[i].LastIndexOf("\\"));
                    Console.WriteLine("{0} {1}", new string(' ', deepLevel + 2), fileNameOnly);
                }
            }
        }

        private static void ShowPathWithNoAccess(string path, Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
    }
}
