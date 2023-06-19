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
        private readonly IDirectoryRepository _directoryRepository;
        public FileService(IFileManager checker, IDirectoryRepository repository)
        {
            _fileManager = checker;
            _directoryRepository = repository;
        }
        public void SaveHistoricalFile(string directoryPath)
        {
            FilesDirectory directory = new FilesDirectory(directoryPath);

            directory.File = _fileManager.HashFilesInPath(directoryPath);
            _directoryRepository.AddNewDirectory(directory);
        }

        public List<FileChanges> CheckIfFilesChanged(string directoryPath)
        {
            FilesDirectory directory = _directoryRepository.GetDirectoryByPath(directoryPath);

            List<FileInDirectory> currentHashedFiles = _fileManager.HashFilesInPath(directoryPath);

            List<FileChanges> editedFiles = directory.TrackChangedFiles(currentHashedFiles);

            directory.ChangesInFiles.AddRange(editedFiles);
            directory.File = currentHashedFiles;
            directory.DirectoryVersion++;

            _directoryRepository.UpdateDirectory(directory);

            return directory.ChangesInFiles;

        }
    }   
}
