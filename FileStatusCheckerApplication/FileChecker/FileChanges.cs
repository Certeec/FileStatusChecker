
namespace FileStatusCheckerApplication.FileChecker
{
    public class FileChanges
    {
        public string FilePath { get; set; }
        public FileStatus Action { get; set; }
        public int Version { get; set; }
    }
}
