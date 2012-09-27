using System.Web.Mvc;

namespace KeaBlog.Areas.KeaAdmin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "KeaAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "KeaAdmin_default",
                "KeaAdmin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "KeaBlog.Areas.KeaAdmin.Controllers" } 
            );
        }
    }
}
