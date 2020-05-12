using DBLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IDirectoryRepository
    {
        IEnumerable<Directory> GetAllDirectories(bool includeContent = false);
        Directory GetDirectoryById(int directoryId, bool includeContent = false);
        void SaveDirectory(Directory achieve);
        void DeleteDirectory(Directory achieve);
    }
}
