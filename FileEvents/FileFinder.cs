namespace DelegatesHomework.FileEvents
{
    public class FileFinder
    {
        private readonly List<string> ProcessedFiles = [];
        private bool StopMonitoring = false;

        public event EventHandler<FileEventArgs> FileFound;

        public void FindFiles(string directoryPath, bool includeSubdirectories = false)
        {
            Console.WriteLine($"Start to search for new files in folder: {directoryPath}");

            DirectoryInfo directory = new(directoryPath);

            while (!StopMonitoring)
            {
                foreach (FileInfo file in directory.GetFiles())
                {
                    if (ProcessedFiles.Contains(file.Name))
                    {
                        continue;
                    }

                    ProcessedFiles.Add(file.Name);
                    OnFileFound(new FileEventArgs(file.Name));
                }

                if (includeSubdirectories)
                {
                    foreach (DirectoryInfo subdirectory in directory.GetDirectories())
                    {
                        FindFiles(subdirectory.FullName, true);
                    }
                } 
            }
        }

        protected virtual void OnFileFound(FileEventArgs e)
        {
            FileFound?.Invoke(this, e);
        }

        public void Stop()
        {
            StopMonitoring = true;
        }
    }
}
