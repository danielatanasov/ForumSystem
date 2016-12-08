using AutoMapper;
using ForumSystem.Models;
using ForumSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Microsoft.AspNet.Identity;
using ForumSystem.Services;
using ForumSystem.Services.Contracts;
using ForumSystem.Common.Caching;

namespace ForumSystem.Controllers
{
    public class PostController : BaseController
    {
        private IPostsService postsService;
        private ICacheService cache;
        private IUsersService usersService;
        private ICategoryService categoryService;

        public PostController(IPostsService postsService, IUsersService usersService, ICategoryService categoryService)
        {
            this.postsService = postsService;
            this.usersService = usersService;
            this.categoryService = categoryService;
        }
        
        // GET: Post
        public ActionResult Index()
        {
            var dbPosts = this.cache.Get<ICollection<Post>>("allPosts", () =>
            {
                return postsService.GetAll().ToList();
            }, 60);
            //var posts = Mapper.Map<List<Post>, List<PostViewModel>>(Data.Posts.All().ToList());
            var posts = Mapper.Map<ICollection<Post>,
                ICollection<PostViewModel>>(dbPosts);
            return View(posts);
        }
        [HttpGet]
        public ActionResult Create(int catId)
        {
            PostViewModel postVM = new PostViewModel();
            postVM.CategoryId = catId;
            
            return View(postVM);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(PostViewModel post)
        {
            
            if (ModelState.IsValid)
            {
                var dbPost = Mapper.Map<Post>(post);
                dbPost.CreatedOn = DateTime.Now;
                dbPost.AuthorId = User.Identity.GetUserId();
                var category = categoryService.Find(post.CategoryId);
                dbPost.Category = category;
                this.postsService.Add(dbPost);
                //return View("Details");
                return RedirectToAction("PostsByCategory","Category", new { id = post.CategoryId });
            }
            ViewBag.AuthorId = new SelectList(this.usersService.GetAll(), "Id", "Email", post.Author);
            return View(post);
        }

        public ActionResult Details(int? id)
        {
            Category category = this.categoryService.Find(id);
            return View(category);
        }

    }
}