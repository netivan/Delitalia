using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DelliItalia_Razor;
using DelliItalia_Razor.Data;
using DelliItalia_Razor.Model;

namespace DelliItalia_Razor.Pages.Public
{
    public class ProductsModel : BaseModel
    {
        private readonly DelliItalia_Razor.Data.DelliItalia_RazorContext _context;

        [BindProperty(SupportsGet =true)]
        public string Ekologisk { get; set; }

        [BindProperty(SupportsGet =true)]
        public string Category { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchProduct { get; set; }

        public ProductsModel(DelliItalia_Razor.Data.DelliItalia_RazorContext context)
        {
            _context = context;
        }

        public List<ProductModel> ProductModel { get;set; }

        //public async Task OnGetAsync()
        //{
        //        await GetCategory();
            
        //        await GetEco();
        //}
        public async Task OnGetAsync()
        {
            
            await GetCategory();
            await GetEco();
            //await GetSearch();
        }

        public async Task OnPostSearchAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                await GetCategory();
                
            }
            
                ProductModel = await _context.ProductModel.AsNoTracking()
                    .Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.Contains(query)).ToListAsync();
                if(ProductModel.Count == 0)
                {
                    ProductModel = await _context.ProductModel.ToListAsync();
                if (!string.IsNullOrEmpty(query))
                {
                    ViewData["IngaProd"] = "Ingen produkt med namnet: " + query + " hittades i webbutiken";
                }
                else 
                { ViewData["IngaProd"] = "För att söka en produkt glöm inte att skriva namnet på produkten"; }
                }
            
            
        }

        

        public async Task<List<ProductModel>> GetCategory()
        {
          if (string.IsNullOrEmpty(Category))
            {
                
                return ProductModel = await _context.ProductModel.ToListAsync();
            }
            else
                try
                {
                    if (!string.IsNullOrEmpty(Category))
                    {
                       ProductModel = _context.ProductModel.Where(p => p.Category.Contains(Category)).ToList();
                        if (ProductModel.Count == 0)
                        {
                            ViewData["IngaProd"] = "Kategori "+ Category + " har inga produkter";
                            return ProductModel = _context.ProductModel.ToList();
                        }
                        return ProductModel;
                    }
                    return ProductModel = _context.ProductModel.ToList();
                }
                catch(ArgumentOutOfRangeException) { return ProductModel = _context.ProductModel.ToList();
                }
        }

        public async Task<List<ProductModel>> GetEco()
        {
            if (string.IsNullOrEmpty(Ekologisk))
            {
               
                return   await GetCategory();
            }
            else
                try
                {
                    if (!string.IsNullOrEmpty(Ekologisk))
                    {
                        ProductModel = _context.ProductModel.Where(p => p.Eco==(true)).ToList();
                        if (ProductModel.Count == 0)
                        {
                            ViewData["IngaProd"] = "Kategori Ekologisk har inga produkter";
                            return ProductModel = _context.ProductModel.ToList();
                        }
                        return ProductModel;
                    }
                    return ProductModel = _context.ProductModel.ToList();
                }
                catch (ArgumentOutOfRangeException)
                {
                    return ProductModel = _context.ProductModel.ToList();
                }
        }

    }
}
