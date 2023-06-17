using FileStatusCheckerApplication.TempFileOperators;
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
        private readonly IFileDirectionChecker _checker;
        private readonly IHistoricalFileHandler _historicalHandler;
        private readonly IFileDirectionRepository _directionRepository;
        public FileService(IFileDirectionChecker checker, IHistoricalFileHandler handler, IFileDirectionRepository fileDirectionRepository)
        {
            _checker = checker;
            _historicalHandler = handler;
            _directionRepository = fileDirectionRepository;
        }
        public void SaveHistoricalFile(string directory)
        {
            var result = _directionRepository.SaveDirectoryToFile(directory);
            var listOfFiles = _checker.GetListOfAllFilesInDirectiory(directory);
            Dictionary<string,string> toSave = _checker.HashFiles(listOfFiles);
            _historicalHandler.SaveHashedToFile(toSave);
        }

        public Dictionary<string, FileStatus> CheckIfFilesChanged()
        {
            var path = _directionRepository.ReadDirectionFromFile();
            var historicalFileHashes = _historicalHandler.ReadHashedFiles();
            string[] currentList = _checker.GetListOfAllFilesInDirectiory(path);
            var currentHashedFiles = _checker.HashFiles(currentList);
            return CompareHashDictionary(historicalFileHashes, currentHashedFiles);

        }

        private Dictionary<string, FileStatus> CompareHashDictionary(Dictionary<string,string> historical, Dictionary<string,string> current)
        {
            Dictionary<string, FileStatus> resultOfCheck = new Dictionary<string, FileStatus>();

            foreach(var file in historical)
            {
                if(current.ContainsKey(file.Key))
                {
                    if (current[file.Key].Contains(file.Value))
                    {

                    }
                    else
                    {
                        resultOfCheck.Add(file.Key, FileStatus.M);
                    }

                    current.Remove(file.Key);

                }
                else
                {
                    resultOfCheck.Add(file.Key, FileStatus.D);
                }
            }

            foreach(var leftFiles in current)
            {
                resultOfCheck.Add(leftFiles.Key, FileStatus.A);
            }

            return resultOfCheck;

            //Tbh i`m not happy with this function.. but it works

        }

        private void CompareVaules()
        {
            
        }
    }
}
