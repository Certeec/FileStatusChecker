
namespace FileStatusCheckerApplication.FileChecker
{
    public interface IFileManager 
    {
        List<FileInDirectory> HashFilesInPath(string path);
    }
}
