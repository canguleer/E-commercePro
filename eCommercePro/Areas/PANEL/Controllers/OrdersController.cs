using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eCommercePro.Models.DAL;

namespace eCommercePro.Areas.PANEL.Controllers
{
    public class OrdersController : Controller
    {
        private ETicaretEntities db;
        public OrdersController(ETicaretEntities _db)
        {
            db = _db;
        }

       
        public ActionResult Index()
        {
            var order = db.Order.Include(o => o.Customer).Include(o => o.Payment).Include(o => o.Product).Include(o => o.Shippers);
            return View(order.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

       
        public ActionResult Create()
        {
            ViewBag.customer_id = new SelectList(db.Customer, "id", "name");
            ViewBag.payment_id = new SelectList(db.Payment, "id", "paymentType");
            ViewBag.product_id = new SelectList(db.Product, "id", "productnName");
            ViewBag.shipper_id = new SelectList(db.Shippers, "id", "CompanyName");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,orderName,shipper_id,code,payment_id,date,product_id,customer_id,status")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Order.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customer_id = new SelectList(db.Customer, "id", "name", order.customer_id);
            ViewBag.payment_id = new SelectList(db.Payment, "id", "paymentType", order.payment_id);
            ViewBag.product_id = new SelectList(db.Product, "id", "productnName", order.product_id);
            ViewBag.shipper_id = new SelectList(db.Shippers, "id", "CompanyName", order.shipper_id);
            return View(order);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.customer_id = new SelectList(db.Customer, "id", "name", order.customer_id);
            ViewBag.payment_id = new SelectList(db.Payment, "id", "paymentType", order.payment_id);
            ViewBag.product_id = new SelectList(db.Product, "id", "productnName", order.product_id);
            ViewBag.shipper_id = new SelectList(db.Shippers, "id", "CompanyName", order.shipper_id);
            return View(order);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,orderName,shipper_id,code,payment_id,date,product_id,customer_id,status")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer_id = new SelectList(db.Customer, "id", "name", order.customer_id);
            ViewBag.payment_id = new SelectList(db.Payment, "id", "paymentType", order.payment_id);
            ViewBag.product_id = new SelectList(db.Product, "id", "productnName", order.product_id);
            ViewBag.shipper_id = new SelectList(db.Shippers, "id", "CompanyName", order.shipper_id);
            return View(order);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Order.Find(id);
            db.Order.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      
    }
}
