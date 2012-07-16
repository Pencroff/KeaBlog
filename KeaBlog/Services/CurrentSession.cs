using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeaBlog.Services
{
    public static class CurrentSession
    { 
        public static String UserId
        {
            get
            {
                if (HttpContext.Current.Session["UserId"] != null)
                    return HttpContext.Current.Session["UserId"].ToString();
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }
    }
}