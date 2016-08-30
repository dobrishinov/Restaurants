namespace Restaurants.ViewModels.Restaurants
{
    using DataAccess.Entity;
    using System;
    using System.Linq.Expressions;
    using Tools;

    public class RestaurantsFilterVM : BaseFilterVM<RestaurantEntity>
    {
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
            Expression<Func<RestaurantEntity, bool>> filter = (p =>
                   (p.RestaurantsStatus == true) &&
                   ((string.IsNullOrEmpty(Name) || p.Name.Contains(Name)) ||
                   (string.IsNullOrEmpty(Type) || p.Type.Contains(Type)) ||
                   ((string.IsNullOrEmpty(Description) || p.Description.Contains(Description)))));

            return filter;
        }
    }
}