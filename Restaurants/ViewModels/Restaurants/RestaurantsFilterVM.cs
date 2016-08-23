namespace Restaurants.ViewModels.Restaurants
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using System;
    using System.Linq.Expressions;
    using Tools;

    public class RestaurantsFilterVM : BaseFilterVM<RestaurantEntity>
    {
        RestaurantsRepository repo = new RestaurantsRepository();

        public RestaurantsFilterVM()
        {
        }

        [FilterProperty(DisplayName = "Name")]
        public string Name { get; set; }

        [FilterProperty(DisplayName = "Type")]
        public string Type { get; set; }

        [FilterProperty(DisplayName = "Description")]
        public string Description { get; set; }

        //[FilterProperty(DisplayName = "UserName", DropDownTargetProperty = "UserName")]
        //public List<ISelectItem> UserName { get; set; }

        public override Expression<Func<RestaurantEntity, bool>> BuildFilter()
        {
            return (p => ((p.Name.Contains(Name) || string.IsNullOrEmpty(Name))
            || ((p.Type.Contains(Type)) || string.IsNullOrEmpty(Type))
            || ((p.Description.Contains(Description)) || string.IsNullOrEmpty(Description))));

        }
    }
}