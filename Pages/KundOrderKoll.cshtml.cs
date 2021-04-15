using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DelliItalia_Razor.Data;
using DelliItalia_Razor.Model;
using System.ComponentModel;

namespace DelliItalia_Razor.Pages
{
    public class KundOrderKollModel : PageModel
    {
        private readonly DelliItalia_Razor.Data.DelliItalia_RazorContext _context;

        public KundOrderKollModel(DelliItalia_Razor.Data.DelliItalia_RazorContext context)
        {
            _context = context;
        }


      
        public IList<ProductBought2> ProductsBought { get;set; }   // lista di quello che vogliamo stampare. 

        public async Task OnGetAsync()
        {
           var KundOrder = await _context.Orders.ToListAsync();      

           var  ProKopt = await _context.ProductsBought.ToListAsync();

           var q = from ord in KundOrder
                   join p in ProKopt on ord.Id equals p.Order2Id   
                   where ord.UserName == User.Identity.Name
                   orderby ord.DatePurchase
                   select new ProductBought2 { ProductName = p.ProductName, DatePurchase = ord.DatePurchase, Price = p.Price, Sale = p.Sale, Sale_procent = p.Sale_procent, Quantity = p.Quantity, TotalPris = p.Quantity * p.Price - (p.Quantity * p.Sale) - (p.Quantity * p.Sale_procent) };

            ProductsBought = q.ToList();

        }


    }

    public class ProductBought2   
    {

        //public int Id { get; set; }
        [DisplayName("Produktnamn")]
        public string ProductName { get; set; }
        public ProductModel IdProduct { get; set; }
        [DisplayName("Inköpsdatum")]
        public DateTime DatePurchase { get; set; }
        [DisplayName("Rea 'SEK'")]
        public decimal Sale { get; set; }
        [DisplayName("Rea '%'")]
        public decimal Sale_procent { get; set; }
        [DisplayName("Antal")]
        public int Quantity { get; set; }
        [DisplayName("Pris")]
        public decimal Price { get; set; }
        [DisplayName("Totalpris")]
        public decimal TotalPris { get; set; }
        public int Order2Id { get; set; }

    }
}



