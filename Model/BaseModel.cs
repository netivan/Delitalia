using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelliItalia_Razor.Model
{
    public class BaseModel:PageModel 
    {
        public string Filter { get; set; }
    }
}
