using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project02BurgerMenu.Entities
{
    public class Product

    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public bool? DealofTheDay { get; set; } 
    }
}