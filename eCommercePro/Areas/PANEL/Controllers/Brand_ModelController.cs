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
    public class Brand_ModelController : Controller
    {
        private ETicaretEntities db;
        public Brand_ModelController(ETicaretEntities _db)
        {
            db = _db;
        }


        public ActionResult Index()
        {
            var brand_Model = db.Brand_Model.Include(b => b.Brand).Include(b => b.Model);
            return View(brand_Model.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand_Model brand_Model = db.Brand_Model.Find(id);
            if (brand_Model == null)
            {
                return HttpNotFound();
            }
            return View(brand_Model);
        }

       
        public ActionResult Create()
        {
            ViewBag.brand_id = new SelectList(db.Brand, "id", "brandName");
            ViewBag.model_id = new SelectList(db.Model, "id", "modelName");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,model_id,brand_id")] Brand_Model brand_Model)
        {
            if (ModelState.IsValid)
            {
                db.Brand_Model.Add(brand_Model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.brand_id = new SelectList(db.Brand, "id", "brandName", brand_Model.brand_id);
            ViewBag.model_id = new SelectList(db.Model, "id", "modelName", brand_Model.model_id);
            return View(brand_Model);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand_Model brand_Model = db.Brand_Model.Find(id);
            if (brand_Model == null)
            {
                return HttpNotFound();
            }
            ViewBag.brand_id = new SelectList(db.Brand, "id", "brandName", brand_Model.brand_id);
            ViewBag.model_id = new SelectList(db.Model, "id", "modelName", brand_Model.model_id);
            return View(brand_Model);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,model_id,brand_id")] Brand_Model brand_Model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand_Model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.brand_id = new SelectList(db.Brand, "id", "brandName", brand_Model.brand_id);
            ViewBag.model_id = new SelectList(db.Model, "id", "modelName", brand_Model.model_id);
            return View(brand_Model);
        }

      
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand_Model brand_Model = db.Brand_Model.Find(id);
            if (brand_Model == null)
            {
                return HttpNotFound();
            }
            return View(brand_Model);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand_Model brand_Model = db.Brand_Model.Find(id);
            db.Brand_Model.Remove(brand_Model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    
    }
}
