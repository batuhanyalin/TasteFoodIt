using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFoodIt.Entities
{
    public class Slider
    {
        public int SliderId { get; set; }
        public string SliderTitle { get; set; }
        public string SliderHeading { get; set; }
        public string SliderDescription { get; set; }
        public string SliderUrl { get; set; }
    }
}