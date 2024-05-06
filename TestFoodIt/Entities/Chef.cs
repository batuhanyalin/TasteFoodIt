using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFoodIt.Entities
{
    public class Chef
    {
        public int ChefId { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ChefSocialMediaName { get; set; }
        public string ChefSocialMediaLogo { get; set; }
        public string ChefSocialMediaUrl { get; set; }


    }
}