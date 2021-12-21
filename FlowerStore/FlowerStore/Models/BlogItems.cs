using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Models
{
    public class BlogItems
    {
        public int id { get; set; }

        public DateTime Date { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }
    }
}
