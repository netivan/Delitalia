using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace DelliItalia_Razor.Model
{
    public class Order2
    {

       public int Id { get; set; }
        [DisplayName("Inköpsdatum:")]
        public DateTime DatePurchase { get; set; }

       public string UserName { get; set; }
        [DisplayName("Totalpris:")]

        [Column(TypeName = "decimal(10,2)")]
       public decimal TotPrice { get; set; }

       public List<ProductsBought> productsBoughts { get; set; }

    }

    public class ProductsBought
        {
          public int Id { get; set; }
        [DisplayName("Produktnamn:")]
        public string ProductName { get; set; }
          public ProductModel IdProduct { get; set; }

        //public int IdProduct { get; set; }
        [DisplayName("Rea 'SEK':")]

        [Column(TypeName = "decimal(10,2)")]
          public decimal Sale { get; set; }
        [DisplayName("Rea '%':")]

        [Column(TypeName = "decimal(10,2)")]
          public decimal Sale_procent { get; set; }
        [DisplayName("Antal:")]
        public int Quantity { get; set; }
        [DisplayName("Pris:")]

        [Column(TypeName = "decimal(10,2)")]
          public decimal Price { get; set; }

          public int Order2Id { get; set; }

    }
}
