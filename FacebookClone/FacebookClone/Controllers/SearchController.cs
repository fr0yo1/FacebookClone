using FacebookClone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacebookClone.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(SearchViewModel searchViewModel)
        {
            var userId = User.Identity.GetUserId();
            ViewBag.searchInput = searchViewModel.searchInput;
            searchViewModel.getResult(userId);
            return View("SearchView",searchViewModel);
        }
    }
}