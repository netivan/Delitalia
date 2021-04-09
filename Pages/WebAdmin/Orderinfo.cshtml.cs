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

        public List<Model.Order> Orderinfos { get; set; }
        [BindProperty]
        public decimal TotalSales { get; set; }
        [BindProperty]
        public List<MostSold> SoldProducts { get; set; }

        public void OnGet()
        {
            Orderinfos = _context.Orders.ToList();
        }
    }

    public class MostSold
    {
        public string Name { get; set; }
        public int Sold { get; set; }
    }
}
