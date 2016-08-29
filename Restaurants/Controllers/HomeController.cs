namespace Restaurants.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using Models;
    using Restautants.ViewModels.Restautants;
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Restaurants;
    using System.Collections.Generic;

    public class HomeController : BaseController<RestaurantEntity, RestaurantsEditVM, RestaurantsListVM, RestaurantsFilterVM>
    {
        public override BaseRepository<RestaurantEntity> CreateRepository()
        {
            return new RestaurantsRepository();
        }

        protected override void OnBeforeList(RestaurantsListVM model)
        {
            model.Items = model.Items.OrderByDescending(x => x.CreateTime).Take(4).ToList();
        }

        public ActionResult Eatinator()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Account");

            Random random = new Random();

            List<int> ids = Repository.GetAll().Select(x => x.Id).ToList();

            RestaurantEntity entity =  Repository.GetById(ids[random.Next(0,ids.Count)]);
            RestaurantsEditVM model = new RestaurantsEditVM();
            PopulateModel(model, entity);
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public override void PopulateEntity(RestaurantEntity entity, RestaurantsEditVM model)
        {
            entity.Name = model.Name;
            entity.Type = model.Type;
            entity.Description = model.Description;
            entity.WorkingTime = model.WorkingTime;
            entity.Email = model.Email;
            entity.Address = model.Address;
            entity.Phone = model.Phone;
            entity.ImageUrl = model.ImageUrl;
            entity.CreateTime = DateTime.Now;
            entity.RestaurantsStatus = false;
        }

        public override void PopulateModel(RestaurantsEditVM model, RestaurantEntity entity)
        {
            model.Name = entity.Name;
            model.Type = entity.Type;
            model.Description = entity.Description;
            model.WorkingTime = entity.WorkingTime;
            model.Email = entity.Email;
            model.Address = entity.Address;
            model.Phone = entity.Phone;
            model.ImageUrl = entity.ImageUrl;
            model.CreateTime = entity.CreateTime;
            model.RestaurantsStatus = entity.RestaurantsStatus;

        }

        //[HttpGet]
        //public ActionResult Login()
        //{
        //    LoginOrRegisterVM model = new LoginOrRegisterVM();
        //    return View(model);
        //}
        ///*

        //     [HttpGet]
        //public ActionResult Register(int? id)
        //{
        //    UsersEditVM model = new UsersEditVM();
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Register(FormCollection collection)
        //{
        //    UsersEditVM model = new UsersEditVM();
        //    TryUpdateModel(model);
        //    if (ModelState.IsValid)
        //    {
        //        UserEntity entity = new UserEntity();
        //        PopulateEntity(entity, model);
        //        return RedirectToAction("Login", "Home");
        //    }
        //    return View(model);
        //}

        // */
        //[HttpPost]
        //public ActionResult Login(string username, string password)
        //{
        //    AuthenticationManager.Authenticate(username, password);

        //    if (AuthenticationManager.LoggedUser == null)
        //    {
        //        ModelState.AddModelError("authenticationFailed", "Wrong username or password!");
        //        ViewData["username"] = username;

        //        return View();
        //    }
        //    return RedirectToAction("Index", "Home");
        //}

        //public ActionResult Logout()
        //{
        //    if (AuthenticationManager.LoggedUser == null)
        //    {
        //        return RedirectToAction("Login", "Home");
        //    }

        //    AuthenticationManager.Logout();

        //    return RedirectToAction("Login", "Home");
        //}

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