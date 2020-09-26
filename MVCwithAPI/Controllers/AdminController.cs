using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCwithAPI.Models;

namespace MVCwithAPI.Controllers
{
    public class AdminController : Controller
    {
        ProductContext context = new ProductContext();
        //public ActionResult Index()
        //{
        //    return View(context.Products.ToList());
        //}
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(string name, int quantity, bool isdiscontinued)
        //{
        //    Product p = new Product();
        //    p.Name = name;
        //    p.Quantity = quantity;
        //    p.IsDiscontinued = isdiscontinued;
        //    context.Products.Add(p);
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    var target=context.Products.Where(x=>x.ID==id).SingleOrDefault();

        //    Product p = new Product();
        //    ViewBag.ID = target.ID;
        //    ViewBag.Name = target.Name;
        //    ViewBag.Quantity = target.Quantity;
        //    ViewBag.IsDiscontinued = target.IsDiscontinued;

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Edit(Product product)
        //{
        //    Product p = new Product();
        //    var target = context.Products.Where(x => x.ID == product.ID).SingleOrDefault();
        //    target.Name=product.Name;
        //    target.Quantity=product.Quantity;
        //    target.IsDiscontinued=product.IsDiscontinued;
            
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public ActionResult Details(int id)
        //{
        //    var target = context.Products.Where(x => x.ID == id).SingleOrDefault();

        //    Product p = new Product();
        //    ViewBag.ID = target.ID;
        //    ViewBag.Name = target.Name;
        //    ViewBag.Quantity = target.Quantity;
        //    ViewBag.IsDiscontinued = target.IsDiscontinued;

        //    return View();
        //}

        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    var target = context.Products.Where(x => x.ID == id).SingleOrDefault();
        //    ViewBag.ID = target.ID;
        //    ViewBag.Name = target.Name;
        //    ViewBag.Quantity = target.Quantity;
        //    ViewBag.IsDiscontinued = target.IsDiscontinued;
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Delete(Product product)
        //{
        //    var target = context.Products.Where(x => x.ID == product.ID).SingleOrDefault();
        //    context.Products.Remove(target);
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}


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

        public int DiscontinueProduct(int id)
        {
            int createdid;
            var target = context.Products.Where(x => x.ID == id).SingleOrDefault();
            target.IsDiscontinued = true;
            context.SaveChanges();
            createdid = target.ID;
            return createdid;
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

    }
}
