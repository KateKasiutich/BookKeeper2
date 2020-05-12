using BusinessLayer;
using DBLayer.Entityes;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Services
{
    public class DirectoryService
    {
        private DataManager DataManager;
        private ContentService ContentService;
        public DirectoryService(DataManager dataManager)
        {
            this.DataManager = dataManager;
            ContentService = new ContentService(dataManager);
        }

        public List<DirectoryModelView> GetDirectoriesList()
        {
            var dirs = DataManager.Directories.GetAllDirectories();
            List<DirectoryModelView> ModelsList = new List<DirectoryModelView>();
            foreach (var item in dirs)
            {
                ModelsList.Add(DirectoryDBToViewModelById(item.Id));
            }
            return ModelsList;
        }

        public DirectoryModelView DirectoryDBToViewModelById(int directoryId)
        {
            var directory = DataManager.Directories.GetDirectoryById(directoryId, true);

            List<ContentModelView> ContentViewModelList = new List<ContentModelView>();
            foreach (var item in directory.Books)
            {
                ContentViewModelList.Add(ContentService.ContentDBModelToView(item.Id));
            }
            return new DirectoryModelView() { Directory = directory, Books = ContentViewModelList };
        }
        public DirectoryModelEdit GetDirectoryEditModel(int directoryId = 0)
        {
            if (directoryId != 0)
            {
                var dirDB = DataManager.Directories.GetDirectoryById(directoryId);
                var dirEditModel = new DirectoryModelEdit()
                {
                    Id = dirDB.Id,
                    Title = dirDB.Title,
                    Html = dirDB.Html
                };
                return dirEditModel;
            }
            else { return new DirectoryModelEdit() { }; }
        }
        public DirectoryModelView SaveDirectoryEditModelToDb(DirectoryModelEdit directoryEditModel)
        {
            Directory directoryDbModel;
            if (directoryEditModel.Id != 0)
            {
                directoryDbModel = DataManager.Directories.GetDirectoryById(directoryEditModel.Id);
            }
            else
            {
                directoryDbModel = new Directory();
            }
            directoryDbModel.Title = directoryEditModel.Title;
            directoryDbModel.Html = directoryEditModel.Html;

            DataManager.Directories.SaveDirectory(directoryDbModel);

            return DirectoryDBToViewModelById(directoryDbModel.Id);
        }

        public DirectoryModelEdit CreateNewDirectoryEditModel()
        {
            return new DirectoryModelEdit() { };

        }
    }
}
