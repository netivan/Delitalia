using DelliItalia_Razor.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelliItalia_Razor.Controllers
{
    [Route("/[controller]")]
    [ApiController]

    public class DeliApiController : ControllerBase
    {

        private readonly DelliItalia_RazorContext _context;


        public DeliApiController(DelliItalia_RazorContext context)    //  Constructor
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<ProductModel> Get()   // 
        {
            return ReadData().ToArray();
        }


        [HttpGet("{id}")]
        public ProductModel Get(int id)
        {
            ProductModel product;

            product = _context.ProductModel.SingleOrDefault(p => p.Id == id);
            if(product == null)
            {
                return new ProductModel();
            }
            else
            {
                return product;
            }
           
        }

        [HttpPost]

        public ActionResult<ProductModel>CreateProduct([FromBody] ProductModel product)
        {
            if (product == null) return BadRequest();
            _context.ProductModel.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        public List<ProductModel> ReadData()
        {
            
            List<ProductModel> products = new List<ProductModel>();


            foreach(var item in _context.ProductModel)
            {
                products.Add(item);
                
            }
            return products;
        }
                

    }
}
