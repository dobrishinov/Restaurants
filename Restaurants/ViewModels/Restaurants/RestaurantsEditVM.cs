namespace Restaurants.ViewModels.Restaurants
{
    using System.ComponentModel.DataAnnotations;

    public class RestaurantsEditVM : BaseEditVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string WorkingTime { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Coordinates { get; set; }

        public bool RestaurantsStatus { get; set; }
    }
}