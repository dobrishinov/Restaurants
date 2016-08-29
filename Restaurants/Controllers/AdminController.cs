namespace Restaurants.Controllers
{
    using DataAccess.Entity;
    using Restautants.ViewModels.Restautants;
    using System;
    using ViewModels.Restaurants;
    using DataAccess.Repository;
    using System.Web.Mvc;
    using System.Linq;
    using Models;
    using Restautants.ViewModels.Users;
    public class AdminController : Controller
    {
        public AdminController()
        {
            UsersRepo = new UsersRepository();
            RestaurantRepo =new RestaurantsRepository();
        }

        private readonly UsersRepository UsersRepo;
        private readonly RestaurantsRepository RestaurantRepo;
        //Users

        public ActionResult Users()
        {
            UsersListVM model = new UsersListVM();
            model.Items = UsersRepo.GetAll().ToList();
            return View(model);
        }
        

        //Restaurants

        public ActionResult Restaurants()
        {
            RestaurantsListVM model = new RestaurantsListVM();
            model.Items = RestaurantRepo.GetAll().ToList();
            return View(model);
        }
   
        public void PopulateRestaurantEntity(RestaurantEntity entity, RestaurantsEditVM model)
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

        public  void PopulateRestaurantModel(RestaurantsEditVM model, RestaurantEntity entity)
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
    }
}