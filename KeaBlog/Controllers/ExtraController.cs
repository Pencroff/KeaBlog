using System.Web.Mvc;
using KeaBLL;
using KeaBLL.General;
using KeaBlog.Areas.Admin.Models;
using ServiceLib.Interfaces;

namespace KeaBlog.Controllers
{
    public class ExtraController : Controller
    {
        public ActionResult MainMenu()
        {
            IMenu<MenuItem> model = new MenuModel();
            model.Items = MainMenuManager.GetMainMenuList();
            model.ActiveItem = null;
            foreach (var item in model.Items)
            {
                if (Request.Path.Contains(item.Item))
                {
                    model.ActiveItem = item;
                }
            }
            return PartialView(model);
        }

        public ActionResult Column()
        {
            return PartialView();
        }

        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}
