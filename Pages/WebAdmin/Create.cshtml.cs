using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DelliItalia_Razor;
using DelliItalia_Razor.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace DelliItalia_Razor.Pages.WebAdmin
{
    public class CreateModel : PageModel
    {
        private readonly DelliItalia_Razor.Data.DelliItalia_RazorContext _context;
        private readonly IWebHostEnvironment _webHost;


        public CreateModel(DelliItalia_Razor.Data.DelliItalia_RazorContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProductModel ProductModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(IFormFile uplImage)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string produktText = Path.GetExtension(uplImage.FileName);

            var prodSave = Path.Combine(_webHost.WebRootPath, "ImageProduct", uplImage.FileName);
            using (var stream = new FileStream(prodSave, FileMode.Create))
            {
                await uplImage.CopyToAsync(stream);
            }

            ProductModel.PhotoNamn = uplImage.FileName;
            ProductModel.PhotoAdress = prodSave;

            _context.ProductModel.Add(ProductModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
