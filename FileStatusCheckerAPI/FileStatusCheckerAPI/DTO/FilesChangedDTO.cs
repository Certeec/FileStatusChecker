using FileStatusCheckerApplication.FileChecker;

namespace FileStatusCheckerAPI.DTO
{
    public class FilesChangedDTO
    {
        public string FilePath { get; set; }
        public string Action { get; set; }
        public int Version { get; set; }
    }
}
