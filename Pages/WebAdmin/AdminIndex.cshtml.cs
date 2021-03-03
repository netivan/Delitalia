using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DelliItalia_Razor.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DelliItalia_Razor.Pages.WebAdmin
{
    //[Authorize(Roles = "Admin")]
    public class AdminIndexModel : BaseModel
    {
        public void OnGet()
        {
        }
    }
}
