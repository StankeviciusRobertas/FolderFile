namespace FolderFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new FilesDbContext();

            // TODO: studentams paimti patha ir nuskenuoti failus jame

            //Enter the directory path
            string directoryPath = @"C:\Users\rstak\OneDrive - Girteka Logistics, UAB\Desktop\.NET skaidres";

            if (Directory.Exists(directoryPath))
            {
                ScanDirectory(directoryPath, dbContext);
            }
            else
            {
                Console.WriteLine("Nera tokios direktorijos");
            }

            static void ScanDirectory(string directoryPath, FilesDbContext dbContext)
            {
                string[] files = Directory.EnumerateFiles(directoryPath, "*", SearchOption.TopDirectoryOnly).ToArray();

                foreach (string filePath in files)
                {
                    FileInfo fileInfo = new FileInfo(filePath);

                    var folder = new Folder()
                    {
                        //Id = Guid.NewGuid(),
                        Name = new DirectoryInfo(directoryPath).Name,
                        Files = new List<File>
                    {
                        new File()
                        {
                            //Id = Guid.NewGuid(),
                            Name = fileInfo.Name,
                            FullDirectory = fileInfo.FullName,
                            Size = (int)fileInfo.Length
                        }
                    }
                    };
                    dbContext.Folders.Add(folder);
                    dbContext.SaveChanges();
                }

                string[] subdirectories = Directory.GetDirectories(directoryPath);
                foreach (string subdirectory in subdirectories)
                {
                    ScanDirectory(subdirectory, dbContext);
                }
            }



            // Pvz rezultate kas turi buti suformuota
            //var folder = new Folder()
            //{
            //    Name = @"Direktorija",
            //    Files = new List<File>
            //    {
            //        new File()
            //        {
            //            Name = "tekstas.txt",
            //            Size = 100,
            //            FullDirectory = "c:Program Files/Abc/Tekstas.txt"
            //        }
            //    }
            //};

            //dbContext.Folders.Add(folder);
            //dbContext.SaveChanges();
        }
    }
}