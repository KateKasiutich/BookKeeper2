using BusinessLayer;
using DBLayer.Entityes;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.Services
{
    public class ContentService
    {
        private DataManager dataManager;
        public ContentService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public ContentModelView ContentDBModelToView(int contentId)
        {
            var model = new ContentModelView()
            {
                Content = dataManager.Books.GetBookById(contentId),
            };
            var dir = dataManager.Directories.GetDirectoryById(model.Content.DirectoryId, true);

            if (dir.Books.IndexOf(dir.Books.FirstOrDefault(x => x.Id == model.Content.Id)) != dir.Books.Count() - 1)
            {
                model.NextContent = dir.Books.ElementAt(dir.Books.IndexOf(dir.Books.FirstOrDefault(x => x.Id == model.Content.Id)) + 1);
            }
            return model;
        }

        public ContentModelEdit GetContentEditModel(int contentId)
        {
            var dbModel = dataManager.Books.GetBookById(contentId);
            var editModel = new ContentModelEdit()
            {
                Id = dbModel.Id = dbModel.Id,
                DirectoryId = dbModel.DirectoryId,
                Title = dbModel.Title,
                Html = dbModel.Html
            };
            return editModel;
        }

        public ContentModelView SaveContentEditModelToDb(ContentModelEdit editModel)
        {
            Content content;
            if (editModel.Id != 0)
            {
                content = dataManager.Books.GetBookById(editModel.Id);
            }
            else
            {
                content = new Content();
            }
            content.Title = editModel.Title;
            content.Html = editModel.Html;
            content.DirectoryId = editModel.DirectoryId;
            dataManager.Books.SaveBook(content);
            return ContentDBModelToView(content.Id);
        }
        public ContentModelEdit CreateNewContentEditModel(int directoryId)
        {
            return new ContentModelEdit() { DirectoryId = directoryId };
        }
    }
}
