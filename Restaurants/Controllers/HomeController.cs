namespace Restaurants.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using Models;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Eatinator()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            AuthenticationManager.Authenticate(username, password);

            if (AuthenticationManager.LoggedUser == null)
            {
                ModelState.AddModelError("authenticationFailed", "Wrong username or password!");
                ViewData["username"] = username;

                return View();
            }



            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            if (AuthenticationManager.LoggedUser == null)
            {
                return RedirectToAction("Login", "Home");
            }

            AuthenticationManager.Logout();

            return RedirectToAction("Login", "Home");
        }

        public ActionResult FakeAdmin()
        {
            UsersRepository userRepo = new UsersRepository();
            UserEntity u = new UserEntity();
            u.Username = "admin";
            u.Password = "admin";
            u.FirstName = "FirstName";
            u.LastName = "LastName";
            u.Email = "SampleEmail@sample.com";
            u.Address = "Sample Adress, Street 12";
            u.Phone = "+3595555555555";
            u.Description = "Description";
            u.ProfileImageUrl = "https://cdn2.iconfinder.com/data/icons/users-6/100/USER7-512.png";
            u.AdminStatus = true;
            userRepo.Save(u);
            return View();
        }
    }
}