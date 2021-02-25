using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelliItalia_Razor.Pages
{
    public class IndexModel : PageModel
    {
      //  private readonly ILogger<IndexModel> _logger;

        private readonly DelliItalia_Razor.Data.DelliItalia_RazorContext _context;

        public IndexModel(DelliItalia_Razor.Data.DelliItalia_RazorContext context)
        {
            _context = context;
        }

        public IEnumerable<DelliItalia_Razor.ProductModel> ProductModel { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Category { get; set; }


        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        //public void OnGet()
        //{

        //}

        public async Task OnGetAsync()
        {
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
