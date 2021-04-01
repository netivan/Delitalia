using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DelliItalia_Razor.Model
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; }
                
        public string Name { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
             

        [Column(TypeName = "decimal(10,2)")]
        public decimal Sale { get; set; }
               

        [Column(TypeName = "decimal(10,2)")]
        public decimal Sale_Percent { get; set; }

        public int Quantity { get; set; }

        public DateTime Datum { get; set; }
    }
}

