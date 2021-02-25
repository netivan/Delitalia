using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelliItalia_Razor.Model
{
    public class CartItem
    {
        public CartProduct product { set; get; }
        public int Quantity { set; get; }
    }
}
