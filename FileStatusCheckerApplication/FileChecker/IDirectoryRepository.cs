using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStatusCheckerApplication.FileChecker
{
    public interface IDirectoryRepository
    {
        FilesDirectory GetDirectoryByPath(string path);
        void AddNewDirectory(FilesDirectory directoryToAdd);
        void UpdateDirectory(FilesDirectory directory);
    }
}
