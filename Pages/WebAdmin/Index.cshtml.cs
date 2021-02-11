﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DelliItalia_Razor;
using DelliItalia_Razor.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace DelliItalia_Razor.Pages.WebAdmin
{
    public class IndexModel : PageModel
    {
        private readonly DelliItalia_Razor.Data.DelliItalia_RazorContext _context;
        private readonly IWebHostEnvironment _webHost;

        public IndexModel(DelliItalia_Razor.Data.DelliItalia_RazorContext context
            , IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;

        }

        [BindProperty]
        public IList<ProductModel> ProductModelList { get;set; }  
        [BindProperty]
        public ProductModel produkt { set; get; }

        public async Task OnGetAsync()
        {
            ProductModelList = await _context.ProductModel.ToListAsync();
        }
      
        public async Task<IActionResult> OnPostAsync(IFormFile uplImage, ProductModel produkt)
        {
            string rootPath = _webHost.WebRootPath + "/ImageProduct";
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
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

            produkt.PhotoNamn = uplImage.FileName;
            produkt.PhotoAdress = prodSave;
            await _context.ProductModel.AddAsync(produkt);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
