using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DelliItalia_Razor.Model
{
    public class WebshopUser : IdentityUser
    {
        [Display(Name = "Förnamn:")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn:")]
        public string LastName { get; set; }
        [Phone]
        [Display(Name = "Mobile:")]
        public string Mobile { get; set; }

        [Display(Name = "Gata/väg:")]
        public string  Address { get; set; }

        [Display(Name = "Postkod:")]
        public string PostCode { get; set; }

        [Display(Name = "Stad:")]
        public string City { get; set; }
    }
}
//hej