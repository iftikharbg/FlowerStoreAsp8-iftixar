using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Models
{
    public class BasketItem
    {
        public Product product { get; set; }

        public int Count { get; set; }
    }
}
