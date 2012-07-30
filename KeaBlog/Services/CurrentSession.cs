using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace KeaBlog.Services
{
    public static class CurrentSession
    { 
        public static String UserId
        {
            get
            {
                var context = HttpContext.Current;
                string userId = null;
                if (context.Session["UserId"] != null)
                {
                    return context.Session["UserId"].ToString();
                }
                else
                {
                    if (context.User.Identity.IsAuthenticated)
                    {
                        string userName = context.User.Identity.Name;
                        var user = new Services.Providers.KeaMembershipService().GetUser(userName);
                        if (user is MembershipUser && user.ProviderUserKey != null)
                        {
                            userId = user.ProviderUserKey.ToString();
                            HttpContext.Current.Session["UserId"] = userId;
                            return userId;
                        }
                        
                    }
                    return userId;
                }
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }
    }
}