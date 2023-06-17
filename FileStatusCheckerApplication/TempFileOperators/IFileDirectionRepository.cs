using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStatusCheckerApplication.TempFileOperators
{
    public interface IFileDirectionRepository
    {
        bool SaveDirectoryToFile(string path);
        string ReadDirectionFromFile();
    }
}
