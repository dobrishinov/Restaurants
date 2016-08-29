namespace Restaurants.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using Models;
    using Restautants.ViewModels.Restautants;
    using Restautants.ViewModels.Users;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Restaurants;
    using ViewModels.Users;

    public class RestaurantController : BaseController<RestaurantEntity, RestaurantsEditVM, RestaurantsListVM, RestaurantsFilterVM>
    {
        public override BaseRepository<RestaurantEntity> CreateRepository()
        {
            return new RestaurantsRepository();
        }

        public override ActionResult RedirectTo(RestaurantEntity entity)
        {
            return RedirectToAction("Index", "Home", new { id = entity.Id });
        }

        protected override void OnBeforeList(RestaurantsListVM model)
        {
            model.Items = model.Items.OrderBy(x => x.Name).ToList();
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
            entity.Coordinates = model.Coordinates;
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
            model.Coordinates = entity.Coordinates;
            model.RestaurantsStatus = entity.RestaurantsStatus;

        }
    }
}