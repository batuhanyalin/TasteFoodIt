using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFoodIt.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string FullAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }

    }
}