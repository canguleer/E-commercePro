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
    public class CompaniesController : Controller
    {
        private ETicaretEntities db;
        public CompaniesController(ETicaretEntities _db)
        {
            db = _db;
        }

        // GET: Companies
        public ActionResult Index()
        {
            return View(db.Supplier.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier Supplier = db.Supplier.Find(id);
            if (Supplier == null)
            {
                return HttpNotFound();
            }
            return View(Supplier);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier Supplier)
        {
            if (ModelState.IsValid)
            {
                db.Supplier.Add(Supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Supplier);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier Supplier = db.Supplier.Find(id);
            if (Supplier == null)
            {
                return HttpNotFound();
            }
            return View(Supplier);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier Supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Supplier);
        }

      
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier Supplier = db.Supplier.Find(id);
            if (Supplier == null)
            {
                return HttpNotFound();
            }
            return View(Supplier);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier Supplier = db.Supplier.Find(id);
            db.Supplier.Remove(Supplier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
