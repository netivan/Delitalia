using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DelliItalia_Razor.Data;
using DelliItalia_Razor.Model;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace DelliItalia_Razor.Pages.Public
{
    public class CartPageModel : BaseModel
    {
        private readonly DelliItalia_Razor.Data.CartPageContext _context;
        private readonly IWebHostEnvironment _webHost;

        public CartPageModel(DelliItalia_Razor.Data.CartPageContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        public IList<CartModel> CartModel { get;set; }
        public CartModel cartProdukt { set; get; }


        public async Task OnGetAsync()
        {
            CartModel = await _context.CartModel.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync(IFormFile uplImage, ProductModel produkt)
        {
            //string rootPath = _webHost.WebRootPath + "/ImageProduct";
            //if (!Directory.Exists(rootPath))
            //{
            //    Directory.CreateDirectory(rootPath);
            //}
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

            cartProdukt.PhotoNamn = uplImage.FileName;
            cartProdukt.PhotoAdress = prodSave;
            await _context.CartModel.AddAsync(cartProdukt);
            await _context.SaveChangesAsync();

            return RedirectToPage("./CartPage");
        }
    }
}
