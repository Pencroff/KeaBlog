using System.Web;
using System.Web.Optimization;

namespace KeaBlog
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/bootstrap/css/bootstrap.css").Include("~/Content/bootstrap/css/bootstrap.css",
                                        "~/Content/bootstrap/css/bootstrap-responsive.css",
                                        "~/Content/css/extra.css"));

            bundles.Add(new StyleBundle("~/Content/css/bbeditor").Include("~/Content/BBEditor/fatcow/wbbtheme-fatcow.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Content/bootstrap/js/bootstrap.js",
                                         "~/Content/bootstrap/js/bootstrap-timepicker.js",
                                         "~/Content/bootstrap/js/bootstrap-datepicker.js",
                                         "~/Content/bootstrap/js/locales/bootstrap-datepicker.ru.js",
                                         "~/Content/bootstrap/js/chosen.jquery.js"));
     
            bundles.Add(new ScriptBundle("~/bundles/bbeditor").Include("~/Scripts/BBEditor/jquery.wysibb.js",
                                                                     "~/Scripts/BBEditor/wysibb.render.js",
                                                                     "~/Scripts/BBEditor/lang/en.js",
                                                                     "~/Scripts/BBEditor/wysibb.config.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/bbeditor.render").Include("~/Scripts/BBEditor/wysibb.render.js",
                                                                     "~/Scripts/BBEditor/lang/en.js",
                                                                     "~/Scripts/BBEditor/wysibb.config.bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css/fonts").Include("~/Content/css/fonts.css"));

            /////////////////////////////
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}