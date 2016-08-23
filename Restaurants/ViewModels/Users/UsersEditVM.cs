namespace Restaurants.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;

    public class UsersEditVM : BaseEditVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string FavouriteFoods { get; set; }
        [Required]
        public string FavouritePlace { get; set; }
        [Required]
        public string ProfileImageUrl { get; set; }

        public bool AdminStatus { get; set; }
    }
}