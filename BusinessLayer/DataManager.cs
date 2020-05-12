using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class DataManager
    {
        private readonly IDirectoryRepository DirectoryRepository;
        private readonly IContentRepository ContentRepository;

        public DataManager(IDirectoryRepository directoryRepository, IContentRepository contentRepository)
        {
            DirectoryRepository = directoryRepository;
            ContentRepository = contentRepository;
        }

        public IDirectoryRepository Directories { get { return DirectoryRepository; } }
        public IContentRepository Books { get { return ContentRepository; } }


    }
}
