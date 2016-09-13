namespace Restaurants.Models
{
    using DataAccess.Entity;
    using ServiceLayer.Services;
    using System.Web;

    public static class AuthenticationManager
    {
        public static UserEntity LoggedUser
        {
            get
            {
                AuthService auth = null;

                if (HttpContext.Current != null && HttpContext.Current.Session["LoggedUser"] == null)
                    HttpContext.Current.Session["LoggedUser"] = new AuthService();

                auth = (AuthService)HttpContext.Current.Session["LoggedUser"];
                return auth.LoggedUser;
            }
        }

        public static void Authenticate(string username, string password)
        {
            AuthService authenticationService = null;

            if (HttpContext.Current != null && HttpContext.Current.Session["LoggedUser"] == null)
                HttpContext.Current.Session["LoggedUser"] = new AuthService();

            authenticationService = (AuthService)HttpContext.Current.Session["LoggedUser"];
            authenticationService.AuthenticateUser(username, password);
        }

        public static void Logout()
        {
            HttpContext.Current.Session["LoggedUser"] = null;
        }
    }
}