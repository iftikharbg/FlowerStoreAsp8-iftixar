using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Models
{
    public class Category 
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Bosh Ola Bilmez"),MaxLength(100,ErrorMessage ="100 den artiq olmaz")]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Desc { get; set; }

        public List<Product> Products { get; set; }
    }
}
