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
using DelliItalia_Razor.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace DelliItalia_Razor.Pages.WebAdmin
{
    public class EditModel : BaseModel
    {
        private readonly DelliItalia_Razor.Data.DelliItalia_RazorContext _context;
        private readonly IWebHostEnvironment _webHost;

        public EditModel(DelliItalia_Razor.Data.DelliItalia_RazorContext context, IWebHostEnvironment webHost)
        {
            _webHost = webHost;
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(IFormFile uplImage)
        {
            if (!ModelState.IsValid)
            {
                return Page();
                
            }
            if(uplImage == null)
            {
                ViewData["IngaBild"] = "Glöm inte att välja produkt bild";
                return Page(); }
            if (uplImage != null)
            {
                var prodSave = Path.Combine(_webHost.WebRootPath, "ImageProduct", uplImage.FileName);
                using (var stream = new FileStream(prodSave, FileMode.Create))
                {
                    await uplImage.CopyToAsync(stream);
                }

                ProductModel.PhotoNamn = uplImage.FileName;
                ProductModel.PhotoAdress = prodSave;
            }

            _context.Attach(ProductModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(ProductModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductModelExists(int id)
        {
            return _context.ProductModel.Any(e => e.Id == id);
        }
    }
}
