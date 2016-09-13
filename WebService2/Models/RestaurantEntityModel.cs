namespace WebServices.Models
{
    using System;

    public class RestaurantEntityModel : BaseEntityModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string WorkingTime { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreateTime { get; set; }
        public bool RestaurantsStatus { get; set; }
    }
}
