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
    public class CartModel : BaseModel
    {
        private readonly DelliItalia_RazorContext _context;

        public List<CartItem> cart { get; set; }
        public CartModel(DelliItalia_RazorContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            string sessionCart = HttpContext.Session.GetString("cart");
            if(sessionCart != null)
            {
                cart = JsonConvert.DeserializeObject<List<CartItem>>(sessionCart);

            }
        }
        public IActionResult OnGetBuyItem(int? Id)
        {
            string sessionCart = HttpContext.Session.GetString("cart");
            ProductModel product = _context.ProductModel.SingleOrDefault(p => p.Id == Id);

            if(sessionCart == null)
            {
                List<CartItem> cartItem = new List<CartItem>();
                cartItem.Add(new CartItem {
                    product = new CartProduct
                    {
                        Id = product.Id,
                        Name = product.Name,
                        PhotoNamn = product.PhotoNamn,
                        Price = product.Price,
                        Sale = product.Sale,
                        Sale_Percent = product.Sale_Percent
                    },
                    Quantity = 1
                });
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cartItem));
                ViewData["antal"] = cartItem.Count.ToString();
            }
            else
            {
                List<CartItem> cartItem = JsonConvert.DeserializeObject
                    <List<CartItem>>(HttpContext.Session.GetString("cart"));
                int index = Exists(Id, cartItem);
                if (index == -1)
                {
                    cartItem.Add(new CartItem
                    {
                        product = new CartProduct
                        {
                            Id = product.Id,
                            Name = product.Name,
                            PhotoNamn = product.PhotoNamn,
                            Price = product.Price,
                            Sale = product.Sale,
                            Sale_Percent = product.Sale_Percent
                        },
                        Quantity = 1
                    });
                }
                else
                {
                    cartItem[index].Quantity++;
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cartItem));                
            }
            return RedirectToPage("Cart");
        }
        public IActionResult OnPost(int[] quantity)
        {
            List<CartItem> cartItem = JsonConvert.DeserializeObject<List<CartItem>>
                (HttpContext.Session.GetString("cart"));
            for(int i=0; i < quantity.Length; i++)
            {
                cartItem[i].Quantity = quantity[i];
            }
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cartItem));
            return RedirectToPage("Cart");
        }
        public IActionResult OnGetRemove(int Id)
        {
            List<CartItem> cartItem = JsonConvert.DeserializeObject<List<CartItem>>
                (HttpContext.Session.GetString("cart"));
            int index = Exists(Id, cartItem);
            cartItem.RemoveAt(index);
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cartItem));

            return RedirectToPage("Cart");
        }
        public IActionResult OnGetRemoveAll()
        {
            List<CartItem> cartItem = JsonConvert.DeserializeObject<List<CartItem>>
                (HttpContext.Session.GetString("cart"));
            cartItem.Clear();
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cartItem));

            return RedirectToPage("Privacy");
        }

        //kontroll om varan är redan i korg
        private int Exists(int? id, List<CartItem> item)
        {
            for(var i = 0; i< item.Count; i++)
            {
                if(item[i].product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public void DeleteItems()
        {
            string sessionCart = HttpContext.Session.GetString("cart");
            sessionCart = null;
        }
    }
}
