using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStatusCheckerApplication.FileChecker
{
    public interface IFileService
    {
        void SaveHistoricalFile(string path);
        Dictionary<string, char> CheckIfFilesChanged();
    }
}
