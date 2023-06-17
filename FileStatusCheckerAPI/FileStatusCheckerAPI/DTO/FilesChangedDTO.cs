using FileStatusCheckerApplication.FileChecker;

namespace FileStatusCheckerAPI.DTO
{
    public class FilesChangedDTO
    {
        public string FilePath { get; set; }
        public FileStatus Action { get; set; }
    }
}
