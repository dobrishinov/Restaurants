namespace WebServices.Models
{
    public class UserEntityModel : BaseEntityModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string FavouriteFoods { get; set; }
        public string FavouritePlace { get; set; }
        public string ProfileImageUrl { get; set; }
        public bool AdminStatus { get; set; }
    }
}
