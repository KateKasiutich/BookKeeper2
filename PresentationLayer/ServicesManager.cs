using BusinessLayer;
using PresentationLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer
{
    public class ServicesManager
    {
        DataManager DataManager;

        private DirectoryService DirectoryService;
        private ContentService ContentService;

        public ServicesManager(DataManager dataManager)
        {
            DataManager = dataManager;
            DirectoryService = new DirectoryService(DataManager);
            ContentService = new ContentService(DataManager);
        }

        public DirectoryService Directories { get { return DirectoryService; } }
        public ContentService Content { get { return ContentService; } }

    }
}
