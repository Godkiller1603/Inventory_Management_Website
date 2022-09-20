using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    public class SaleController : Controller
    {
        InventoryManagementDBEntities Db = new InventoryManagementDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplaySale()
        {
            List<Sale> productList = Db.Sales.OrderByDescending(x => x.Product_ID).ToList();
            return View(productList);
        }

        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<string> products = Db.Purchases.Select(x => x.Purchase_Product).ToList();
            ViewBag.ProductName = new SelectList(products);
            return View();
        }

        [HttpPost]
        public ActionResult SaleProduct(Sale product)
        {
            List<string> products = Db.Purchases.Select(x => x.Purchase_Product).ToList();
            ViewBag.ProductName = new SelectList(products);
            if (ModelState.IsValid)
            {
                Purchase pro = Db.Purchases.Where(x => x.Purchase_Product == product.Sale_Product).SingleOrDefault();
                if (Convert.ToInt32(product.Sale_Qnty) <= Convert.ToInt32(pro.Purchase_Qnty))
                {
                    product.Sale_Date = DateTime.Now;
                    Db.Sales.Add(product);
                    pro.Purchase_Qnty = (Convert.ToInt32(pro.Purchase_Qnty) - Convert.ToInt32(product.Sale_Qnty)).ToString();
                    Db.SaveChanges();
                    return RedirectToAction("DisplayPurchase");
                }
                else
                {
                    ViewBag.Message = "Selected quantity more than available quantity..";
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Details(int ID)
        {
            Sale product = Db.Sales.Where(x => x.Product_ID==ID).SingleOrDefault();
            return View(product);
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            Sale product = Db.Sales.Where(x => x.Product_ID == id).SingleOrDefault();
            List<string> products = Db.Purchases.Select(x => x.Purchase_Product).ToList();
            ViewBag.ProductName = new SelectList(products);
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct(int id, Sale product)
        {
            Sale pr = Db.Sales.Where(x => x.Product_ID == id).SingleOrDefault();
            pr.Sale_Product = product.Sale_Product;
            pr.Sale_Qnty = product.Sale_Qnty;
            Db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Sale product = Db.Sales.Where(x => x.Product_ID == id).SingleOrDefault();
            Db.Sales.Remove(product);
            Db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }
    }
}