using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace FileStatusCheckerApplication.FileChecker
{
    public class FileDirectionChecker : IFileDirectionChecker
    {
        public string[] GetListOfAllFilesInDirectiory(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath);
            return files;
        }

        public Dictionary<string, string> HashFiles(string[] files)
        {
            Dictionary<string, string> listOfFilesHashed = new Dictionary<string, string>();
            foreach(var file in files)
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(file))
                    {
                        listOfFilesHashed.Add(file, Encoding.Default.GetString(md5.ComputeHash(stream)));
                    }
                }
            }
            return listOfFilesHashed;
        }
    }
}
