using System.Web.Mvc;
using KeaBlog.Areas.KeaAdmin.Models;

namespace KeaBlog.Areas.KeaAdmin.Controllers
{
    [Authorize]
    public class SettingController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new SettingListViewModel();
            viewModel.FillAll();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(SettingViewModel setting)
        {
            if (ModelState.IsValid)
            {
                setting.DbUpdate();
            }
            return RedirectToAction("Index");
        }

    }
}
