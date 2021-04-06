//using DelliItalia_Razor.Data;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace DelliItalia_Razor.Controllers
//{

//    [Route("/[controller]")]
//    [ApiController]



//    public class DeliOrdersController : ControllerBase
//    {


//        private readonly DelliItalia_RazorContext Db;


//        public DeliOrdersController(DelliItalia_RazorContext x)   // x = context
//        {

//            Db = x;
//        }

//        [HttpGet]

//        public IEnumerable<Model.Order> Get()
//        {

//            return Db.Orders;
//        }

//        [HttpGet ("{id}")]       

//        public IEnumerable<Model.Order> Get(int id)
//        {
//            //List<Model.Order> x = new List<Model.Order>();

//                List<Model.Order> result = new List<Model.Order>();   // skapar en lista result. I det finns rsultatet

//            var TabOrders = Db.Orders.ToList();   // i TabOrders finns all data som finns i tabellen orders (database)

//             var TabOrdDesc = TabOrders.OrderByDescending(x => x.Datum);     //  lista TabOrers modifierad (orderbydesc) som läggs in i en ny lista TabOrdDesc 
                                                 
//            int n = 0;

//            foreach(var item in TabOrdDesc)
//            {
//                result.Add(item);
//                n = n + 1;

//                if (n >= id) break;
//            }
                                 

//            return result;
//        }

//    }
//}
