using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelliItalia_Razor.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
           : base(options)
        {
        }
        public DbSet<DelliItalia_Razor.Model.Order2> Orders { get; set; }
    }
}
