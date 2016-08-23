namespace Restaurants
{
    using DataAccess.Entity;
    using System.Data.Entity;

    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("RestaurantsDb")
        {
        }

        public DbSet<RestaurantEntity> Restaurants { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public System.Data.Entity.DbSet<Restaurants.ViewModels.Restaurants.RestaurantsEditVM> AppointmentsEditVMs { get; set; }

        public System.Data.Entity.DbSet<Restaurants.ViewModels.Users.UsersEditVM> DoctorsEditVMs { get; set; }
    }
}