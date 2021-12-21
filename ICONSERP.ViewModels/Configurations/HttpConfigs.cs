using ICONSERP.Models.Security;
using static ICONSERP.Models.Enums.Enums;

namespace ICONSERP.ViewModels.Configurations
{
    public class HttpConfigs
    {
        private static IHttpContextAccessor httpContextAccessor;
        public static void SetHttpContextAccessor(IHttpContextAccessor accessor)
        {
            httpContextAccessor = accessor;
        }
        public static long UserID
        {
            get
            {

                long userID = 0;
                string token = null;
                if (httpContextAccessor != null)
                    token = httpContextAccessor.HttpContext.Request.Headers["AccessToken"].ToString();

                if (!string.IsNullOrEmpty(token))
                    userID = SecurityHelper.GetUserIDFromToken(SecurityHelper.Decrypt(token));
                return userID;
            }
            set { }
        }



        public static UserType UserType
        {
            get
            {

                UserType UserType = UserType.User;
                string token = httpContextAccessor.HttpContext.Request.Headers["AccessToken"].ToString();

                if (!string.IsNullOrEmpty(token))
                    UserType = SecurityHelper.GetUserTypeFromToken(SecurityHelper.Decrypt(token));
                return UserType;
            }
            set { }
        }
        public static bool IsAuthorized
        {
            get
            {
                string token = httpContextAccessor.HttpContext.Request.Headers["AccessToken"].ToString();

                if (!string.IsNullOrEmpty(token))
                    return true;
                return false;
            }
            set { }
        }
        public static long GetUserID()
        {
            var HttpContext = httpContextAccessor.HttpContext;
            long userID = 0;
            string token = HttpContext.Request.Headers["AccessToken"].ToString();

            if (!string.IsNullOrEmpty(token))
                userID = SecurityHelper.GetUserIDFromToken(SecurityHelper.Decrypt(token));
            return userID;
        }


    }



}

