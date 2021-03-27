using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DelliItalia_Razor.Data;
using DelliItalia_Razor.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace DelliItalia_Razor.Pages.Public
{
    public class CartFinalModel : PageModel
    {
         
    
        private readonly DelliItalia_RazorContext _context;  // 

        public List<CartItem> cart { get; set; }
        public CartFinalModel(DelliItalia_RazorContext context)   // Constructor
        {
            _context = context;
        }

        public void OnGet()
        {

            string sessionCart = HttpContext.Session.GetString("cart");
            if (sessionCart != null)
            {
                cart = JsonConvert.DeserializeObject<List<CartItem>>(sessionCart);

            }

        }

        public IActionResult OnGetUpdateDb()                                //updateDb
        {
            List<CartItem> x = JsonConvert.DeserializeObject<List<CartItem>>
                   (HttpContext.Session.GetString("cart"));
            int ID;
            foreach (var item in x)
            {
                ID = item.product.Id;
                ProductModel product = _context.ProductModel.SingleOrDefault(p => p.Id == ID);
                product.Quantity -= item.Quantity;
                _context.ProductModel.Update(product); // update databasen


                Order item2 = new Order { Quantity = item.Quantity, Name = item.product.Name, Price = item.product.Price, UserId = User.Identity.Name };    //updateDbKöp
                _context.Orders.Add(item2);


            }

            _context.SaveChanges();

            x.Clear();
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(x));

            return RedirectToPage("ThanxForBuy");


        }


    }



}

