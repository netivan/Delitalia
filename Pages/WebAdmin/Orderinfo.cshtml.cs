using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DelliItalia_Razor.Pages.WebAdmin
{
    public class OrderinfoModel : PageModel
    {
        private readonly DelliItalia_Razor.Data.DelliItalia_RazorContext _context;

        public OrderinfoModel(DelliItalia_Razor.Data.DelliItalia_RazorContext context)
        {
            _context = context;
        }
        [BindProperty]
        public List<Model.Order2> OrderList { get; set; }
        [BindProperty]
        public decimal TotalSales { get; set; }
        [BindProperty]
        public List<Model.ProductsBought> ProductList { get; set; }

        public void OnGet()
        {
            OrderList = _context.Orders.ToList();
            ProductList = _context.ProductsBought.ToList();
        }
    }

 
}
