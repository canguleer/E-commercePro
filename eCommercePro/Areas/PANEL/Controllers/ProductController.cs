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
    public class ProductController : Controller
    {
        private ETicaretEntities db;
        public ProductController(ETicaretEntities _db)
        {
            db = _db;
        }

      
        public ActionResult Index()
        {
            var product = db.Product.Include(p => p.Brand_Model).Include(p => p.Supplier);
            return View(product.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

       
        public ActionResult Create()
        {
            ViewBag.brand_model_id = new SelectList(db.Brand_Model, "id", "id");
            ViewBag.Supplier_id = new SelectList(db.Supplier, "id", "companyName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,productnName,Supplier_id,code,serialNo,creationDate,brand_model_id,status")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.brand_model_id = new SelectList(db.Brand_Model, "id", "id", product.brand_model_id);
            ViewBag.Supplier_id = new SelectList(db.Supplier, "id", "companyName", product.Supplier_id);
            return View(product);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.brand_model_id = new SelectList(db.Brand_Model, "id", "id", product.brand_model_id);
            ViewBag.Supplier_id = new SelectList(db.Supplier, "id", "companyName", product.Supplier_id);
            return View(product);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,productnName,Supplier_id,code,serialNo,creationDate,brand_model_id,status")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.brand_model_id = new SelectList(db.Brand_Model, "id", "id", product.brand_model_id);
            ViewBag.Supplier_id = new SelectList(db.Supplier, "id", "companyName", product.Supplier_id);
            return View(product);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }       
    }
}
