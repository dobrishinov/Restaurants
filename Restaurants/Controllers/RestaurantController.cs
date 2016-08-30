namespace Restaurants.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using Restautants.ViewModels.Restautants;
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Restaurants;

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

        protected override void BeforeList(RestaurantsListVM model)
        {
            model.Items =model.Items.OrderByDescending(x => x.CreateTime)
                                                .Skip((model.Pager.CurrentPage - 1) * model.Pager.PageSize).Take(model.Pager.PageSize).ToList(); 
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
    }
}