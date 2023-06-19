using FileStatusCheckerApplication.FileChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStatusCheckerApplication.Memory
{
    public interface IMemoryDatabase
    {
        List<FilesDirectory> AllDirectories { get; set; }
    }
}
