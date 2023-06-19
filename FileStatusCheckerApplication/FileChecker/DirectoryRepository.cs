using FileStatusCheckerApplication.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStatusCheckerApplication.FileChecker
{
    public class DirectoryRepository : IDirectoryRepository
    {
        private readonly IDatabase _database;

        public DirectoryRepository(IDatabase database)
        {
            _database = database;
        }
        public FilesDirectory GetDirectoryByPath(string path)
        {
            return _database.AllDirectories.Single(n => n.Path == path);
        }

        public void AddNewDirectory(FilesDirectory directoryToAdd)
        {
            _database.AllDirectories.Add(directoryToAdd);
        }

        public void UpdateDirectory(FilesDirectory directory)
        {

        }

    }
}
