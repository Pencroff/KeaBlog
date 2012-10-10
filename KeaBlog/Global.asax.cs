using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using KeaBLL;
using KeaBlog.Controllers;
using StackExchange.Profiling;

namespace KeaBlog
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MiniProfilerEF.Initialize();
        }

        protected void Application_BeginRequest()
        {
            bool useMiniProfiler = SettingManager.ReadSetting<bool>("Use MiniProfiler");
            if (useMiniProfiler)
            {
                MiniProfiler.Start();    
            }
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            var httpException = exception as HttpException;
            Response.Clear();
            Server.ClearError();
            Response.StatusCode = httpException.GetHttpCode();
            if (Response.StatusCode == 404)
            {
                Response.TrySkipIisCustomErrors = true;
                IController errorController = null;
                var rd = new RouteData();
                rd.Values["controller"] = "Errors";
                rd.Values["action"] = "NotFound";

                errorController = new ErrorsController();
                
                HttpContextWrapper wrapper = new HttpContextWrapper(Context);
                var rc = new RequestContext(wrapper, rd);
                errorController.Execute(rc);
            }
        }
    }
}