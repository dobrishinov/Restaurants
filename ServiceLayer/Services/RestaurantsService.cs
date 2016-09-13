namespace ServiceLayer.Services
{
    using DataAccess.Entity;
    using DataAccess.Repository;

    public class RestaurantsService : BaseService<RestaurantEntity>
    {
        protected override BaseRepository<RestaurantEntity> GenerateService()
        {
            return new RestaurantsRepository();
        }
    }
}