using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
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
            var entries = db.Entries.Include(e => e.auth_Users);
            return View(entries.ToList());
        }

        //
        // GET: /Entry/Details/5

        public ActionResult Details(int id = 0)
        {
            Entry entry = db.Entries.Find(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }

        //
        // GET: /Entry/Create

        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Auth_User, "Id", "Login");
            return View();
        }

        //
        // POST: /Entry/Create

        [HttpPost]
        public ActionResult Create(Entry entry)
        {
            if (ModelState.IsValid)
            {
                db.Entries.Add(entry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Auth_User, "Id", "Login", entry.AuthorId);
            return View(entry);
        }

        //
        // GET: /Entry/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Entry entry = db.Entries.Find(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Auth_User, "Id", "Login", entry.AuthorId);
            return View(entry);
        }

        //
        // POST: /Entry/Edit/5

        [HttpPost]
        public ActionResult Edit(Entry entry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Auth_User, "Id", "Login", entry.AuthorId);
            return View(entry);
        }

        //
        // GET: /Entry/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Entry entry = db.Entries.Find(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }

        //
        // POST: /Entry/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Entry entry = db.Entries.Find(id);
            db.Entries.Remove(entry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}