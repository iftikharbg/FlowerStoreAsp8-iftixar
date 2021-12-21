using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Models
{
    public class Product
    {
        public int id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }

        public string Image { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
