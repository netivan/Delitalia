using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DelliItalia_Razor.Model;

namespace DelliItalia_Razor.Data
{
    public class CartPageContext : DbContext
    {
        public CartPageContext (DbContextOptions<CartPageContext> options)
            : base(options)
        {
        }

        public DbSet<DelliItalia_Razor.Model.CartModel> CartModel { get; set; }
    }
}
