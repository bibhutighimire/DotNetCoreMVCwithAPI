using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCwithAPI.Models;
using MVCwithAPI.Models.Exceptions;

namespace MVCwithAPI.Controllers
{
    public class AdminController : Controller
    {
        ProductContext context = new ProductContext();

        public int Create(string name, int quantity, bool isdiscontinued)
        {
            
            int createdid;
            Product p = new Product();
            p.Name = name;
            p.Quantity = quantity;
            p.IsDiscontinued = isdiscontinued;
            context.Products.Add(p);
            context.SaveChanges();
            createdid = p.ID ;
            return createdid;
        }

        public void DiscontinueProduct(int id)
        {
            ValidationException exception = new ValidationException();
           
            var target = context.Products.Where(x => x.ID == id).SingleOrDefault();

            if (context.Products.Where(x => x.ID == id).Count() != 1)
            {
                exception.SubExceptions.Add(new NullReferenceException("Person with that ID does not exist."));
            }
            else
            {
               
                target.IsDiscontinued = true;
                context.SaveChanges();
            }
        }

        public int AddQuantityProduct(int id, int quantity)
        {
            int createdid;
            var target = context.Products.Where(x => x.ID == id).SingleOrDefault();
            target.Quantity = target.Quantity+ quantity;
            context.SaveChanges();
            createdid = target.ID;
            return createdid;
        }
        
        public int SubtractQuantityProduct(int id, int quantity)
        {
            int createdid;
            var target = context.Products.Where(x => x.ID == id).SingleOrDefault();
            target.Quantity = target.Quantity - quantity;
            context.SaveChanges();
            createdid = target.ID;
            return createdid;
        }

        public List<Product> ShowInventory()
        {
            List<Product> products = context.Products.Where(x => x.IsDiscontinued == false).ToList();
             return products;
        }
    }
}
