namespace Restaurants.Controllers
{
    using DataAccess.Entity;
    using System.Web.Mvc;
    using ViewModels.Users;
    public class RegistrationController : Controller
    {
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

        //public ActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register(UsersEditVM user)
        //{
        //    TryUpdateModel(user);
        //    UsersRepository userRepo = new UsersRepository();
        //    if (ModelState.IsValid)
        //    {
        //        UserEntity u = new UserEntity()
        //        {
        //            FirstName = user.FirstName,
        //            LastName = user.LastName,
        //            Username = user.Username,
        //            Password = user.Password,
        //            Email = user.Email
        //        };
        //        userRepo.Save(u);

        //        return RedirectToAction("Index", "User");
        //    }
        //    return RedirectToAction("Register");
        //}
    }
}