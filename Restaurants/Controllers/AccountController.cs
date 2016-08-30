namespace Restaurants.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using Restaurants.Models;
    using Restaurants.ViewModels.Common;
    using System.Web.Mvc;
    using ViewModels.Users;

    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            LoginOrRegisterVM model = new LoginOrRegisterVM();
            model.Register = new UsersEditVM();
            model.Login = new LoginVM();
            return View(model);
        }


        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            UsersRepository repo = new UsersRepository();
            UsersEditVM model = new UsersEditVM();
            TryUpdateModel(model);
            if (ModelState.IsValid)
            {
                UserEntity entity = new UserEntity();
                PopulateEntity(entity, model);
                repo.Save(entity); 
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Account");
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
                return RedirectToAction("Login", "Account");
            }

            AuthenticationManager.Logout();

            return RedirectToAction("Login", "Account");
        }

        private void PopulateEntity(UserEntity entity, UsersEditVM model)
        {
            entity.Username = model.Username;
            entity.Password = model.Password;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.Address = model.Address;
            entity.Phone = model.Phone;
            entity.Description = model.Description;
            entity.FavouriteFoods = model.FavouriteFoods;
            entity.FavouritePlace = model.FavouritePlace;
            entity.ProfileImageUrl = model.ProfileImageUrl;
            entity.AdminStatus = false;
        }
    }
}