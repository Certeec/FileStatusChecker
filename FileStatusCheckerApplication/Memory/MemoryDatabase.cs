using FileStatusCheckerApplication.FileChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStatusCheckerApplication.Memory
{
    public class MemoryDatabase : IDatabase
    {
       public List<FilesDirectory> AllDirectories { get; set; }
        
        public MemoryDatabase()
        {
            AllDirectories = new List<FilesDirectory>();
        }
    }
}
