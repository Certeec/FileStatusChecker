using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStatusCheckerApplication.TempFileOperators
{
    public class HistoricalFileHandler : IHistoricalFileHandler
    {
        private readonly string _url = ".\\TempFiles\\Historical.txt";
  
        public void SaveHashedToFile(Dictionary<string,string> hashedFilesValue)
        {
            using(StreamWriter sw = new StreamWriter(_url))
            {
                foreach(var file in hashedFilesValue)
                {
                    sw.WriteLine(file.Key + "," + file.Value);
                }
            }

        }

        public Dictionary<string,string> ReadHashedFiles()
        {
            Dictionary<string, string> historicalHashed = new Dictionary<string, string>();
            using (StreamReader sr = new StreamReader(_url))
            {
                string srLine;
                while((srLine = sr.ReadLine()) != null)
                {
                    var fileToAdd = SplitString(srLine);
                    historicalHashed.Add(fileToAdd.Name, fileToAdd.HashValue);
                }
            }
            return historicalHashed;
        }

        private HashedFile SplitString(string toSplit)
        {
            string[] parts = toSplit.Split(',');
            return new HashedFile()
            {
                Name = parts[0],
                HashValue = parts[1]
            };
        }
    
    }
}
