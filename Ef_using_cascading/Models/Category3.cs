using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ef_using_cascading.Models
{
    public class Category3
    {
        [Key]
        public int catid { get; set; } = 0;

        public string catname { get; set; } = null;
    }
}
