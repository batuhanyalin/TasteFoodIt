using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestFoodIt.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        [Required(ErrorMessage ="Ad soyad bilgisi boş bırakılamaz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "E-posta bilgisi boş bırakılamaz")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Telefon bilgisi boş bırakılamaz")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Tarih bilgisi boş bırakılamaz")]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }
        public byte GuestCount { get; set; }
        public string ReservationStatus { get; set; }
    }
}