using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DelliItalia_Razor;
using DelliItalia_Razor.Data;

namespace DelliItalia_Razor.Pages.Public
{
    public class PublicDetaljModel : PageModel
    {
        private readonly DelliItalia_Razor.Data.DelliItalia_RazorContext _context;

        public PublicDetaljModel(DelliItalia_Razor.Data.DelliItalia_RazorContext context)
        {
            _context = context;
        }

        //public IList<ProductModel> ProductModel { get;set; }
        public ProductModel ProductModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductModel = await _context.ProductModel.FirstOrDefaultAsync(m => m.Id == id);

            if (ProductModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
