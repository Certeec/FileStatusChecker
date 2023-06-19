using FileStatusCheckerApplication.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStatusCheckerApplication.FileChecker
{
    public class FileService : IFileService
    {
        private readonly IFileManager _fileManager;
        private readonly IMemoryDatabase _memoryDatabase;
        public FileService(IFileManager checker, IMemoryDatabase memoryDatabase)
        {
            _fileManager = checker;;
            _memoryDatabase = memoryDatabase;
        }
        public void SaveHistoricalFile(string directoryPath)
        {
            FilesDirectory directory = new FilesDirectory(directoryPath);

            var listOfFiles = _fileManager.GetListOfAllFilesInDirectiory(directoryPath);
            directory.File = _fileManager.HashFiles(listOfFiles);
            _memoryDatabase.AllDirectories.Add(directory);
        }

        public List<FileChanges> CheckIfFilesChanged(string path)
        {
            FilesDirectory directory = _memoryDatabase.AllDirectories.Single(n => n.Path == path);

            string[] currentList = _fileManager.GetListOfAllFilesInDirectiory(path);
            List<FileInDirectory> currentHashedFiles = _fileManager.HashFiles(currentList);
            var comparisonList = CompareHashedLists(directory.File, currentHashedFiles, directory.DirectoryVersion);

            directory.ChangesInFiles.AddRange(comparisonList);
            directory.File = currentHashedFiles;
            directory.DirectoryVersion++;

            return directory.ChangesInFiles;

        }

        private List<FileChanges> CompareHashedLists(List<FileInDirectory> historical, List<FileInDirectory> current, int version)
        {
            List<FileInDirectory> currentList = current.ToList();
            //there i will be deleting content from current... Does it mean that i have to copy list like i did at top?
            // otherwise i would be modifying list "Current"?
            List<FileChanges> filesChanged = new List<FileChanges>();

            foreach(var file in historical)
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
                        }); ;
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

            foreach(var file in currentList)
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
