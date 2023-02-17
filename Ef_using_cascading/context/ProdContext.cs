using Ef_using_cascading.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ef_using_cascading.context
{
    public class ProdContext: DbContext
    {
        public ProdContext(DbContextOptions<ProdContext> options) : base(options)
        {

        }
        public DbSet<Category3> Category3 { get; set; }/////create Dbset for Catagory Table
        public DbSet<Product3> Product3 { get; set; }/////create Dbset for Product12 Table
        public DbSet<SubCategory3> SubCategory3 { get; set; }/////create Dbset for Product12 Tab
    }
}
