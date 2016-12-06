using ForumSystem.Areas.Administration.ViewModels;
using ForumSystem.Models;
using ForumSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumSystem.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PostsByCategory()
        {
            var posts = Mapper.Map<List<Post>, List<PostViewModel>>(Data.Posts.All().ToList());
            return View(posts);
        }
    }
}