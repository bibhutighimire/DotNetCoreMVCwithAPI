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
        public ActionResult AddProduct(string name, string quantity, string isdiscontinued)
        {
            ActionResult response;
            if (string.IsNullOrWhiteSpace(name))
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "Blank Name or NULL Name or White Space is NOT ACCEPTED.");
            }


             if (string.IsNullOrWhiteSpace(quantity))
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "Blank quantity or NULL quantity or White Space is NOT ACCEPTED.");
            }

            if (string.IsNullOrWhiteSpace(isdiscontinued))
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "Blank isdiscontinued or NULL isdiscontinued or White Space is NOT ACCEPTED.");
            }

            else
            {
                AdminController adminc = new AdminController();
                adminc.AddProduct(name, Convert.ToInt32(quantity), Convert.ToBoolean(isdiscontinued));
                response = Ok(new { message = $"Successfully added new record to database with Name: {name}, Quantity: {quantity} and IsDiscontinued: {isdiscontinued}." });
            }
            return response;
        }

        [HttpPut("product/DiscontinueProduct")]
        public ActionResult DiscontinueProduct(string id)
        {
            
            if (string.IsNullOrWhiteSpace(id))
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "Blank ID or NULL ID or White Space is NOT ACCEPTED.");
            }
            else
            {
                AdminController adminc = new AdminController();
                ActionResult response;
                Product product = context.Products.Find(Convert.ToInt32(id));
                if (product == null)
                {
                    return StatusCode((int)HttpStatusCode.Forbidden, "Hey Buddy! The provided ID is invalid and does not exist in database record..");
                }

                else
                {

                    try
                    {
                        adminc.DiscontinueProduct(Convert.ToInt32(id));
                        response = Ok(new { message = $"Successfully disconnected the person with ID {id}. So now IsDisconnected property will be TRUE." });
                    }
                    catch
                    {
                        response = NotFound(new { error = $"No person at ID {id} could be found." });
                    }

                }


                return response;
            }
           
        }

        [HttpPut("product/AddQuantityProduct")]
        public ActionResult AddQuantityProduct(string id,string quantity)
        {


            if (string.IsNullOrWhiteSpace(id))
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "Blank ID or NULL ID or White Space is NOT ACCEPTED.");
            }


            if (string.IsNullOrWhiteSpace(quantity))
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "Blank quantity or NULL quantity or White Space is NOT ACCEPTED.");
            }



            else
            {
                AdminController adminc = new AdminController();

                Product product = context.Products.Find(Convert.ToInt32(id));
                if (product == null)
                {
                    return StatusCode((int)HttpStatusCode.Forbidden, "Hey Buddy! The provided ID is invalid and does not exist in database record..");
                }

                if (Convert.ToInt32(quantity) < 0 || Convert.ToInt32(quantity) == 0)
                {
                    return StatusCode((int)HttpStatusCode.Forbidden, "The quantity to be added should not be negative value or zero. ");
                }

                if (product.IsDiscontinued == true)
                {
                    return StatusCode((int)HttpStatusCode.Forbidden, "The quantity can not be added to product that has been discontinued. Sorry !! ");
                }
                else
                {
                    adminc.AddQuantityProduct(Convert.ToInt32(id), Convert.ToInt32(quantity));
                    return StatusCode((int)HttpStatusCode.OK, "Successfully added quantity");

                }
            }
           
            
        }

        [HttpPut("product/SubtractQuantityProduct")]
        public ActionResult SubtractQuantityProduct(string id, string quantity)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "Blank ID or NULL ID or White Space is NOT ACCEPTED.");
            }


            if (string.IsNullOrWhiteSpace(quantity))
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "Blank quantity or NULL quantity or White Space is NOT ACCEPTED.");
            }
            else
            {
                AdminController adminc = new AdminController();

                Product product = context.Products.Find(Convert.ToInt32(id));
                if (product == null)
                {
                    return StatusCode((int)HttpStatusCode.Forbidden, "Hey Buddy! The provided ID is invalid and does not exist in database record..");
                }
                int qtyindb = Convert.ToInt32(product.Quantity);
                int qty = Convert.ToInt32(quantity);
                if (Convert.ToInt32(quantity) > product.Quantity)
                {
                    return StatusCode((int)HttpStatusCode.Forbidden, $"sorry the quantity in stock is less than the quantity you are trying to add. Quantity in Stock : {qtyindb} and you tried subtracting {quantity} ...do the maths yourself and be logical");
                }
                if (Convert.ToInt32(quantity) == 0)
                {
                    return StatusCode((int)HttpStatusCode.Forbidden, "Please don't put 0 in quantity. i need valid number to subtract from stock. help me! ");
                }

                if (Convert.ToInt32(quantity) < 0)
                {
                    return StatusCode((int)HttpStatusCode.Forbidden, "Please don't put negative number in quantity. i need valid number to subtract from stock. help me! ");
                }


                else
                {
                    if (product.IsDiscontinued == true)
                    {
                        adminc.SubtractQuantityProduct(Convert.ToInt32(id), Convert.ToInt32(quantity));
                        return StatusCode((int)HttpStatusCode.OK, "Since we no longer sell this product, IT WILL BE FINAL SALE! NO REFUND OR EXCHANGE ");
                    }
                    else
                    {
                        adminc.SubtractQuantityProduct(Convert.ToInt32(id), Convert.ToInt32(quantity));
                        return StatusCode((int)HttpStatusCode.OK, "Successfully subtracted the quantity");
                    }
                   

                }
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
