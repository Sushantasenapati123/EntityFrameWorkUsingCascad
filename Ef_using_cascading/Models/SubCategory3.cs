using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ef_using_cascading.Models
{
    public class SubCategory3
    {
        [Key]
        public int subcatid { get; set; } = 0;
        public int catid { get; set; } = 0;

        public string subcatname { get; set; } = null;
    }
}
