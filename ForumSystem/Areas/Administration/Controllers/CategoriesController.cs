using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ForumSystem.Data;
using ForumSystem.Models;
using ForumSystem.Controllers;
using ForumSystem.Areas.Administration.ViewModels;
using ForumSystem.Services.Contracts;

namespace ForumSystem.Areas.Administration.Controllers
{
    public class CategoriesController : BaseController
    {
        private ICategoryService categoryService;
        private IUsersService usersService;

        public CategoriesController(ICategoryService categoryService, IUsersService usersService)
        {
            this.categoryService = categoryService;
            this.usersService = usersService;
        }

        // GET: Administration/Posts
        public ActionResult Index()
        {
            var categories = Mapper.Map<List<Category>,
                List<CategoryViewModel>>(categoryService.GetAll().ToList());

            return View(categories);
        }

        // GET: Administration/Posts/Create
        public ActionResult Create()
        {
            CategoryViewModel categoryVM = new CategoryViewModel();
            categoryVM.Users = new SelectList(this.usersService.GetAll(), "Id", "UserName");

            return View(categoryVM);
        }

        // POST: Administration/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var dbCategory = Mapper.Map<Category>(category);
                this.categoryService.Add(dbCategory);
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(this.categoryService.GetAll(), "Id", "Email", category.LastModifiedById);
            return View(category);
        }

        [ValidateInput(false)]
        // GET: Administration/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = this.categoryService.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            CategoryViewModel categoryVM = Mapper.
                Map<CategoryViewModel>(category);
            categoryVM.Users = new SelectList(this.usersService.GetAll(), "Id", "Email", category.LastModifiedById);
            return View(categoryVM);
        }

        // POST: Administration/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var dbCategory = Mapper.Map<Category>(category);
                this.categoryService.Update(dbCategory);
                return RedirectToAction("Index");
            }

            category.Users = new SelectList(this.usersService.GetAll(), "Id", "Email", category.LastModifiedById);
            return View(category);
        }

        // GET: Administration/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = this.categoryService.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Administration/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.categoryService.Delete(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}