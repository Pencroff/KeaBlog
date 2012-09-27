using System.Collections.Generic;
using System.Web.Mvc;
using KeaBLL;
using KeaBLL.General;
using KeaBlog.Areas.KeaAdmin.Models;
using ServiceLib.Interfaces;

namespace KeaBlog.Areas.KeaAdmin.Controllers
{
    public class ExtraController : Controller
    {
        public ActionResult AdminMainMenu()
        {
            IMenu<MenuItem> model = new MenuModel();
            model.ActiveItem = null;
            if (Request.IsAuthenticated)
            {
                model.Items = MainMenuManager.GetAdminMainMenuList();
                foreach (var item in model.Items)
                {
                    if (Request.Path.Contains(item.Item))
                    {
                        model.ActiveItem = item;
                    }
                }   
            }
            else
            {
                model.Items = new List<MenuItem>();
            }
            return PartialView(model);
        }

        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}
