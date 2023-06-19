
namespace FileStatusCheckerApplication.FileChecker
{
    public class FilesDirectory
    {
        public string Path { get; }
        public List<FileInDirectory> File { get; set; }
        public int DirectoryVersion { get; set; }
        public List<FileChanges> ChangesInFiles { get; set; }

        public FilesDirectory(string path)
        {
            Path = path;
            ChangesInFiles = new List<FileChanges>();
            File = new List<FileInDirectory>();
            DirectoryVersion = 0;
        }

        public List<FileChanges> TrackChangedFiles(List<FileInDirectory> current)
        {

            return CompareHashedLists(File, current, DirectoryVersion);
        }

        private List<FileChanges> CompareHashedLists(List<FileInDirectory> historical, List<FileInDirectory> current, int version)
        {
            List<FileInDirectory> currentList = current.ToList();
            //there i will be deleting content from current... Does it mean that i have to copy list like i did at top?
            // otherwise i would be modifying list "Current"?
            List<FileChanges> filesChanged = new List<FileChanges>();

            foreach (var file in historical)
            {
                var foundFile = currentList.SingleOrDefault(n => n.Path == file.Path);
                if (foundFile != null)
                {
                    if (foundFile.HashedValue != file.HashedValue)
                    {
                        filesChanged.Add(new FileChanges()
                        {
                            FilePath = file.Path,
                            Action = FileStatus.M,
                            Version = version
                        });
                        currentList.Remove(foundFile);
                    }
                    else
                    {
                        currentList.Remove(foundFile);
                    }
                }
                else
                {
                    filesChanged.Add(new FileChanges()
                    {
                        FilePath = file.Path,
                        Action = FileStatus.D,
                        Version = version
                    });
                }
            }

            foreach (var file in currentList)
            {
                filesChanged.Add(new FileChanges()
                {
                    FilePath = file.Path,
                    Action = FileStatus.A,
                    Version = version
                });
            }

            return filesChanged;
        }
    }
}

