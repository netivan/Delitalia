using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DelliItalia_Razor;

namespace DelliItalia_Razor.Data
{
    public class DelliItalia_RazorContext : DbContext
    {
        public DelliItalia_RazorContext (DbContextOptions<DelliItalia_RazorContext> options)
            : base(options)
        {
        }

        public DbSet<DelliItalia_Razor.ProductModel> ProductModel { get; set; }
    }
}
