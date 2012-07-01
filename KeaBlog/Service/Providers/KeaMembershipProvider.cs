using System;
using System.Collections.Specialized;
using System.Web.Security;
using KeaBLL;
using KeaDAL;
using ServiceLib;

namespace KeaBlog.Service.Providers
{
    public class KeaMembershipProvider : MembershipProvider
    {
        /*
            enablePasswordRetrieval="false" 
            enablePasswordReset="true" 
            requiresQuestionAndAnswer="false" 
            requiresUniqueEmail="false" 
            maxInvalidPasswordAttempts="5" 
            minRequiredPasswordLength="6" 
            minRequiredNonalphanumericCharacters="0" 
            passwordAttemptWindow="10" 
            applicationName="/"
        */
        private bool _EnablePasswordRetrieval = false;
        private bool _EnablePasswordReset = false;
        private bool _RequiresQuestionAndAnswer = false;
        private string _AppName = "App";
        private bool _RequiresUniqueEmail = false;
        private int _MaxInvalidPasswordAttempts = 5;
        private MembershipPasswordFormat _PasswordFormat = new MembershipPasswordFormat();
        private int _PasswordAttemptWindow = 10;
        private int _MinRequiredPasswordLength = 4;
        private int _MinRequiredNonalphanumericCharacters = 0;
        private string _PasswordStrengthRegularExpression = null;

        // Ok
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, password, true);
            OnValidatingPassword(args);

            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }
            if (RequiresUniqueEmail && GetUserNameByEmail(email) != string.Empty)
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }
            MembershipUser user = GetUser(username, true);
            if (user == null)
            {
                Auth_User authUser = new Auth_User();
                authUser.Login = username;
                string salt;
                authUser.PassHash = SecurityOperations.FillPassHash(password, out salt);
                authUser.PassSalt = salt;
                UserManager.CreateUser(authUser);
                status = MembershipCreateStatus.Success;
                return GetUser(username, true);
            }
            else
            {
                status = MembershipCreateStatus.DuplicateUserName;
            }

            return null;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string login, string oldPassword, string newPassword)
        {
            return UserManager.ChangePassword(login, oldPassword, newPassword);
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string login, string password)
        {
            Auth_User user = UserManager.GetUserByLoginPass(login, password);
            if (user != null)
                return true;
            return false;
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string login, bool userIsOnline)
        {
            Auth_User authUser = UserManager.GetUser(login);
            if (authUser != null)
            {
                MembershipUser memUser = new MembershipUser("KeaMembershipProvider", login, authUser.Id, authUser.Email,
                                                            string.Empty, string.Empty,
                                                            true, false, DateTime.MinValue,
                                                            DateTime.MinValue,
                                                            DateTime.MinValue,
                                                            DateTime.Now, DateTime.Now);
                return memUser;
            }
            return null;
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { return _EnablePasswordRetrieval; }
        }

        public override bool EnablePasswordReset
        {
            get { return _EnablePasswordReset; }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return _RequiresQuestionAndAnswer; }
        }

        public override string ApplicationName
        {
            get { return _AppName; }
            set { _AppName = value; }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return _MaxInvalidPasswordAttempts; }
        }

        public override int PasswordAttemptWindow
        {
            get { return _PasswordAttemptWindow; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return _RequiresUniqueEmail; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return _PasswordFormat; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return _MinRequiredPasswordLength; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return _MinRequiredNonalphanumericCharacters; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { return _PasswordStrengthRegularExpression; }
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            // ToDo Create Initialize from Web.config
            base.Initialize(name, config);
            //var keys = config.AllKeys;
            //string value;
            //foreach (string key in keys)
            //{
            //    value = config.Get(key);
            //}
            //    HttpRuntime.CheckAspNetHostingPermission(AspNetHostingPermissionLevel.Low, "Feature_not_supported_at_this_level");
            //    if (config == null)
            //    {
            //        throw new ArgumentNullException("config");
            //    }
            //    if (string.IsNullOrEmpty(name))
            //    {
            //        name = "SqlMembershipProvider";
            //    }
            //    if (string.IsNullOrEmpty(config["description"]))
            //    {
            //        config.Remove("description");
            //        config.Add("description", SR.GetString("MembershipSqlProvider_description"));
            //    }
            //    base.Initialize(name, config);
            //    this._SchemaVersionCheck = 0;
            //    this._EnablePasswordRetrieval = SecUtility.GetBooleanValue(config, "enablePasswordRetrieval", false);
            //    this._EnablePasswordReset = SecUtility.GetBooleanValue(config, "enablePasswordReset", true);
            //    this._RequiresQuestionAndAnswer = SecUtility.GetBooleanValue(config, "requiresQuestionAndAnswer", true);
            //    this._RequiresUniqueEmail = SecUtility.GetBooleanValue(config, "requiresUniqueEmail", true);
            //    this._MaxInvalidPasswordAttempts = SecUtility.GetIntValue(config, "maxInvalidPasswordAttempts", 5, false, 0);
            //    this._PasswordAttemptWindow = SecUtility.GetIntValue(config, "passwordAttemptWindow", 10, false, 0);
            //    this._MinRequiredPasswordLength = SecUtility.GetIntValue(config, "minRequiredPasswordLength", 7, false, 128);
            //    this._MinRequiredNonalphanumericCharacters = SecUtility.GetIntValue(config, "minRequiredNonalphanumericCharacters", 1, true, 128);
            //    this._PasswordStrengthRegularExpression = config["passwordStrengthRegularExpression"];
            //    if (this._PasswordStrengthRegularExpression != null)
            //    {
            //        this._PasswordStrengthRegularExpression = this._PasswordStrengthRegularExpression.Trim();
            //        if (this._PasswordStrengthRegularExpression.Length == 0)
            //        {
            //            goto IL_16C;
            //        }
            //        try
            //        {
            //            new Regex(this._PasswordStrengthRegularExpression);
            //            goto IL_16C;
            //        }
            //        catch (ArgumentException ex)
            //        {
            //            throw new ProviderException(ex.Message, ex);
            //        }
            //    }
            //    this._PasswordStrengthRegularExpression = string.Empty;
            //IL_16C:
            //    if (this._MinRequiredNonalphanumericCharacters > this._MinRequiredPasswordLength)
            //    {
            //        throw new HttpException(SR.GetString("MinRequiredNonalphanumericCharacters_can_not_be_more_than_MinRequiredPasswordLength"));
            //    }
            //    this._CommandTimeout = SecUtility.GetIntValue(config, "commandTimeout", 30, true, 0);
            //    this._AppName = config["applicationName"];
            //    if (string.IsNullOrEmpty(this._AppName))
            //    {
            //        this._AppName = SecUtility.GetDefaultAppName();
            //    }
            //    if (this._AppName.Length > 256)
            //    {
            //        throw new ProviderException(SR.GetString("Provider_application_name_too_long"));
            //    }
            //    string text = config["passwordFormat"];
            //    if (text == null)
            //    {
            //        text = "Hashed";
            //    }
            //    string a;
            //    if ((a = text) != null)
            //    {
            //        if (!(a == "Clear"))
            //        {
            //            if (!(a == "Encrypted"))
            //            {
            //                if (!(a == "Hashed"))
            //                {
            //                    goto IL_24C;
            //                }
            //                this._PasswordFormat = MembershipPasswordFormat.Hashed;
            //            }
            //            else
            //            {
            //                this._PasswordFormat = MembershipPasswordFormat.Encrypted;
            //            }
            //        }
            //        else
            //        {
            //            this._PasswordFormat = MembershipPasswordFormat.Clear;
            //        }
            //        if (this.PasswordFormat == MembershipPasswordFormat.Hashed && this.EnablePasswordRetrieval)
            //        {
            //            throw new ProviderException(SR.GetString("Provider_can_not_retrieve_hashed_password"));
            //        }
            //        this._sqlConnectionString = SecUtility.GetConnectionString(config);
            //        string value = config["passwordCompatMode"];
            //        if (!string.IsNullOrEmpty(value))
            //        {
            //            this._LegacyPasswordCompatibilityMode = (MembershipPasswordCompatibilityMode)Enum.Parse(typeof(MembershipPasswordCompatibilityMode), value);
            //        }
            //        config.Remove("connectionStringName");
            //        config.Remove("connectionString");
            //        config.Remove("enablePasswordRetrieval");
            //        config.Remove("enablePasswordReset");
            //        config.Remove("requiresQuestionAndAnswer");
            //        config.Remove("applicationName");
            //        config.Remove("requiresUniqueEmail");
            //        config.Remove("maxInvalidPasswordAttempts");
            //        config.Remove("passwordAttemptWindow");
            //        config.Remove("commandTimeout");
            //        config.Remove("passwordFormat");
            //        config.Remove("name");
            //        config.Remove("minRequiredPasswordLength");
            //        config.Remove("minRequiredNonalphanumericCharacters");
            //        config.Remove("passwordStrengthRegularExpression");
            //        config.Remove("passwordCompatMode");
            //        if (config.Count > 0)
            //        {
            //            string key = config.GetKey(0);
            //            if (!string.IsNullOrEmpty(key))
            //            {
            //                throw new ProviderException(SR.GetString("Provider_unrecognized_attribute", new object[]
            //        {
            //            key
            //        }));
            //            }
            //        }
            //        return;
            //    }
            //IL_24C:
            //    throw new ProviderException(SR.GetString("Provider_bad_password_format"));
        }

    }
}