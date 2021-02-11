using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DelliItalia_Razor
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Namn:")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Pris:")]
        public decimal Price { get; set; }
        [DisplayName("Foto namn:")]
        public string PhotoNamn { get; set; }
        [DisplayName("Foto:")]
        public string PhotoAdress { get; set; }
        
        [DisplayName("Beskrivning:")]
        public string Description { get; set; }
        [DisplayName("Produkt kategori")]
        public string Category { get; set; }
        [DisplayName("Rea i kronor:")]
        public decimal Sale { get; set; }
        [DisplayName("Rea i procent:")]
        public decimal Sale_Percent { get; set; }
        [DisplayName("Inköps datum:")]
        public DateTime DateIn { get; set; }
        [DisplayName("Antal i lager:")]
        public int Quantity { get; set; }
        [DisplayName("Utvald:")]
        public string Chosen { get; set; }
    }
}
