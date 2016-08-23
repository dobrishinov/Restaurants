namespace DataAccess.Entity
{
    public class RestaurantEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string WorkingTime { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public string Coordinates { get; set; }
        public bool RestaurantsStatus { get; set; }
    }
}