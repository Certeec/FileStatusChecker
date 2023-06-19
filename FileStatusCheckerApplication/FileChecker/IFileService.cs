
namespace FileStatusCheckerApplication.FileChecker
{
    public interface IFileService
    {
        void SaveHistoricalFile(string path);
        List<FileChanges> CheckIfFilesChanged(string path);
    }
}
