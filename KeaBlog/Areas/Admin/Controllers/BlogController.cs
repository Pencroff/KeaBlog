using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using KeaBLL;
using KeaBlog.Areas.Admin.Models;
using KeaDAL;

namespace KeaBlog.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private KeaContext db = new KeaContext();

        //
        // GET: /Entry/

        public ActionResult Index()
        {
            //var entries = db.Posts.Include(e => e.auth_Users);
            var viewModel = new PostListViewModel();
            viewModel.FillByIndex(1);
            return View(viewModel.Posts);
        }

        //
        // GET: /Entry/Details/5

        public ActionResult Details(int id = 0)
        {
            PostViewModel viewModel = new PostViewModel();
            viewModel.FillById(id);
            if (viewModel.Id != id)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        //
        // GET: /Entry/Create

        public ActionResult Create()
        {
            ViewBag.AuthorId = Guid.Empty;//new SelectList(db.Auth_User, "Id", "Login");
            return View();
        }

        //
        // POST: /Entry/Create

        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.AuthorId = Guid.Parse("E21486DE-07F0-4E9B-BC61-B49ADEFBBCD3");
                PostManager.InsertPost(post);
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = Guid.Empty;
            return View(post);
        }

        //
        // GET: /Entry/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PostViewModel viewModel = new PostViewModel();
            viewModel.FillById(id);
            if (viewModel.Id != id)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        //
        // POST: /Entry/Edit/5

        [HttpPost]
        public ActionResult Edit(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SaveToDb();
                return RedirectToAction("Index");
            }
            return View(model);
        }

    //    //
    //    // GET: /Entry/Delete/5

    //    public ActionResult Delete(int id = 0)
    //    {
    //        Entry entry = db.Entries.Find(id);
    //        if (entry == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(entry);
    //    }

    //    //
    //    // POST: /Entry/Delete/5

    //    [HttpPost, ActionName("Delete")]
    //    public ActionResult DeleteConfirmed(int id)
    //    {
    //        Entry entry = db.Entries.Find(id);
    //        db.Entries.Remove(entry);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        db.Dispose();
    //        base.Dispose(disposing);
    //    }
    }
}