
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
    }
}
