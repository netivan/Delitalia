using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DelliItalia_Razor.Model
{
    public class Order2
    {

       public int Id { get; set; }

       public DateTime DatePurchase { get; set; }

       public string UserName { get; set; }

        [Column(TypeName = "decimal(10,2)")]
       public decimal TotPrice { get; set; }

       public List<ProductsBought> productsBoughts { get; set; }

    }

    public class ProductsBought
        {
          public int Id { get; set; }
          public string ProductName { get; set; }
          public ProductModel IdProduct { get; set; }

        //public int IdProduct { get; set; }

        [Column(TypeName = "decimal(10,2)")]
          public decimal Sale { get; set; }
 
          [Column(TypeName = "decimal(10,2)")]
          public decimal Sale_procent { get; set; }

          public int Quantity { get; set; }

          [Column(TypeName = "decimal(10,2)")]
          public decimal Price { get; set; }

          public int Order2Id { get; set; }

    }
}
