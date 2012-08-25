using System.Web.Mvc;
using KeaBLL;
using KeaBLL.General;
using KeaBlog.Areas.Admin.Models;
using ServiceLib.Interfaces;
using System.Collections.Generic;
using KeaDAL;

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
            Dictionary<string, object> viewModel = new Dictionary<string, object>();
            List<TagTop> tagList = TagManager.GetTagListTop();
            viewModel.Add("_TagList", tagList);
            //List<CategoryTop> categoryList = CategoryManager.GetCategoryListTop();
            //viewModel.Add("_CategoryList", categoryList);
            return PartialView(viewModel);
        }

        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}