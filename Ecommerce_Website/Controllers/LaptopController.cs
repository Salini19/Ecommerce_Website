using Ecommerce_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce_Website.Controllers
{
    public class LaptopController : Controller
    {
        EcommerceEntities1 e = null;
        public LaptopController()
        {
            e = new EcommerceEntities1();
        }
        // GET: Laptop
        public ActionResult Index()
        {
            Session["UserId"] = 1;
            if (TempData["cart"] != null)
            {
                float x = 0;
                List<EcommerceModel> t = TempData["cart"] as List<EcommerceModel>;
                foreach (var item in t)
                {
                    x += item.Bill;

                }

                TempData["total"] = x;
            }
            TempData.Keep();
            return View(e.Products.OrderByDescending(x=>x.ProductId).ToList());
  
        }


        public ActionResult Addtocart(int? Id)
        {

            Product p = e.Products.Where(x => x.ProductId == Id).SingleOrDefault();
            return View(p);
        }

        List<EcommerceModel> li = new List<EcommerceModel>();

        [HttpPost]
        public ActionResult Addtocart(Product pi, string qty, int Id)
        {
            Product p = e.Products.Where(x => x.ProductId == Id).SingleOrDefault();

            EcommerceModel c = new EcommerceModel();
            c.productid = p.ProductId;
            c.price = (float)p.ProductPrice;
            c.Quantity = Convert.ToInt32(qty);
            c.Bill = c.price * c.Quantity;
            c.productname = p.ProductName;
            if (TempData["cart"] == null)
            {
                li.Add(c);
                TempData["cart"] = li;

            }
            else
            {
                List<EcommerceModel> l = TempData["cart"] as List<EcommerceModel>;
                int flag = 0;
                foreach (var item in l)
                {
                    if (item.productid == c.productid)
                    {
                        item.Quantity += c.Quantity;
                        item.Bill += c.Bill;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    l.Add(c);
                }
                TempData["cart"] = l;
            }

            TempData.Keep();




            return RedirectToAction("Index");
        }

        public ActionResult remove(int? id)
        {
            List<EcommerceModel> b = TempData["cart"] as List<EcommerceModel>;
            EcommerceModel c = b.Where(ae => ae.productid == id).SingleOrDefault();
            b.Remove(c);
            float a = 0;
            foreach (var item in b)
            {
                a += item.Bill;
            }
            TempData["total"] = a;
            return RedirectToAction("ViewCart");
        }
        public ActionResult ViewCart()
        {
            TempData.Keep();


            return View();
        }
        [HttpPost]
        public ActionResult ViewCart(Order_tbl o)
        {
            List<EcommerceModel> list = TempData["cart"] as List<EcommerceModel>;
            Invoice i = new Invoice();
            i.Invoice_FK_User = Convert.ToInt32(Session["UserId"].ToString());
            i.Invoicedate = System.DateTime.Now;
            i.InvoiceTotalBill = (float)TempData["total"];
            e.Invoices.Add(i);
            e.SaveChanges();

            foreach (var item in list)
            {
                Order_tbl or = new Order_tbl();
                or.Order_FK_Product = item.productid;
                or.order_FK_Invoice = i.InvoiceId;
                or.OrderDate = System.DateTime.Now;
                or.OrderQuantity = item.Quantity;
                or.OrderUnitprice = (int)item.price;
                or.OrderBill = item.Bill;
                e.Order_tbl.Add(or);
                e.SaveChanges();

            }

            TempData.Remove("total");
            TempData.Remove("cart");

            TempData["msg"] = "Ordered Successfully";
            TempData.Keep();


            return RedirectToAction("Index");

        }

    }
}
