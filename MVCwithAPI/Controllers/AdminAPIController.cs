using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCwithAPI.Models;
using MVCwithAPI.Models.Exceptions;

namespace MVCwithAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAPIController : ControllerBase
    {

        ProductContext context = new ProductContext();
        [HttpPost("product/AddProduct")]
        public void AddProduct(string name, int quantity, bool isdiscontinued)
        {
            AdminController adminc = new AdminController();
            adminc.Create(name, quantity, isdiscontinued);  
        }

        [HttpPut("product/DiscontinueProduct")]
        public ActionResult DiscontinueProduct(int id)
        {
            AdminController adminc = new AdminController();
            ActionResult response;

            Product product = context.Products.Find(id);
            if (product == null)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "Hey Buddy! The provided ID is invalid and does not exist in database record..");
            }
           
            else
            {
               
                try
                {
                    adminc.DiscontinueProduct(id);
                    response = Ok(new { message = $"Successfully disconnected the person with ID {id}." });
                }
                catch
                {
                    response = NotFound(new { error = $"No person at ID {id} could be found." });
                }
                
            }


            return response;
        }

        [HttpPut("product/AddQuantityProduct")]
        public string AddQuantityProduct(int id,int quantity)
        {
            string response;
          
            AdminController adminc = new AdminController();
            adminc.AddQuantityProduct(id,quantity);
            response = "Successfully added quantity";
            return response;
        }

        [HttpPut("product/SubtractQuantityProduct")]
        public void SubtractQuantityProduct(int id, int quantity)
        {
            AdminController adminc = new AdminController();
            adminc.SubtractQuantityProduct(id, quantity);
            //response = $"Successfully subtracted quantity {quantity} with the original quantity of producy with id {id} and {nameof(p.Name)}";
            //return response;
        }
        
        [HttpGet("product/ShowInventory")]
        public List<Product> ShowInventory()
        {

            AdminController adminc = new AdminController();
            return adminc.ShowInventory();

        }

    }
}
