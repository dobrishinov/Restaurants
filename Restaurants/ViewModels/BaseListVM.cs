namespace Restaurants.ViewModels
{
    using DataAccess.Entity;
    using System.Collections.Generic;

    public class BaseListVM<T, F>
        where T : BaseEntity, new()
        where F : BaseFilterVM<T>, new()
    {
        public BaseListVM()
        {
            this.Filter = new F();
            this.Pager = new Pager();
        }

        public List<T> Items { get; set; }

        public Pager Pager { get; set; }

        public F Filter { get; set; }
    }
}