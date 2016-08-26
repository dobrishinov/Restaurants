namespace Restaurants.Controllers
{
    using DataAccess.Entity;
    using Restautants.ViewModels.Users;
    using System;
    using ViewModels.Users;
    using DataAccess.Repository;
    using System.Web.Mvc;

    public class AdminController : BaseController<UserEntity, UsersEditVM, UsersListVM, UsersFilterVM>
    {
        public override BaseRepository<UserEntity> CreateRepository()
        {
            return new UsersRepository();
        }

        public override ActionResult RedirectTo(UserEntity entity)
        {
            return RedirectToAction("Index", "UsersManager", new { id = entity.Id });
        }

        public override void PopulateEntity(UserEntity entity, UsersEditVM model)
        {
            throw new NotImplementedException();
        }

        public override void PopulateModel(UsersEditVM model, UserEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}