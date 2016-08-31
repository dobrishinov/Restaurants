namespace Restaurants.Controllers
{
    using DataAccess.Entity;
    using Restautants.ViewModels.Restautants;
    using System;
    using ViewModels.Restaurants;
    using DataAccess.Repository;
    using System.Web.Mvc;
    using System.Linq;
    using Restautants.ViewModels.Users;
    using ViewModels;
    using Models;
    using Filter;

    [AdminAuthentication]
    public class AdminController : Controller
    {
        public AdminController()
        {
            UsersRepo = new UsersRepository();
            RestaurantRepo = new RestaurantsRepository();
        }

        private readonly UsersRepository UsersRepo;
        private readonly RestaurantsRepository RestaurantRepo;

        //  ----  Users    ---- 

        public ActionResult Users()
        {
            UsersListVM model = new UsersListVM();
            TryUpdateModel(model);
            model.Items = UsersRepo.GetAll(model.Filter.BuildFilter(), model.Pager.CurrentPage, model.Pager.PageSize).ToList();

            //Pager
            string action = this.ControllerContext.RouteData.Values["action"].ToString();
            string controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            model.Pager = new Pager(UsersRepo.GetAll(model.Filter.BuildFilter()).Count(), model.Pager.CurrentPage, "Pager.", action, controller, model.Pager.PageSize);
            //Filter
            model.Filter.ParentPager = model.Pager;

            return View(model);
        }

        // ---- Restaurants ----
        public ActionResult Restaurants()
        {
            RestaurantsListVM model = new RestaurantsListVM();
            TryUpdateModel(model);
            model.Items = RestaurantRepo.GetAll(model.Filter.BuildFilter()).OrderByDescending(x => x.CreateTime)
                                                .Skip((model.Pager.CurrentPage - 1) * model.Pager.PageSize).Take(model.Pager.PageSize).ToList();

            //Pager
            string action = this.ControllerContext.RouteData.Values["action"].ToString();
            string controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            model.Pager = new Pager(RestaurantRepo.GetAll(model.Filter.BuildFilter()).Count(), model.Pager.CurrentPage, "Pager.", action, controller, model.Pager.PageSize);
            //Filter
            model.Filter.ParentPager = model.Pager;
            return View(model);
        }
        

        public ActionResult ApproveRestaurants()
        {
            RestaurantsListVM model = new RestaurantsListVM();

            TryUpdateModel(model);

            model.Items = RestaurantRepo.GetAll(model.Filter.BuildDeclineFilter()).OrderByDescending(x => x.CreateTime)
                                                .Skip((model.Pager.CurrentPage - 1) * model.Pager.PageSize).Take(model.Pager.PageSize).ToList();

            //Pager
            string action = this.ControllerContext.RouteData.Values["action"].ToString();
            string controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            model.Pager = new Pager(RestaurantRepo.GetAll(model.Filter.BuildDeclineFilter()).Count(), model.Pager.CurrentPage, "Pager.", action, controller, model.Pager.PageSize);
            //Filter
            model.Filter.ParentPager = model.Pager;
            return View(model);
        }

        public ActionResult Aprove(int id)
        {
            RestaurantEntity entity = RestaurantRepo.GetById(id);
            entity.RestaurantsStatus = true;
            RestaurantRepo.Save(entity);
            return RedirectToAction("ApproveRestaurants");
        }

        public ActionResult Decline(int id)
        {
            DeleteRestaurant(id);
            return RedirectToAction("ApproveRestaurants");
        }
        public ActionResult Delete(int id)
        {
            DeleteRestaurant(id);
            return RedirectToAction("Restaurants");
        }

        private void DeleteRestaurant(int id)
        {
            RestaurantEntity entity = RestaurantRepo.GetById(id);
            RestaurantRepo.Delete(entity);
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

        public void PopulateRestaurantModel(RestaurantsEditVM model, RestaurantEntity entity)
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