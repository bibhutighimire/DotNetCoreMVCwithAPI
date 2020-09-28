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
                    response = Ok(new { message = $"Successfully disconnected the person with ID {id}. So now IsDisconnected property will be TRUE." });
                }
                catch
                {
                    response = NotFound(new { error = $"No person at ID {id} could be found." });
                }
                
            }


            return response;
        }

        [HttpPut("product/AddQuantityProduct")]
        public ActionResult AddQuantityProduct(int id,int quantity)
        {
            AdminController adminc = new AdminController();

            Product product = context.Products.Find(id);
            if (product == null)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "Hey Buddy! The provided ID is invalid and does not exist in database record..");
            }

            if (quantity < 0 || quantity==0)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "The quantity to be added should not be negative value or zero. ");
            }

            if (product.IsDiscontinued== true )
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "The quantity can not be added to product that has been discontinued. Sorry !! ");
            }
            else
            {
                adminc.AddQuantityProduct(id, quantity);
                 return StatusCode((int)HttpStatusCode.OK, "Successfully added quantity"); 
                
            }
            
        }

        [HttpPut("product/SubtractQuantityProduct")]
        public ActionResult SubtractQuantityProduct(int id, int quantity)
        {
            AdminController adminc = new AdminController();

            Product product = context.Products.Find(id);
            if (product == null)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "Hey Buddy! The provided ID is invalid and does not exist in database record..");
            }
            int qtyindb = Convert.ToInt32(product.Quantity);
            int qty = Convert.ToInt32(quantity);
            if (quantity > product.Quantity )
            {
                return StatusCode((int)HttpStatusCode.Forbidden, $"sorry the quantity in stock is less than the quantity you are trying to add. Quantity in Stock : {qtyindb} and you tried subtracting {quantity} ...do the maths yourself and be logical");
            }
            if (quantity == 0)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "Please don't put 0 in quantity. i need valid number to subtract from stock. help me! ");
            }

           
            else
            {
                if (product.IsDiscontinued == true)
                {
                    return StatusCode((int)HttpStatusCode.OK, "Since we no longer sell this product, IT WILL BE FINAL SALE! NO REFUND OR EXCHANGE ");
                }
                adminc.SubtractQuantityProduct(id, quantity);
                return StatusCode((int)HttpStatusCode.OK, "Successfully added quantity");

            }
        }
        
        [HttpGet("product/ShowInventory")]
        public List<Product> ShowInventory()
        {

            AdminController adminc = new AdminController();
             
            return adminc.ShowInventory();

        }

    }
}
