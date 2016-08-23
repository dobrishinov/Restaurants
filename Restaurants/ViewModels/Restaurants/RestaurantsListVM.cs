namespace Restautants.ViewModels.Restautants
{
    using DataAccess.Entity;
    using Restaurants.ViewModels;
    using Restaurants.ViewModels.Restaurants;

    public class RestaurantsListVM : BaseListVM<RestaurantEntity, RestaurantsFilterVM>
    {
    }
}