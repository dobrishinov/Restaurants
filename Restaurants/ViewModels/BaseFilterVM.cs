namespace Restaurants.ViewModels
{
    using DataAccess.Entity;
    using System;
    using System.Linq.Expressions;

    public abstract class BaseFilterVM<T> where T : BaseEntity
    {
        public abstract Expression<Func<T, bool>> BuildFilter();

        public string Prefix { get { return "Filter."; } }
        
        public Pager ParentPager { get; set; }
    }
}