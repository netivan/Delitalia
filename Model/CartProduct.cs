using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DelliItalia_Razor.Model
{
    public class CartProduct
    {
        public int Id { get; set; }       
        [DisplayName("Namn:")]
        public string Name { get; set; }        
        [DisplayName("Pris:")]
        public decimal Price { get; set; }
        [DisplayName("Foto namn:")]
        public string PhotoNamn { get; set; }
        [DisplayName("Rea i kronor:")]
        public decimal Sale { get; set; }
        [DisplayName("Rea i procent:")]
        public decimal Sale_Percent { get; set; }
       
    }
}
