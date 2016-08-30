namespace Restautants.ViewModels.Restautants
{
    using DataAccess.Entity;
    using Restaurants.ViewModels;
    using Restaurants.ViewModels.Restaurants;
    using System.Collections.Generic;

    public class RestaurantsListVM : BaseListVM<RestaurantEntity, RestaurantsFilterVM>
    {
        public List<CarouselEntity> Carousel { get; set; }
    }
}