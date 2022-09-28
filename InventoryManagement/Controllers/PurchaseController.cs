using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    public class PurchaseController : Controller
    {
        InventoryManagementDBEntities Db = new InventoryManagementDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayPurchase()
        {
            List<Purchase> productList = Db.Purchases.OrderByDescending(x=>x.Product_ID).ToList();
            return View(productList);
        }

        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            List<string> products = Db.Products.Select(x => x.Product_Name).ToList();
            ViewBag.ProductName = new SelectList(products);
            return View();
        }

        [HttpPost]
        public ActionResult PurchaseProduct(Purchase product)
        {
            List<string> products = Db.Products.Select(x => x.Product_Name).ToList();
            ViewBag.ProductName = new SelectList(products);
            if (ModelState.IsValid)
            {
                Product pro = Db.Products.Where(x => x.Product_Name == product.Purchase_Product).SingleOrDefault();
                Purchase pr = Db.Purchases.Where(x => x.Purchase_Product== product.Purchase_Product).SingleOrDefault();
                if (pro != null && Convert.ToInt32(pro.Product_Qnty) != 0)
                {
                    if (Convert.ToInt32(product.Purchase_Qnty) <= Convert.ToInt32(pro.Product_Qnty))
                    {
                        product.Purchase_Date = DateTime.Now.ToString();
                        if (pr != null)
                        {
                                pr.Purchase_Qnty = (Convert.ToInt32(pr.Purchase_Qnty) + Convert.ToInt32(product.Purchase_Qnty)).ToString();
                                pro.Product_Qnty = (Convert.ToInt32(pro.Product_Qnty) - Convert.ToInt32(product.Purchase_Qnty)).ToString();
                                Db.SaveChanges();
                                return RedirectToAction("DisplayPurchase");
                        }
                        else
                        {
                            Db.Purchases.Add(product);
                            pro.Product_Qnty = (Convert.ToInt32(pro.Product_Qnty) - Convert.ToInt32(product.Purchase_Qnty)).ToString();
                            Db.SaveChanges();
                            return RedirectToAction("DisplayPurchase");
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Selected quantity more than available quantity..";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "Product unavailable..";
                    return View();
                }


            }
            return View();
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            Purchase product = Db.Purchases.Where(x=>x.Product_ID==id).SingleOrDefault();
            List<string> products = Db.Products.Select(x => x.Product_Name).ToList();
            ViewBag.ProductName = new SelectList(products);
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct(int id, Purchase product)
        {
            Purchase pr = Db.Purchases.Where(x => x.Product_ID == id).SingleOrDefault();
            pr.Purchase_Product = product.Purchase_Product;
            pr.Purchase_Qnty=product.Purchase_Qnty;
            Db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult Details(int ID)
        {
            Purchase product = Db.Purchases.Where(x => x.Product_ID == ID).SingleOrDefault();
            return View(product);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Purchase product = Db.Purchases.Where(x => x.Product_ID == id).SingleOrDefault();
            Db.Purchases.Remove(product);
            Db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }
    }
}