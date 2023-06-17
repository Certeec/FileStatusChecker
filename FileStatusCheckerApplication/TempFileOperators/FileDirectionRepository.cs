using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStatusCheckerApplication.TempFileOperators
{
    public class FileDirectionRepository : IFileDirectionRepository
    {
        private string _url = ".\\TempFiles\\Directory.txt";
        public bool SaveDirectoryToFile(string path)
        {
            try
            {
                using (StreamWriter wr = new StreamWriter(_url, false))
                {

                    if (path != null) wr.WriteLine(path);
                }
                return true;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public string ReadDirectionFromFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_url))
                {
                    return sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem while reading Directory " + e);
                throw;
            }

        }

    }
}
