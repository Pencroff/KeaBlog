using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeaBlog.Areas.Admin.Models;

namespace KeaBlog.Areas.Admin.Controllers
{
    public class TagController : Controller
    {
        public ActionResult Index(int page = 1)
        {
            var viewModel = new TagListViewModel();
            viewModel.FillByPage(page);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(TagViewModel tag)
        {
            if (ModelState.IsValid)
            {
                tag.DbInsert();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(TagViewModel tag)
        {
            if (ModelState.IsValid)
            {
                tag.DbUpdate();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int tagId)
        {
            TagViewModel tag = new TagViewModel();
            tag.DeleteById(tagId);
            return RedirectToAction("Index");
        }

    }
}
