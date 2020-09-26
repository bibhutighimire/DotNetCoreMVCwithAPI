using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCwithAPI.Models;

namespace MVCwithAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAPIController : ControllerBase
    {
        //api/AdminAPI/product/all
        ProductContext context = new ProductContext();
        //[HttpGet("product/all")]
        //public ActionResult<IEnumerable<Product>> GetAll()
        //{
        //    AdminController controller = new AdminController();
        //    return controller.GetAll();
        //}

        [HttpPost("product/AddProduct")]
        public void AddProduct(string name, int quantity, bool isdiscontinued)
        {
            Product p = new Product();
            AdminController adminc = new AdminController();
            adminc.Create(name, quantity, isdiscontinued);  
        }

        [HttpPut("product/DiscontinueProduct")]
        public string DiscontinueProduct(int id)
        {
            string response;
            Product p = new Product();
            AdminController adminc = new AdminController();
            adminc.DiscontinueProduct(id);
            response = "Successfully changed product to DISCONTINUED";
            return response;
        }

        [HttpPut("product/AddQuantityProduct")]
        public string AddQuantityProduct(int id,int quantity)
        {
            string response;
            Product p = new Product();
            AdminController adminc = new AdminController();
            adminc.AddQuantityProduct(id,quantity);
            response = "Successfully added quantity";
            return response;
        }

        [HttpPut("product/SubtractQuantityProduct")]
        public string SubtractQuantityProduct(int id, int quantity)
        {
            string response;
            Product p = new Product();
            AdminController adminc = new AdminController();
            adminc.SubtractQuantityProduct(id, quantity);
            response = "Successfully subtracted quantity";
            return response;
        }

    }
}
