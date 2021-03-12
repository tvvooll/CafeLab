using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CafeLab.Models
{
    public partial class Category
    {
        public Category()
        {
            Dishes = new HashSet<Dish>();
        }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Це поле є обов'язковим!")]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
