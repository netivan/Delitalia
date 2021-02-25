using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DelliItalia_Razor;
using DelliItalia_Razor.Data;

namespace DelliItalia_Razor.Pages.Public
{
    public class ProductsModel : PageModel
    {
        private readonly DelliItalia_Razor.Data.DelliItalia_RazorContext _context;

        public ProductsModel(DelliItalia_Razor.Data.DelliItalia_RazorContext context)
        {
            _context = context;
        }

        public IList<ProductModel> ProductModel { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Category { get; set; }

        public async Task OnGetAsync()
        {
            ProductModel = await _context.ProductModel.ToListAsync();

            var products = from m in _context.ProductModel
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.Name.Contains(SearchString));
            }

            ProductModel = await products.ToListAsync();

            ViewData["SearchString"] = SearchString;
        }
    }
}
