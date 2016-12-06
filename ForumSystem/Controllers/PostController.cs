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

namespace ForumSystem.Controllers
{
    public class PostController : BaseController
    {
        private ICategoryService categoriesService;

        public PostController(ICategoryService service)
        {
            this.categoriesService = service;
        }
        // GET: Post
        public ActionResult Index()
        {
            var posts = Mapper.Map<List<Post>, List<PostViewModel>>(Data.Posts.All().ToList());
            return View(posts);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PostViewModel post)
        {
            
            if (ModelState.IsValid)
            {
                var dbPost = Mapper.Map<Post>(post);
                dbPost.CreatedOn = DateTime.Now;
                dbPost.AuthorId = User.Identity.GetUserId();
                //dbPost.Category = post.
                Data.Posts.Add(dbPost);
                Data.Posts.SaveChanges();
                return RedirectToAction("PostsByCategory","Category", new { id = post.Category.Id.ToString() });
            }
            ViewBag.AuthorId = new SelectList(Data.Users.All(), "Id", "Email", post.Author);
            return View(post);
        }

        public ActionResult Details(int? id)
        {
            Category category = Data.Categories.Find(id);
            return View(category);
        }

    }
}