using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CafeLab.Models
{
    public partial class Cafe
    {
        public Cafe()
        {
            Orders = new HashSet<Order>();
        }

        public int CafeId { get; set; }
        
        [Required(ErrorMessage = "Це поле обов'язкове!")]
        [Display(Name = "Адреса")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Це поле обов'язкове!")]
        [Display(Name = "Час відкриття")]
        public TimeSpan OpenHour { get; set; }

        [Required(ErrorMessage = "Це поле обов'язкове!")]
        [Display(Name = "Час закриття")]
        public TimeSpan CloseHour { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
