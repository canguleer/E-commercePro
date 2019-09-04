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
    public class ModelsController : Controller
    {
        private ETicaretEntities db;
        public ModelsController(ETicaretEntities _db)
        {
            db = _db;
        }

        
        public ActionResult Index()
        {
            return View(db.Model.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Model.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,modelName,code,status")] Model model)
        {
            if (ModelState.IsValid)
            {
                db.Model.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Model.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,modelName,code,status")] Model model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

      
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Model.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Model model = db.Model.Find(id);
            db.Model.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      
    }
}
