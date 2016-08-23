namespace DataAccess
{
    using System.Data.Entity;

    public class RestaurantsDb<T> : DbContext where T : class
    {
        public RestaurantsDb() : base("RestaurantsDb")
        {
        }

        public DbSet<T> Items { get; set; }

    }
}