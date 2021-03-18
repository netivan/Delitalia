using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DelliItalia_Razor
{
    //Branch Sano
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Namn:")]
        public string Name { get; set; }
        [DisplayName("Ekologisk:")]
        public bool Eco { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("Pris:")]
        public decimal Price { get; set; }
        [DisplayName("Fotonamn:")]
        public string PhotoNamn { get; set; }
        [DisplayName("Foto:")]
        public string PhotoAdress { get; set; }
        
        [DisplayName("Beskrivning:")]
        public string Description { get; set; }
        [DisplayName("Produktkategori:")]
        public string Category { get; set; }
        [DisplayName("Rea i kronor:")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Sale { get; set; }
        [DisplayName("Rea i procent:")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Sale_Percent { get; set; }
        [DisplayName("Inköpsdatum:")]
        public DateTime DateIn { get; set; }
        [DisplayName("Antal i lager:")]
        public int Quantity { get; set; }
        [DisplayName("Utvald:")]
        public string Chosen { get; set; }
    }
}
