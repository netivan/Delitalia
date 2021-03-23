using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelliItalia_Razor.Pages
{
    public class ThanxForBuyModel : PageModel
    {
        private readonly ILogger<ThanxForBuyModel> _logger;

        public ThanxForBuyModel(ILogger<ThanxForBuyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public int Rad { get; set; }
    }
}
