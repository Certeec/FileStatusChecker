using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace FileStatusCheckerApplication.FileChecker
{
    public class FileManager : IFileManager
    {
        public string[] GetListOfAllFilesInDirectiory(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);
            return files;
        }

        public List<FileInDirectory> HashFiles(IEnumerable<string> files)
        {
            List<FileInDirectory> listOfFiles = new List<FileInDirectory>();
            foreach(var file in files)
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(file))
                    {
                        FileInDirectory fileInDirectory = new FileInDirectory(file,
                           Encoding.Default.GetString(md5.ComputeHash(stream)),
                           1);
                        listOfFiles.Add(fileInDirectory);
                    }
                }
            }

            return listOfFiles;
        }
    }
}
