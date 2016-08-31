namespace Restaurants.ViewModels.Restaurants
{
    using DataAccess.Entity;
    using System;
    using System.Linq.Expressions;
    using Tools;

    public class RestaurantsFilterVM : BaseFilterVM<RestaurantEntity>
    {
        [FilterProperty(DisplayName = "Restaurants Name")]
        public string Name { get; set; }

        [FilterProperty(DisplayName = "Type of restaurant")]
        public string Type { get; set; }

        //[FilterProperty(DisplayName = "UserName", DropDownTargetProperty = "UserName")]
        //public List<ISelectItem> UserName { get; set; }

        public override Expression<Func<RestaurantEntity, bool>> BuildFilter()
        {
            Expression<Func<RestaurantEntity, bool>> filter = (p =>
                   (p.RestaurantsStatus == true) &&
                   ((p.Name.Contains(Name) || string.IsNullOrEmpty(Name)) &&
                   (p.Type.Contains(Type) || string.IsNullOrEmpty(Type))));

            return filter;
        }

        public  Expression<Func<RestaurantEntity, bool>> BuildDeclineFilter()
        {
            Expression<Func<RestaurantEntity, bool>> filter = (p =>
                   (p.RestaurantsStatus == false) &&
                   ((p.Name.Contains(Name) || string.IsNullOrEmpty(Name)) &&
                   (p.Type.Contains(Type) || string.IsNullOrEmpty(Type))));

            return filter;
        }
    }
}