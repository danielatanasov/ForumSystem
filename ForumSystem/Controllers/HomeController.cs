using ForumSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using ForumSystem.Models;
using ForumSystem.Services.Contracts;
using ForumSystem.Common.Caching;

namespace ForumSystem.Controllers
{
    public class HomeController : BaseController
    {
        private ICategoryService categoriesService;
        private ICacheService cache;
        public HomeController(ICategoryService service, ICacheService cache)
        {
            this.cache = cache;
            this.categoriesService = service;
        }

        public ActionResult Index()
        {
            var dbCategories = this.cache.Get<ICollection<Category>>("allCategories", () =>
            {
                return categoriesService.GetAll().ToList();
            }, 60);

            var categories = Mapper.Map<ICollection<Category>,
                ICollection<CategoryViewModel>>(dbCategories);

            return View(categories);
        }
        //public ActionResult Index()
        //{
        //    var categories = Mapper.Map<List<Category>, List<CategoryViewModel>>(Data.Categories.All().ToList());
        //    return View(categories);
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}