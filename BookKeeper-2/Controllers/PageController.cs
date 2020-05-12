    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Models;
using static DBLayer.Enums.PageEnums;

namespace BookKeeper_2.Controllers
{
    public class PageController : Controller
    {
        private DataManager DataManager;
        private ServicesManager ServicesManager;

        public PageController(DataManager dataManager)
        {
            DataManager = dataManager;
            ServicesManager = new ServicesManager(dataManager);
        }

        public IActionResult Index(int pageId, PageType pageType)
        {
            PageModelView ViewModel;
            switch (pageType)
            {
                case PageType.Directory: ViewModel = ServicesManager.Directories.DirectoryDBToViewModelById(pageId); break;
                case PageType.Content: ViewModel = ServicesManager.Content.ContentDBModelToView(pageId); break;
                default: ViewModel = null; break;
            }
            ViewBag.PageType = pageType;
            return View(ViewModel);
        }

        [HttpGet]
        public IActionResult PageEditor(int pageId, PageType pageType, int directoryId = 0)
        {
            PageModelEdit EditModel;

            switch (pageType)
            {
                case PageType.Directory:
                    if (pageId != 0) EditModel = ServicesManager.Directories.GetDirectoryEditModel(pageId);
                    else EditModel = ServicesManager.Directories.CreateNewDirectoryEditModel();
                    break;
                case PageType.Content:
                    if (pageId != 0) EditModel = ServicesManager.Content.GetContentEditModel(pageId);
                    else EditModel = ServicesManager.Content.CreateNewContentEditModel(directoryId);
                    break;
                default: EditModel = null; break;
            }

            ViewBag.PageType = pageType;
            return View(EditModel);
        }

        [HttpPost]
        public IActionResult SaveDirectory(DirectoryModelEdit model)
        {
            ServicesManager.Directories.SaveDirectoryEditModelToDb(model);
            return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, pageType = PageType.Directory });
        }

        [HttpPost]
        public IActionResult SaveMaterial(ContentModelEdit model)
        {
            ServicesManager.Content.SaveContentEditModelToDb(model);
            return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, pageType = PageType.Content });
        }

    }
}