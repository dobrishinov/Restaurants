namespace DataAccess.Entity
{
    using System;

    public class CarouselEntity : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
    }
}