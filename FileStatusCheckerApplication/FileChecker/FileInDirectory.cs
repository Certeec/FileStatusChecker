
namespace FileStatusCheckerApplication.FileChecker
{
    public class FileInDirectory
    {
        public string Path { get; set; }
        public string HashedValue { get; set; }
        public int Version { get; set; } = 0;
        public FileInDirectory(string path, string hashedValue, int version)
        {
            Path = path;
            HashedValue = hashedValue;
            Version += version;
        }
    }
}
