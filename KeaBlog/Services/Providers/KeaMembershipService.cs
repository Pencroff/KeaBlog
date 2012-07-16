using System.Web.Security;

namespace KeaBlog.Services.Providers
{
    public interface IMembershipService
    {
        int MinPasswordLength { get; }

        bool ValidateUser(string userName, string password);
        string GetCanonicalUsername(string userName);
        MembershipCreateStatus CreateUser(string userName, string password, string email);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
        MembershipUser GetUser(string userName);
    }

    public class KeaMembershipService : IMembershipService
    {
        private MembershipProvider _provider;

        public KeaMembershipService()
            : this(null)
        {
        }

        public KeaMembershipService(MembershipProvider provider)
        {
            _provider = provider ?? new KeaMembershipProvider();
        }

        public int MinPasswordLength
        {
            get
            {
                return _provider.MinRequiredPasswordLength;
            }
        }

        public bool ValidateUser(string userName, string password)
        {
            return _provider.ValidateUser(userName, password);
        }

        public string GetCanonicalUsername(string userName)
        {
            var user = _provider.GetUser(userName, true);
            if (user != null)
            {
                return user.UserName;
            }

            return null;
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            MembershipCreateStatus status;
            _provider.CreateUser(userName, password, email, null, null, true, null, out status);
            return status;
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            MembershipUser currentUser = _provider.GetUser(userName, true /* userIsOnline */);
            return currentUser.ChangePassword(oldPassword, newPassword);
        }

        public MembershipUser GetUser(string userName)
        {
            return _provider.GetUser(userName, true /* userIsOnline */);
        }
    }
}