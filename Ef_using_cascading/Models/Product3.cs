using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ef_using_cascading.Models
{
    public class Product3
    {
        [Key]
        public int pid { get; set; } = 0;
        [Required]
        public int catid { get; set; }
        [Required]
        public int? subcatid { get; set; }
        [Required]
        public string pname { get; set; } = null;
        [Required]
        public decimal? price { get; set; }
        [Required]
        public int? pqty { get; set; }

        [NotMapped]
        public string catname { get; set; } = null;
        [NotMapped]
        public string subcatname { get; set; } = null;
    }
}
