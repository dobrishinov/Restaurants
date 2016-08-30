namespace Restaurants.ViewModels.Carousel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CarouselEditVM : BaseEditVM
    {
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
    }
}