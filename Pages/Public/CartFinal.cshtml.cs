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
            List<CartItem> cartSano = JsonConvert.DeserializeObject<List<CartItem>>
                   (HttpContext.Session.GetString("cart"));
            int ID;

            Order2 ord = new Order2 { UserName = User.Identity.Name, DatePurchase = DateTime.Now, productsBoughts = new List<ProductsBought>() };

            ord.TotPrice = 0;


            foreach (var item in cartSano)
            {
                ID = item.product.Id;
            
                ProductModel product = _context.ProductModel.SingleOrDefault(p => p.Id == ID);

              
               
                int q = product.Quantity - item.Quantity;      // q = quantity

                if(item.Quantity <= product.Quantity)  // produkterna finns i lagret
                {
                    product.Quantity -= item.Quantity;

                    product.AmountSold += item.Quantity;

                   _context.ProductModel.Update(product); // update databasen


                    ProductsBought item2 = new ProductsBought { Quantity = item.Quantity, ProductName = item.product.Name, IdProduct = product, Sale = item.product.Sale, Sale_procent = item.product.Sale_Percent, Price = item.product.Price };    //updateDbKöp     

                 //   ord.TotPrice += item.Quantity * item.product.Price;      // totalprice av singel order

                    
                        if (item.product.Sale != 0)
                        {
                            ord.TotPrice += (item.product.Price - item.product.Sale) * item.Quantity;
                        }
                        else if (item.product.Sale_Percent != 0)
                        {
                            ord.TotPrice += (item.product.Price * ((100 - item.product.Sale_Percent) / 100)) * item.Quantity;
                        }
                        else
                        {
                            ord.TotPrice += item.product.Price * item.Quantity;
                        }
                    

                    ord.productsBoughts.Add(item2);

                }
                else
                {
                    // Produkten är slut
                }
            }
            
            _context.Orders.Add(ord);        //////////////////////////////////////////////
            _context.SaveChanges();

            cartSano.Clear();
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cartSano));

            return RedirectToPage("ThanxForBuy");


        }


    }



}

