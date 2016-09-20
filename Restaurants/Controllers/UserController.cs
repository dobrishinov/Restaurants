namespace Restaurants.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using Filter;
    using Models;
    using Restautants.ViewModels.Users;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels;
    using ViewModels.Users;

    public class UsersController : BaseController<UserEntity, UsersEditVM, UsersListVM, UsersFilterVM>
    {
        public override BaseRepository<UserEntity> CreateRepository()
        {
            return new UsersRepository();
        }

        public override ActionResult RedirectTo(UserEntity entity)
        {
            return RedirectToAction("Index", "Home", new { id = entity.Id });
        }

        protected override void BeforeList(UsersListVM model)
        {
            model.Items = model.Items.OrderByDescending(x => x.Username)
                                                .Skip((model.Pager.CurrentPage - 1) * model.Pager.PageSize).Take(model.Pager.PageSize).ToList();
        }

        public ActionResult Profile(int id)
        {
            BaseEditVM model = new BaseEditVM();
            if (ModelState.IsValid)
            {
                UserEntity entity = Repository.GetById(id);
               
            }
            return View();
        }

        public override ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
                return RedirectToAction("Profile", "Users", new { id = AuthenticationManager.LoggedUser.Id});
        }

        public override void PopulateEntity(UserEntity entity, UsersEditVM model)
        {
            //entity.Id = AuthenticationManager.LoggedUser.Id;
            entity.Username = AuthenticationManager.LoggedUser.Username;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Password = model.Password;
            entity.Email = model.Email;
            entity.Address = model.Address;
            entity.Phone = model.Phone;
            entity.Description = model.Description;
            entity.FavouriteFoods = model.FavouriteFoods;
            entity.FavouritePlace = model.FavouritePlace;
            entity.ProfileImageUrl = model.ProfileImageUrl;
            entity.AdminStatus = false;
        }

        public override void PopulateModel(UsersEditVM model, UserEntity entity)
        {
            model.Username = entity.Username;
            model.FirstName = entity.FirstName;
            model.LastName = entity.LastName;
            model.Password = entity.Password;
            model.Email = entity.Email;
            model.Address = entity.Address;
            model.Phone = entity.Phone;
            model.Description = entity.Description;
            model.FavouriteFoods = entity.FavouriteFoods;
            model.FavouritePlace = entity.FavouritePlace;
            model.ProfileImageUrl = entity.ProfileImageUrl;
            model.AdminStatus = entity.AdminStatus;
        }
    }
}