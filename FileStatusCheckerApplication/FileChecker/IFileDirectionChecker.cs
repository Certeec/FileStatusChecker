using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStatusCheckerApplication.FileChecker
{
    public interface IFileDirectionChecker 
    {
        List<string> GetListOfAllFilesInDirectiory(string directoryPath);
        Dictionary<string, string> GetFilesHashed(List<string> files);
    }
}
