using ForumSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumSystem.Models;
using ForumSystem.Data;
using ForumSystem.Services;
using ForumSystem.Controllers;
using ForumSystem.Common.Caching;
using System.Web.Mvc;
using ForumSystem.ViewModels;

namespace ForumSystem.Services
{
    public class CategoryController : BaseController
    {
        private IPostsService postsService;
        private ICacheService cache;
        
        public CategoryController(IPostsService service, ICacheService cache)
        {
            this.cache = cache;
            this.postsService = service;
        }
        public ActionResult PostsByCategory(int Id)
        {

            var posts = Mapper.Map<List<Post>, List<PostViewModel>>(this.postsService.GetAllById(Id).ToList());
            ViewData["category"] = Id;
            return View(posts);
        }
//public ActionResult Index()
//{
//    var dbPosts = this.cache.Get<ICollection<Post>>("allPosts", () =>
//    {
//        return postsService.GetAll().ToList();
//    }, 60);

        //    var posts = Mapper.Map<ICollection<Post>,
        //        ICollection<PostViewModel>>(dbPosts);

        //    return View(posts);
        //}

        //public ActionResult Info(int id)
        //{
        //    var post = Mapper.Map<PostViewModel>(this.postsService.Find(id));
        //    if (post.Content.Length > 30)
        //    {
        //        post.SubHeader = post.Content.Substring(0, 30);
        //    }
        //    else
        //    {
        //        post.SubHeader = post.Content;
        //    }

        //    return View(post);
        //}

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
//using ForumSystem.Areas.Administration.ViewModels;
//using ForumSystem.Models;
//using ForumSystem.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace ForumSystem.Controllers
//{
//    public class CategoryController : BaseController
//    {
//        // GET: Category
//        public ActionResult Index()
//        {
//            return View();
//        }

//        public ActionResult PostsByCategory()
//        {
//            var posts = Mapper.Map<List<Post>, List<PostViewModel>>(Data.Posts.All().ToList());
//            return View(posts);
//        }
//    }
//}