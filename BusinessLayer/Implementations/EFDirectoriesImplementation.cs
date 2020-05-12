using BusinessLayer.Interfaces;
using DBLayer;
using DBLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Implementations
{
    public class EFDirectoriesImplementation : IDirectoryRepository
    {
        private EFDBContext context;
        public void EFDirectoriesRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Directory> GetAllDirectories(bool includeContent = false)
        {
            if (includeContent)
                return context.Set<Directory>().Include(x => x.Books).AsNoTracking().ToList();
            else
                return context.Directory.ToList();
        }

        public Directory GetDirectoryById(int directoryId, bool includeContent = false)
        {
            if (includeContent)
                return context.Set<Directory>().Include(x => x.Books).AsNoTracking().FirstOrDefault(x => x.Id == directoryId);
            else
                return context.Directory.FirstOrDefault(x => x.Id == directoryId);
        }

        public void SaveDirectory(Directory directory)
        {
            if (directory.Id == 0)
                context.Directory.Add(directory);
            else
                context.Entry(directory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteDirectory(Directory directory)
        {
            context.Directory.Remove(directory);
            context.SaveChanges();
        }
    }
}
