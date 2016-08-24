namespace Restaurants.ViewModels.Common
{
    using Users;

    public class LoginOrRegisterVM
    {
        public LoginOrRegisterVM()
        {
            Register = new UsersEditVM();
            Login = new LoginVM();
        }
        public UsersEditVM Register { get; set; }

        public LoginVM Login { get; set; }
    }
}