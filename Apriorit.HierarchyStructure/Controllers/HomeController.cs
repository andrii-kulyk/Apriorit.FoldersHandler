using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apriorit.HierarchyStructure.Mvc.Models;

namespace Apriorit.HierarchyStructure.Mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string folders)
        {
            var model = new FoldersViewModel
            {
                RawString = folders,
            };
            return View("Index", model);
        }
    }
}