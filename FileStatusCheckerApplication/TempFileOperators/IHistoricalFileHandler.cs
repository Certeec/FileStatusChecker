using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileStatusCheckerApplication.TempFileOperators
{
    public interface IHistoricalFileHandler
    {
        void SaveHashedToFile(Dictionary<string, string> hashedFilesValue);
        Dictionary<string, string> ReadHashedFiles();
    }
}
