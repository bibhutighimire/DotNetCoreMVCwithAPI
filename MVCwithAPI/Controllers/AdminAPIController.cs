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

        [HttpGet("product/all")]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            // This is what we are returning. It gets serialized as JSON if we return an object.
            AdminController controller = new AdminController();
            return controller.GetAll();
        }

        //[HttpPost("product/create")]
        //public Product Create(Product product)
        //{
        //    // This is what we are returning. It gets serialized as JSON if we return an object.
        //    AdminController controller = new AdminController();
        //    return controller.Create(product);

        //}
    }
}
