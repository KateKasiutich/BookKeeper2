using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Interfaces;
using DBLayer;
using DBLayer.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentationLayer;
using PresentationLayer.Models;
using BookKeeper_2.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private DataManager DataManager;
        private ServicesManager ServicesManager;
        public HomeController(DataManager dataManager)
        {
            DataManager = dataManager;
            ServicesManager = new ServicesManager(DataManager);
        }

        public IActionResult Index()
        {
            List<DirectoryModelView> dirs = ServicesManager.Directories.GetDirectoriesList();

            return View(dirs);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}