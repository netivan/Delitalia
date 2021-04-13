using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DelliItalia_Razor.Model
{
    public class CartItem2
    {
        public int Id { get; set; }
        [DisplayName("Namn:")]
        public string Name { get; set; }
        [DisplayName("Pris:")]

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }   
        [DisplayName("Foto namn:")]
        public string PhotoNamn { get; set; }  // kan raderas
        [DisplayName("Rea i kronor:")]

        [Column(TypeName = "decimal(10,2)")]
        public decimal Sale { get; set; }

        [DisplayName("Rea i procent:")]

        [Column(TypeName = "decimal(10,2)")]
        public decimal Sale_Percent { get; set; }

        public int Quantity { get; set; }


    }
}
