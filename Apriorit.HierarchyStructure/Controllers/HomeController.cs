using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apriorit.HierarchyStructure.Mvc.BL;
using Apriorit.HierarchyStructure.Mvc.Infrastructure;
using Apriorit.HierarchyStructure.Mvc.Models;

namespace Apriorit.HierarchyStructure.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFoldersFacade _foldersFacade;

        public HomeController(IFoldersFacade foldersFacade)
        {
            foldersFacade.ThrowIfNull(nameof(foldersFacade));
            _foldersFacade = foldersFacade;
        }

        // GET: Home
        public ActionResult Index(string folders)
        {
            if (string.IsNullOrEmpty(folders))
                folders = String.Empty;

            var model = _foldersFacade.GetPathContent(folders);

            foreach (var subFolder in model.SubFolders)
            {

                subFolder.Link = Request.Url.AbsoluteUri + (Request.Url.AbsoluteUri.EndsWith("/")
                    ? $"{subFolder.Name}/"
                    : $"/{subFolder.Name}/");
            }

            return View("Index", model);
        }
    }
}