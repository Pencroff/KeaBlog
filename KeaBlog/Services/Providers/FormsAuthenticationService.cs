using System;
using System.Web;
using System.Web.Security;

namespace KeaBlog.Services.Providers
{
    public interface IFormsAuthentication
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }

    public class FormsAuthenticationService : IFormsAuthentication
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1, //version
                userName, // user name
                DateTime.Now,             //creation
                DateTime.Now.AddMinutes(30), //Expiration
                createPersistentCookie, //Persistent
                userName); //since Classic logins don't have a "Friendly Name".  OpenID logins are handled in the AuthController.

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }

    //public static class FormsAuthenticationService
    //{
    //    public static void SignIn(string login, bool createPersistentCookie, int timeout)
    //    {
    //        if (timeout == 0)
    //        {
    //            timeout = 120;
    //        }
    //        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName);
    //        cookie.Path = FormsAuthentication.FormsCookiePath;
    //        cookie.Value = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(login, createPersistentCookie, timeout));
    //        cookie.Expires = DateTime.Now.AddMinutes(timeout);
    //        HttpContext.Current.Response.Cookies.Add(cookie);
    //    }

    //    public static void SignOut()
    //    {
    //        FormsAuthentication.SignOut();
    //    }
    //}
}