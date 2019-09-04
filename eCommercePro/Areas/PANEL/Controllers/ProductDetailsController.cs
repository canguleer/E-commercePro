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
    public class ProductDetailsController : Controller
    {
        private ETicaretEntities db;
        public ProductDetailsController(ETicaretEntities _db)
        {
            db = _db;
        }

        
        public ActionResult Index()
        {
            var productDetail = db.ProductDetail.Include(p => p.Product);
            return View(productDetail.ToList());
        }

      
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			ProductDetail productDetail = db.ProductDetail.Where(w => w.product_id == id).FirstOrDefault();
            {
                return HttpNotFound();
            }
            return View(productDetail);
        }

       
        public ActionResult Create()
        {
            ViewBag.product_id = new SelectList(db.Product, "id", "productnName");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,notes,image1,image2,image3,image4,date,product_id,durum")] ProductDetail productDetail)
        {
            if (ModelState.IsValid)
            {
                db.ProductDetail.Add(productDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.product_id = new SelectList(db.Product, "id", "productnName", productDetail.product_id);
            return View(productDetail);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetail productDetail = db.ProductDetail.Find(id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.product_id = new SelectList(db.Product, "id", "productnName", productDetail.product_id);
            return View(productDetail);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,notes,image1,image2,image3,image4,date,product_id,durum")] ProductDetail productDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.product_id = new SelectList(db.Product, "id", "productnName", productDetail.product_id);
            return View(productDetail);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetail productDetail = db.ProductDetail.Find(id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            return View(productDetail);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductDetail productDetail = db.ProductDetail.Find(id);
            db.ProductDetail.Remove(productDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
                
    }
}
