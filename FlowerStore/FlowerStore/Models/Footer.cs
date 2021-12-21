using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Models
{
    public class Footer
    {
        [Key]
        public int id { get; set; }
        public string  Logo { get; set; }

        [MaxLength(200)]
        [DataType("nvarchar")]
        public string FacebookUrl { get; set; }

        [MaxLength(100)]
        [DataType("nvarchar")]
        public string LinkedinUrl { get; set; }
        [NotMapped]

        public IFormFile File { get; set; }
    }
}
