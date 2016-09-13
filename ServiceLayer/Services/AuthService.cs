namespace ServiceLayer.Services
{
    using DataAccess.Entity;
    using System.Linq;

    public class AuthService
    {
        public UserEntity LoggedUser { get; private set; }

        public void AuthenticateUser(string username, string password)
        {
            UsersService usersService = new UsersService();
            LoggedUser = usersService.GetAll(u => u.Username == username && u.Password == password).FirstOrDefault();
        }
    }
}

