using ForumSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using ForumSystem.Models;

namespace ForumSystem.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var categories = Mapper.Map<List<Category>, List<CategoryViewModel>>(Data.Categories.All().ToList());
            return View(categories);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}