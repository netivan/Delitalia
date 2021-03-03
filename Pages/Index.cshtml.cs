using DelliItalia_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelliItalia_Razor.Pages
{
    public class IndexModel : BaseModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DelliItalia_Razor.Data.DelliItalia_RazorContext _context;

        public IndexModel(ILogger<IndexModel> logger, DelliItalia_Razor.Data.DelliItalia_RazorContext context)
        {
            _logger = logger;
            _context = context;
        }
        public List<ProductModel> prod { get; set; }
        public void OnGet()
        {
        }
        public async Task<List<ProductModel>> GetItem()
        {
            if (prod.Count == 0)
            {

                return prod = await _context.ProductModel.ToListAsync();
            }
            else
                try
                {
                    if (prod.Count != 0)
                    {
                        prod = _context.ProductModel.Where(p => p.DateIn != null).ToList();
                        if (prod.Count == 0)
                        {
                            //ViewData["IngaProd"] = "Kategori " + Category + " har inga produkter";
                            return prod = _context.ProductModel.ToList();
                        }
                        return prod;
                    }
                    return prod = _context.ProductModel.ToList();
                }
                catch (ArgumentOutOfRangeException)
                {
                    return prod = _context.ProductModel.ToList();
                }
        }
    }
}
