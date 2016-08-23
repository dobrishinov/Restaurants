namespace Restaurants.Tools
{
    using System;

    public class FilterPropertyAttribute : Attribute
    {
        public string DisplayName { get; set; }

        public string DropDownTargetProperty { get; set; }
    }
}