using CRUD_Ado.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Ado.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        CrudEntities proEntities = new CrudEntities();
        public ActionResult Display()
        {
            List<Product1> product = proEntities.Product1.ToList();
            return View(product);
        }
        [HttpGet]
        public ActionResult details(int? id)
        {
            Product1 product = proEntities.Product1.Find(id);
            return View(product);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Proid,ProName,Sector,Quantity,Price")] Product1 pro)
        {
            if (ModelState.IsValid)
            {
                proEntities.Product1.Add(pro);
                proEntities.SaveChanges();

                return RedirectToAction("Display");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product1 products= proEntities.Product1.Find(id);
            return View(products);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Proid,ProName,Sector,Quantity,Price")]Product1 pro) {
            if (ModelState.IsValid)
            {
                proEntities.Entry(pro).State = EntityState.Modified;
                proEntities.SaveChanges();
                return RedirectToAction("Display");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            Product1 product = proEntities.Product1.Find(id);

            proEntities.Product1.Remove(product);
            proEntities.SaveChanges();
            return RedirectToAction("Display");
        }
    }
}