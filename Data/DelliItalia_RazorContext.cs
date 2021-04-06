using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DelliItalia_Razor;

namespace DelliItalia_Razor.Data
{
    //test --force push
    public class DelliItalia_RazorContext : DbContext
    {
        public DelliItalia_RazorContext (DbContextOptions<DelliItalia_RazorContext> options)
            : base(options)
        {
        }

        public DbSet<DelliItalia_Razor.ProductModel> ProductModel { get; set; }

        
        public DbSet<DelliItalia_Razor.Model.Order2> Orders2 { get; set; }

        //private List<ProductModel> ProductModelList;
        //public List<ProductModel> findAll()
        //{
        //    return ProductModelList;
        //}
        //public ProductModel finById(int id)
        //{
        //    return ProductModelList.Where(p => p.Id == id).FirstOrDefault();
        //}
    }
}
