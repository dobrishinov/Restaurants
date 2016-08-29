namespace Restaurants.ViewModels.Restaurants
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using System;
    using System.Linq.Expressions;
    using Tools;

    public class CarouselFilterVM : BaseFilterVM<CarouselEntity>
    {
        CarouselRepository repo = new CarouselRepository();

        public CarouselFilterVM()
        {
        }

        [FilterProperty(DisplayName = "Title")]
        public string Title { get; set; }

        [FilterProperty(DisplayName = "Description")]
        public string Description { get; set; }

        //[FilterProperty(DisplayName = "UserName", DropDownTargetProperty = "UserName")]
        //public List<ISelectItem> UserName { get; set; }

        public override Expression<Func<CarouselEntity, bool>> BuildFilter()
        {
            return (p => ((p.Title.Contains(Title) || string.IsNullOrEmpty(Title))
            || ((p.Description.Contains(Description)) || string.IsNullOrEmpty(Description))));

        }
    }
}