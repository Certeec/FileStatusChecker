
namespace FileStatusCheckerApplication.FileChecker
{
    public interface IFileManager 
    {
        string[] GetListOfAllFilesInDirectiory(string directoryPath);
        List<FileInDirectory> HashFiles(IEnumerable<string> files);
    }
}
