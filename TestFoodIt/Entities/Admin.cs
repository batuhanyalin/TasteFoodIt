using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFoodIt.Entities
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string Namesurname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserPhotoURL { get; set; }
    }
}