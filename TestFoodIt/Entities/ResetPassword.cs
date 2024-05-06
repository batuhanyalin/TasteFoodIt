using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestFoodIt.Entities
{
    public class ResetPassword
    {
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage ="Girilen şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }
}