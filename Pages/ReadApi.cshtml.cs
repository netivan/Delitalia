using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace DelliItalia_Razor.Pages
{
    public class ReadApiModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        public HttpClient client = new HttpClient();

        public List<ProductModel> ListaP { get; set; }        


        public async Task<IActionResult> OnGetAsync()
        {

            System.Threading.Thread.Sleep(3000);
            string link = $"https://localhost:"+ HttpContext.Request.Host.Port + "/deliapi/";   //   HttpContext.Request.Host.Port = 44352  
            Task<string> ReadJasonTask = client.GetStringAsync(link);       // 
            string ReadJson = await ReadJasonTask;
            ListaP = JsonConvert.DeserializeObject<List<ProductModel>>(ReadJson);
            return Page();
            

        }





        //public async Task<List<Model.Order>> GetRaderAsync()
        //{
        //    string mx = "/6";
        //    System.Threading.Thread.Sleep(3000);   // om man ansluter sig innan får man error.
        //    string link = $"https://localhost:44377/deliorders/{mx}";
        //    Task<string> raderStringTask = client.GetStringAsync(link);
        //    string raderString = await raderStringTask;
        //    return JsonConvert.DeserializeObject<List<Model.Order>>(raderString);

        //}

    }
}
