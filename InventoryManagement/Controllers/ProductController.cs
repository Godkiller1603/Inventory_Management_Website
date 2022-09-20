using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    public class ProductController : Controller
    {
        InventoryManagementDBEntities Db = new InventoryManagementDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List<Product> products = Db.Products.OrderByDescending(x=>x.Product_ID).ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult Details(int ID)
        {
            Product product = Db.Products.Where(x => x.Product_ID == ID).SingleOrDefault(); 
            return View(product);
        }

        [HttpGet]
        public ActionResult Delete (int ID)
        {
            Product product = Db.Products.Where(x => x.Product_ID == ID).SingleOrDefault();
            return View(product);
        }
        
        [HttpPost]
        public ActionResult Delete(int ID,Product product)
        {
            Product prod = Db.Products.Where(x => x.Product_ID == ID).SingleOrDefault();
            Db.Products.Remove(prod);
            Db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            Product product = Db.Products.Where(x=>x.Product_ID==ID).SingleOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(int ID, Product product)
        {
            Product pro = Db.Products.Where(x => x.Product_ID == ID).SingleOrDefault();
            pro.Product_Name = product.Product_Name;
            pro.Product_Qnty = product.Product_Qnty;
            Db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
        [HttpGet]
        public ActionResult Add_Product()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_Product(Product product)
        {
            Product pro = Db.Products.Where(x=>x.Product_Name==product.Product_Name).SingleOrDefault();
            if (pro != null)
            {
                if (product.Product_Name == pro.Product_Name)
                {
                    pro.Product_Qnty = Convert.ToString(Convert.ToInt16(pro.Product_Qnty) + Convert.ToInt16(product.Product_Qnty));
                    Db.SaveChanges();
                }
            }
            else
            {
                Db.Products.Add(product);
                Db.SaveChanges();
            }
            return RedirectToAction("DisplayProduct");
            
        }
    }
}