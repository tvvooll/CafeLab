using System;
using System.Collections.Generic;

#nullable disable

namespace CafeLab.Models
{
    public partial class Dish
    {
        public Dish()
        {
            DishesInOrders = new HashSet<DishesInOrder>();
        }

        public int DishId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public int? Weight { get; set; }
        public string Description { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<DishesInOrder> DishesInOrders { get; set; }
    }
}
