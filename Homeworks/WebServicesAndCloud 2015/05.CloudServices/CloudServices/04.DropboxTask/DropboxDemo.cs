namespace DropboxTask
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using CloudServices.Common;
    using Dropbox.Api;
    using Dropbox.Api.Files;
    using Dropbox.Api.Users;

    /// <summary>
    /// Task 4. Write a C# program to publish a photo album with few photos into DropBox and share the photos 
    /// through the Dropbox sharing functionality.
    /// Source: https://www.dropbox.com/developers/documentation/dotnet#tutorial
    /// </summary>
    public class DropboxDemo
    {
        

        public static void Main()
        {
            Task task = Task.Run(Run);
            task.Wait();
        }

        private static async Task Run()
        {
            using (var dropboxAccount = new DropboxClient(GlobalConstatns.AccessTokenDropBox))
            {
                FullAccount full = await dropboxAccount.Users.GetCurrentAccountAsync();
                Console.WriteLine($"Hello {full.Name.DisplayName} !");

                string[] catPictures = Directory.GetFiles(Directory.GetCurrentDirectory() + "..\\..\\..\\Album");
                foreach (var cat in catPictures)
                {
                    byte[] bytes = ReadBinaryFile(cat);
                    
                    await Upload(dropboxAccount, "/Cats", cat.Substring(cat.LastIndexOf("\\") + 1), bytes);
                }
            }
        }

        private static async Task Upload(DropboxClient dbx, string folder, string file, byte[] content)
        {
            using (var mem = new MemoryStream(content)) 
            {
                FileMetadata updated = await dbx.Files.UploadAsync(
                    folder + "/" + file,
                    WriteMode.Overwrite.Instance,
                    body: mem);
                Console.WriteLine("Saved {0}/{1} rev {2}", folder, file, updated.Rev);
            }
        }

        /// <summary>
        /// Copied from database course Ado.Net lecture.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static byte[] ReadBinaryFile(string fileName)
        {
            FileStream stream = File.OpenRead(fileName);
            using (stream)
            {
                int position = 0;
                var length = (int)stream.Length;
                var buffer = new byte[length];
                while (true)
                {
                    int bytesRead = stream.Read(buffer, position, length - position);
                    if (bytesRead == 0)
                    {
                        break;
                    }

                    position += bytesRead;
                }

                return buffer;
            }
        }
    }
}
