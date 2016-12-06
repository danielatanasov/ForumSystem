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

namespace ForumSystem.Areas.Administration.Controllers
{
    public class CategoriesController : BaseController
    {
        // GET: Administration/Categories
        public ActionResult Index()
        {
            var categories = Mapper.Map<List<Category>, List<CategoryViewModel>>(Data.Categories.All().ToList());
            return View(categories);
        }

        // GET: Administration/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = Data.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Administration/Categories/Create
        public ActionResult Create()
        {
            CategoryViewModel createVM = new CategoryViewModel();
            createVM.Users = new SelectList(Data.Users.All(), "Id", "UserName");
            return View(createVM);
        }

        // POST: Administration/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var dbCategory = Mapper.Map<Category>(category);
                dbCategory.CreatedOn = DateTime.Now;
                Data.Categories.Add(dbCategory);
                Data.Categories.SaveChanges();
   
                return RedirectToAction("Index");
            }

            ViewBag.LastModifiedById = new SelectList(Data.Users.All(), "Id", "Email", category.LastModifiedById);
            return View(category);
        }

        // GET: Administration/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = Data.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.LastModifiedById = new SelectList(Data.Users.All(), "Id", "Email", category.LastModifiedById);
            return View(category);
        }

        // POST: Administration/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ShortDescription,LastModifiedById,CreatedOn,IsDeleted")] Category category)
        {
            if (ModelState.IsValid)
            {
                Data.Categories.Update(category);
                Data.Categories.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LastModifiedById = new SelectList(Data.Users.All(), "Id", "Email", category.LastModifiedById);
            return View(category);
        }

        // GET: Administration/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = Data.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Administration/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = Data.Categories.Find(id);
            Data.Categories.Delete(category);
            Data.Categories.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        Data.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
