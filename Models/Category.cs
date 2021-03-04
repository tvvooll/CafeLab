using System;
using System.Collections.Generic;

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
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
